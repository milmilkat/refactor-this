using refactor_this.DatabaseHelpers;
using refactor_this.Models;
using System;
using System.Configuration;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        private readonly AccountRepository Repository;

        public AccountController()
        {
            Repository = new AccountRepository(ConfigurationManager.
                ConnectionStrings["conStr"].ConnectionString);
        }

        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            return Ok(Repository.GetById(id));
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            return Ok(Repository.GetAll());
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            Repository.Add(account);
            return Ok();
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Account account)
        {
            Repository.Update(account);
            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var account = Repository.GetById(id);
            Repository.Delete(account);
            return Ok();
        }
    }
}