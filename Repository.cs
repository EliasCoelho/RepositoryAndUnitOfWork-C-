using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class Repository : CRepositoryUnitOfWork.Repository, IRepositoryUnitOfWork.IRepository, IDisposable
    {

        public Repository(bool autoDetectChanges = false, bool proxyCreationEnabled = false)
            : base(new SchoolDBEntities(), autoDetectChanges, proxyCreationEnabled)
        {

        }
    }
}
