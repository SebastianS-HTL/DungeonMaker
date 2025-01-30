using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonmaker
{
    public class Tile
    {
        private bool[] _connections = { false, false, false, false };
        private List<string> attributes = new List<string>();

        public Tile(bool[] connections)
        {
            SetConnections(connections);
        }

        public bool SetConnections(bool[] connections)
        {
            if (connections.Length == 4)
            {
                _connections = connections;
                return true;
            }

            return false;
        }

        public void AddAttribute(string attribute)
        {
            attributes.Add(attribute);
        }

        public bool[] getConnections() {
            if (_connections == null)
            {
                return [ false, false, false, false ];
            }
            return _connections; 
        }

        public List<string> getAttributes() { 
            return attributes;
        }
    }
}
