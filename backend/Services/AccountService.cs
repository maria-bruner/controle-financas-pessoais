using backend.Domain;
using backend.Enum;
using backend.Services.Interface;
using backend.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace backend.Services
{
    class AccountService : IRead<Account>, IWrite<Account>
    {
        public AccountService()
        { }

        public List<Account> List()
        {
            return Program.AccountList;
        }

        public void Create(Account accountCreate)
        {
            if (accountCreate.Balance <= 0) throw new Exception("Saldo preenchido incorretamente.");
            if (accountCreate.Type is <= 0 or > (AccountType)3) throw new Exception("Tipo de Conta preenchida incorretamente.");
            if (string.IsNullOrEmpty(accountCreate.FinancialInstitution)) throw new Exception("Instituição Financeira preenchida incorretamente.");

            accountCreate.ID = IncrementId();
            Program.AccountList.Add(accountCreate);
        }

        private int IncrementId()
        {
            return Program.AccountList.Count + 1;
        }
        public void Delete(int id)
        {
            Account accountDelete = null;

            for (int i = 0; i < Program.AccountList.Count; i++)
            {
                if (Program.AccountList[i].ID == id)
                {
                    accountDelete = Program.AccountList[i];
                }
            }
            if (accountDelete == null) throw new Exception("Registro inexistente!");

            Program.AccountList.Remove(accountDelete);
        }

        public void Update(Account accountUpdate, int id)
        {
            if (accountUpdate.ID != id)
            {
                throw new Exception("Preencha os ID's corretamente!");
            }

            for (int i = 0; i < Program.AccountList.Count; i++)
            {
                if (Program.AccountList[i].ID == id)
                {
                    Account originalAccount = Program.AccountList[i];

                    if (accountUpdate.Balance > 0) originalAccount.Balance = accountUpdate.Balance;
                    if (!string.IsNullOrEmpty(accountUpdate.FinancialInstitution)) originalAccount.FinancialInstitution = accountUpdate.FinancialInstitution;
                    if (accountUpdate.Type is > 0 and <= (AccountType)3) originalAccount.Type = accountUpdate.Type;


                    Program.AccountList[i] = originalAccount;
                }
            }
        }
    }
}

