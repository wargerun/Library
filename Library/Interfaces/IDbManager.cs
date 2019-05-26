namespace Library.Interfaces
{
    public interface IDbManager<in T>
    {
        void AddNewRow(T entity);

        void UpdateRow(T entity);

        void RemoveRow(T entity); 
    }
}