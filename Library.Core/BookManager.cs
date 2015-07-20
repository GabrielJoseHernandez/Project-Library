using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Library.Core.Models;

namespace Library.Core
{
    public class BookManager : IBookOperation
    {
        public IEnumerable<BookPreviewDto> GetAllBooks()
        {
            IEnumerable<BookPreviewDto> result;
            using (var context = new LibraryDatabaseEntities())
            {
                List<BookPreviewDto> listBook = (from b in context.Book
                                                 select new BookPreviewDto
                                                 {
                                                     Isbn = b.ISBN,
                                                     Book = b.Book_Name,
                                                     Thumb = string.IsNullOrEmpty(b.Imagen) ? "/Assets/Images/notAvailable.jpg" : b.Imagen,
                                                     AuthorName = b.Author.Author_Name + " " + b.Author.Author_LastName,
                                                     Pages = (short)b.Quantity_Page
                                                 }).ToList<BookPreviewDto>();
                result = listBook;
            }
            return result;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            IEnumerable<Category> result;
            try
            {
                using (var context = new LibraryDatabaseEntities())
                {
                    List<Category> listCat = (from c in context.Category
                                              select c).ToList<Category>();
                    result = listCat;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                result = null;
            }
            return result;
        }

        public IEnumerable<BookPreviewDto> GetBookByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new Exception("You need to provide a category");
            }
            IEnumerable<BookPreviewDto> result;
            using (var context = new LibraryDatabaseEntities())
            {
                List<BookPreviewDto> listCat = (from b in context.Book_ByCategory
                                                where b.Category.Category_Name.Contains(category.Trim())
                                                select new BookPreviewDto
                                                {
                                                    AuthorName = b.Book.Author.Author_Name + " " + b.Book.Author.Author_LastName,
                                                    Book = b.Book.Book_Name,
                                                    Isbn = b.Book.ISBN,
                                                    Pages = (short)b.Book.Quantity_Page,
                                                    Thumb = string.IsNullOrEmpty(b.Book.Imagen) ? "/Assets/Images/notAvailable.jpg" : b.Book.Imagen
                                                }).ToList<BookPreviewDto>();
                result = listCat;
            }
            return result;
        }

        public IEnumerable<BookPreviewDto> GetBookByCategory(long id)
        {
            IEnumerable<BookPreviewDto> result;
            using (var context = new LibraryDatabaseEntities())
            {
                List<BookPreviewDto> listCat = (from b in context.Book_ByCategory
                                                where b.Category.Id_Category.Equals(id)
                                                select new BookPreviewDto
                                                {
                                                    AuthorName = b.Book.Author.Author_Name + " " + b.Book.Author.Author_LastName,
                                                    Book = b.Book.Book_Name,
                                                    Isbn = b.Book.ISBN,
                                                    Pages = (short)b.Book.Quantity_Page,
                                                    Thumb = string.IsNullOrEmpty(b.Book.Imagen) ? "/Assets/Images/notAvailable.jpg" : b.Book.Imagen
                                                }).ToList<BookPreviewDto>();
                result = listCat;
            }
            return result;
        }

        public IEnumerable<BookPreviewDto> GetBookByAuthor(string[] author)
        {
            if (author.Length < 1)
            {
                throw new Exception("You need to provide an Author");
            }
            IEnumerable<BookPreviewDto> result;
            using (var context = new LibraryDatabaseEntities())
            {
                List<BookPreviewDto> listAuthor = (from b in context.Book_ByCategory
                                                   where author.Any((string item) => b.Book.Author.Author_Name.ToLower().Contains(item.ToLower())) || author.Any((string item) => b.Book.Author.Author_LastName.ToLower().Contains(item.ToLower()))
                                                   select new BookPreviewDto
                                                   {
                                                       AuthorName = b.Book.Author.Author_Name + " " + b.Book.Author.Author_LastName,
                                                       Book = b.Book.Book_Name,
                                                       Isbn = b.Book.ISBN,
                                                       Pages = (short)b.Book.Quantity_Page,
                                                       Thumb = string.IsNullOrEmpty(b.Book.Imagen) ? "/Assets/Images/notAvailable.jpg" : b.Book.Imagen
                                                   }).ToList<BookPreviewDto>();
                result = listAuthor;
            }
            return result;
        }

        public IEnumerable<BookPreviewDto> GetBookByAuthor(long id)
        {
            IEnumerable<BookPreviewDto> result;
            using (var context = new LibraryDatabaseEntities())
            {
                List<BookPreviewDto> listAuthor = (from b in context.Book_ByCategory
                                                   where b.Book.Id_Author.Equals(id)
                                                   select new BookPreviewDto
                                                   {
                                                       AuthorName = b.Book.Author.Author_Name + " " + b.Book.Author.Author_LastName,
                                                       Book = b.Book.Book_Name,
                                                       Isbn = b.Book.ISBN,
                                                       Pages = (short)b.Book.Quantity_Page,
                                                       Thumb = string.IsNullOrEmpty(b.Book.Imagen) ? "/Assets/Images/notAvailable.jpg" : b.Book.Imagen
                                                   }).ToList<BookPreviewDto>();
                result = listAuthor;
            }
            return result;
        }

        public IEnumerable<Author> GetAllAuthor()
        {
            IEnumerable<Author> result;
            try
            {
                using (var context = new LibraryDatabaseEntities())
                {
                    List<Author> listAutho = (from c in context.Author
                                              select c).ToList<Author>();
                    result = listAutho;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                result = null;
            }
            return result;
        }

        public byte[] GetPdf(long isbn)
        {
            byte[] result;
            using (var context = new LibraryDatabaseEntities())
            {
                byte[] pdf = (from b in context.Book
                              where b.ISBN == isbn
                              select b.Doc_Data).SingleOrDefault<byte[]>();
                result = pdf;
            }
            return result;
        }
    }
}