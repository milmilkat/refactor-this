using System.Configuration;
using System.Data.Entity;

namespace refactor_this.Data
{
    public class refactor_thisContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public refactor_thisContext() : base(ConfigurationManager.
            ConnectionStrings["conStr"].ConnectionString)
        {
        }

        public System.Data.Entity.DbSet<refactor_this.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<refactor_this.Models.Transaction> Transactions { get; set; }
    }
}
