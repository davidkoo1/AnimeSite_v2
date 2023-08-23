using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
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
            _dataContext.Remove(editor);
            return Save();
        }

        public async Task<IEnumerable<Editor>> GetAllEditors() => await _dataContext.Editors.ToListAsync();

        public async Task<Editor> GetEditorById(int id) => await _dataContext.Editors.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Editor> GetEditorByIdNoTracking(int id) => await _dataContext.Editors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public bool Save() => _dataContext.SaveChanges() > 0 ? true : false;

        public bool Update(Editor editor)
        {
            _dataContext.Update(editor);
            return Save();
        }
    }
}
