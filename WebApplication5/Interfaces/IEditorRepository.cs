using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IEditorRepository
    {
        Task<IEnumerable<Editor>> GetAllEditors();
        Task<Editor> GetEditorById(int Id);
        Task<Editor> GetEditorByIdNoTracking(int Id);
        bool Add(Editor editor);
        bool Update(Editor editor);
        bool Delete(Editor editor);
        bool Save();
    }
}
