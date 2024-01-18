using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Binary;
using Albatross.Yokai_Watch.Logic;
using Albatross.Level5.Archive.ARC0;
using Albatross.Yokai_Watch.Games.YWB.Logic;

namespace Albatross.Yokai_Watch.Games.YWB
{
    public class YWB : IGame
    {
        public string Name => "Yo-Kai Watch Blaster";

        public Dictionary<int, string> Tribes => Common.Tribes.YWB;

        public Dictionary<int, string> FoodsType => new Dictionary<int, string>();

        public Dictionary<int, string> ScoutablesType => Common.ScoutablesType.YW3;

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;

        public Dictionary<string, GameFile> Files { get; set; }

        public YWB(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\ywb_lg_" + LanguageCode + ".fa", FileMode.Open));

            Files = new Dictionary<string, GameFile>
            {
                { "chara_text", new GameFile(Language, "/data/res/text/chara_text_" + LanguageCode + ".cfg.bin") },
                { "item_text", new GameFile(Language, "/data/res/text/item_text_" + LanguageCode + ".cfg.bin") },
                { "battle_text", new GameFile(Language, "/data/res/text/battle_text_" + LanguageCode + ".cfg.bin") },
                { "skill_text", new GameFile(Language, "/data/res/text/skill_text_" + LanguageCode + ".cfg.bin") },
                { "chara_ability_text", new GameFile(Language, "/data/res/text/chara_ability_text_" + LanguageCode + ".cfg.bin") },
                { "addmembermenu_text", new GameFile(Language, "/data/res/text/menu/addmembermenu_text_" + LanguageCode + ".cfg.bin") },
                { "face_icon", new GameFile(Game, "/data/menu/face_icon") },
                { "item_icon", new GameFile(Game, "/data/menu/item_icon") },
                { "model", new GameFile(Game, "/data/character") },
            };
        }

        public void Save()
        {
            string tempPath = @"./temp";

            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            // Save
            Game.Save(tempPath + @"\yw_a.fa");
            Language.Save(tempPath + @"\ywb_lg_" + LanguageCode + ".fa");

            // Close File
            Game.Close();
            Language.Close();

            // Move
            string[] sourceFiles = new string[2] { @"./temp/yw_a.fa", @"./temp/ywb_lg_" + LanguageCode + ".fa" };
            string[] destinationFiles = new string[2] { RomfsPath + @"\yw_a.fa", RomfsPath + @"\ywb_lg_" + LanguageCode + ".fa" };

            for (int i = 0; i < 2; i++)
            {
                if (File.Exists(destinationFiles[i]))
                {
                    File.Delete(destinationFiles[i]);
                }

                File.Move(sourceFiles[i], destinationFiles[i]);
            }

            // Re Open
            Game = new ARC0(new FileStream(RomfsPath + @"\yw_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\ywb_lg_" + LanguageCode + ".fa", FileMode.Open));
        }

