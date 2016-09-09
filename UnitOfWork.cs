using IRepositoryUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CRepositoryUnitOfWork
{
    public class UnitOfWork : Repository, IRepository, IUnitOfWork, IDisposable
    {
        //Constructor
        public UnitOfWork(DbContext Context, bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
            :base(Context, autoDetectChangesEnabled, proxyCreationEnabled)
        {
        }

        int IUnitOfWork.Save()
        {
            int Result = 0;
            try
            {
                Result = Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        protected override int TrySaveChanges()
        {
            return 0;
        }

    }
}
