using EntityModel;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("/User")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        MembershipRepository service;

        public AccountController()
        {
            service = new MembershipRepository();
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return service.GetAllUsers();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("Login")]
        public bool Post([FromBody] Login value)
        {
            bool result = false;
            if(ModelState.IsValid)
            {
                result = service.ValidateUser(value.EmailId, value.Password);
                return true;
            }
            return result;
        }
        [HttpPost]
        [Route("SignUp")]
        public bool Post([FromBody] Signup value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.CreateUser(value.userName, value.password, value.mobileNo, value.emailId,value.roleId);
                return true;
            }
            return result;
        }
        [HttpPost]
        [Route("Reset")]
        public bool Post([FromBody] ResetPassword value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.ResetPassword(value.EmailId, value.OTP, value.Password);
            }
            return result;
        }

        //GENERATE OTP
        [HttpPost()]
        [Route("GenerateOTP")]
        public string Post([FromBody] GenerateOTP value)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                string otp = service.GenerateOTP(value.EmailId);
            }
            return result;
        }
        [HttpPost()]
        [Route("ChangePassword")]
        public bool Post([FromBody] ChangePassword value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.ChangePassword(value.EmailId, value.OldPassword, value.NewPassword);
            }
            return result;
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{EmailId}")]

        public bool Delete(string EmailId)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                service.DeleteUser(EmailId);
                service.GetAllUsers();
                return true;
            }
            return result;
        }
    }
}
