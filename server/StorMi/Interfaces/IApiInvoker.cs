using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorMi.Interfaces
{
    public interface IApiInvoker
    {
        //public void AddApiRequest(string apiRequest);

        //public void RemodeApiRequest(string apiRequest);

        //public Task<IDictionary<string, dynamic>> InvokerAll();

        public Task<dynamic> Invoke(string apiRequest);
    }
}