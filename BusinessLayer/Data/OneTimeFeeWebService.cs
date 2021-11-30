using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class OneTimeFeeWebService : IOneTimeFeeWebService
    {
        private BookAndPlayPort port;
        private SOAPOneTimeFeeResponse1 response;

        public OneTimeFeeWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPOneTimeFeeResponse1> getOneTimeFeeResponse(Operation name, int eventId,string username, OneTimeFee oneTimeFee )
        {
            SOAPOneTimeFeeRequest soapOneTimeFeeRequest = new SOAPOneTimeFeeRequest();
            soapOneTimeFeeRequest.Operation = name;
            soapOneTimeFeeRequest.username = username;
            soapOneTimeFeeRequest.OneTimeFee = oneTimeFee;
            soapOneTimeFeeRequest.eventId = eventId;
            SOAPOneTimeFeeRequest1 soapRequest1 = new SOAPOneTimeFeeRequest1(soapOneTimeFeeRequest);
            SOAPOneTimeFeeResponse1 soapResponse1 = new SOAPOneTimeFeeResponse1();
            soapResponse1 = port.SOAPOneTimeFeeAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task CreateOneTimeFee(OneTimeFee oneTimeFee)
        {
            response = await getOneTimeFeeResponse(Operation.CREATE,0, "", oneTimeFee);
        }

        public async Task<OneTimeFee> GetOneTimeFee(string username, int eventId)
        {
            response = await getOneTimeFeeResponse(Operation.GET, eventId,username, null);
            return response.SOAPOneTimeFeeResponse.OneTimeFee;
        }

        public async Task<IList<OneTimeFee>> GetOneTimeFeeList(string username)
        {
            response = await getOneTimeFeeResponse(Operation.GETALL, 0,username, null);
            return response.SOAPOneTimeFeeResponse.OneTimeFeeList;
        }
    }
}