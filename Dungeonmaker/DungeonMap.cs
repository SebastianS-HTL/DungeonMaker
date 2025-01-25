using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonmaker
{
    internal class DungeonMap
    {
        private Tile[,]? connector;

        public Tile[,]? getTiles()
        {
            if (connector != null)
            {
                return connector;
            }

            return null;
        }

        public void createDungeonMap(MapSettings settings)
        {
            int width = settings.width;
            int height = settings.height;
            connector = new Tile[width, height];
            Tuple<int,int> startPosition = settings.startPosition;
        }
    }
}

