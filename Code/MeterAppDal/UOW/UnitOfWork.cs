using System;
using System.Collections.Generic;
using MeterAppDal.GenericRepository;
using MeterAppDal.Interfaces;
using MeterAppEntity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeterAppDal.UOW
{
    public class UnitOfWork
    {
        private bool _disposed;
        private Dictionary<string, object> _repositories;
        private MeterContext _context = new MeterContext();   // entities class object

        //public UnitOfWork(bool disposed)
        //{
        //    _disposed = disposed;
        //}

        //#region Fields
        //public IGenericRepository<Module> Module { get; set; }
        //public IGenericRepository<User> User { get; set; }
        //public IGenericRepository<WorkLogs> WorkLogs { get; set; }
        //public IGenericRepository<GlobalCode> GlobalCode { get; set; }
        //public IGenericRepository<GlobalCodeCategory> GlobalCodeCategory { get; set; }
        //public IGenericRepository<Messages> Messages { get; set; }
        //public IGenericRepository<FileUpload> FileUpload { get; set; }
        //public IGenericRepository<Developer_Module> Developer_Module { get; set; }
        //public IGenericRepository<Developer_Skill> Developer_Skill { get; set; }
        //public IGenericRepository<Project> Project { get; set; }
        //public IGenericRepository<Project_Skill> Project_Skill { get; set; }
        //public IGenericRepository<IdentityUser> UserRepository { get; set; }
        //public IGenericRepository<IdentityUserRole> UserRoleRepository { get; set; }
        //public IGenericRepository<IdentityRole> RoleRepository { get; set; }
        //#endregion


        public GenericRepository<T> GenericRepository<T>() where T : class ,new()
        {

            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)_repositories[type];
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    if (_context != null)
            //    {
            //        _context.Dispose();
            //        _context = null;
            //    }
            //}
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
