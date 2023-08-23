namespace WebApplication5.ViewModels
{
    public class EditEditorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageSource { get; set; }
    }
}
