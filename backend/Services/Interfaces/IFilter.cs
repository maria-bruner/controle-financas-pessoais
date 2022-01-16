using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Services.Interfaces
{
    public interface IFilter<T> where T : class
    {
        public List<T> FilterPeriod(DateTime dataInicial, DateTime dataFinal);

        public List<T> FilterType(int type);
    }
}
