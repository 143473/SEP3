package com.example.producingwebservice.EventGameList;

import io.spring.guides.gs_producing_web_service.GameList;

public interface EventGameLists
{
  GameList readAllEventGameList(int eventId);
  void removeGameFromEventGameList(int gameId, int eventId, String username);
  void addGameToEventGameList(int gameId, int eventId, String username);
}
