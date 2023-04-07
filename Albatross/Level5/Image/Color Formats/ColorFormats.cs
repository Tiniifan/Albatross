using System.Drawing;

namespace Albatross.Level5.Image
{
    public class RGBA8 : IColorFormat
    {
        public string Name => "RGBA8";

        public int Size => 4;

        public byte[] Encode(Color color)
        {
            int argb = color.ToArgb();
            return new byte[] { (byte)((argb >> 24) & 0xFF), (byte)(argb & 0xFF), (byte)((argb >> 8) & 0xFF), (byte)((argb >> 16) & 0xFF) };
        }

        public Color Decode(byte[] data)
        {
            if (data.Length < 4)
            {
                System.Console.WriteLine(System.BitConverter.ToString(data).Replace("-", ""));
                return Color.FromArgb(0);
            }
            int argb = (data[0] << 24) | (data[3] << 16) | (data[2] << 8) | data[1];
            return Color.FromArgb(argb);
        }
    }
}
