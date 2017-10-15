using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.RealWorld
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var colorManager = new ColorManager();

            // Initialize with standard colors
            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            // User clones selected colors
            var color1 = (Color)colorManager["red"].Clone();
            var color2 = (Color)colorManager["peace"].Clone();
            var color3 = (Color)colorManager["flame"].Clone();

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine( "Cloning color RGB: {0,5},{1,4},{2,3}", _red, _green, _blue);
            return this.MemberwiseClone() as ColorPrototype;
        }

    }

    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
