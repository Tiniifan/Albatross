using System.Collections.Generic;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games
{
    public interface IGame
    {
        string Name { get; }

        Dictionary<int, string> Tribes { get; }

        Dictionary<int, string> FoodsType { get; }

        Dictionary<int, string> ScoutablesType { get; }

        ARC0 Game { get; set; }

        ARC0 Language { get; set; }

        Dictionary<string, GameFile> Files { get; set; }

        void Save();

        ICharabase[] GetCharacterbase(bool isYokai);

        void SaveCharaBase(ICharabase[] charabases);

        ICharascale[] GetCharascale();

        void SaveCharascale(ICharascale[] charascales);

        ICharaparam[] GetCharaparam();

        void SaveCharaparam(ICharaparam[] charaparams);

        ICharaevolve[] GetCharaevolution();

        void SaveCharaevolution(ICharaevolve[] charaevolves);

        IItem[] GetItems(string itemType);

        ICharaabilityConfig[] GetSkills();

        IBattleCommand[] GetBattleCommands();
    }
}
