using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGNWebAppCli.Services
{
    interface IReportSerivce<T>
    {
        Task<List<T>> GetAllAsync(string requestUri);
    }
}
