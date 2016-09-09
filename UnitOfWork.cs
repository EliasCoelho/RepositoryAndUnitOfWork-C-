﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UnitOfWork : CRepositoryUnitOfWork.Repository, IRepositoryUnitOfWork.IRepository, IDisposable
    {
        public UnitOfWork(bool autoDetectChanges = false, bool proxyCreationEnabled = false)
            : base(new SchoolDBEntities(), autoDetectChanges, proxyCreationEnabled)
        {

        }
    }
}