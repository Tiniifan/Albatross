using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tool;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
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

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;

        public YW2(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw2_a.fa", FileMode.Open));
            Language = new ARC0(new FileStream(RomfsPath + @"\yw2_lg_" + LanguageCode + ".fa", FileMode.Open));
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
            string[] sourceFiles = new string[2] { @"./temp/yw2_a.fa", @"./temp/yw2_lg_" + LanguageCode + ".fa"};
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

        public List<Yokai> GetYokais()
        {
            List<Yokai> yokais;

            T2bþ yokaiNames = new T2bþ(Language.Directory.GetFileFromFullPath("/data/res/text/chara_text_" + LanguageCode + ".cfg.bin"));

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.03a.cfg.bin")))
            {
                charaparam.SeekOf<uint>(0xEEEFA832, 0x10);
                charaparam.Skip(0x08);
                YW2Support.Charaparam[] yokaiParams = charaparam.ReadMultipleStruct<YW2Support.Charaparam>(charaparam.ReadValue<int>());

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_base_0.04c.cfg.bin")))
                {
                    charabase.SeekOf<uint>(0x76687850, 0x10);
                    charabase.Skip(0x08);
                    YW2Support.Charabase[] yokaiBases = charabase.ReadMultipleStruct<YW2Support.Charabase>(charabase.ReadValue<int>());

                    // Link
                    Dictionary<YW2Support.Charaparam, YW2Support.Charabase> yokaiConfigs = yokaiParams
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
                        AttributeDamage = new float[] { yokaiConfig.Key.AttributesDamage.Fire, yokaiConfig.Key.AttributesDamage.Ice, yokaiConfig.Key.AttributesDamage.Earth, yokaiConfig.Key.AttributesDamage.Ligthning, yokaiConfig.Key.AttributesDamage.Water, yokaiConfig.Key.AttributesDamage.Wind },
                        AttackID = yokaiConfig.Key.AttackID,
                        TechniqueID = yokaiConfig.Key.TechniqueID,
                        InspiritID = yokaiConfig.Key.InspiritID,
                        SoultimateID = yokaiConfig.Key.SoultimateID,
                        SkillID = yokaiConfig.Key.SkillID,
                        Money = yokaiConfig.Key.Money,
                        Experience = yokaiConfig.Key.Experience,
                        DropID = new uint[] { yokaiConfig.Key.Drop1.ID, yokaiConfig.Key.Drop2.ID },
                        DropRate = new int[] { yokaiConfig.Key.Drop1.Rate, yokaiConfig.Key.Drop2.Rate },
                        ExperienceCurve = yokaiConfig.Key.ExperienceCurve,
                        EvolveOffset = yokaiConfig.Key.EvolveOffset,
                        MedaliumOffset = yokaiConfig.Key.MedaliumOffset,
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

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_param_0.03a.cfg.bin")))
            {
                // Find Yokai Param
                charaparam.SeekOf<uint>(yokai.ParamID, 0x30);
                uint yokaiParamOffset = (uint)charaparam.Position - 0x14;
                charaparam.Seek(yokaiParamOffset);

                // Get Yokai Param and Replace
                YW2Support.Charaparam yokaiParam = charaparam.ReadStruct<YW2Support.Charaparam>();
                yokaiParam.ReplaceWith(yokai);

                // Save new Yokai Param
                charaparam.Seek(yokaiParamOffset);
                charaparam.WriteStruct(yokaiParam);

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_base_0.04c.cfg.bin")))
                {
                    // Find Yokai Base
                    charabase.SeekOf<uint>(yokai.BaseID, 0x9298);
                    uint yokaiBaseOffset = (uint)charabase.Position - 0x0C;
                    charabase.Seek(yokaiBaseOffset);

                    // Get Yokai Base and Replace
                    YW2Support.Charabase yokaiBase = charabase.ReadStruct<YW2Support.Charabase>();
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
    }
}
