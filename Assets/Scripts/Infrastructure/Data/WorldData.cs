using System;

namespace Infrastructure.Data
{
    [Serializable]
    public class WorldData
    {
        public string LevelName;
        public Vector3Data Position;

        public WorldData(string levelName,Vector3Data vector)
        {
            LevelName = levelName;
            Position = vector;
        }
        public WorldData()
        {
            
        }
    }
}
