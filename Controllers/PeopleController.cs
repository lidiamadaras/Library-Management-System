using Microsoft.AspNetCore.Mvc;
namespace mentorp.Controllers;

[ApiController]
[Route ("[controller]")]

public class PeopleController : ControllerBase{

    private static List<People> peopleList = new();
    private readonly ILogger<PeopleController> _logger;
    private readonly IPeopleRepository _repository;


    public PeopleController(ILogger<PeopleController> logger, IPeopleRepository repository){
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<People> GetPeople(){
        return Ok(_repository.GetAllPeople());
    }

    [HttpPost]
    public ActionResult<People> AddPeople([FromBody] People people){
        if(people == null){
            return BadRequest("No data given.");
        }
        if(people.Age < 0){
            return BadRequest("Age cannot be negative.");
        }
        
        return Ok(_repository.AddPeople(people));
    }

    [HttpPut]
    public ActionResult<People> UpdatePeople([FromQueryAttribute] string name, [FromBody] People people){
        if(name == null){
            return BadRequest("No data given");
        }
        if(people == null){
            return BadRequest("Invalid data.");
        }
        People update = _repository.GetAllPeople().Find(b => b.Name == name);
        update.Name = people.Name;
        update.Age = people.Age;
        update.Phonenumber = people.Phonenumber;

        return Ok(_repository.UpdatePeople(update));
    }

    [HttpDelete]
    public ActionResult<People> DeletePeople([FromQueryAttribute] string name){
        if(name == null){
            return BadRequest("No data given");
        }
        People deleteThis = _repository.GetAllPeople().Find(b => b.Name == name);
        peopleList.Remove(deleteThis);
        return Ok(_repository.DeletePeople(deleteThis));
    }
}