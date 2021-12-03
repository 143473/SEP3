﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Data
{
    public interface IUserService
    {
        Task<string> helloWorld();
        Task<User> ValidateUser(string userName, string password);
        Task<string> CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizer();
        Task AcceptPromotion(User user);
        Task DeclinePromotion(User user);
        Task DeleteAccountAsync(string username);
        Task<UserList> GetUsersAsync();
    }
}