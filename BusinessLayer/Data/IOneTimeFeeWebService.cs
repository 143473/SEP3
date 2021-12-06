using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IOneTimeFeeWebService
    {
        Task CreateOneTimeFeeAsync(OneTimeFee oneTimeFee);
        Task<OneTimeFee> GetOneTimeFeeAsync(string username, int eventId);
        Task<IList<OneTimeFee>> GetOneTimeFeeListAsync(string username);
    }
}