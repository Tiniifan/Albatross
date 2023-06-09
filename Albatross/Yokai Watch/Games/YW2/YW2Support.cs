﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW2
{
    public static class YW2Support
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
            public GameSupport.Medal Medal;
            public uint Unk1;
            public int Rank;
            public bool IsRare;
            public bool IsLegendary;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x1C)]
            public byte[] EmptyBlock3;
            public int Tribe;
            public bool IsClassic;
            public uint Unk2;

            public void ReplaceWith(Yokai yokai)
            {
                Model.ModelFromText(yokai.ModelName);
                Rank = yokai.Rank;
                IsRare = yokai.Statut.IsRare;
                IsLegendary = yokai.Statut.IsLegendary;
                Tribe = yokai.Tribe;
                IsClassic = yokai.Statut.IsClassic;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Charaparam
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14)]
            public byte[] EmptyBlock1;
            public uint ParamID;
            public uint BaseID;
            public GameSupport.Stat MinStat;
            public GameSupport.Stat MaxStat;
            public int FavoriteDonut;
            public uint AttackID;
            public uint Unk2;
            public uint TechniqueID;
            public uint Unk3;
            public uint InspiritID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] EmptyBlock2;
            public GameSupport.Attributes AttributesDamage;
            public uint SoultimateID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock3;
            public int ScoutableID;
            public uint SkillID;
            public int Money;
            public int Experience;
            public uint Unk4;
            public GameSupport.Drop Drop1;
            public GameSupport.Drop Drop2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock4;
            public int ExperienceCurve;
            public GameSupport.Quotes Quotes;
            public uint Unk5;
            public int EvolveOffset;
            public int MedaliumOffset;
            public uint Unk6;
            public uint Unk7;
            public uint Unk8;

            public void ReplaceWith(Yokai yokai)
            {
                MinStat = new GameSupport.Stat { HP = yokai.MinStat[0], Strength = yokai.MinStat[1], Spirit = yokai.MinStat[2], Defense = yokai.MinStat[3], Speed = yokai.MinStat[4] };
                MaxStat = new GameSupport.Stat { HP = yokai.MaxStat[0], Strength = yokai.MaxStat[1], Spirit = yokai.MaxStat[2], Defense = yokai.MaxStat[3], Speed = yokai.MaxStat[4] };
                AttackID = yokai.AttackID;
                TechniqueID = yokai.TechniqueID;
                InspiritID = yokai.InspiritID;
                AttributesDamage = new GameSupport.Attributes { Fire = yokai.AttributeDamage[0], Ice = yokai.AttributeDamage[1], Earth = yokai.AttributeDamage[2], Ligthning = yokai.AttributeDamage[3], Water = yokai.AttributeDamage[4], Wind = yokai.AttributeDamage[4] };
                SoultimateID = yokai.SoultimateID;
                SkillID = yokai.SkillID;
                Money = yokai.Money;
                Experience = yokai.Experience;
                Drop1 = new GameSupport.Drop { ID = yokai.DropID[0], Rate = yokai.DropRate[0] };
                Drop2 = new GameSupport.Drop { ID = yokai.DropID[1], Rate = yokai.DropRate[1] };
                ExperienceCurve = yokai.ExperienceCurve;
                EvolveOffset = yokai.EvolveOffset;
                MedaliumOffset = yokai.MedaliumOffset;
            }
        }

        public static Dictionary<string, string> AvailableLanguages = new Dictionary<string, string>()
        {
            { "English (GB)", "engb"},
            { "English (US)", "en"},
            { "Deutsch", "de"},
            { "Español", "es"},
            { "Français", "fr"},
            { "Italiano", "it"},
            { "Nederlands", "nl"},
            { "русский язык", "ru"},
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Equipment
        {
            public GameSupport.Item Item;
            public uint Effect1ID;
            public uint Effect2ID;
            public GameSupport.EquipmentStat EquipmentStat;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
            public byte[] EmptyBlock3;
            public int CharaConditionID;
            public uint Unk1;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Soul
        {
            public GameSupport.Item Item;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x18)]
            public byte[] EmptyBlock1;
            public uint SoulEffectID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0C)]
            public byte[] EmptyBlock2;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Consumable
        {
            public GameSupport.Item Item;
            public uint Effect1ID;
            public uint Effect2ID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x18)]
            public byte[] EmptyBlock1;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct KeyItem
        {
            public GameSupport.Item Item;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x0C)]
            public byte[] EmptyBlock1;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CreatureItem
        {
            public GameSupport.Item Item;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] EmptyBlock1;
        }
    }
}