        public ICharabase[] GetCharacterbase(bool isYokai)
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastcharabase = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_base")).OrderByDescending(x => x).First();

            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastcharabase));

            if (isYokai)
            {
                return charaBaseFile.Entries
                .Where(x => x.GetName() == "CHARA_BASE_YOKAI_INFO_BEGIN")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<YokaiCharabase>())
                .ToArray();
            }
            else
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

            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastcharabase = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_base")).OrderByDescending(x => x).First();

            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastcharabase));

            charaBaseFile.ReplaceEntry("CHARA_BASE_INFO_BEGIN", "CHARA_BASE_INFO_", npcCharabases);
            charaBaseFile.ReplaceEntry("CHARA_BASE_YOKAI_INFO_BEGIN", "CHARA_BASE_YOKAI_INFO_", yokaiCharabases);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files[lastcharabase].ByteContent = charaBaseFile.Save();
        }

        public ICharascale[] GetCharascale()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastCharascale = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_scale")).OrderByDescending(x => x).First();

            CfgBin charaScaleFile = new CfgBin();
            charaScaleFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastCharascale));

            return charaScaleFile.Entries
                .Where(x => x.GetName() == "CHARA_SCALE_INFO_LIST_BEG")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<Charascale>())
                .ToArray();
        }

        public void SaveCharascale(ICharascale[] charascales)
        {
            Charascale[] formatCharascales = charascales.OfType<Charascale>().ToArray();

            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastCharascale = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_scale")).OrderByDescending(x => x).First();

            CfgBin charaparamFile = new CfgBin();
            charaparamFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastCharascale));

            charaparamFile.ReplaceEntry("CHARA_SCALE_INFO_LIST_BEG", "CHARA_SCALE_INFO_", formatCharascales);

            Game.Directory.GetFolderFromFullPath("/data/res/character").Files[lastCharascale].ByteContent = charaparamFile.Save();
        }

        public ICharaparam[] GetCharaparam()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastcharabase = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_param")).OrderByDescending(x => x).First();

            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastcharabase));

            return new ICharaparam[] { };
            //return charaBaseFile.Entries
            //.Where(x => x.GetName() == "CHARA_BASE_YOKAI_INFO")
            //.SelectMany(x => x.Children)
            //.Select(x => x.ToClass<Charabase>())
            //.ToArray();
        }

        public void SaveCharaparam(ICharaparam[] charaparams)
        {

        }

        public ICharaevolve[] GetCharaevolution()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastcharabase = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_param")).OrderByDescending(x => x).First();

            CfgBin charaBaseFile = new CfgBin();
            charaBaseFile.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastcharabase));

            return new ICharaevolve[] { };
        }

        public void SaveCharaevolution(ICharaevolve[] charaevolutions)
        {

        }

        public IItem[] GetItems(string itemType)
        {
            CfgBin itemconfigFile = new CfgBin();
            itemconfigFile.Open(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin"));

            switch (itemType)
            {
                default:
                    return new IItem[] { };
            }
        }

        public ISkillconfig[] GetSkills()
        {
            return null;
        }

        public IBattleCharaparam[] GetBattleCharaparam()
        {
            return null; ;
        }

        public void SaveBattleCharaparam(IBattleCharaparam[] battleCharaparams)
        {

        }

        public IHackslashCharaparam[] GetHackslashCharaparam()
        {
            return null;
        }

        public void SaveHackslashCharaparam(IHackslashCharaparam[] hackslashCharaparams)
        {

        }

        public IHackslashCharaabilityConfig[] GetHackslashAbilities()
        {
            return null;
        }

        public IHackslashTechnic[] GetHackslashSkills()
        {
            return null;
        }

        public ICharaabilityConfig[] GetAbilities()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastskillFile = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_ability")).OrderByDescending(x => x).First();

            CfgBin charaabilityConfig = new CfgBin();
            charaabilityConfig.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastskillFile));

            return new ICharaabilityConfig[] { };
            //return charaabilityConfig.Entries
            //.Where(x => x.GetName() == "CHARA_ABILITY_CONFIG_INFO_BEGIN")
            //.SelectMany(x => x.Children)
            //.Select(x => x.ToClass<CharaabilityConfig>())
            //.ToArray();
        }

        public IBattleCommand[] GetBattleCommands()
        {
            VirtualDirectory battleFolder = Game.Directory.GetFolderFromFullPath("data/res/battle");
            string lastBattleCommand = battleFolder.Files.Keys.Where(x => x.StartsWith("battle_command")).OrderByDescending(x => x).First();

            CfgBin battlecommandConfig = new CfgBin();
            battlecommandConfig.Open(Game.Directory.GetFileFromFullPath("/data/res/battle/" + lastBattleCommand));

            return new IBattleCommand[] { };
            //return battlecommandConfig.Entries
            //.Where(x => x.GetName() == "BATTLE_COMMAND_INFO_BEGIN")
            //.SelectMany(x => x.Children)
            //.Select(x => x.ToClass<BattleCommand>())
            //.ToArray();
        }

        public string[] GetMapWhoContainsEncounter()
        {
            return null;
        }

        public (IEncountTable[], IEncountChara[]) GetMapEncounter(string mapName)
        {
            VirtualDirectory mapFolder = Game.Directory.GetFolderFromFullPath(Files["map_encounter"].Path);
            string lastEncountConfigFile = mapFolder.Files.Keys.Where(x => x.StartsWith(mapName + "_enc_")).OrderByDescending(x => x).First();

            CfgBin encountConfig = new CfgBin();
            encountConfig.Open(Game.Directory.GetFileFromFullPath(Files["map_encounter"].Path + mapName + "/" + lastEncountConfigFile));

            //IEncountTable[] encountTable = encountConfig.Entries
            //.Where(x => x.GetName() == "ENCOUNT_TABLE_BEGIN")
            //.SelectMany(x => x.Children)
            //.Select(x => x.ToClass<EncountTable>())
            //.ToArray();

            //IEncountChara[] encountChara = encountConfig.Entries
            //.Where(x => x.GetName() == "ENCOUNT_CHARA_BEGIN")
            //.SelectMany(x => x.Children)
            //.Select(x => x.ToClass<EncountChara>())
            //.ToArray();

            return (new IEncountTable[] { }, new IEncountChara[] { });
        }
    }
}
