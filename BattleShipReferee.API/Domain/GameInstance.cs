using System.Collections.Generic;

namespace BattleShipReferee.API.Domain
{
    public class GameInstance
    {
        private static GameInstance _Instance;
        private readonly Dictionary<string, GameState> _Games = new Dictionary<string, GameState>();
        public static GameInstance Instance => _Instance ?? (_Instance = new GameInstance());

        public GameState GetGame(string gameId)
        {
            return _Games[gameId];
        }

        public bool IsGameReady(string gameId)
        {
            return _Games[gameId].IsGameReady();
        }

        public void Register(RegisterRequest request)
        {
            if (_Games.ContainsKey(request.GameId))
            {
                _Games[request.GameId].PlayerTwo = new Player
                {
                    Id = request.PlayerId,
                    Url = request.Url,
                    BoardState = new BoardState(request.BattleShips)
                };
                return;
            }

            _Games.Add(request.GameId, new GameState
            {
                PlayerOne = new Player
                {
                    Id = request.PlayerId,
                    Url = request.Url,
                    BoardState = new BoardState(request.BattleShips)
                }
            });
        }
    }
}