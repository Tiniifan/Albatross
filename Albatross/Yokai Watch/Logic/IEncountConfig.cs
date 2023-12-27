using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Yokai_Watch.Logic
{
    public class IEncountTable
    {
        public int EncountConfigHash { get; set; }
        public int[] EncountOffsets { get; set; }
    }

    public class IEncountChara
    {
        public int ParamHash { get; set; }
        public int Level { get; set; }
    }
}
