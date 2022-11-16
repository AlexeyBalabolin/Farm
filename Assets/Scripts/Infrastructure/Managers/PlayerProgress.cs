using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData PositionOnLevel;

        public PlayerProgress()
        {
            PositionOnLevel = new WorldData();
        }
    }
}
