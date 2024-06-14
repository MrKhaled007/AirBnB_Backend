using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace test.controller{
[ApiController]
[Route("[controller]")]

public class UserController: ControllerBase {


  private IAnonymousEurosongDataContext _data;
  
  public UserController(IAnonymousEurosongDataContext data)
  {
    _data = data;
  }

[HttpGet]

  public ActionResult<IEnumerable<User>> Get()
  {
    return Ok(_data.GetUsers());
  }

 [HttpPost("Register")]
        public IActionResult CreateUser(User newUser)
        {
            // Retrieve all users
            var users = _data.GetUsers();

            // Check if the user already exists
            foreach (var user in users)
            {
                if (user.Username == newUser.Username)
                {
                    return BadRequest("User already exists.");
                }
            }

            // Add the new user
            
            _data.AddUser(newUser);
            

            return Ok(newUser);
        }




        [HttpGet("GetUser")]
        public IActionResult GetUser(string email, string password)
        {
            var user = _data.GetUsers().FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }


        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
          return Ok(_data.GetUserById(id));
        }


        [HttpPut("Update{id}")]
        public IActionResult UpdateUser(int id, User updatedUser) {
            var user = _data.GetUserById(id);
            if (user == null) {
                return NotFound(new { message = "User not found" });
            }

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            // Add other fields as necessary

            _data.UpdateUser(user);

            return Ok(user);
        }


        



}
}