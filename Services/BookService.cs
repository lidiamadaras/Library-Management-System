using mentorp;
public class BookService : IBookService{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository){
        _repository = repository;
    }

    public async void InsertSecondVersionOfBooks(List<int> ids){
            foreach (int id in ids)
            {
            Book book = _repository.GetById(id);
            book.Title += "_2";
            _repository.UpdateBook(book);
            }
    }

    public List<Book> GetAll(){
       return  _repository.GetAll();
    }

    public Book AddBook(Book book){
        return _repository.AddBook(book);
    }

    public Book UpdateBook(Book book){
        return _repository.UpdateBook(book);
    }

    public Book DeleteBook(Book book){
        return _repository.DeleteBook(book);
    }
    



}