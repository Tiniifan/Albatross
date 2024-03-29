﻿using Albatross.Yokai_Watch.Logic;

namespace Albatross.Yokai_Watch.Games.YW1.Logic
{
    public class ShopConfig : IShopConfig
    {
        public new int ShopConfigHash { get => base.ShopConfigHash; set => base.ShopConfigHash = value; }
        public new int ItemHash { get => base.ItemHash; set => base.ItemHash = value; }
        public new int Price { get => base.Price; set => base.Price = value; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        public int Unk3 { get; set; }
        public int Unk4 { get; set; }
        public int Unk5 { get; set; }
        public int Unk6 { get; set; }
        public int Unk7 { get; set; }
        public int Unk8 { get; set; }
    }
}
