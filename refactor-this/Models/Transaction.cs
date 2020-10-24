using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace refactor_this.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        private Account Account { get; set; }
    }
}