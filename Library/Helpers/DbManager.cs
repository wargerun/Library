using System;
using Library.Abstract;
using Library.Interfaces;

namespace Library.Helpers
{
    public sealed class DbManager<T> : BaseDbManager, IDisposable  
    {
        // ReSharper disable once InconsistentNaming
        public T Entity { private get; set; }    
        // ReSharper disable once InconsistentNaming
        private IDbManager<T> Manager { get; set; }

        public DbManager(IDbManager<T> dbManager, T entity)
        {
            this.Manager = dbManager;
            this.Entity = entity;
        }

        public override void AddNewRow() =>
            Process(() =>
                Manager.AddNewRow(Entity));

        public override void UpdateRow() => 
            Process(() =>
                Manager.UpdateRow(Entity));

        public override void RemoveRow() =>
            Process(() =>
                Manager.RemoveRow(Entity));

        public void Dispose()
        {
            Manager = null;
            Entity = default(T);
        }
    }
}