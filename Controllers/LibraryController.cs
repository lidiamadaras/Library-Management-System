
using Microsoft.AspNetCore.Mvc;
namespace mentorp.Controllers;

[ApiController]
[Route ("[controller]")]

public class LibraryController : ControllerBase{
    //private static List<Library> libraryList = new();
    private readonly ILogger<LibraryController> _logger;
    //private readonly ILibraryRepository _repository;

    //i should use service instead:

    private readonly ILibraryService _service;



    
    public LibraryController(ILogger<LibraryController> logger,  ILibraryService libraryService){
        _logger = logger;
        _service = libraryService;
    }
    

    [HttpGet]
    public ActionResult <IEnumerable<Library>> GetLibrary(){
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public ActionResult<Library> AddLibrary([FromBody] Library library){
        if(library == null){
            return BadRequest("No data given.");
        }
        if(library.Name == null){
            return BadRequest("Library must have a name.");
        }
        
        return Ok(_service.AddLibrary(library));
    }

    [HttpPut]
    public ActionResult<Library> UpdateLibrary([FromQueryAttribute] int id, [FromBody] Library library){
        if(library == null){
            return BadRequest("Invalid data.");
        }
        Library update = _service.GetAll().Find(b => b.ID == id);
        update.Name = library.Name;
        update.Books = library.Books;
        //update.Peoples = library.Peoples;

        return Ok(_service.UpdateLibrary(update.ID, library));
    }

    [HttpDelete]
    public ActionResult<Library> DeleteLibrary([FromQueryAttribute] int id){
        if(id == null){
            return BadRequest("No data given");
        }
        Library deleteThis = _service.GetAll().Find(b => b.ID == id);
        
        return Ok(0);
    }

}
