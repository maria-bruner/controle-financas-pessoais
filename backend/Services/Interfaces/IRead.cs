using System.Collections.Generic;

namespace backend.Services.Interfaces
{
    public interface IRead<T> where T : class
    {
        public List<T> List();
    }
}
