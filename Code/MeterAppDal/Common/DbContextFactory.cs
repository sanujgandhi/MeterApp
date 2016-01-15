using System;
using System.Data.Entity;

namespace MeterAppDal.Common
{
    public interface IDbContextFactory
    {
        DbContext Context { get; }
    }
    /// <summary>
    /// Class inherited db context factory interface and idisposable interface
    /// </summary>
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        private readonly DbContext _context;

        #region IDBContextFactory members
        public DbContextFactory()
        {
            _context = new MeterContext();
        }

        public DbContext Context
        {
            get { return _context; }
        }
        #endregion
        

        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        /// <remarks>
        /// Calling Dispose allows the resources used by this object to 
        /// be reallocated for other purposes.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        /// <remarks>
        /// Calling Dispose allows the resources used by this object to be reallocated for other purposes.
        /// </remarks>
        /// <param name="disposing"><see langword="true"/>/<see langword="false"/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    //context.Dispose();
                }
            }
        }


        #endregion

    }
}
