﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class GameWebService : IGameWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPGameResponse1 response;

        public GameWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPGameResponse1> getGameResponseAsync(int id, Operation name, Game game, bool approved)
        {
            SOAPGameRequest soapGameRequest = new SOAPGameRequest();
            soapGameRequest.id = id;
            soapGameRequest.Operation = name;
            soapGameRequest.Game = game;
            soapGameRequest.approved = approved;
            SOAPGameRequest1 soapRequest1 = new SOAPGameRequest1(soapGameRequest);
            SOAPGameResponse1 soapResponse1 = new SOAPGameResponse1();
            soapResponse1 = port.SOAPGameAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<Game> GetGameAsync(int id)
        {
            response = await getGameResponseAsync(id, Operation.GET, null, false);
            Game game = response.SOAPGameResponse.game;

            return  game;
        }

        public async Task  SuggestGameAsync(Game game)
        {
            response = await getGameResponseAsync(0, Operation.CREATE, game, false);
        }

        public async Task<IList<Game>> GetGamesAsync(bool approved)
        {
            response = await getGameResponseAsync(0, Operation.GETALL, null, approved);
            return response.SOAPGameResponse.gameList;
        }

        public async Task RemoveGameAsync(int id)
        {
            response = await getGameResponseAsync(id, Operation.REMOVE, null, false);
        }

        public async Task EditGameAsync(Game game)
        {
            response = await getGameResponseAsync(0, Operation.UPDATE, game, false);
        }
    }
}