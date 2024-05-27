using mentorp;

public class LibraryRepository : ILibraryRepository{
    private readonly BookContext _context;

    public LibraryRepository(BookContext context){
        _context = context;
    }

    // public List<Library> GetAllLibraries(){
    //     List<Library> libraries = _context.Libraries.ToList();
    //     return libraries;
    // }
    public List<Library> GetAll()
    {

        List<Library> libraries = _context.Libraries.ToList();
        return libraries; 
        /*
        var libraries = _context.Libraries.Where(l => !l.IsDeleted).ToList();
        return libraries.ToList();
        */
    }


// you should only be able to change the libraries where flag is false
public Library UpdateLibrary(int id, Library updateLibrary)
    {
        /*
        var library = _context.Libraries.Find(id);
        if (!library.IsDeleted)                                                     ///////
        {
            library.Name = updateLibrary.Name;
            library.Address = updateLibrary.Address;
            library.Books = updateLibrary.Books;
            _context.SaveChanges();
        }
        return library;
        */
        _context.Update(id);
        _context.SaveChanges();
        return updateLibrary;
    }
    public Library AddLibrary(Library library){
        _context.Add(library);
        _context.SaveChanges();
        return library;
    }
    // public Library UpdateLibrary(Library library){
    //     _context.Update(library);
    //     _context.SaveChanges();
    //     return library;
    // }

    public void DeleteLibrary(int id)
    {
        //var library = _context.Libraries.Include(l => l.Books).FirstOrDefault(l => l.Id == id);
        /*
        var library = _context.Libraries.Find(id);
        if (library != null)
        {
            if (library.Books.Any())
            {
                library.IsDeleted = true;                   //////////////////////////////////
            }
            else
            {
                _context.Libraries.Remove(library);
            }
           _context.SaveChanges();
           return library;
        }
        return null;
        */
        _context.Remove(id);
        _context.SaveChanges();
    }





}