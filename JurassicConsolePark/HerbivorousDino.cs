using System.Text.RegularExpressions;
using JurassicConsolePark.Dinosaur;

namespace JurassicConsolePark
{

    public class HerbivorousDino : Dinozaur
    {
        public Herbivorous SpeciesEnum { get; set; }
        public string UlubionyKolorHex { get; set; }
        public (int R, int G, int B) UlubionyKolorRGB { get; set; }

        public HerbivorousDino (Herbivorous speciesEnum)
        {
            SpeciesEnum = speciesEnum;
            Species= speciesEnum.ToString();
            Type = 'R';
            Random rnd = new Random();
            HowMuchEatPerDay = rnd.Next(2, 9);
            PrzypiszKolorLisci(speciesEnum);
        }
       private void PrzypiszKolorLisci(Herbivorous speciesEnum)
        { 
            switch (SpeciesEnum)
            {
                case Herbivorous.Triceratops:
                    UlubionyKolorHex = "#7CFC00";
                    UlubionyKolorRGB = (124, 252, 0);
                    break;
                case Herbivorous.Brachiosaurus:
                    UlubionyKolorHex = "#228B22";
                    UlubionyKolorRGB = (34, 139, 34);
                    break;
                case Herbivorous.Stegosaurus:
                    UlubionyKolorHex = "#ADFF2F";
                    UlubionyKolorRGB = (173, 255, 47);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Nieobsługiwany gatunek: {SpeciesEnum}");
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
        where T :  Enum
        {
            Console.WriteLine($"\nDostępne gatunki roślinożerne:");
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("- " + name);
            }
            while (true)
            {
                Console.WriteLine("\nWpisz nazwę gatunku:");
                string gatunekInput = Console.ReadLine();

                if (Enum.TryParse(typeof(T),gatunekInput, true, out object parsedEnum) &&
                    Enum.IsDefined(typeof(T), parsedEnum))
                {
                    T wybranyGatunek = (T)parsedEnum;
                    Console.WriteLine("Wybrano gatunek: " + wybranyGatunek);
                    Console.WriteLine("\nIle dinozaurów tego gatunku chcesz dodać?");
                    if (int.TryParse(Console.ReadLine(), out int liczbaDino) && liczbaDino > 0)
                    {
                        var dino = new HerbivorousDino((Herbivorous)(object)wybranyGatunek)
                        {
                            Type = 'R',
                            Species = wybranyGatunek.ToString(),
                            Number = liczbaDino
                        };

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



