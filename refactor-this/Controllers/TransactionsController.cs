using refactor_this.Data;
using refactor_this.Models;
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace refactor_this.Controllers
{
    public class TransactionsController : ApiController
    {
        private refactor_thisContext db = new refactor_thisContext();

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IQueryable<Transaction> GetTransactions(Guid id)
        {
            return db.Transactions.Where(x => x.AccountId == id).OrderBy(x => x.Date);
        }

        [ResponseType(typeof(Transaction))]
        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public async Task<IHttpActionResult> PostTransaction(Guid id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaction.Id = Guid.NewGuid();
            transaction.Date = DateTime.Now;
            transaction.AccountId = id;

            db.Transactions.Add(transaction);
            var account = await db.Accounts.FindAsync(id);
            account.Amount += transaction.Amount;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionExists(transaction.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // GET: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> GetTransaction(Guid id)
        {
            throw new NullReferenceException("Not implemented");
        }

        // PUT: api/Transactions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransaction(Guid id, Transaction transaction)
        {
            throw new NullReferenceException("Not implemented");
        }

        // DELETE: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public async Task<IHttpActionResult> DeleteTransaction(Guid id)
        {
            throw new NullReferenceException("Not implemented");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(Guid id)
        {
            return db.Transactions.Count(e => e.Id == id) > 0;
        }
    }
}