namespace mentorp;
using System.ComponentModel.DataAnnotations.Schema;
public class Book{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set; }
    
    public string Title{ get; set; }

    //public int PublishYear{ get; set; }
    //public int Pages{ get; set; }

    public int LibraryId { get; set; }
    
}