using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Albatross.Tools;
using Albatross.Level5.Text;
using Albatross.Level5.Binary;

namespace Albatross.Yokai_Watch.Games
{
    public static class GameSupport
    {
        public static Dictionary<int, char> PrefixLetter = new Dictionary<int, char>() 
        {
            {0, 'c'},
            {6, 'y'},
            {7, 'x'},
            {12, '?'},
            {17, '?'},
        };

        public static string GetFileModelText(int prefix, int number, int variant)
        {
            return PrefixLetter[prefix] + number.ToString("D3") + variant.ToString("D3");
        }

        public static (int,int,int) GetFileModelValue(string text)
        {
            int prefixIndex = PrefixLetter.FirstOrDefault(x => x.Value == text[0]).Key;
            int number = int.Parse(text.Substring(1, 3));
            int variant = int.Parse(text.Substring(4, 3));

            number = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            variant = BitConverter.ToInt32(BitConverter.GetBytes(variant), 0);

            return (prefixIndex, number, variant);
        }

        public static void SaveTextFile(GameFile fileName, T2bþ fileData)
        {
            VirtualDirectory directory = fileName.File.Directory.GetFolderFromFullPath(Path.GetDirectoryName(fileName.Path).Replace("\\", "/"));
            directory.Files[Path.GetFileName(fileName.Path)].ByteContent = fileData.Save(false);
        }

        public static T GetLogic<T>() where T : class, new()
        {
            return new T();
        }
    }
}

