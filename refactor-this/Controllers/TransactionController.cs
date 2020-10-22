using refactor_this.DatabaseHelpers;
using refactor_this.Models;
using System;
using System.Configuration;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        private readonly TransactionRepository Repository;
        private readonly AccountRepository AccRepository;

        public TransactionController()
        {
            Repository = new TransactionRepository(ConfigurationManager.
                ConnectionStrings["conStr"].ConnectionString);
            AccRepository = new AccountRepository(ConfigurationManager.
                ConnectionStrings["conStr"].ConnectionString);
        }

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            return Ok(Repository.GetAll(id));
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            var account = AccRepository.GetById(id);

            Repository.Add(transaction, id);

            account.Amount += transaction.Amount;
            AccRepository.Update(account);


            return Ok();
        }
    }
}