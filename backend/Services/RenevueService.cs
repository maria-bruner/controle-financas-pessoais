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
    class RenevueService : IRead<Renevue>, IWrite<Renevue>, IFilter<Renevue>
    {
        public RenevueService()
        { }
        public List<Renevue> List()
        {
            return Program.RenevueList;
        }
        public void Create(Renevue renevueCreate)
        {
            if (renevueCreate.Value <= 0) throw new Exception("Valor preenchido incorretamente.");
            if (renevueCreate.ExpectedReceipt < DateTime.MinValue) throw new Exception("Data do Pagamento Esperado preenchido incorretamente.");
            if (string.IsNullOrEmpty(renevueCreate.Description)) throw new Exception("Descrição preenchida incorretamente.");
            if (renevueCreate.Type is <= 0 or > (RenevueType)4) throw new Exception("Tipo de Despesa preenchida incorretamente.");
            if (renevueCreate.Account == null) throw new Exception("Conta preenchida incorretamente.");

            renevueCreate.ID = IncrementId();
            Program.RenevueList.Add(renevueCreate);
        }

        private int IncrementId()
        {
            return Program.RenevueList.Count + 1;
        }

        public void Delete(int id)
        {
            Renevue renevueDelete = null;

            for (int i = 0; i < Program.RenevueList.Count; i++)
            {
                if (Program.RenevueList[i].ID == id)
                {
                    renevueDelete = Program.RenevueList[i];
                }
            }
            if (renevueDelete == null) throw new Exception("Registro inexistente!");

            Program.RenevueList.Remove(renevueDelete);
        }

        public void Update(Renevue renevueUpdate, int id)
        {
            for (int i = 0; i < Program.RenevueList.Count; i++)
            {
                if (Program.RenevueList[i].ID == id)
                {
                    Renevue originalRenevue = Program.RenevueList[i];

                    if (renevueUpdate.Value > 0) originalRenevue.Value = renevueUpdate.Value;

                    if (renevueUpdate.Receipt > DateTime.MinValue) originalRenevue.Receipt = renevueUpdate.Receipt;

                    if (renevueUpdate.ExpectedReceipt > DateTime.MinValue) originalRenevue.ExpectedReceipt = renevueUpdate.ExpectedReceipt;

                    if (!string.IsNullOrEmpty(renevueUpdate.Description)) originalRenevue.Description = renevueUpdate.Description;

                    if (renevueUpdate.Type is > 0 and <= (RenevueType)4) originalRenevue.Type = renevueUpdate.Type;

                    if (renevueUpdate.Account != null) originalRenevue.Account = renevueUpdate.Account;

                    Program.RenevueList[i] = originalRenevue;
                }
            }
        }

        public List<Renevue> FilterPeriod(DateTime initial, DateTime end)
        {
            if (initial <= DateTime.MinValue && end <= DateTime.MinValue)
            {
                throw new Exception("Data inicial ou final preenchida incorretamente!");
            }

            List<Renevue> renevueFilter = new List<Renevue>();

            for (int i = 0; i < Program.RenevueList.Count; i++)
            {
                if (initial >= DateTime.MinValue && end <= DateTime.MinValue)
                {
                    if (Program.RenevueList[i].ExpectedReceipt >= initial && Program.RenevueList[i].ExpectedReceipt <= end)
                    {
                        renevueFilter.Add(Program.RenevueList[i]);
                    }
                }
                else if (initial >= DateTime.MinValue)
                {
                    if (Program.RenevueList[i].ExpectedReceipt >= initial) renevueFilter.Add(Program.RenevueList[i]);
                }
                else
                {
                    if (Program.RenevueList[i].ExpectedReceipt >= end) renevueFilter.Add(Program.RenevueList[i]);
                }
            }

            return renevueFilter;
        }

        public List<Renevue> FilterType(int type)
        {
            if (type <= 0 || type > 8) throw new Exception("Tipo de Receita inexistente.");

            List<Renevue> renevueFilterType = new List<Renevue>();

            for (int i = 0; i < Program.RenevueList.Count; i++)
            {
                if (Program.RenevueList[i].Type == (RenevueType)type)
                {
                    renevueFilterType.Add(Program.RenevueList[i]);
                }
            }

            return renevueFilterType;
        }
    }
}
