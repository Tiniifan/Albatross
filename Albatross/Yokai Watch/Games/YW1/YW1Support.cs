using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Albatross.Yokai_Watch.Games.YW1
{
    public static class YW1Support
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Charabase
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0C)]
            public byte[] EmptyBlock1;
            public uint BaseID;
            public GameSupport.Model Model;
            public uint NameID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14)]
            public byte[] EmptyBlock2;
            public uint Description;
            public int Rank;
            public bool IsRare;
            public bool IsLegendary;
            public GameSupport.Medal Medal;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            public byte[] EmptyBlock3;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Charaparam
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14)]
            public byte[] EmptyBlock1;
            public uint ParamID;
            public uint BaseID;
            public int Tribe;
            public GameSupport.Stat BaseStat;
            public uint Unk1;
            public uint AttackID;
            public uint Unk2;
            public uint TechniqueID;
            public uint Unk3;
            public uint InspiritID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] EmptyBlock3;
            public GameSupport.Attributes AttributesDamage;
            public uint SoultimateID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock4;
            public uint ScoutableID;
            public uint SkillID;
            public int Money;
            public int Experience;
            public GameSupport.Drop Drop1;
            public GameSupport.Drop Drop2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x1C)]
            public byte[] EmptyBlock5;
            public int ExperienceCurve;
            public GameSupport.Quotes Quotes;
            public uint Unk5;
            public int EvolveOffset;
            public int MedaliumOffset;
            public uint Unk6;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Evolution
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock1;
            public int Level;
            public uint EvolveToID;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Fusion
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock1;
            public bool BaseIsYokai;
            public uint BaseID;
            public bool MaterialIsYokai;
            public uint MaterialID;
            public bool EvolveToIsYokai;
            public uint EvolveToID;
            public uint FusionID;
        }

        public static Dictionary<string, string> AvailableLanguages = new Dictionary<string, string>()
        {
            { "English (GB)", "engb"},
            { "Deutsch)", "de"},
            { "Español", "es"},
            { "Français", "fr"},
            { "Italiano", "it"},
        };
    }
}
