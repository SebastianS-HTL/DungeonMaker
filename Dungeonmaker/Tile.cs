using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonmaker
{
    internal class Tile
    {
        private bool[] connections;
        private int[] effects;

        public Tile(bool[] connections, int[] effects = null) {
            if (connections.Length == 4)
            {
                this.connections = connections;
            }
            else 
            {
                throw new ArgumentException("you need 4 booleans as parameters in connections");
            }

            this.effects = effects;
        }

        public bool[] getConnections() { return connections; }
    }
}
