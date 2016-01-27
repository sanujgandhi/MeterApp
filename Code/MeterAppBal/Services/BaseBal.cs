using System;
using MeterAppDal;
using MeterAppDal.UOW;

namespace MeterAppBal.Services
{
    public class BaseBal : IDisposable
    {
        #region Fields
        
        private bool _disposed;
       
        public readonly UnitOfWork UnitOfWork = new UnitOfWork();
        #endregion

        #region Constructors

       
        #endregion

        #region Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion

    }
}
