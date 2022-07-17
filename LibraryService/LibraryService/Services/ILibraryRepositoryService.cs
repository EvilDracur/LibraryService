using LibraryService.Models;

namespace LibraryService.Services
{
    public interface ILibraryRepositoryService : IRepository<Book>
    {
        IList<Book> GetByTitle(string title);

        IList<Book> GetByAuthor(string authorName);

        IList<Book> GetByCategory(string category);







        IList<string> GetDescriptionByTitle(string title);
        IList<string> GetDescriptionByAuthor(string authorName);
        IList<string> GetDescriptionByCategory(string category);
    }
}
