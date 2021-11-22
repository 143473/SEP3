package com.example.producingwebservice.events;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import com.example.producingwebservice.games.GameDAO;
import io.spring.guides.gs_producing_web_service.*;

import javax.annotation.Resource;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.time.Instant;
import java.util.Date;
import java.util.GregorianCalendar;

public class EventDAO implements Events {
    private DatabaseHelper<Event> helper;
    private final EventList eventList;
    private GameDAO gameDAO;

    @Resource(name = "jdbcUrl")
    private String jdbcUrl;

    @Resource(name = "username")
    private String username;

    @Resource(name = "password")
    private String password;

    public EventDAO() {
        eventList = new EventList();
    }
    private DatabaseHelper<Event> helper(){
        if(helper == null)
            helper = new DatabaseHelper<>(jdbcUrl, username, password);
        return helper;
    }

    private static Event createEvent(int id, String name, Date startTimeStamp, Date endTimeStamp,String addressStreetName,
                                     String addressStreetNumber, String addressApartmentNumber, int maxNumberOfParticipants,
                                     int numberOfParticipants, int eventCategory, String organizer, UserList participants,
                                     UserList organizers, EventGameList gameList)


    {
        Event event = new Event();

        //Date to XMLGregorianCalendar conversion
        GregorianCalendar c = new GregorianCalendar();

        try{
          c.setTime(startTimeStamp);
          XMLGregorianCalendar start = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
          event.setStartTime(start);

          if(endTimeStamp != null)
          {
            c.clear();
            c.setTime(endTimeStamp);
            XMLGregorianCalendar end = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
            event.setEndTime(end); // set the event end time
          }
        }
        catch (DatatypeConfigurationException e){}

        event.setId(id);
        event.setName(name);
        event.setAddressStreetName(addressStreetName);
        event.setAddressStreetNumber(addressStreetNumber);
        event.setAddressApartmentNumber(addressApartmentNumber);
        event.setMaxNumberOfParticipants(maxNumberOfParticipants);
        event.setNumberOfParticipants(numberOfParticipants);
        event.setEventCategory(eventCategory);
        event.setOrganizer(organizer);
        event.setParticipants(participants);
        event.setOrganizers(organizers);
        event.setGameList(gameList);
        return event;
    }

    public Event create(Event event){
        Timestamp startTime = new Timestamp(event.getStartTime().toGregorianCalendar().getTimeInMillis());
        Timestamp endTime = new Timestamp(event.getEndTime().toGregorianCalendar().getTimeInMillis());

        helper().executeUpdate(
                "INSERT INTO event(name, start_time, end_time, address_street_name, address_street_number, address_apartment_number, max_number_of_participants, event_category_id, organizer) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
                event.getName(), startTime, endTime, event.getAddressStreetName(), event.getAddressStreetNumber(),
                event.getAddressApartmentNumber(), event.getMaxNumberOfParticipants(), event.getEventCategory(),
                event.getOrganizer());
        return event;
    }

    public EventList searchAndFilter(String filter, int category, int currentPage, int resultsPerPage){
        eventList.getEventList().clear();
        EventList pagedEventList = new EventList();
        String statement = "SELECT * FROM event";

        if(!filter.equals("all")){
          statement += " WHERE ";
          if(filter.contains("byDate"))
          {
            statement +="start_time > now() AND";
          }
          if(filter.contains("byCategory"))
          {
            statement +=" event_category_id = " + category+ " AND";
          }
          if(filter.contains("byAvailability"))
          {
            statement +=" number_of_participants < max_number_of_participants AND";
          }
          if(statement.endsWith("AND"))
          {
            statement = statement.substring(0, statement.length() - 4);
            statement +=" ORDER BY id;";
          }
        }
        else
          statement +=" ORDER BY id;";
      System.out.println(statement);

        eventList.getEventList().addAll(helper().map(new EventMapper(), statement));

        //cut out the ; in the end
        statement = statement.substring(0, statement.length()-1);

        statement += " LIMIT "+resultsPerPage+" OFFSET "+(currentPage-1)*resultsPerPage+";";
        pagedEventList.getEventList().addAll(helper().map(new EventMapper(), statement));

        return pagedEventList;
    }

    public int getNumberOfPages(int resultsPerPage){
        return (int) Math.ceil(eventList.getEventList().size() / (float)resultsPerPage);
    }


    private static class EventMapper implements DataMapper<Event> {
        public Event create(ResultSet rs)
            throws SQLException
        {
             int id = rs.getInt("id");
             String name = rs.getString("name");
             Date startTime = rs.getTimestamp("start_time");
             Date endTime = rs.getTimestamp("end_time");
             String addressStreetName = rs.getString("address_street_name");
             String addressStreetNumber = rs.getString("address_street_number");
             String addressApartmentNumber = rs.getString("address_apartment_number");
             int maxNumberOfParticipants = rs.getInt("max_number_of_participants");
             int numberOfParticipants = rs.getInt("number_of_participants");
             int eventCategory = rs.getInt("event_category_id");
             String organizer =  rs.getString("organizer");
             //User organizer;
             UserList participants;
             UserList organizers;
             EventGameList gameList;

            return createEvent(id, name, startTime,endTime,addressStreetName,
               addressStreetNumber, addressApartmentNumber,maxNumberOfParticipants,
          numberOfParticipants,eventCategory, organizer,null,
               null, null);
        }
    }
}
