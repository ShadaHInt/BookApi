using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookDbContext _bookContext = new BookDbContext();

        [HttpGet]
        
        public IActionResult GetBooklist() 
        {
            var list = _bookContext.Books.ToList();
            return Ok(list);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookModel model)
        {
            _bookContext.Books.Add(model);
            _bookContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
         public IActionResult DeleteBook(int id)
        { 
          var delete = _bookContext.Books.Find(id);
            _bookContext.Books.Remove(delete);
            _bookContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookModel updatedModel)
        {
            var existingBook = _bookContext.Books.Find(id);

            if (existingBook == null)
            {
                return NotFound(); 
            }

           
            existingBook.BookName = updatedModel.BookName;
            existingBook.AuthorName = updatedModel.AuthorName;

            _bookContext.SaveChanges();

            return Ok(existingBook); 
        }


    }
}
