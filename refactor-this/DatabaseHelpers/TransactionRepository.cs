using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace refactor_this.DatabaseHelpers
{
    public class TransactionRepository : AdoRepository<Transaction>
    {
        public TransactionRepository(string connectionString)
            : base(connectionString)
        {
        }

        public IEnumerable<Transaction> GetAll(Guid id)
        {
            using (var command = new SqlCommand("SELECT * FROM Transactions WHERE AccountId = @Id"))
            {
                command.Parameters.AddWithValue("@Id", id);
                return GetRecords(command).OrderBy(x => x.Date);
            }
        }

        public void Add(Transaction transaction, Guid id)
        {
            var builder = new SqlQueryBuilder<Transaction>(transaction);
            transaction.Id = Guid.NewGuid();
            transaction.AccountId = id;
            transaction.Date = DateTime.Now;
            ExecuteCommand(builder.GetInsertCommand());
        }

        public override Transaction PopulateRecord(SqlDataReader reader)
        {
            return new Transaction
            {
                Id = reader.GetGuid(0),
                Amount = float.Parse(reader.GetValue(1).ToString()),
                Date = reader.GetDateTime(2),
                AccountId = reader.GetGuid(3)
            };
        }
    }
}