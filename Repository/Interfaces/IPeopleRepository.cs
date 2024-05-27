using mentorp;

public interface IPeopleRepository{
    public List<People> GetAllPeople();

    public People AddPeople(People people);

    public People UpdatePeople(People people);

    public People DeletePeople(People people);
}