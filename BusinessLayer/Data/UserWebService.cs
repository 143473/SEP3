﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class UserWebService : IUserWebService

    {
        private readonly BookAndPlayPort port;
        private SOAPUserResponse1 response;

        public UserWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPUserResponse1> getUserResponseAsync(string username, Operation name, User thisUser)
        {
            SOAPUserRequest soapUserRequest = new SOAPUserRequest();
            soapUserRequest.username = username;
            soapUserRequest.Operation = name;
            soapUserRequest.User = thisUser;
            SOAPUserRequest1 soapRequest1 = new SOAPUserRequest1(soapUserRequest);
            SOAPUserResponse1 soapResponse1 = new SOAPUserResponse1();
            soapResponse1 = port.SOAPUserAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<User> GetUserAsync(string username)
        {
            response = await getUserResponseAsync(username, Operation.GET, null);
            User User = response.SOAPUserResponse.user;
            return  User;
        }

        public async Task CreateAccountAsync(User user)
        {
            response = await getUserResponseAsync("", Operation.CREATE, user);
            
        }

        public async Task DeleteAccountAsync(string username)
        {
            response = await getUserResponseAsync(username, Operation.REMOVE,null);
        }

        public async Task UpdateUser(User user)
        {
            await getUserResponseAsync("", Operation.UPDATE, user);
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            response = await getUserResponseAsync("", Operation.GETALL, null);
            return response.SOAPUserResponse.userList;
        }
    }
}