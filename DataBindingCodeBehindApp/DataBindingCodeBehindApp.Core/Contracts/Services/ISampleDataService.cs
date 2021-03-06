﻿using System.Collections.Generic;
using System.Threading.Tasks;

using DataBindingCodeBehindApp.Core.Models;

namespace DataBindingCodeBehindApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
