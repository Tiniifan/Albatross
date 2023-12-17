﻿using Albatross.Level5.Archive.ARC0;

namespace Albatross.Yokai_Watch.Games
{
    public class GameFile
    {
        public ARC0 File;
        public string Path;

        public GameFile()
        {

        }

        public GameFile(ARC0 file, string path)
        {
            File = file;
            Path = path;
        }
    }
}
