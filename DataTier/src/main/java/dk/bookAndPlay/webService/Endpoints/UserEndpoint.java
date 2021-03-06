package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.users.Users;
import dk.bookandplay.web_service.SOAPUserRequest;
import dk.bookandplay.web_service.SOAPUserResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class UserEndpoint {
    private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

    private final Users usersDAO;

    @Autowired
    public UserEndpoint(Users dao) {
        this.usersDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPUserRequest")
    @ResponsePayload
    public SOAPUserResponse userResponse(@RequestPayload SOAPUserRequest request) {
        SOAPUserResponse response = new SOAPUserResponse();
        switch (request.getOperation()) {
            case GET:
                response.setUser(usersDAO.get(request.getUsername()));
                break;
            case CREATE:
                usersDAO.create(request.getUser());
                break;
            case UPDATE:
                usersDAO.update(request.getUser());
                break;
            case GETALL:
                response.setUserList(usersDAO.getUserList(request.getFilter()));
                break;
            case REMOVE:
                usersDAO.delete(request.getUsername());
        }
        return response;
    }
}
