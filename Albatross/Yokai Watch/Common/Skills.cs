﻿using System.Collections.Generic;

namespace Albatross.Yokai_Watch.Common
{
    public static class Skills
    {
        public static Dictionary<uint, string> YW2 = new Dictionary<uint, string>
        {
            {0x00000000, " "},
            {0x602CAFF6, "Careless"},
            {0x42B7B01E, "Shooting Rhythm"},
            {0x90543B82, "Soft Skin"},
            {0x6DD61711, "Bladed Body"},
            {0xF438FE86, "Gambler"},
            {0x833FCE10, "Light Speed"},
            {0x79379EB7, "Cursed Skin"},
            {0x521ACD74, "Spirit Guard"},
            {0x251DFDE2, "Blazing Spirit"},
            {0xF3B282B2, "Courageous Spirit"},
            {0x6ABBD308, "Shining Spirit (1)"},
            {0xA8129DD3, "Shining Spirit (2)"},
            {0x317FA0AC, "Lone Soldier"},
            {0xD208AD8F, "Intimidation"},
            {0xBC14AC58, "Sword Hunting"},
            {0xCB139CCE, "Annoyance"},
            {0x2800FD28, "Secrecy"},
            {0xB109AC92, "Snow Play"},
            {0x461CFCFF, "Hanging In"},
            {0x4B01FC35, "Forgot to Guard"},
            {0xEA4E0BDE, "Prediction"},
            {0xBB796841, "Guard Break"},
            {0xCC7E58D7, "The Stand"},
            {0xD878695C, "Popularity"},
            {0xAF7F59CA, "Unpopularity"},
            {0x7AF1164F, "Caring"},
            {0x73475A64, "Grip On You"},
            {0x172B9F60, "Good Fortune"},
            {0x975D935E, "Free To Be"},
            {0x5F07CDBE, "Lighting Play"},
            {0x1D5B5BB3, "Long Lasting"},
            {0x7E5A5AAE, "Mirror Body"},
            {0x04406AF2, "Brother's Vow"},
            {0x14ED1798, "Penetrate"},
            {0xFD690A80, "Sense Of Smell"},
            {0x3DA0CA51, "Darkness Falls"},
            {0x3FC0445B, "Glossy Skin"},
            {0x095D6A38, "Spiky Guard"},
            {0x10465B79, "Blocker"},
            {0x84B5B224, "Endurance"},
            {0x008F4AD6, "Rocky Terrain"},
            {0x48C774CD, "Gold Guard"},
            {0x6D31AF3C, "Bronze Guard"},
            {0x1A369FAA, "Silver Guard"},
            {0x894F0AC3, "Platinum Guard"},
            {0xB664688B, "Insulator"},
            {0xE7530B14, "Blessed Body"},
            {0xF3553A9F, "Modest"},
            {0xF925FE4C, "Eyesight A"},
            {0x2F6D3931, "Wind Play"},
            {0x1DBCE39E, "Adrenaline"},
            {0xD3AEAB7D, "All or Nothing"},
            {0x7081D29C, "Pompadour"},
            {0xFE483A55, "Linked Together"},
            {0x5BAC815F, "Skilled Loafer"},
            {0xE73767D1, "Fill 'Er Up"},
            {0xED23CFC7, "Alpha"},
            {0x9A24FF51, "Omega"},
            {0x4678903A, "Lightning Up!"},
            {0x90305747, "Firewall"},
            {0x77887A40, "Superconductor"},
            {0x227039FB, "Dodge"},
            {0xDF71C180, "Fangsicles"},
            {0x586A09A7, "Fire Watchout"},
            {0x6048C333, "Alpine Wall"},
            {0x1E9DD34B, "Fire Play"},
            {0x03CA16C6, "Starver"},
            {0xA876F116, "Bear Care"},
            {0x4DAE521B, "Mutt's Paradise"},
            {0x9D493B48, "Jar Guard"},
            {0x04A7D2DF, "Miraculous Scales"},
            {0xE03ECF0D, "Wavy Body"},
            {0x9AC3477C, "Insecure"},
            {0x3B6B08BA, "Prayer"},
            {0xEDC477EA, "Strict"},
            {0x67416BEF, "Extreme Critical"},
            {0x742A9E7D, "Vampiric"},
            {0x311BCC69, "Windshield"},
            {0x2CABB1C9, "Revenge"},
            {0x5577096D, "Oldness Zone"},
            {0xA50F9D19, "Gassy Sphere"},
            {0x032DAEEB, "Secrecy"},
            {0x9DAE8365, "Moist Skin"},
            {0x73A0E249, "Stiff Skin"},
            {0x8E22CEDA, "Greed"},
            {0x74CD2650, "Snitch"},
            {0x8A6E3A16, "Stealing"},
            {0xE4723BC1, "Optimism Power"},
            {0x35B08088, "Death Sphere"},
            {0x83D8763D, "Suspicion"},
            {0x6A5C6B25, "Too Afraid"},
            {0x9739FF9B, "Mine"},
            {0x0DF626D9, "Ultimate Dark"},
            {0x36760870, "Summon"},
            {0x417138E6, "Hard Worker"},
            {0x0786E20A, "Dragon Force"},
            {0xC163581D, "Waterproof"},
            {0xF4DF46AB, "Loiterer"},
            {0x93750B57, "Shark Skin"},
            {0xDF15AD45, "Matchless Shell"},
            {0x63EA270E, "Venocharge"},
            {0xA4A99BEB, "Lord of Light"},
            {0x56D5ED50, "Washed Out"},
            {0xB600044E, "Rice and Dice"},
            {0xE05AA3C8, "Lickaway"},
            {0x2BA21915, "Acrobat"},
            {0xFE2C5690, "Sludge Grudge"},
            {0x4FCEDC11, "Gimme Twenty"},
            {0x1D3F3776, "Lie-In Wait"},
            {0x551365A8, "Sneaky Snacker"},
            {0x6A3807E0, "Soul Snacker"},
            {0x4B6590F0, "Gust o' Gusto"},
            {0xF331565A, "Magic Mist"},
            {0x2214553E, "Make Amends"},
            {0xBC70C09D, "Me Too!"},
            {0xBB1D0484, "Electro Field"},
            {0x843666CC, "Tasty Aroma"},
            {0x1A52F36F, "In a Flash"},
            {0x25799127, "Rest In Pieces"},
            {0x6D55C3F9, "Bitter Rice"},
            {0x21D2DDC6, "Oily Mess"},
            {0x26DB751A, "Diggin In"},
            {0x7E3E366B, "Sticky Fingers"},
            {0xF45C9243, "Thick Crust"},
            {0x835BA2D5, "Earth Cannon"},
            {0x13E4BF44, "Eye See You"},
            {0x45BE18C2, "Carnivaura"},
            {0xCC1A3412, "Going Nowhere"},
            {0x8E46A21F, "Toadally Saved"},
            {0x64E38FD2, "Geckstra Safe"},
            {0x527EA1B1, "Bony Bond"},
            {0x32B92854, "Soulful Promise"},
            {0x3C62A066, "Great Legs"},
            {0x04240637, "Step Up"},
            {0x3B0F647F, "Downpour"},
            {0xCB77F00B, "Shuffle"},
            {0x04C3BE1A, "Use the Hose"},
            {0x5CA52983, "Lick It Clean"},
            {0xF9419289, "Sun Shield"},
            {0x732336A1, "Sand Still"},
            {0xEA2A671B, "Carefree Spirit"},
            {0xD26CC14A, "Feel the Beat"},
            {0x9D2D578D, "Clairvoidance"},
            {0x4C0854E9, "Sunburn"},
            {0x0349C22E, "Seaweed Samba"},
            {0x744EF2B8, "Golden Touch"},
            {0x6725072A, "Second Wind"},
            {0xED47A302, "Got Your Back"},
            {0xC10734D8, "Night Life"},
            {0xD5010553, "Herbivaura"},
            {0x9A409394, "Me First!"},
            {0x580E6562, "You First"},
            {0x0AFF8E05, "Zap Away"},
            {0x361264B5, "Triple-Header"},
            {0x2F0955F4, "Know Your Place"},
            {0x7DF8BE93, "Bloodsucker"},
            {0x83BC1AF8, "Hairnet"},
            {0x19947B97, "Spin-no-rama"},
            {0xF4BB2A6E, "Center Stage"},
            {0x286491ED, "Curse Worsener"},
            {0x5F63A17B, "Pigskin"},
            {0xA20635C5, "Noise Pollution"},
            {0x102237BC, "Haiwax"},
            {0xC66AF0C1, "Highlander"},
            {0x7953F272, "Rest Less"},
            {0xD81C0599, "Hassle"},
            {0x174FF3A5, "Windbreaker"},
            {0x892B6606, "Waterworks"},
            {0x6DB27BD4, "Saintly Scales"},
            {0x1AB54B42, "Rubberneck"},
            {0x6E934B01, "Just a Minute"},
            {0xB16DC057, "Twinkle Toes"},
            {0x84D1DEE1, "Biochemistry"},
            {0xF3D6EE77, "Tongue Twister"},
            {0x6ADFBFCD, "Dirt Rat"},
            {0x1DD88F5B, "Number One!"},
            {0x8D6792CA, "Night Guard"},
            {0xAF1B350F, "Polarity"},
            {0xFA60A25C, "Healer Moon"},
            {0x9AA72BB9, "Purrsistence"},
            {0x4AA7FAC7, "He Just Nose"},
            {0x947CA38B, "Born Winner"},
            {0xE37B931D, "Born Lucky"},
            {0xEDA01B2F, "Breaking Baad"},
            {0x74A94A95, "Fast Asleep"},
            {0x03AE7A03, "Killer Comeback"},
            {0x9DCAEFA0, "Sandbag"},
            {0xEACDDF36, "Eruption"},
            {0x73C48E8C, "How Sweet"},
            {0x0E54C2E4, "Juicy Goodness"},
        };
    }
}
