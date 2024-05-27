namespace mentorp;
using System.ComponentModel.DataAnnotations.Schema;

public class Library{
    public int ID{get; set;}
    public string Name{get; set;}

    public List<Book> Books {get; set;}

     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // We need id for automatic generation
    //public int Id { get; set; }
    //public string Name { get; set; }
    public string Address { get; set; }
    // the rest of the members
    public bool IsDeleted { get; set; } = false;   // ez a flag

    //public List<Book> Books { get; set; }
    //public List<People> Peoples = new();

    // public Library(string name, List<Book> books, List<People> peoples){
    //     Name = name;
    //     Books = books;
    //     Peoples = peoples;
    // }
    
}
