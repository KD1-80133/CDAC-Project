using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        MembershipRepository service;
        public AccountController()
        {
            service = new MembershipRepository();
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("/User/Login")]
        public bool Post([FromBody] Login value)
        {
            bool result = false;
            if(ModelState.IsValid)
            {
                result = service.ValidateUser(value.EmailId, value.Password);
            }
            return result;
        }
        [HttpPost]
        [Route("/User/Signup")]
        public bool Post([FromBody] Signup value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.CreateUser(value.userName, value.password, value.mobileNo, value.emailId,value.RoleId);
                return true;
            }
            return result;
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
