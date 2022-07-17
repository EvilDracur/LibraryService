using LibraryService.Models;
using LibraryService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Controllers
{
    //[Route("api/library")]
    //[ApiController]
    public class LibraryController : Controller //ControllerBase
    {
        private readonly ILibraryRepositoryService _libraryRepositoryService;

        public LibraryController(ILibraryRepositoryService libraryRepositoryService)
        {
            _libraryRepositoryService = libraryRepositoryService;
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index(SearchType searchType, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString) && searchString.Length >= 3)
                switch (searchType)
                {
                    /*case SearchType.Title:
                        BookCategoryViewModel bookCategoryViewModel = new BookCategoryViewModel();
                        IList<Book> books = _libraryRepositoryService.GetByTitle(searchString);
                        bookCategoryViewModel.Books = books;
                        return View(bookCategoryViewModel);*/
                    case SearchType.Title:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByTitle(searchString) });
                    case SearchType.Category:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByCategory(searchString) });
                    case SearchType.Author:
                        return View(new BookCategoryViewModel() { Books = _libraryRepositoryService.GetByAuthor(searchString) });

                }

            return View(new BookCategoryViewModel { Books = new List<Book>() });
        }

        /// <summary>
        /// Получить список книг по наименованию
        /// </summary>
        /// <param name="title">Наименование книги</param>
        /// <returns></returns>
        [HttpGet("get/by-title")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByTitle([FromQuery] string title) =>
            Ok(_libraryRepositoryService.GetByTitle(title));

        /// <summary>
        /// Получить список книг по автору
        /// </summary>
        /// <param name="authorName">Автор</param>
        /// <returns></returns>
        [HttpGet("get/by-author")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByAuthor([FromQuery] string authorName) =>
            Ok(_libraryRepositoryService.GetByAuthor(authorName));

        /// <summary>
        /// Получить список книг по жанру
        /// </summary>
        /// <param name="category">Жанр</param>
        /// <returns></returns>
        [HttpGet("get/by-category")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooksByCategory([FromQuery] string category) =>
            Ok(_libraryRepositoryService.GetByCategory(category));







        /// <summary>
        /// Получить список описаний книг по наименованию
        /// </summary>
        /// <param name="title">Наименование книги</param>
        /// <returns></returns>
        [HttpGet("get/description/by-title")]
        [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
        public IActionResult GetBooksDescriptionByTitle([FromQuery] string title) =>
            Ok(_libraryRepositoryService.GetDescriptionByTitle(title));

        /// <summary>
        /// Получить описание книг по автору
        /// </summary>
        /// <param name="authorName">Автор</param>
        /// <returns></returns>
        [HttpGet("get/description/by-author")]
        [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
        public IActionResult GetBooksDescriptionByAuthor([FromQuery] string authorName) =>
            Ok(_libraryRepositoryService.GetDescriptionByAuthor(authorName));

        /// <summary>
        /// Получить список описаний книг по жанру
        /// </summary>
        /// <param name="category">Жанр</param>
        /// <returns></returns>
        [HttpGet("get/description/by-category")]
        [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
        public IActionResult GetBooksDescriptionByCategory([FromQuery] string category) =>
            Ok(_libraryRepositoryService.GetDescriptionByCategory(category));

    }
}
