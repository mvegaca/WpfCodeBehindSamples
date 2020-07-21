using System.Collections.Generic;
using System.Threading.Tasks;

using CodeBehindApp.Core.Models;

namespace CodeBehindApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
