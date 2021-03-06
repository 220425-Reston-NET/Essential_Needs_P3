using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreBL;
using StoreModel;


namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBL _prodBL;
        public ProductsController(IProductsBL p_prodBL)
        {
            _prodBL = p_prodBL;
            
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Products> listOfCurrentProducts = _prodBL.GetAllProducts();

                return Ok(listOfCurrentProducts);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpGet("SearchProductByName")]
        public IActionResult SearchProductByName([FromQuery] string p_pName)
        {
            try
            {
                return Ok(_prodBL.SearchProductByName(p_pName));
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }


    
    }
}
