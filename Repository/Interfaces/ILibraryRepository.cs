using mentorp;

public interface ILibraryRepository{
    //public List<Library> GetAllLibraries();
    public List<Library> GetAll();

    public Library AddLibrary(Library library);

    //public Library UpdateLibrary(Library library);
    
    public Library UpdateLibrary(int id, Library updateLibrary);
    public void DeleteLibrary(int id);

}