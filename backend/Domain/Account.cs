using backend.Enum;

namespace backend.Domain
{
    public class Account
    {
        public Account(int id, decimal balance, AccountType type, string financialInstitution)
        {
            ID = id;
            Balance = balance;
            Type = type;
            FinancialInstitution = financialInstitution;

        }
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public string FinancialInstitution { get; set; }
    }
}
