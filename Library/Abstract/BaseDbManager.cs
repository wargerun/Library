using System;
using System.Data.Entity.Validation;
using System.Windows;
using NLog;

namespace Library.Abstract
{
    public abstract class BaseDbManager
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public bool IsOk { get; set; } = false;

        public abstract void AddNewRow();
        public abstract void UpdateRow();
        public abstract void RemoveRow();
              
        protected virtual void Process(Action action)
        {
            try
            {
                _logger.Info("Getting started pre proccess database");
                action();

                IsOk = true;
                _logger.Info("End-to-end pre proccess database: seccess");
            }
            catch (DbEntityValidationException validationError)
            {
                string errorsLine = ValidationHelpers.GetValidationErrors(validationError);
                MessageBox.Show(errorsLine, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }
    }
}