using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
using Albatross.Level5.Binary;
using Albatross.Yokai_Watch.Games.YW2.Logic;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW2
{
    public class YW2 : IGame 
    {
        public string Name => "Yo-Kai Watch 2";

        public Dictionary<uint, string> Attacks => Common.Attacks.YW2;

        public Dictionary<uint, string> Techniques => Common.Techniques.YW2;

        public Dictionary<uint, string> Inspirits => Common.Inspirits.YW2;

        public Dictionary<uint, string> Soultimates => Common.Soultimates.YW2;

        public Dictionary<uint, string> Skills => Common.Skills.YW2;

        public Dictionary<uint, string> Items => Common.Items.YW2;

        public Dictionary<int, string> Tribes => Common.Tribes.YW2;

        public Dictionary<int, string> FoodsType => Common.FoodsType.YW2;

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;

        public Dictionary<string, GameFile> Files { get; set; }

        public YW2(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw2_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\yw2_lg_" + LanguageCode + ".fa", FileMode.Open));

            Files = new Dictionary<string, GameFile>
            {
                { "chara_text", new GameFile(Game, "/data/res/text/chara_text_" + LanguageCode + ".cfg.bin") },
                { "face_icon", new GameFile(Game, "/data/menu/face_icon") },
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
            Game.Save(tempPath + @"\yw2_a.fa");
            Language.Save(tempPath + @"\yw2_lg_" + LanguageCode + ".fa");

            // Close File
            Game.Close();
            Language.Close();

            // Move
            string[] sourceFiles = new string[2] { @"./temp/yw2_a.fa", @"./temp/yw2_lg_" + LanguageCode + ".fa" };
            string[] destinationFiles = new string[2] { RomfsPath + @"\yw2_a.fa", RomfsPath + @"\yw2_lg_" + LanguageCode + ".fa" };

            for (int i = 0; i < 2; i++)
            {
                if (File.Exists(destinationFiles[i]))
                {
                    File.Delete(destinationFiles[i]);
                }

                File.Move(sourceFiles[i], destinationFiles[i]);
            }

            // Re Open
            Game = new ARC0(new FileStream(RomfsPath + @"\yw2_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\yw2_lg_" + LanguageCode + ".fa", FileMode.Open));
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
                .Where(x => x.GetName() == "CHARA_BASE_YOKAI_INFO")
                .SelectMany(x => x.Children)
                .Select(x => x.ToClass<Charabase>())
                .ToArray();
            } else
            {
                return charaBaseFile.Entries
                    .Where(x => x.GetName() == "CHARA_BASE_YOKAI_INFO")
                    .SelectMany(x => x.Children)
                    .Select(x => x.ToClass<Charabase>())
                    .ToArray();
            }
        }

        public void SaveCharaBase(ICharabase[] charabases)
        {

        }

        public ICharascale[] GetCharascale()
        {
            return null;
        }

        public void SaveCharascale(ICharascale[] charascales)
        {

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

        public ICharaabilityConfig[] GetSkills()
        {
            VirtualDirectory characterFolder = Game.Directory.GetFolderFromFullPath("data/res/character");
            string lastskillFile = characterFolder.Files.Keys.Where(x => x.StartsWith("chara_ability")).OrderByDescending(x => x).First();

            CfgBin charaabilityConfig = new CfgBin();
            charaabilityConfig.Open(Game.Directory.GetFileFromFullPath("/data/res/character/" + lastskillFile));

            return new ICharaabilityConfig[] {};
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
    }
}
