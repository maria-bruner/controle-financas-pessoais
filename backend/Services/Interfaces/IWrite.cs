namespace backend.Services.Interface
{
    public interface IWrite<T> where T : class
    {
        public void Create(T objeto);
        public void Delete(int id);
        public void Update(T objeto, int id);
    }
}
