using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Yokai_Watch.Logic
{
    public class ICharabase
    {
        public int BaseHash { get; set; }
        public int FileNamePrefix { get; set; }
        public int FileNameNumber { get; set; }
        public int FileNameVariant { get; set; }
        public int NameHash { get; set; }
        public int DescriptionHash { get; set; }
        public int Tribe { get; set; }
        public int Rank { get; set; }
        public int Role { get; set; }
        public bool IsRare { get; set; }
        public bool IsLegend { get; set; }
        public int MedalPosX = -1;
        public int MedalPosY = -1;
        public int FavoriteFoodHash { get; set; }
        public int HatedFoodHash { get; set; }
        public bool IsClassic { get; set; }
        public bool IsYokai { get; set; }
    }
}
