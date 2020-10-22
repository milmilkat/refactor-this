using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace refactor_this.DatabaseHelpers
{
    public class AccountRepository : AdoRepository<Account>
    {
        public AccountRepository(string connectionString)
            : base(connectionString)
        {
        }

        public IEnumerable<Account> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM Accounts"))
            {
                return GetRecords(command);
            }
        }

        public Account GetById(Guid id)
        {
            using (var command = new SqlCommand("SELECT * FROM Accounts WHERE Id = @id"))
            {
                command.Parameters.AddWithValue("@Id", id);
                return GetRecord(command);
            }
        }

        public void Add(Account account)
        {
            var builder = new SqlQueryBuilder<Account>(account);
            account.Id = Guid.NewGuid();
            ExecuteCommand(builder.GetInsertCommand());
        }

        public void Update(Account account)
        {
            var builder = new SqlQueryBuilder<Account>(account);
            ExecuteCommand(builder.GetUpdateCommand());
        }

        public void Delete(Account account)
        {
            var builder = new SqlQueryBuilder<Account>(account);
            ExecuteCommand(builder.GetDeleteCommand());
        }

        public override Account PopulateRecord(SqlDataReader reader)
        {
            return new Account
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Number = reader.GetString(2),
                Amount = float.Parse(reader.GetValue(3).ToString())
            };
        }
    }
}