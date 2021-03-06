package dk.bookAndPlay.DAO.events;

import dk.bookandplay.web_service.Event;
import dk.bookandplay.web_service.EventList;
import dk.bookandplay.web_service.Filter;

public interface Events {
    EventList getFilteredEvents(Filter filter);
    void create(Event event);
    Event get(int id);
    void cancel(int id);
    void edit(Event event);
    EventList getOrganizersEvents(String username);
    EventList getCoOrganizersEvents(String username);
    EventList getParticipantsEvents(String username);
}
