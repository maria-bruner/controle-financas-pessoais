using backend.Enum;
using System;

namespace backend.Domain
{
    public class Renevue
    {
        public Renevue(int id, decimal value, DateTime receipt, DateTime expectedReceipt, string description, Account account, RenevueType type)
        {
            ID = id;
            Value = value;
            Receipt = receipt;  
            ExpectedReceipt = expectedReceipt;
            Description = description;
            Account = account;
            Type = type;
        }
        public int ID { get; set; }
        public decimal Value { get; set; }
        public DateTime Receipt { get; set; }
        public DateTime ExpectedReceipt { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
        public RenevueType Type { get; set; }

    }
}
