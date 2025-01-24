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

        public void createDungeonMap(int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}

