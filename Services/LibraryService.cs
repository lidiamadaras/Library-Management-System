using mentorp;

public class LibraryService : ILibraryService{

    private readonly ILibraryRepository _repository;

    public LibraryService(ILibraryRepository repository){
        _repository = repository;
    }

    //instead of doing this in LibraryController, I corrected it by putting them here:
    
    public List<Library> GetAll(){
        return _repository.GetAll();
    }

    
    public Library AddLibrary( Library library){
        return _repository.AddLibrary(library);


        /*
        if(library == null){
            return BadRequest("No data given.");
        }
        if(library.Name == null){
            return BadRequest("Library must have a name.");
        }
        
        return Ok(_repository.AddLibrary(library));
        */
    }

    
    public Library UpdateLibrary(int id, Library updateLibrary){

        return _repository.UpdateLibrary(id, updateLibrary);

        /*
        if(name == null){
            return BadRequest("No data given");
        }
        if(library == null){
            return BadRequest("Invalid data.");
        }
        Library update = _repository.GetAllLibraries().Find(b => b.Name == name);
        update.Name = library.Name;
        update.Books = library.Books;
        //update.Peoples = library.Peoples;

        return Ok(_repository.UpdateLibrary(update));
        */
    }

    
    public void DeleteLibrary(int id){

        _repository.DeleteLibrary(id);

        /*
        if(name == null){
            return BadRequest("No data given");
        }
        Library deleteThis = _repository.GetAllLibraries().Find(b => b.Name == name);
        
        return Ok(_repository.DeleteLibrary(deleteThis));
        */
    }


}