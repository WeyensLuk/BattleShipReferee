using System.Collections.Generic;

namespace BattleShipReferee.API.Domain
{
    public class GameInstance
    {
        private static GameInstance _Instance;
        public static GameInstance Instance => _Instance ?? (_Instance = new GameInstance());

        private readonly Dictionary<string, GameState> _Games = new Dictionary<string, GameState>();

        public bool IsGameReady(string gameId)
        {
            return _Games[gameId].IsGameReady();
        }

        public GameState GetGame(string gameId)
        {
            return _Games[gameId];
        }

        public void Register(RegisterRequest request)
        {
            if (_Games.ContainsKey(request.GameId))
            {
                _Games[request.GameId].PlayerTwo = new Player(request.BattleShipGrid)
                {
                    Id = request.PlayerId,
                    Url = request.Url
                };
                return;
            }

            _Games.Add(request.GameId, new GameState
            {
                PlayerOne = new Player(request.BattleShipGrid)
                {
                    Id = request.PlayerId,
                    Url = request.Url
                }
            });
        }
    }
}