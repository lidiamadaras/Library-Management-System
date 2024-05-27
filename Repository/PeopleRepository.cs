using mentorp;

public class PeopleRepository : IPeopleRepository{
    private readonly BookContext _context;

    public PeopleRepository(BookContext context){
        _context = context;
    }

    public List<People> GetAllPeople(){
        List<People> peoples = _context.Peoples.ToList();
        return peoples;
    }
    public People AddPeople(People people){
        _context.Add(people);
        _context.SaveChanges();
        return people;
    }
    public People UpdatePeople(People people){
        _context.Update(people);
        _context.SaveChanges();
        return people;
    }

    public People DeletePeople(People people){
        _context.Remove(people);
        _context.SaveChanges();
        return people;
    }


}