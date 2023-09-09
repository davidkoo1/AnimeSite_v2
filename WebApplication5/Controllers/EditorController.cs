using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    public class EditorController : Controller
    {
        private readonly IEditorRepository _editorRepository;
        private readonly IMediaService _photoService;

        public EditorController(IEditorRepository editorRepository, IMediaService photoService)
        {
            _editorRepository = editorRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var editors = await _editorRepository.GetAllEditors();
            return View(editors);
        }

        public IActionResult Detail(int search)
        {
            var editor = _editorRepository.GetEditorById(search);
            if (editor != null)
                return View(editor);
            else
                return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateEditorViewModel editorVM)
        {

            if (editorVM.Image != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _photoService.AddPhotoAsync(editorVM.Image);
                    var editor = new Editor
                    {
                        Id = editorVM.Id,
                        Name = editorVM.Name,
                        Description = editorVM.Description,
                        Image = result.Url.ToString()
                    };
                    _editorRepository.Add(editor);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Photo upload failed");
                }
            }
            else if (editorVM.ImageSource != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(editorVM);
                }
                Editor editor = new Editor { Id = editorVM.Id, Name = editorVM.Name, Description = editorVM.Description, Image = editorVM.ImageSource };
                _editorRepository.Add(editor);
                return RedirectToAction("Index");
            }

            return View(editorVM);
        }

        public IActionResult Edit(int id)
        {
            var editor = _editorRepository.GetEditorById(id);
            if (editor == null)
                return View("Error");
            var editorVM = new EditEditorViewModel
            {
                Name = editor.Name,
                Description = editor.Description,
                ImageSource = editor.Image

            };
            return View(editorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEditorViewModel editorVM)
        {

            var editEditor = await _editorRepository.GetEditorByIdNoTracking(id);
            if (editEditor != null)
            {
                var editor = new Editor
                {
                    Id = id,
                    Name = editorVM.Name,
                    Description = editorVM.Description
                };
                if (editorVM.Image != null)
                {
                    try
                    {
                        await _photoService.DeletePhotoAsync(editEditor.Image);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", editorVM);
                        //return View(editorVM);
                    }

                    var photoRes = await _photoService.AddPhotoAsync(editorVM.Image);
                    editor.Image = photoRes.Url.ToString();
                }
                else
                {
                    try
                    {
                        await _photoService.DeletePhotoAsync(editEditor.Image);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Could not delete photo");
                        return View("Edit", editorVM);
                        //return View(editorVM);
                    }
                    editor.Image = editorVM.ImageSource;
                }

                _editorRepository.Update(editor);
                return RedirectToAction("Index");
            }
            else { return View(editorVM); }

        }

        public IActionResult Delete(int id)
        {
            var editorDetail = _editorRepository.GetEditorById(id);
            if (editorDetail == null)
                return View("Error");
            return View(editorDetail);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteEditor(int id)
        {
            var editorDetail = _editorRepository.GetEditorById(id);
            if (editorDetail == null)
                return View("Error");

            _editorRepository.Delete(editorDetail);
            return RedirectToAction("Index");
        }
    }

}
