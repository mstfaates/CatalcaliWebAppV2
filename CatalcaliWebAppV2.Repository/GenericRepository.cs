
using System.Collections.Generic;


namespace CatalcaliWebAppV2.Repository
{
    public abstract class GenericRepository<T, I>
    {
        public abstract Result<int> Create(T item);
        public abstract Result<int> Delete(I item);
        public abstract Result<int> Update(T item);
        public abstract Result<List<T>> GetAll();
        public abstract Result<T> GetById(I id);
        public abstract Result<List<T>> GetLatest(int quantity);
    }
}
