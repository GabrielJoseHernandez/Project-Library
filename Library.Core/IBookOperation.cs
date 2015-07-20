using System.Collections.Generic;
using Library.Core.Models;

namespace Library.Core
{
    internal interface IBookOperation
    {
        IEnumerable<BookPreviewDto> GetAllBooks();

        IEnumerable<Category> GetAllCategory();

        IEnumerable<BookPreviewDto> GetBookByCategory(string category);

        IEnumerable<BookPreviewDto> GetBookByCategory(long id);

        IEnumerable<Author> GetAllAuthor();

        IEnumerable<BookPreviewDto> GetBookByAuthor(string[] author);

        IEnumerable<BookPreviewDto> GetBookByAuthor(long id);
    }
}
