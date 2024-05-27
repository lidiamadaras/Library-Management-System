using mentorp;

public interface ILibraryService{
    public List<Library> GetAll();

    public Library AddLibrary( Library library);

    public Library UpdateLibrary(int id, Library updateLibrary);

    public void DeleteLibrary(int id);
}