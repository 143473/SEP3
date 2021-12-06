using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IEventWebService
    {
        Task CreateEventAsync(Event newEvent);
        Task<EventList> GetFilteredEventsAsync(Filter filter);
        Task<Event> GetEventAsync(int id);
        Task CancelEventAsync(int id);
        Task EditEventAsync(Event eventToEdit);
    }
}