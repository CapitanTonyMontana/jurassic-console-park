using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum Herbivorous
{
    Triceratops,
    Brachiosaurus,
    Stegosaurus
}

namespace Jurassic_Console_Park
{

    public class HerbivorousDino : Dinozaur

    {

        public string UlubionyKolorHex { get; set; }
        public (int R, int G, int B) UlubionyKolorRGB { get; set; }


        public override int Eat(int foodStore)
        {
            int consumption = Liczba * HowMuchEatPerDay;
            return foodStore - consumption;
        }

        public virtual void PrzypiszKolorLisci()
        {

            switch (Gatunek)
            {
                case "Triceratops":
                    UlubionyKolorHex = "#7CFC00";
                    UlubionyKolorRGB = (124, 252, 0);
                    break;
                case "Brachiosaurus":
                    UlubionyKolorHex = "#228B22";
                    UlubionyKolorRGB = (34, 139, 34);
                    break;
                case "Stegosaurus":
                    UlubionyKolorHex = "#ADFF2F";
                    UlubionyKolorRGB = (173, 255, 47);
                    break;
                default:
                    UlubionyKolorHex = "#00FF00";
                    UlubionyKolorRGB = (0, 255, 0);
                    break;
            }
        }

        public virtual void PokazKolorLisci()
        {
            Console.WriteLine($"\nUlubiony kolor liści: {UlubionyKolorHex} (RGB: {UlubionyKolorRGB.R}, {UlubionyKolorRGB.G}, {UlubionyKolorRGB.B})");
            Console.WriteLine("   ////");
            Console.WriteLine("  //////");
            Console.WriteLine(" ////////");
            Console.WriteLine("  ||||\n");
        }
        public HerbivorousDino()
        {
            Random rnd = new Random();
            HowMuchEatPerDay = rnd.Next(2, 9);
        }
    }
}



