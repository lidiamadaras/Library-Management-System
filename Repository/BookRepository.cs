using mentorp;

public class BookRepository : IBookRepository{
    private readonly BookContext _context;
    public BookRepository(BookContext context){
        _context = context;
}
    public List<Book> GetAll(){
        List<Book> books = _context.Books.ToList();
        return books;   
    }

    public Book AddBook(Book book){
        _context.Add(book);
        _context.SaveChanges();
        return book;
    }

    public Book UpdateBook(Book book){
        _context.Update(book);
        _context.SaveChanges();
        return book;
    }

    public Book DeleteBook(Book book){
        _context.Remove(book);
        _context.SaveChanges();
        return book;
    }
    public Book GetById(int id){
        return _context.Books.Find(id);
    }


}