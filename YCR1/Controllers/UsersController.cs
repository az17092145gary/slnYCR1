using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using YCR1.Model;

namespace YCR1.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserFactorycs _userFactorycs;
        public UsersController(UserFactorycs userFactorycs)
        {
            _userFactorycs = userFactorycs;
        }

        [HttpGet]
        [Route("Get{id}")]
        public ActionResult<User> Get(string id)
        {
            using (var connection = new SqlConnection(_userFactorycs._connectionString))
            {
                connection.Open();
                var result = _userFactorycs.UserGet(connection, id);
                connection.Close();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.id)) 
            {
                return Ok("必須填入ID");
            }
            using (var connection = new SqlConnection(_userFactorycs._connectionString))
            {
                connection.Open();
                var result = _userFactorycs.UserAdd(connection, user);
                connection.Close();
                if (result > 0)
                {
                    return Ok("新增成功");
                }
                return NotFound();
            }
        }
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.id))
            {
                return Ok("必須填入ID");
            }
            using (var connection = new SqlConnection(_userFactorycs._connectionString))
            {
                connection.Open();
                var result = _userFactorycs.UserEdit(connection, user);
                connection.Close();
                if (result > 0) 
                {
                    return Ok("修改成功");
                }
                return NotFound();
            }

        }
        [HttpPost]
        [Route("Delete{id}")]
        public ActionResult Delete(string id)
        {
            using (var connection = new SqlConnection(_userFactorycs._connectionString))
            {
                connection.Open();
                var result = _userFactorycs.UserDelete(connection, id);
                connection.Close();
                if (result > 0)
                {
                    return Ok("刪除成功");
                }
                return NotFound();
            }
        }

    }
}
