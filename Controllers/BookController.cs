
using Microsoft.AspNetCore.Mvc;
namespace mentorp.Controllers;

//Get always returns data
//Post saves
//Update
//Delete


[ApiController]                 //its an attribute, for example it also controls that there can only be one get

//[Route("[controller]")]
public class BookController : ControllerBase
{
   
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _service;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        //_repository = bookRepository;
        _service = bookService;
    }

    //this is an endpoint

    [HttpGet]
    [Route("api/v1/books")]
    // public IEnumerable<Book> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new Book
    //     {
    //         Title = "Cim",
    //         PublishYear = 1999,
    //         Pages = 300
    //     })
    //     .ToArray();
    // }

    public ActionResult <IEnumerable<Book>> GetBooks()
    {
        return Ok(_service.GetAll());
        
    }

    [HttpPost]
    [Route("api/v1/books")]
    public ActionResult<Book> AddBook([FromBody] Book newBook){
        if(newBook == null){
            return BadRequest("Invalid book data");
        }
        // if(newBook.Pages <= 0){
        //     return BadRequest("Pages cannot be a negative value");
        // }

        
        //bookList.Add(newBook);
        return Ok(_service.AddBook(newBook));
    }

    [HttpPut]
    [Route("api/v1/books/")]

    public ActionResult<Book> UpdateBook([FromQueryAttribute] int bookid, [FromBody] Book updatebook){

        if(updatebook == null){
            return BadRequest("Invalid book data.");
        }
        
        Book UBook = _service.GetAll().Find(x => x.Id == bookid);
        if(UBook == null){
            return BadRequest("Cannot find book.");
        }
        UBook.Title = updatebook.Title;
        //UBook.PublishYear = updatebook.PublishYear;
        //UBook.Pages = updatebook.Pages;

        return Ok(_service.UpdateBook(UBook));    
    }

    [HttpDelete]
    [Route("api/v1/books/")]

    public ActionResult<Book> DeleteBook([FromQueryAttribute] int bookid){
        if(bookid == null){
            return BadRequest("No data given.");
        }
        Book deleteThisBook = _service.GetAll().Find(b => b.Id== bookid);
        if(deleteThisBook == null){
            return BadRequest("Cannot find book.");
        }

        // bookList.Remove(deleteThisBook);
        return Ok(_service.DeleteBook(deleteThisBook));
    }


    [HttpPatch]
    [Route("api/v1/books/{id}")]
    public ActionResult<Book> UpdateBooks(List<int> ids){
        _service.InsertSecondVersionOfBooks(ids);
        return Ok(ids);
    }





}
