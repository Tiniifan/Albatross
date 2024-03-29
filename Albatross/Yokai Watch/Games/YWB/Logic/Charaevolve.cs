﻿using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YWB.Logic
{
    public class Charaevolve : ICharaevolve
    {
        public new int ParamHash { get => base.ParamHash; set => base.ParamHash = value; }
        public new int Level { get => base.Level; set => base.Level = value; }
        public new int Cost { get => base.Cost; set => base.Cost = value; }
    }
}
