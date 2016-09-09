using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositoryUnitOfWork
{
    /// <summary>
    /// Allow work with entities (Transactionally)
    /// </summary>
    public interface IUnitOfWork : IRepository, IDisposable
    {
        /// <summary>
        /// Allow send the transactions to the database
        /// </summary>
        /// <returns>Number of transactions do it</returns>
        int Save();
    }
}
