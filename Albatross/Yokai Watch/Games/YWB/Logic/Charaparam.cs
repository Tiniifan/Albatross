﻿using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YWB.Logic
{
    public class Charaparam : ICharaparam
    {
        public new int ParamHash { get => base.ParamHash; set => base.ParamHash = value; }
        public new int BaseHash { get => base.BaseHash; set => base.BaseHash = value; }
        public new bool ShowInMedalium { get => base.ShowInMedalium; set => base.ShowInMedalium = value; }
        public new int MedaliumOffset { get => base.MedaliumOffset; set => base.MedaliumOffset = value; }
        public new int MinHP { get => base.MinHP; set => base.MinHP = value; }
        public new int MinStrength { get => base.MinStrength; set => base.MinStrength = value; }
        public new int MinSpirit { get => base.MinSpirit; set => base.MinSpirit = value; }
        public new int MinDefense { get => base.MinDefense; set => base.MinDefense = value; }
        public new int MaxHP { get => base.MaxHP; set => base.MaxHP = value; }
        public new int MaxStrength { get => base.MaxStrength; set => base.MaxStrength = value; }
        public new int MaxSpirit { get => base.MaxSpirit; set => base.MaxSpirit = value; }
        public new int MaxDefense { get => base.MaxDefense; set => base.MaxDefense = value; }
        public new int Speed { get => base.Speed; set => base.Speed = value; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public new int Strongest { get => base.Strongest; set => base.Strongest = value; }
        public new int Weakness { get => base.Weakness; set => base.Weakness = value; }
        public new int BlasterSkill { get => base.SkillHash; set => base.SkillHash = value; }
        public new int BlasterAttack { get => base.AttackHash; set => base.AttackHash = value; }
        public new int BlasterSoultimate { get => base.AttackHash; set => base.AttackHash = value; }
        public new int BlasterMoveSlot1 { get => base.AttackHash; set => base.AttackHash = value; }
        public int BlasterEarnLevelMoveSlot1 { get; set; }
        public new int BlasterMoveSlot2 { get => base.AttackHash; set => base.AttackHash = value; }
        public int BlasterEarnLevelMoveSlot2 { get; set; }
        public new int BlasterMoveSlot3 { get => base.AttackHash; set => base.AttackHash = value; }
        public int BlasterEarnLevelMoveSlot3 { get; set; }
        public new int BlasterMoveSlot4 { get => base.AttackHash; set => base.AttackHash = value; }
        public int BlasterEarnLevelMoveSlot4 { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
        public int Unk5 { get; set; }
        public int Unk6 { get; set; }
        public int Unk7 { get; set; }
        public int Unk8 { get; set; }
        public int Unk9 { get; set; }
        public int Unk10 { get; set; }
        public int Unk11 { get; set; }
        public int Unk12 { get; set; }
        public int Unk13 { get; set; }
        public int Unk14 { get; set; }
        public int Unk15 { get; set; }
        public int Unk16 { get; set; }
        public int Unk17 { get; set; }
        public int Unk18 { get; set; }
        public int Unk19 { get; set; }
        public int Unk20 { get; set; }
        public int Unk21 { get; set; }
        public int Unk22 { get; set; }
        public int Unk23 { get; set; }
        public new int Drop1Hash { get => base.Drop1Hash; set => base.Drop1Hash = value; }
        public new int Drop2Hash { get => base.Drop2Hash; set => base.Drop2Hash = value; }
        public new int Drop1Rate { get => base.Drop1Rate; set => base.Drop1Rate = value; }
        public new int Drop2Rate { get => base.Drop2Rate; set => base.Drop2Rate = value; }
        public int Unk24 { get; set; }
        public int DropOniOrbRate { get; set; }
        public int DropOniOrb { get; set; }
        public int Unk25 { get; set; }
        public bool CanFuse { get; set; }
        public new int EvolveOffset { get => base.EvolveOffset; set => base.EvolveOffset = value; }
    }
}
