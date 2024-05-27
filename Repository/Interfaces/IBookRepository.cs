using mentorp;

public interface IBookRepository{
    public List<Book> GetAll();

    public Book AddBook(Book book);

    public Book UpdateBook(Book book);

    public Book DeleteBook(Book book);
    public Book GetById(int id);
}