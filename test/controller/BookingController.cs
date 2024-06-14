using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace test.controller{
[ApiController]
[Route("[controller]")]

public class BookingController: ControllerBase {


  private IAnonymousEurosongDataContext _data;
  
  public BookingController(IAnonymousEurosongDataContext data)
  {
    _data = data;
  }

[HttpGet]

  public ActionResult<IEnumerable<Bookings>> Get()
  {
    return Ok(_data.GetBookings());
  }





  [HttpPost]
  
  public ActionResult Post([FromBody] Bookings bookings)
  { 
    _data.AddBooking(bookings);
    
    return Ok("Booking Done");
  }

  [HttpGet("byUsername")]
        public ActionResult<IEnumerable<Bookings>> GetBookingsByUsername([FromQuery] string username)
        {
            var bookings = _data.GetBookings().Where(b => b.userName == username).ToList();

            if (bookings == null || !bookings.Any())
            {
                return NotFound();
            }

            return Ok(bookings);
        }


  

 



  




        



}
}