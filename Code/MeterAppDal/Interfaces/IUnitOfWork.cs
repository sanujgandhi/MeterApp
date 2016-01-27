﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;

namespace MeterAppDal.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Module> Module { get; set; } 


    }
}