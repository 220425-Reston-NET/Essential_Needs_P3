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
                _userBL.AddUser(u_use);
                return Created("Customer was added!", u_use);
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }

        [HttpGet("SearchUserByName")]
        public IActionResult SearchUserByName([FromQuery] string userName)
        {
            try
            {
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

