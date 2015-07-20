using System;
using System.Net;
using System.Web.Mvc;
using Library.Core;

namespace TrackLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var model = new BookManager().GetAllBooks();
            return View(model);
        }

        public FileContentResult ReturnBookInPdf(string isbn)
        {
            try
            {

                var bytes = new BookManager().GetPdf(Convert.ToInt64(isbn));

                const string mimeType = "application/pdf";

                var content = new System.Net.Mime.ContentDisposition
                {
                    FileName = "Test.pdf",
                    Inline = true
                };

                Response.AppendHeader("Content-Disposition", content.ToString());
                return File(bytes, mimeType);
            }
            catch (Exception)
            {
                return null;
               

            }
        }

        public JsonResult BookByAuthor(string filterKey)
        {
            try
            {
                string[] keywords = filterKey.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var model = new BookManager().GetBookByAuthor(keywords);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult BookByCategory(string filterKey)
        {
            try
            {
                var model = new BookManager().GetBookByCategory(filterKey.Trim());
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}