using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace test.controller{
[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{

    private IAnonymousEurosongDataContext _data;
  
  public ArtistController(IAnonymousEurosongDataContext data)
  {
    _data = data;
  }

    


  

  [HttpPost]
  [Authorize(Policy = "BasicAuthentication")]
  public ActionResult Post([FromBody] Artist artist)
  { 
    _data.AddArtist(artist);
    return Ok("Hooray");
  }

  [HttpDelete]
  [Authorize(Policy = "BasicAuthentication", Roles = "admin")]
  public ActionResult Delete(int id)
  {
    _data.DeleteArtist(id);
    return Ok("Artist was deleted!");
    
  }

  

  
  [HttpGet]
  public ActionResult<IEnumerable<Artist>> Get()
  {
    return Ok(_data.GetArtists());
  }

 [HttpGet("{id}")]
  public ActionResult<Artist> Get(int id)
  {
    return Ok(_data.GetSinger(id));
  }

  [HttpGet("{id}/songs")]

  public ActionResult<Song> GetSongsByArtistId(int id)
  {
    return Ok(_data.getSongsByArtistID(id));
  }

  
  	

  

}

}