using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refactor_this.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        public float Amount { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("AccountId")]
        public Guid AccountId { get; set; }
    }
}