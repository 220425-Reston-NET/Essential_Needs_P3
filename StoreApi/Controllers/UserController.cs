global using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreBL;
using StoreModel;

namespace StoreApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        private readonly IProductsBL _productsBL;
        public UserController(IUserBL p_userBL, IProductsBL p_productsBL)
        {
            _userBL = p_userBL;
            _productsBL = p_productsBL;
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                Log.Information("User was Searched");
                List<User> listOfCurrentUser = _userBL.GetAllUser();

                return Ok(listOfCurrentUser);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User u_use)
        {
            try
            {
                Log.Information("User Was Added");
                _userBL.AddUser(u_use);
                return Created("User was added!", u_use);
            }
            catch (SqlException)
            {
                Log.Warning("User was not found");
                return Conflict();
            }
        }

        [HttpGet("SearchUserByName")]
        public IActionResult SearchUserByName([FromQuery] string userName)
        {
            try
            {
                Log.Information("User was searched by name");
                return Ok(_userBL.SearchUserByName(userName));
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }

        [HttpGet("SearchUserByEmailAndPassword")]
        public IActionResult SearchUserByEmailAndPassword([FromQuery] string Email, [FromQuery] string Password)
        {
            try
            {
                Log.Information("User was searched by email and password");
                return Ok(_userBL.SearchUserByEmailAndPassword(Email, Password));
            }
            catch (System.AccessViolationException)
            {
                return Conflict();
            }
        }

        [HttpPut("ReplenishQuantity")]
        public IActionResult ReplenishQuantity([FromQuery] int pID, [FromQuery] int Quantity, [FromQuery] string Email, [FromQuery] string Password)
        {
            User found = _userBL.SearchUserByEmailAndPassword(Email, Password);

            if (found == null)
            {
                Log.Warning("Store was not found!");
                return NotFound("Store was not found!");
            }

            else
            {
                try
                {
                    _productsBL.ReplenishProductsQuantity(pID, found.uID, Quantity);

                    return Ok();
                }
                catch (SqlException)
                {
                    return Conflict();
                }
            }
        }
    }
}

