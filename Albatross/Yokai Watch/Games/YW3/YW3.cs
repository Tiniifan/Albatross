using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tool;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW3
{
    public class YW3 : IGame
    {
        public string Name => "Yo-Kai Watch 3";

        public Dictionary<uint, string> Attacks => Common.Attacks.YW3;

        public Dictionary<uint, string> Techniques => Common.Techniques.YW3;

        public Dictionary<uint, string> Inspirits => Common.Inspirits.YW3;

        public Dictionary<uint, string> Soultimates => Common.Soultimates.YW3;

        public Dictionary<uint, string> Skills => Common.Skills.YW3;

        public Dictionary<uint, string> Items => Common.Items.YW3;

        public Dictionary<int, string> Tribes => Common.Tribes.YW3;

        public List<Effect> Effects => null;

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;

        public YW3(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\yw_lg_" + LanguageCode + ".fa", FileMode.Open));
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
            Language.Save(tempPath + @"\yw_lg_" + LanguageCode + ".fa");

            // Close File
            Game.Close();
            Language.Close();

            // Move
            string[] sourceFiles = new string[2] { @"./temp/yw_a.fa", @"./temp/yw_lg_" + LanguageCode + ".fa" };
            string[] destinationFiles = new string[2] { RomfsPath + @"\yw_a.fa", RomfsPath + @"\yw_lg_" + LanguageCode + ".fa" };

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
            Language = new ARC0(new FileStream(RomfsPath + @"\yw_lg_" + LanguageCode + ".fa", FileMode.Open));
        }

        public List<Yokai> GetYokais()
        {
            List<Yokai> yokais;

            T2bþ yokaiNames = new T2bþ(Language.Directory.GetFileFromFullPath("/data/res/text/chara_text_" + LanguageCode + ".cfg.bin"));

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.03.25.cfg.bin")))
            {
                charaparam.SeekOf<uint>(0xA2D54CD5, 0x10);
                charaparam.Skip(0x08);
                YW3Support.Charaparam[] yokaiParams = charaparam.ReadMultipleStruct<YW3Support.Charaparam>(charaparam.ReadValue<int>());

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_base_0.03.25.cfg.bin")))
                {
                    charabase.SeekOf<uint>(0x76687850, 0x10);
                    charabase.Skip(0x08);
                    YW3Support.Charabase[] yokaiBases = charabase.ReadMultipleStruct<YW3Support.Charabase>(charabase.ReadValue<int>());

                    // Link
                    Dictionary<YW3Support.Charaparam, YW3Support.Charabase> yokaiConfigs = yokaiParams
                        .Join(yokaiBases, x => x.BaseID, y => y.BaseID, (x, y) => new { Charaparam = x, Charabase = y })
                        .ToDictionary(z => z.Charaparam, z => z.Charabase);

                    // Create Yokai Object List
                    yokais = yokaiConfigs.Select(yokaiConfig => new Yokai
                    {
                        Name = yokaiNames.GetNounText(yokaiConfig.Value.NameID, 0),
                        ModelName = yokaiConfig.Value.Model.GetText(),
                        Rank = yokaiConfig.Value.Rank,
                        Tribe = yokaiConfig.Value.Tribe,
                        MinStat = new int[] { yokaiConfig.Key.MinStat.HP, yokaiConfig.Key.MinStat.Strength, yokaiConfig.Key.MinStat.Spirit, yokaiConfig.Key.MinStat.Defense, yokaiConfig.Key.MinStat.Speed },
                        MaxStat = new int[] { yokaiConfig.Key.MaxStat.HP, yokaiConfig.Key.MaxStat.Strength, yokaiConfig.Key.MaxStat.Spirit, yokaiConfig.Key.MaxStat.Defense, yokaiConfig.Key.MaxStat.Speed },
                        Strongest = (byte)yokaiConfig.Key.Strongest,
                        Weakness = (byte)yokaiConfig.Key.Strongest,
                        AttackID = yokaiConfig.Key.AttackID,
                        TechniqueID = yokaiConfig.Key.TechniqueID,
                        InspiritID = yokaiConfig.Key.InspiritID,
                        SoultimateID = yokaiConfig.Key.SoultimateID,
                        SkillID = yokaiConfig.Key.SkillID,
                        //Money = yokaiConfig.Key.Money,
                        //Experience = yokaiConfig.Key.Experience,
                        //DropID = new uint[] { yokaiConfig.Key.Drop1.ID, yokaiConfig.Key.Drop2.ID },
                        //DropRate = new int[] { yokaiConfig.Key.Drop1.Rate, yokaiConfig.Key.Drop2.Rate },
                        ExperienceCurve = yokaiConfig.Key.ExperienceCurve,
                        EvolveOffset = yokaiConfig.Key.EvolveOffset,
                        MedaliumOffset = yokaiConfig.Key.MedalliumOffset,
                        Medal = new Point(yokaiConfig.Value.Medal.X, yokaiConfig.Value.Medal.Y),
                        ScoutableID = (uint)yokaiConfig.Key.ScoutableID,
                        BaseID = yokaiConfig.Key.BaseID,
                        ParamID = yokaiConfig.Key.ParamID,
                        Statut = new Statut
                        {
                            IsLegendary = yokaiConfig.Value.IsLegendary,
                            IsRare = yokaiConfig.Value.IsRare,
                            IsBoss = yokaiConfig.Value.Tribe == 0x09 || yokaiConfig.Value.Tribe == 0x00,
                            IsScoutable = yokaiConfig.Key.ScoutableID != 0x00,
                            IsStatic = !(yokaiConfig.Key.ScoutableID != 0x00) && (yokaiConfig.Value.Tribe == 0x09 || yokaiConfig.Value.Tribe == 0x00),
                            IsClassic = yokaiConfig.Value.IsClassic,
                            IsDeva = yokaiConfig.Value.IsDeva,
                            IsMerican = yokaiConfig.Value.IsMerican,
                            IsMystery = yokaiConfig.Value.IsMystery,
                            IsTreasure = yokaiConfig.Value.IsTreasure,
                        },
                    }).ToList();

                    yokais = yokais.Select((yokai, index) =>
                    {
                        if (yokai.Name == null)
                        {
                            yokai.Name = "Yokai n°" + index;
                        }

                        return yokai;
                    }).ToList();
                }
            }

            return yokais;
        }

        public void SaveYokai(Yokai yokai)
        {
            //T2bþ yokaiNames = new T2bþ(Language.GetFile("data/res/text/", "chara_text_" + LanguageCode + ".cfg.bin"));

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_param_0.03.25.cfg.bin")))
            {
                // Find Yokai Param
                charaparam.SeekOf<uint>(yokai.ParamID, 0x2C);
                uint yokaiParamOffset = (uint)charaparam.Position - 0x10;
                charaparam.Seek(yokaiParamOffset);

                // Get Yokai Param and Replace
                YW3Support.Charaparam yokaiParam = charaparam.ReadStruct<YW3Support.Charaparam>();
                yokaiParam.ReplaceWith(yokai);

                // Save new Yokai Param
                charaparam.Seek(yokaiParamOffset);
                charaparam.WriteStruct(yokaiParam);

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_base_0.03.25.cfg.bin")))
                {
                    // Find Yokai Base
                    charabase.SeekOf<uint>(yokai.BaseID, 0xE4A0);
                    uint yokaiBaseOffset = (uint)charabase.Position - 0x0C;
                    charabase.Seek(yokaiBaseOffset);

                    // Get Yokai Base and Replace
                    YW3Support.Charabase yokaiBase = charabase.ReadStruct<YW3Support.Charabase>();
                    yokaiBase.ReplaceWith(yokai);

                    // Save new Yokai Param
                    charabase.Seek(yokaiBaseOffset);
                    charabase.WriteStruct(yokaiBase);
                }
            }
        }

        public (int, UInt32) GetEvolution(int evolutionOffset)
        {
            //DataReader charaparamReader = new DataReader(LocalFiles["charaparam"].Data);
            //charaparamReader.Seek(0x18);

            // Skip Yo-Kai Data
            //int numberYokai = charaparamReader.ReadInt32();
            //charaparamReader.Skip((uint) numberYokai * 232);

            // Skip Boss Data
            //charaparamReader.Skip(0x6B0C);

            // Evolution Data
            //charaparamReader.Skip(0x08);
            //int evolutionCount = charaparamReader.ReadInt32();

            //if (evolutionOffset < evolutionCount)
            //{
            //charaparamReader.Skip((uint) evolutionOffset * 16);
            //charaparamReader.Skip(0x08);
            //return (charaparamReader.ReadInt32(), charaparamReader.ReadUInt32());
            // } else
            // {
            //return (0, 0);
            //}

            return (0, 0x0);
        }

        public List<Item> GetItems()
        {
            return null;
        }

        public Dictionary<string, List<Yokai>> GetCharaCond(List<Yokai> yokais)
        {
            return null;
        }

        public void SaveCharaCond(Dictionary<string, List<Yokai>> charaConds)
        {

        }
    }
}
