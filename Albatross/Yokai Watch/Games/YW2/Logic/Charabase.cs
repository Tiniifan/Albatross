using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW2.Logic
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
        public bool MedalPosY { get; set; }
        public bool Unk6 { get; set; }
        public int Rank { get; set; }
        public int IsRare { get; set; }
        public int IsLegendary { get; set; }
        public int FavoriteFoodHash { get; set; }
        public int HatedFoodHash { get; set; }
        public int Unk7 { get; set; }
        public int Unk8 { get; set; }
        public int Unk9 { get; set; }
        public int Unk10 { get; set; }
        public int Unk11 { get; set; }
        public int Tribe { get; set; }
        public int IsClassic { get; set; }
        public int Unk12 { get; set; }
    }
}
