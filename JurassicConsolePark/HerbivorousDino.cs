using System.Text.RegularExpressions;
using JurassicConsolePark.Dinosaur;

namespace JurassicConsolePark
{

    public class HerbivorousDino : Dinozaur
    {
        public Herbivorous Species { get; set; } 
        public string FavColorHex { get; set; } = string.Empty;
        public (int R, int G, int B) FavColorRGB { get; set; }
        public HerbivorousDino(Herbivorous species)
        {
            Species = species;
            base.Species = species.ToString();
            Type = 'R';
            HowMuchEatPerDay = new Random().Next(2, 9);
            SetLeafColor();
        }
        private void SetLeafColor()
        { 
            switch (Species)
            {
                case Herbivorous.Triceratops:
                    FavColorHex = "#7CFC00";
                    FavColorRGB = (124, 252, 0);
                    break;
                case Herbivorous.Brachiosaurus:
                    FavColorHex = "#228B22";
                    FavColorRGB = (34, 139, 34);
                    break;
                case Herbivorous.Stegosaurus:
                    FavColorHex = "#ADFF2F";
                    FavColorRGB = (173, 255, 47);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Nieobsługiwany gatunek: {Species}");
            }
        }
        public  void ShowLeafColor()
        {
                Console.WriteLine($"Ulubiony kolor liści (hex): {FavColorHex}, RGB: ({FavColorRGB.R}, {FavColorRGB.G}, {FavColorRGB.B})");
                Console.WriteLine("   ////");
                Console.WriteLine("  //////");
                Console.WriteLine(" ////////");
                Console.WriteLine("  ||||\n");
        }
        protected override int CountDailyComsumption()
        {
            return base.CountDailyComsumption() * 2;
        }
    
    }
}



