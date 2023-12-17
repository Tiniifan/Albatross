using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW3.Logic
{
    public class Charabase : ICharabase
    {
        public int BaseHash { get; set; }
        public int FileNamePrefix { get; set; }
        public int FileNameNumber { get; set; }
        public int FileNameVariant { get; set; }
        public int NameHash { get; set; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
        public int Unk5 { get; set; }
        public int DescriptionHash { get; set; }
        public int MedalPosX { get; set; }
        public int MedalPosY { get; set; }
        public int Unk6 { get; set; }
        public int Rank { get; set; }
        public bool IsRare { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsPionner { get; set; }
        public bool IsCommander { get; set; }
        public int FavoriteFoodHash { get; set; }
        public int HatedFoodHash { get; set; }
        public int Unk7 { get; set; }
        public int Unk8 { get; set; }
        public int Tribe { get; set; }
        public bool IsClassic { get; set; }
        public bool IsMerican { get; set; }
        public int BlasterTRole { get; set; }
        public bool IsDeva { get; set; }
        public bool IsMystery { get; set; }
        public bool IsTreasure { get; set; }
    }
}
