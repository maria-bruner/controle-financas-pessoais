using backend.Domain;
using backend.Enum;
using backend.Services.Interface;
using backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Services
{
    class ExpenseService : IRead<Expense>, IWrite<Expense>, IFilter<Expense>
    {
        public ExpenseService()
        { }

        public List<Expense> List()
        {
            return Program.ExpenseList;
        }
        public void Create(Expense expenseCreate)
        {
            if (expenseCreate.Value <= 0) throw new Exception("Valor preenchido incorretamente.");
            if (expenseCreate.ExpectedPayment < DateTime.MinValue) throw new Exception("Data do Pagamento Esperado preenchido incorretamente.");
            if (expenseCreate.Type is <= 0 or > (ExpenseType)8) throw new Exception("Tipo de Despesa preenchida incorretamente.");
            if (expenseCreate.Account == null) throw new Exception("Conta preenchida incorretamente.");

            expenseCreate.ID = IncrementId();
            Program.ExpenseList.Add(expenseCreate);
        }

        private int IncrementId()
        {
            return Program.ExpenseList.Count + 1;
        }

        public void Delete(int id)
        {
            Expense expenseDelete = null;

            for (int i = 0; i < Program.ExpenseList.Count; i++)
            {
                if (Program.ExpenseList[i].ID == id)
                {
                    expenseDelete = Program.ExpenseList[i];
                }
            }
            if (expenseDelete == null) throw new Exception("Registro inexistente!");

            Program.ExpenseList.Remove(expenseDelete);
        }

        public void Update(Expense ExpenseUpdate, int id)
        {
            if (ExpenseUpdate.ID != id)
            {
                throw new Exception("Preencha os ID's corretamente!");
            }

            for (int i = 0; i < Program.ExpenseList.Count; i++)
            {
                if (Program.ExpenseList[i].ID == id)
                {
                    Expense originalExpense = Program.ExpenseList[i];

                    if (ExpenseUpdate.Value > 0) originalExpense.Value = ExpenseUpdate.Value;

                    if (ExpenseUpdate.Payment > DateTime.MinValue) originalExpense.Payment = ExpenseUpdate.Payment;

                    if (ExpenseUpdate.ExpectedPayment > DateTime.MinValue) originalExpense.ExpectedPayment = ExpenseUpdate.ExpectedPayment;

                    if (ExpenseUpdate.Type is > 0 and <= (ExpenseType)8) originalExpense.Type = ExpenseUpdate.Type;

                    if (ExpenseUpdate.Account != null) originalExpense.Account = ExpenseUpdate.Account;

                    Program.ExpenseList[i] = originalExpense;
                }
            }
        }

        public List<Expense> FilterPeriod(DateTime initial, DateTime end)
        {
            if (initial <= DateTime.MinValue && end <= DateTime.MinValue)
            {
                throw new Exception("Data inicial ou final preenchida incorretamente!");
            }

            List<Expense> expenseFilter = new List<Expense>();

            for (int i = 0; i < Program.ExpenseList.Count; i++)
            {
                if (initial >= DateTime.MinValue && end <= DateTime.MinValue)
                {
                    if (Program.ExpenseList[i].ExpectedPayment >= initial && Program.ExpenseList[i].ExpectedPayment <= end)
                    {
                        expenseFilter.Add(Program.ExpenseList[i]);
                    }
                }
                else if (initial >= DateTime.MinValue)
                {
                    if (Program.ExpenseList[i].ExpectedPayment >= initial) expenseFilter.Add(Program.ExpenseList[i]);
                }
                else
                {
                    if (Program.ExpenseList[i].ExpectedPayment >= end) expenseFilter.Add(Program.ExpenseList[i]);
                }
            }

            return expenseFilter;
        }

        public List<Expense> FilterType(int type)
        {
            if (type <= 0 || type > 8) throw new Exception("Tipo de Despesa inexistente.");

            List<Expense> expenseFilterType = new List<Expense>();

            for (int i = 0; i < Program.ExpenseList.Count; i++)
            {
                if (Program.ExpenseList[i].Type == (ExpenseType)type)
                {
                    expenseFilterType.Add(Program.ExpenseList[i]);
                }
            }

            return expenseFilterType;
        }
    }
}