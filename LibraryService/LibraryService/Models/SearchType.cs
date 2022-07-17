using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models
{
    public enum SearchType
    {
        [Display(Name = "Заголовок")]
        Title,
        [Display(Name = "Автор")]
        Author,
        [Display(Name = "Категория")]
        Category
    }
}
