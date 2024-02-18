using EntityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model.BANKDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/BankAccount")]
    [ApiController]
    [Authorize]
    public class BankController : ControllerBase
    {
        BankAccountRepository service;

        public BankController()
        {
            service = new BankAccountRepository();
        }
        // GET: api/<BankController>
        [HttpGet]
        public IEnumerable<BankAccount> Get()
        {
            return service.GetAllAccount();
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public BankAccount Get(string id)
        {
            return service.FindById(id);
        }

        // POST api/<BankController>
        [HttpPost]
        public void Post([FromBody] BankAccount bankacc)
        {
            service.Add(bankacc);
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] ModifyBankDTO bankacc)
        {

            BankAccount tomodified = service.FindById(id);
            Console.WriteLine(tomodified);
            tomodified.AccountNo = id;
            tomodified.AccountType = bankacc.AccountType;
            tomodified.AccountHolderName = bankacc.AccountHolderName;
            tomodified.UserId = bankacc.UserId;
            Console.WriteLine(tomodified);
            service.Modify(tomodified);

        }

        // DELETE api/<BankController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Remove(id);
        }
    }
}

