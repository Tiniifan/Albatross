using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Albatross.Tool;
using Albatross.Level5.Text;
using Albatross.Level5.Archive.ARC0;
using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW1
{
    public class YW1 : IGame 
    {
        public string Name => "Yo-Kai Watch 1";

        public Dictionary<uint, string> Attacks => Common.Attacks.YW1;

        public Dictionary<uint, string> Techniques => Common.Techniques.YW1;

        public Dictionary<uint, string> Inspirits => Common.Inspirits.YW1;

        public Dictionary<uint, string> Soultimates => Common.Soultimates.YW1;

        public Dictionary<uint, string> Skills => Common.Skills.YW1;

        public Dictionary<uint, string> Items => Common.Items.YW1;

        public Dictionary<int, string> Tribes => Common.Tribes.YW1;

        public List<Effect> Effects => Common.Effects.YW1;

        public ARC0 Game { get; set; }

        public ARC0 Language { get; set; }

        public string LanguageCode { get; set; }

        private string RomfsPath;

        public YW1(string romfsPath, string language)
        {
            RomfsPath = romfsPath;
            LanguageCode = language;

            Game = new ARC0(new FileStream(RomfsPath + @"\yw1_a.fa", FileMode.Open));
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

        public List<Yokai> GetYokais()
        {
            List<Yokai> yokais;

            T2bþ yokaiNames = new T2bþ(Game.Directory.GetFileFromFullPath("/data/res/text/chara_text_" + LanguageCode + ".cfg.bin"));

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_param_0.02.cfg.bin")))
            {
                charaparam.SeekOf<uint>(0xEEEFA832, 0x10);
                charaparam.Skip(0x08);
                YW1Support.Charaparam[] yokaiParams = charaparam.ReadMultipleStruct<YW1Support.Charaparam>(charaparam.ReadValue<int>());

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/character/chara_base_0.04j.cfg.bin")))
                {
                    charabase.SeekOf<uint>(0x76687850, 0x10);
                    charabase.Skip(0x08);
                    YW1Support.Charabase[] yokaiBases = charabase.ReadMultipleStruct<YW1Support.Charabase>(charabase.ReadValue<int>());

                    // Link
                    Dictionary<YW1Support.Charaparam, YW1Support.Charabase> yokaiConfigs = yokaiParams
                        .Join(yokaiBases, x => x.BaseID, y => y.BaseID, (x, y) => new { Charaparam = x, Charabase = y })
                        .ToDictionary(z => z.Charaparam, z => z.Charabase);

                    // Create Yokai Object List
                    yokais = yokaiConfigs.Select(yokaiConfig => new Yokai
                    {
                        Name = yokaiNames.GetNounText(yokaiConfig.Value.NameID, 0),
                        ModelName = yokaiConfig.Value.Model.GetText(),
                        Rank = yokaiConfig.Value.Rank,
                        Tribe = yokaiConfig.Key.Tribe,
                        MinStat = new int[] { yokaiConfig.Key.BaseStat.HP, yokaiConfig.Key.BaseStat.Strength, yokaiConfig.Key.BaseStat.Spirit, yokaiConfig.Key.BaseStat.Defense, yokaiConfig.Key.BaseStat.Speed },
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
                        ScoutableID = yokaiConfig.Key.ScoutableID,
                        BaseID = yokaiConfig.Key.BaseID,
                        ParamID = yokaiConfig.Key.ParamID,
                        Statut = new Statut
                        {
                            IsLegendary = yokaiConfig.Value.IsLegendary,
                            IsRare = yokaiConfig.Value.IsRare,
                            IsBoss = yokaiConfig.Key.Tribe == 0x09 || yokaiConfig.Key.Tribe == 0x00,
                            IsScoutable = yokaiConfig.Key.ScoutableID != 0x00,
                            IsStatic = !(yokaiConfig.Key.ScoutableID != 0x00) && (yokaiConfig.Key.Tribe == 0x09 || yokaiConfig.Key.Tribe == 0x00),
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

            using (BinaryDataReader charaparam = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_param_0.02.cfg.bin")))
            {
                // Find Yokai Param
                charaparam.SeekOf<uint>(yokai.ParamID, 0x30);
                uint yokaiParamOffset = (uint)charaparam.Position - 0x14;
                charaparam.Seek(yokaiParamOffset);

                // Get Yokai Param and Replace
                YW1Support.Charaparam yokaiParam = charaparam.ReadStruct<YW1Support.Charaparam>();
                yokaiParam.ReplaceWith(yokai);

                // Save new Yokai Param
                charaparam.Seek(yokaiParamOffset);
                charaparam.WriteStruct(yokaiParam);

                // Charabase
                using (BinaryDataReader charabase = new BinaryDataReader(Game.Directory.GetFileFromFullPath("data/res/character/chara_base_0.04j.cfg.bin")))
                {
                    // Find Yokai Base
                    charabase.SeekOf<uint>(yokai.BaseID, 0x2B74);
                    uint yokaiBaseOffset = (uint)charabase.Position - 0x0C;
                    charabase.Seek(yokaiBaseOffset);

                    // Get Yokai Base and Replace
                    YW1Support.Charabase yokaiBase = charabase.ReadStruct<YW1Support.Charabase>();
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
            List<Item> items = new List<Item>();

            T2bþ itemNames = new T2bþ(Game.Directory.GetFileFromFullPath("/data/res/text/item_text_" + LanguageCode + ".cfg.bin"));

            using (BinaryDataReader itemconfig = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin")))
            {
                itemconfig.SeekOf<uint>(0x02c18213, 0x10);
                itemconfig.Skip(0x08);
                YW1Support.Equipment[] equipments = itemconfig.ReadMultipleStruct<YW1Support.Equipment>(itemconfig.ReadValue<int>());

                // Update Effect List
                uint[] effectsID = equipments.SelectMany(x => new[] { x.Effect1ID, x.Effect2ID }).ToArray();
                foreach (uint effectID in effectsID.Where(x => x != 0x00))
                {
                    Effect effect = Effects.FirstOrDefault(x => x.ID == effectID);
                    effect.Text = itemNames.GetText(effect.TextID, 0);
                }

                items.AddRange(equipments.Select(equipment => new Equipment
                {
                    Name = itemNames.GetNounText(equipment.Item.NameID, 0),
                    Description = itemNames.GetText(equipment.Item.DescriptionID, 0),
                    ID = equipment.Item.ItemID,
                    MaxQuantity = equipment.Item.MaxQuantity,
                    CanBeBuy = equipment.Item.CanBeBuy,
                    CanBeSell = equipment.Item.CanBeSell,
                    SellPrize = equipment.Item.SellPrize / 100,
                    ItemIcon = "item_" + (equipment.Item.ItemIcon.X + equipment.Item.ItemIcon.Y * 16 +1).ToString("000"),
                    Effect1 = Effects.FirstOrDefault(x => x.ID == equipment.Effect1ID),
                    Effect2 = Effects.FirstOrDefault(x => x.ID == equipment.Effect2ID),
                    Stat = new int[4] { equipment.EquipmentStat.Strength, equipment.EquipmentStat.Spirit, equipment.EquipmentStat.Defense, equipment.EquipmentStat.Speed },
                    CharaConditionID = equipment.CharaConditionID,
                }
                ));

                itemconfig.SeekOf<uint>(0xb12f6877, (uint)itemconfig.Position);
                itemconfig.Skip(0x08);
                YW1Support.Consumable[] consumables = itemconfig.ReadMultipleStruct<YW1Support.Consumable>(itemconfig.ReadValue<int>());
                items.AddRange(consumables.Select(consumable => new Consumable
                {
                    Name = itemNames.GetNounText(consumable.Item.NameID, 0),
                    Description = itemNames.GetNounText(consumable.Item.DescriptionID, 0),
                    ID = consumable.Item.ItemID,
                    MaxQuantity = consumable.Item.MaxQuantity,
                    CanBeBuy = consumable.Item.CanBeBuy,
                    CanBeSell = consumable.Item.CanBeSell,
                    SellPrize = consumable.Item.SellPrize / 100,
                    ItemIcon = "item_" + (consumable.Item.ItemIcon.X + consumable.Item.ItemIcon.Y * 16 + 1).ToString("000"),
                    Effect1ID = consumable.Effect1ID,
                    Effect2ID = consumable.Effect2ID,
                }
                ));

                itemconfig.SeekOf<uint>(0x275ad2aa, (uint)itemconfig.Position);
                itemconfig.Skip(0x08);
                YW1Support.KeyItem[] keyitems = itemconfig.ReadMultipleStruct<YW1Support.KeyItem>(itemconfig.ReadValue<int>());
                items.AddRange(keyitems.Select(key => new KeyItem
                {
                    Name = itemNames.GetNounText(key.Item.NameID, 0),
                    Description = itemNames.GetNounText(key.Item.DescriptionID, 0),
                    ID = key.Item.ItemID,
                    MaxQuantity = key.Item.MaxQuantity,
                    CanBeBuy = key.Item.CanBeBuy,
                    CanBeSell = key.Item.CanBeSell,
                    SellPrize = key.Item.SellPrize / 100,
                    ItemIcon = "item_" + (key.Item.ItemIcon.X + key.Item.ItemIcon.Y * 16 + 1).ToString("000"),
                }
                ));

                itemconfig.SeekOf<uint>(0x562199bb, (uint)itemconfig.Position);
                itemconfig.Skip(0x08);
                YW1Support.CreatureItem[] creatures = itemconfig.ReadMultipleStruct<YW1Support.CreatureItem>(itemconfig.ReadValue<int>());
                items.AddRange(creatures.Select(creature => new CreatureItem
                {
                    Name = itemNames.GetNounText(creature.Item.NameID, 0),
                    Description = itemNames.GetNounText(creature.Item.DescriptionID, 0),
                    ID = creature.Item.ItemID,
                    MaxQuantity = creature.Item.MaxQuantity,
                    CanBeBuy = creature.Item.CanBeBuy,
                    CanBeSell = creature.Item.CanBeSell,
                    SellPrize = creature.Item.SellPrize / 100,
                    ItemIcon = "item_" + (creature.Item.ItemIcon.X + creature.Item.ItemIcon.Y * 16 + 1).ToString("000"),
                }
                ));
            }

            return items;
        }

        public void SaveItems(List<Item> items)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryDataWriter itemWriter = new BinaryDataWriter(memoryStream))
                {
                    using (BinaryDataReader itemReader = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin")))
                    {
                        // Not implement add item
                    }
                }
            }
        }

        public Dictionary<string, List<Yokai>> GetCharaCond(List<Yokai> yokais)
        {
            Dictionary<string, List<Yokai>> charaConds = new Dictionary<string, List<Yokai>>();

            using (BinaryDataReader itemconfig = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin")))
            {
                itemconfig.SeekOf<uint>(0x4139418c, 0x10);
                itemconfig.Skip(0x08);
                YW1Support.ItemEquipCond[] itemEquipConds = itemconfig.ReadMultipleStruct<YW1Support.ItemEquipCond>(itemconfig.ReadValue<int>());

                itemconfig.SeekOf<uint>(0x67803ed1, (uint)itemconfig.Position);
                itemconfig.Skip(0x08);
                YW1Support.ItemEquipCondChara[] itemEquipCondCharas = itemconfig.ReadMultipleStruct<YW1Support.ItemEquipCondChara>(itemconfig.ReadValue<int>());

                charaConds.Add("No condition", new List<Yokai>());
                charaConds.Add("For D and E Rank Yo-kai", yokais.Where(x => x.Rank < 2 && x.Statut.IsScoutable).ToList());

                for (int i = 1; i < itemEquipConds.Length; i ++)
                {
                    YW1Support.ItemEquipCond itemEquipCond = itemEquipConds[i];
                    List<Yokai> yokaisWithCondition = new List<Yokai>();

                    for (int j = 0; j < itemEquipCond.Number; j++)
                    {
                        YW1Support.ItemEquipCondChara itemEquipCondChara = itemEquipCondCharas[itemEquipCond.StartOffset + j];
                        yokaisWithCondition.Add(yokais.FirstOrDefault(x => x.BaseID == itemEquipCondChara.CharaBaseID));
                    }

                    charaConds.Add("Custom Condition " + i, yokaisWithCondition);
                }

                return charaConds;
            }
        }

        public void SaveCharaCond(Dictionary<string, List<Yokai>> charaConds)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryDataWriter itemWriter = new BinaryDataWriter(memoryStream))
                {
                    using (BinaryDataReader itemReader = new BinaryDataReader(Game.Directory.GetFileFromFullPath("/data/res/item/item_config_0.05d.cfg.bin")))
                    {
                        int entryCount = itemReader.ReadValue<int>();
                        long tableOffset = itemReader.ReadValue<int>();
                        
                        // Item condition
                        itemReader.SeekOf<uint>(0x4139418c, 0x10);
                        itemWriter.Write(itemReader.GetSection(0, (int)itemReader.Position));
                        itemReader.Skip(0x08);
                        int oldNumberItemCondition = itemReader.ReadValue<int>();

                        // Header condition
                        itemWriter.Write(0x4139418c);
                        itemWriter.Write(0xFFFF0101);
                        itemWriter.Write(charaConds.Count - 1);

                        // No condition
                        itemWriter.Write(0x3ADB482F);
                        itemWriter.Write(0xFFFF1503);
                        itemWriter.Write(1);
                        itemWriter.Write(0);
                        itemWriter.Write(0);

                        // Custom condition
                        int yokaiOffset = 0;
                        foreach (List<Yokai> yokais in charaConds.Where(x => x.Key.StartsWith("Custom Condition")).Select(x => x.Value))
                        {
                            itemWriter.Write(0x3ADB482F);
                            itemWriter.Write(0xFFFF1503);
                            itemWriter.Write(0xFFFFFFFF);
                            itemWriter.Write(yokaiOffset);
                            itemWriter.Write(yokais.Count);
                            yokaiOffset += yokais.Count;
                        }

                        // Close item condition
                        itemWriter.Write(0xF928CEB7);
                        itemWriter.Write(0xFFFFFF00);

                        itemReader.SeekOf<uint>(0x67803ed1, (uint)itemReader.Position);
                        itemReader.Skip(0x08);
                        int oldNumberItemConditionChara = itemReader.ReadValue<int>();

                        // Header condition chara
                        itemWriter.Write(0x67803ED1);
                        itemWriter.Write(0xFFFF0101);
                        itemWriter.Write(yokaiOffset);

                        // Custom condition chara
                        foreach (List<Yokai> yokais in charaConds.Where(x => x.Key.StartsWith("Custom Condition")).Select(x => x.Value))
                        {
                            foreach (Yokai yokai in yokais)
                            {
                                itemWriter.Write(0xB3371A58);
                                itemWriter.Write(0xFFFF0101);
                                itemWriter.Write(yokai.BaseID);
                            }
                        }

                        // write end of file
                        itemWriter.Write(0x06572B28);
                        itemWriter.WriteAlignment();
                        itemReader.Seek((uint)tableOffset);
                        tableOffset = itemWriter.Position;
                        itemWriter.Write(itemReader.GetSection((int) (itemReader.Length-itemReader.Position)));

                        // Edit Header file
                        itemWriter.Seek(0x0);
                        entryCount -= oldNumberItemCondition;
                        entryCount -= oldNumberItemConditionChara;
                        itemWriter.Write(entryCount + (charaConds.Count - 1) + yokaiOffset);
                        itemWriter.Write(tableOffset);
                    }

                    // Replace File
                    Game.Directory.GetFolderFromFullPath("/data/res/item/").Files["item_config_0.05d.cfg.bin"].ByteContent = memoryStream.ToArray();
                }
            }
        }
    }
}
