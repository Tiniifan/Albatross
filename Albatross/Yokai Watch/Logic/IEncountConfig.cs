﻿namespace Albatross.Yokai_Watch.Logic
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
