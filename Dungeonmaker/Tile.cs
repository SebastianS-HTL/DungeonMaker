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
        private List<string> attributes = new List<string>();

        public Tile(bool[] connections) {
            setConnections(connections);

            this.attributes = attributes;
        }

        public void setConnections(bool[] connections)
        {
            if (connections.Length == 4)
            {
                this.connections = connections;
            }
            else
            {
                throw new ArgumentException("you need 4 booleans as parameters in connections");
            }
        }

        public void addAttribute(string attribute)
        {
            attributes.Add(attribute);
        }

        public bool[] getConnections() { return connections; }
    }
}
