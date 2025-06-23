using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JurassicConsolePark.Dinosaur;


namespace JurassicConsolePark
{

    public class HerbivorousDino : Dinozaur
    {
        public string UlubionyKolorHex { get; set; }
        public (int R, int G, int B) UlubionyKolorRGB { get; set; }
        public HerbivorousDino()
        {
            Type = 'R';
            Random rnd = new Random();
            HowMuchEatPerDay = rnd.Next(2, 9);
        }

       protected void PrzypiszKolorLisci()
        { 
            switch (Species)
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

        public  void PokazKolorLisci()
        {
                Console.WriteLine($"Ulubiony kolor liści (hex): {UlubionyKolorHex}, RGB: ({UlubionyKolorRGB.R}, {UlubionyKolorRGB.G}, {UlubionyKolorRGB.B})");
                Console.WriteLine("   ////");
                Console.WriteLine("  //////");
                Console.WriteLine(" ////////");
                Console.WriteLine("  ||||\n");
        }
       
        protected override int CountDailyComsumption()
        {
            return base.CountDailyComsumption() * 2;
        }

        public static void DodajRoslinozerne<T>(char rodzaj, List<Dinozaur> wszystkieDino)
        where T : struct, Enum
        {
            Console.WriteLine($"\nDostępne gatunki roślinożerne:");
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("- " + name);
            }
            T wybranyGatunek;
            while (true)
            {
                Console.WriteLine("\nWpisz nazwę gatunku:");
                string gatunekInput = Console.ReadLine();

                if (Enum.TryParse(gatunekInput, true, out wybranyGatunek) &&
                    Enum.IsDefined(typeof(T), wybranyGatunek))
                {
                    Console.WriteLine("Wybrano gatunek: " + wybranyGatunek);
                    Console.WriteLine("\nIle dinozaurów tego gatunku chcesz dodać?");
                    if (int.TryParse(Console.ReadLine(), out int liczbaDino) && liczbaDino > 0)
                    {
                        var dino = new HerbivorousDino
                        {
                            Type = 'R',
                            Species = wybranyGatunek.ToString(),
                            Number = liczbaDino
                        };
                        dino.PrzypiszKolorLisci();

                        for (int i = 1; i <= liczbaDino; i++)
                        {
                            Console.Write($"Podaj imię dla dinozaura #{i}: ");
                            string imie = Console.ReadLine();
                            if (Regex.IsMatch(imie, @"^[a-zA-Z]+$"))
                                dino.Imiona.Add(imie);
                        }
                        wszystkieDino.Add(dino);
                    }
                    break;
                }
                else Console.WriteLine("Niepoprawna nazwa gatunku.");
            }
        }
    }
}



