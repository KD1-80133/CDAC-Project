using EnitityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLib;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        [AllowAnonymous]

        [Route("/User/Login")]
        
        public IActionResult Post([FromBody] Login value)
        {
            IActionResult Response = Unauthorized();
            bool result = false;
            if(ModelState.IsValid)
            {
                
                result = service.ValidateUser(value.EmailId, value.Password);
                if(result==true)
                {

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bd1a1ccf8095037f361a4d351e7c0de65f0776bfc2f478ea8d312c763bb6caca"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "CodeMaze",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });


                    
                    
                }
            }
            return Response;
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
                string otp = service.GenerateOTP(value.EmailId);
            }
            return result;
        }


        //CHANGE PASSWORD   
        [HttpPost]
        [Route("ChangePassword")]
        public bool Post([FromBody] ChangePassword value)
        {
            bool result = true;
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
