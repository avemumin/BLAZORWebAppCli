using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGNWebAppCli.Services
{
    interface IReportSerivce<T>
    {
        Task<List<T>> GetAllAsync(string requestUri,bool isSpecialMode=false);


        Task<T> GetByIdAsync(string requestUri, int Id);
        Task<T> SaveAsync(string requestUri, T obj);
        Task<T> UpdateAsync(string requestUri, int Id, T obj);
        Task<bool> DeleteAsync(string requestUri, int Id);

    }
}
