﻿using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW1.Logic
{
    public class EncountTable : IEncountTable
    {
        public new int EncountConfigHash { get => base.EncountConfigHash; set => base.EncountConfigHash = value; }
        public new int[] EncountOffsets { get => base.EncountOffsets; set => base.EncountOffsets = value; }
        public int[] UnkBlock = new int[10];
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
        public int Unk5 { get; set; }

        public EncountTable()
        {
            EncountOffsets = new int[4];
        }
    }

    public class EncountChara : IEncountChara
    {
        public new int ParamHash { get => base.ParamHash; set => base.ParamHash = value; }
        public new int Level { get => base.Level; set => base.Level = value; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
        public int Unk5 { get; set; }
    }
}
