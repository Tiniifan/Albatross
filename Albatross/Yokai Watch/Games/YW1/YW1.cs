﻿using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
using Albatross.Level5.Binary;
using Albatross.Level5.Binary.Logic;
using Albatross.Yokai_Watch.Games;
using Albatross.Yokai_Watch.Games.YW1.Logic;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW1
{
    public class YW1 : IGame
    {
        public string Name => "Yo-Kai Watch 1";

        public Dictionary<int, string> Tribes => Common.Tribes.YW1;

        public Dictionary<int, string> FoodsType => Common.FoodsType.YW1;

        public Dictionary<int, string> ScoutablesType => Common.ScoutablesType.YW1;

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;
        public Dictionary<string, GameFile> Files { get; set; }

        public YW1(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw1_a.fa", FileMode.Open));

            Files = new Dictionary<string, GameFile>
            {
                { "chara_text", new GameFile(Game, "/data/res/text/chara_text_" + LanguageCode + ".cfg.bin") },
                { "item_text", new GameFile(Game, "/data/res/text/item_text_" + LanguageCode + ".cfg.bin") },
                { "battle_text", new GameFile(Game, "/data/res/text/battle_text_" + LanguageCode + ".cfg.bin") },
                { "skill_text", new GameFile(Game, "/data/res/text/skill_text_" + LanguageCode + ".cfg.bin") },
                { "chara_ability_text", new GameFile(Game, "/data/res/text/chara_ability_text_" + LanguageCode + ".cfg.bin") },
                { "addmembermenu_text", new GameFile(Game, "/data/res/text/menu/addmembermenu_text_" + LanguageCode + ".cfg.bin") },
                { "face_icon", new GameFile(Game, "/data/menu/face_icon") },
                { "item_icon", new GameFile(Game, "/data/menu/item_icon") },
                { "model", new GameFile(Game, "/data/character") },
            };
        }

        public void Save()
        {
            // Save
            Game.Save(RomfsPath + @"\yw1_a.fa.temp");

            // Close File
            Game.Close();

            if (File.Exists(RomfsPath + @"\yw1_a.fa"))
            {
                File.Delete(RomfsPath + @"\yw1_a.fa");
            }

            File.Move(RomfsPath + @"\yw1_a.fa.temp", RomfsPath + @"\yw1_a.fa");

            // Re Open
            Game = new ARC0(new FileStream(RomfsPath + @"\yw1_a.fa", FileMode.Open));
        }

        public ICharabase[] GetCharacterbase(bool isYokai)
        {
            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_base_0.04j.cfg.bin"));

            if (isYokai)
            {
                return charaBaseFile.Entries
                    .Where(x => x.GetName() == "CHARA_BASE_YOKAI_INFO_BEGIN")
                    .SelectMany(x => x.Children)
                    .Select(x => x.ToClass<YokaiCharabase>())
                    .ToArray();

            } else
            {
                return charaBaseFile.Entries
                    .Where(x => x.GetName() == "CHARA_BASE_INFO_BEGIN")
                    .SelectMany(x => x.Children)
                    .Select(x => x.ToClass<NPCCharabase>())
                    .ToArray();
            }
        }

        public void SaveCharaBase(ICharabase[] charabases)
        {
            NPCCharabase[] npcCharabases = charabases.OfType<NPCCharabase>().ToArray();
            YokaiCharabase[] yokaiCharabases = charabases.OfType<YokaiCharabase>().ToArray();

            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_base_0.04j.cfg.bin"));

            charaBaseFile.ReplaceEntry("CHARA_BASE_INFO_BEGIN", "CHARA_BASE_INFO_", npcCharabases);
            charaBaseFile.ReplaceEntry("CHARA_BASE_YOKAI_INFO_BEGIN", "CHARA_BASE_YOKAI_INFO_", yokaiCharabases);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files["chara_base_0.04j.cfg.bin"].ByteContent = charaBaseFile.Save();
        }

        public ICharascale[] GetCharascale()
        {
            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_scale.cfg.bin"));

            return charaparamFile.Entries
                .Where(x => x.GetName() == "CHARA_SCALE_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<Charascale>())
                .ToArray();
        }

        public void SaveCharascale(ICharascale[] charascales)
        {
            Charascale[] formatCharascales = charascales.OfType<Charascale>().ToArray();

            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_scale.cfg.bin"));

            charaparamFile.ReplaceEntry("CHARA_SCALE_INFO_BEGIN", "CHARA_SCALE_INFO_", formatCharascales);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files["chara_scale.cfg.bin"].ByteContent = charaparamFile.Save();
        }

        public ICharaparam[] GetCharaparam()
        {
            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.02.cfg.bin"));

            return charaparamFile.Entries
                .Where(x => x.GetName() == "CHARA_PARAM_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<Charaparam>())
                .ToArray();
        }

        public void SaveCharaparam(ICharaparam[] charaparams)
        {
            Charaparam[] formatCharaparams = charaparams.OfType<Charaparam>().ToArray();

            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.02.cfg.bin"));

            charaparamFile.ReplaceEntry("CHARA_PARAM_INFO_BEGIN", "CHARA_PARAM_INFO_", formatCharaparams);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files["chara_param_0.02.cfg.bin"].ByteContent = charaparamFile.Save();
        }

        public ICharaevolve[] GetCharaevolution()
        {
            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.02.cfg.bin"));

            return charaparamFile.Entries
                .Where(x => x.GetName() == "CHARA_EVOLVE_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<Charaevolve>())
                .ToArray();
        }

        public void SaveCharaevolution(ICharaevolve[] charaevolutions)
        {
            Charaevolve[] formatCharaevolutions = charaevolutions.OfType<Charaevolve>().ToArray();

            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.02.cfg.bin"));

            charaparamFile.ReplaceEntry("CHARA_EVOLVE_INFO_BEGIN", "CHARA_EVOLVE_INFO_", formatCharaevolutions);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files["chara_param_0.02.cfg.bin"].ByteContent = charaparamFile.Save();
        }

        public IItem[] GetItems(string itemType)
        {
            CfgBin itemconfigFile = new CfgBin();
            itemconfigFile.Open(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin"));

            switch (itemType)
            {
                case "equipment":
                    return itemconfigFile.Entries
                        .Where(x => x.GetName() == "ITEM_EQUIPMENT_BEGIN")
                        .SelectMany(x => x.Children)
                        .Select(x => x.ToClass<Consumable>())
                        .ToArray();
                case "consumable":
                    return itemconfigFile.Entries
                        .Where(x => x.GetName() == "ITEM_CONSUME_BEGIN")
                        .SelectMany(x => x.Children)
                        .Select(x => x.ToClass<Consumable>())
                        .ToArray();
                case "important":
                    return itemconfigFile.Entries
                        .Where(x => x.GetName() == "ITEM_IMPORTANT_BEGIN")
                        .SelectMany(x => x.Children)
                        .Select(x => x.ToClass<Consumable>())
                        .ToArray();
                case "creature":
                    return itemconfigFile.Entries
                        .Where(x => x.GetName() == "ITEM_CREATURE_BEGIN")
                        .SelectMany(x => x.Children)
                        .Select(x => x.ToClass<Consumable>())
                        .ToArray();
                case "all":
                    string[] itemTypes = { "ITEM_EQUIPMENT_BEGIN", "ITEM_CONSUME_BEGIN", "ITEM_IMPORTANT_BEGIN", "ITEM_CREATURE_BEGIN" };
                    return itemconfigFile.Entries
                        .Where(x => itemTypes.Contains(x.GetName()))
                        .SelectMany(x => x.Children)
                        .Select(x => x.ToClass<Item>())
                        .ToArray();
                default:
                    return new IItem[] { };
            }
        }

        public ICharaabilityConfig[] GetSkills()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastskillFile = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_ability")).OrderByDescending(x => x).First();

            CfgBin charaabilityConfig = new CfgBin();
            charaabilityConfig.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastskillFile));

            return charaabilityConfig.Entries
                .Where(x => x.GetName() == "CHARA_ABILITY_CONFIG_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<CharaabilityConfig>())
                .ToArray();
        }

        public IBattleCommand[] GetBattleCommands()
        {
            VirtualDirectory battleFolder = Game.Directory.GetFolderFromFullPath("data/res/battle");
            string lastBattleCommand = battleFolder.Files.Keys.Where(x => x.StartsWith("battle_command") && !x.Contains("config")).OrderByDescending(x => x).First();

            CfgBin battlecommandConfig = new CfgBin();
            battlecommandConfig.Open(Game.Directory.GetFileFromFullPath("/data/res/battle/" + lastBattleCommand));

            return battlecommandConfig.Entries
                .Where(x => x.GetName() == "BATTLE_COMMAND_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<BattleCommand>())
                .ToArray();
        }
    }
}
