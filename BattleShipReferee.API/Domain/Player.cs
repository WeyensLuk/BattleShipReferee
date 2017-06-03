namespace BattleShipReferee.API.Domain
{
    public class Player
    {
        public Player(bool[,] battleShipGrid)
        {
            BattleShipGrid = new FieldState[10,10];
            InitializeBattleShipGrid(battleShipGrid);
        }

        public Player()
        {
            
        }

        private void InitializeBattleShipGrid(bool[,] requestBattleShipGrid)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (requestBattleShipGrid[i, j])
                        BattleShipGrid[i, j] = FieldState.Boat;
                }
            }
        }

        public string Id { get; set; }
        public FieldState[,] BattleShipGrid { get; set; }
        public bool IsMyTurn { get; set; }
        public string Url { get; set; }
    }

    public enum FieldState
    {
        Shot = 2,
        Empty = 0,
        Boat = 1
    }
}