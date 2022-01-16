using backend.Enum;
using System;

namespace backend.Domain
{
    public class Expense
    {
        public Expense(int id, decimal value, DateTime payment, DateTime expectedPayment, ExpenseType type, Account account)
        {
            ID = id;
            Value = value;
            Payment = payment;
            ExpectedPayment = expectedPayment;
            Type = type;
            Account = account;
        }

        public decimal Value { get; set; }
        public DateTime Payment { get; set; }
        public DateTime ExpectedPayment { get; set; }
        public ExpenseType Type { get; set; }
        public Account Account { get; set; }
        public int ID { get; set; }

    }
}
