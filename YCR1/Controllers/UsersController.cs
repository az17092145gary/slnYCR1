using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace YCR1.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("Get")]
        public ActionResult Get(string id)
        {
            using (var connection = new SqlConnection()) 
            {
                
            
            }
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(string id, string name, int age)
        {
            return View();
        }
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(int id, string? name, int? age)
        {

            return View();

        }
        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
