using Domain.Models;

namespace DAL.Interfaces
{
    public interface IEditorRepository
    {
        Task<IList<Editor>> GetAllEditors();
        Editor GetEditorById(int Id);
        Task<Editor> GetEditorByIdNoTracking(int Id);
        bool Add(Editor editor);
        bool Update(Editor editor);
        bool Delete(Editor editor);
        bool Save();
    }
}
