﻿using System.Collections.Generic;
using Albatross.Level5.Text;
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

        Dictionary<int, string> FoodsType { get; }

        ARC0 Game { get; set; }

        ARC0 Language { get; set; }

        Dictionary<string, GameFile> Files { get; set; }

        void Save();

        ICharabase[] GetCharacterbase(bool isYokai);

        void SaveCharaBase(ICharabase[] charabases);

        ICharaparam[] GetCharaparam();

        void SaveCharaparam(ICharaparam[] charaparams);

        object[] GetCharaevolution();

        IItem[] GetItems(string itemType);

        ICharaabilityConfig[] GetSkills();

        IBattleCommand[] GetBattleCommands();
    }
}
