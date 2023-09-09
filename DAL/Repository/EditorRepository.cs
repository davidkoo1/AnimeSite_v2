using DAL.Interfaces;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class EditorRepository : IEditorRepository
    {
        private readonly DataContext _dataContext;

        public EditorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Add(Editor editor)
        {
            _dataContext.Add(editor);
            return Save();
        }

        public bool Delete(Editor editor)
        {
            /*var animes = _dataContext.Animes.Where(x => x.EditorId == editor.Id).ToList();
            foreach (var anime in animes) 
            {
                anime.EditorId = null;
                _dataContext.Animes.Update(anime);
            }
            */

            _dataContext.Editors.Remove(editor);
            return Save();
        }

        public async Task<IList<Editor>> GetAllEditors() => await _dataContext.Editors.ToListAsync();

        public Editor GetEditorById(int id) => _dataContext.Editors.FirstOrDefault(x => x.Id == id);
        public async Task<Editor> GetEditorByIdNoTracking(int id) => await _dataContext.Editors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Editor editor)
        {
            _dataContext.Update(editor);
            return Save();
        }
    }
}
