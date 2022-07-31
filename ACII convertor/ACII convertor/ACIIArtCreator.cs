using System;
using System.Drawing;
using System.IO;

namespace ACII_convertor
{
    public class ACIIArtCreator
    {
        private string imageLocation;
        private string _pixels = " .-+*wGHM#&%";
        public ACIIArtCreator(string imageLoication)
        {
                this.imageLocation = imageLoication;
        }

        public void Go(string saveLocation)
        {
            var Image = new Bitmap(imageLocation);
            
            using (var wtr = new StreamWriter(saveLocation))
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    for (int x = 0; x < Image.Width; x++)
                    {
                        var color = Image.GetPixel(x, y);
                        var brightness = Brightness(color);
                        var idx = brightness / 255 * (_pixels.Length - 1);
                        var pxl = _pixels[_pixels.Length - (int)Math.Round(idx) - 1];
                        wtr.Write(pxl);
                    }
                    wtr.WriteLine();
                }
            }
        }

        private static double Brightness(Color c)
        {
            return Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }
    }
}
