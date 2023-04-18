using System.Collections.Generic;
using Albatross.Level5.Archive.ARC0;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games
{
    public interface IGame
    {
        string Name { get; }

        Dictionary<uint, string> Attacks { get; }

        Dictionary<uint, string> Techniques { get; }

        Dictionary<uint, string> Inspirits { get; }

        Dictionary<uint, string> Soultimates { get; }

        Dictionary<uint, string> Skills { get; }

        Dictionary<uint, string> Items { get; }

        Dictionary<int, string> Tribes { get; }

        List<Effect> Effects { get; }

        ARC0 Game { get; set; }

        ARC0 Language { get; set; }

        List<Yokai> GetYokais();

        void SaveYokai(Yokai yokai);

        List<Item> GetItems();

        Dictionary<string, List<Yokai>> GetCharaCond(List<Yokai> yokais);

        void SaveCharaCond(Dictionary<string, List<Yokai>> charaConds);

        void Save();

        //(int, UInt32) GetEvolution(int evolutionOffset);
    }
}
