using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Rodriguez
{
    
    internal class Desk
    {
        public enum DesktopMaterial
        {
            Oak,
            Laminated,
            Pine,
            Rosewood,
            Veneer
        }
        
        public const int MinWidth = 24;
        public const int MaxWidth = 96;

        public const int MinDepth = 12;
        public const int MaxDepth = 48;
    }
}
