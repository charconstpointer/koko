using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Koko
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var imagePath = args.FirstOrDefault() ?? "logo_pr40.png";
            var image = new Bitmap(imagePath);
            //Exif missing
            image.RotateFlip(RotateFlipType.Rotate90FlipX);
            var width = image.Width;

            Console.Clear();
            for (;;)
            {
                var row = 0;
                for (var j = 1; j < Math.Pow(width,2) + 1; j++)
                {
                    Console.SetCursorPosition(j % width * 2, row);
                    var color = image.GetPixel(row, j % width);
                    Console.Write("O+", color);
                    if (j % width == 0) row++;
                }

                await Task.Delay(1000);
            }
        }
    }
}