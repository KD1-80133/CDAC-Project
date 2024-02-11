using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/user")]
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

        //LOGIN
        // POST api/<AccountController>
        [HttpPost]
        [Route("SignIn")]
        public bool Post([FromBody] Login value)
        {
            bool result = false;
            if(ModelState.IsValid)
            {
                result = service.ValidateUser(value.EmailId, value.Password);
            }
            return result;
        }

        //SIGNUP
        [HttpPost]
        [Route("SignUp")]
        public bool Post([FromBody] SignUp value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.CreateUser(value.userName, value.password, value.mobileNo, value.emailId);
            }
            return result;
        }

        //RESET USER
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
                string otp=service.GenerateOTP(value.EmailId);
            }
            return result;
        }


        //CHANGE PASSWORD   
        [HttpPost]
        [Route("ChangePassword")]
        public bool Post([FromBody] ChangePassword value)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.ChangePassword(value.EmailId,value.OldPassword,value.NewPassword);
               
            }
            return result;
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        //DELETE USER
        // DELETE api/<AccountController>/EmailId
        [HttpDelete("{EmailId}")]
        public bool Delete(string EmailId)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = service.DeleteUser(EmailId);
            }
            return result;
        }
    }
}
