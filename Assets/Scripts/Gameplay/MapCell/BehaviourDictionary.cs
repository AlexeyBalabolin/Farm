using System.Collections.Generic;

namespace Gameplay
{
    public class BehaviourDictionary
    {
        private static Dictionary<CellType, ICellStrategy> _strategies = new Dictionary<CellType, ICellStrategy>()
        {
            { CellType.Empty, new CreateStrategy() },
            { CellType.Grass, new UseStrategy() },
            { CellType.Carrot, new UseStrategy()},
            { CellType.Tree, new NothingToDoStrategy()}
        };

        public static Dictionary<CellType, ICellStrategy> Strategies { get => _strategies; }

        public BehaviourDictionary()
        {
            
        }
    }
}

