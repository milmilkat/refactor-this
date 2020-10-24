using System;

namespace refactor_this.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public double Amount { get; set; }
    }
}