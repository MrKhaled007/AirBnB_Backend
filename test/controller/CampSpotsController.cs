using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace test.controller{
[ApiController]
[Route("[controller]")]
public class CampSpotsController : ControllerBase
{

    private IAnonymousEurosongDataContext _data;
  
  public CampSpotsController(IAnonymousEurosongDataContext data)
  {
    _data = data;
  }

    


  [HttpGet]
  public ActionResult<IEnumerable<CampSpots>> Get()
  {
    return Ok(_data.GetCampSpots());
  }

 




  [HttpPost("AddNewSpot")]
  
  public ActionResult Post([FromBody] CampSpots campSpots)
  { 
    _data.AddCampSpots(campSpots);
    
    return Ok("Spot was added!");
  }

  [HttpDelete]
  public ActionResult Delete(int id)
  {
    _data.DeleteSpot(id);
    return Ok("Spot was deleted!");
    
  }

  [HttpGet("{id}")]
  public ActionResult<CampSpots> Get(int id)
  {
    return Ok(_data.GetCampSpot(id));
  }


  






    




  

  


  

}

}