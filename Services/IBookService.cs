using mentorp;

public interface IBookService{
    public void InsertSecondVersionOfBooks(List<int> ids);

    public List<Book> GetAll();

    public Book AddBook(Book book);

    public Book UpdateBook(Book book);

    public Book DeleteBook(Book book);
    
}