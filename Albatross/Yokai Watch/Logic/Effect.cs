using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Yokai_Watch.Logic
{
    public class Effect
    {
        public uint ID;

        public uint TextID;

        public string Text;

        public Effect(uint id, uint textID)
        {
            ID = id;
            TextID = textID;
        }

        public Effect(uint id, uint textID, string text)
        {
            ID = id;
            TextID = textID;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
