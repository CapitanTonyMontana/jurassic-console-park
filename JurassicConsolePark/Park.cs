using System.Text.RegularExpressions;
using JurassicConsolePark.Dinosaur;

namespace JurassicConsolePark
{
    internal class Park
    {

       
        public int FoodStore { get; set; }
        private Random rnd = new Random();

        public List<Dinozaur> dinozaurs = new List<Dinozaur>();
      

        public Park()
        {
            Random rnd = new Random();
            FoodStore = rnd.Next(1000, 1501);

        }
        public void DodajDinozaury<T>(char rodzaj, List<Dinozaur> wszystkieDino)
       where T : struct, Enum
        {
            Console.WriteLine($"\nDostępne gatunki {(rodzaj == 'R' ? "roślinożerne" : "mięsożerne")}:");
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
                    int liczbaDino;
                    while (!int.TryParse(Console.ReadLine(), out liczbaDino) || liczbaDino < 1)
                    {
                        Console.WriteLine("Podaj poprawną liczbę większą od 0:");
                    }

                    Dinozaur nowyDino;

                    if (rodzaj == 'R')
                    {
                        var dino = new HerbivorousDino
                        {
                            Type = 'R',
                            Species = wybranyGatunek.ToString(),
                            Number = liczbaDino,
                        };

                        for (int i = 1; i <= liczbaDino; i++)
                        {
                            while (true)
                            {
                                Console.Write($"Podaj imię dla dinozaura #{i}: ");
                                string imie = Console.ReadLine();
                                if (Regex.IsMatch(imie, @"^[a-zA-Z]+$"))
                                {
                                    dino.Imiona.Add(imie);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Imię może zawierać tylko litery. Spróbuj ponownie.");
                                }
                            }
                        }

                        if (dino is HerbivorousDino herb)
                        {
                            herb.PrzypiszKolorLisci();
                            herb.PokazKolorLisci();
                        }


                        dino.WypiszInformacje();
                        dino.GetSound();
                        nowyDino = dino;
                    }
                    else
                    {
                        var dino = new Carnivorous
                        {
                            Type = 'M',
                            Species = wybranyGatunek.ToString(),
                            Number = liczbaDino,
                        };

                        for (int i = 1; i <= liczbaDino; i++)
                        {
                            while (true)
                            {
                                Console.Write($"Podaj imię dla dinozaura #{i}: ");
                                string imie = Console.ReadLine();
                                if (Regex.IsMatch(imie, @"^[a-zA-Z]+$"))
                                {
                                    dino.Imiona.Add(imie);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Imię może zawierać tylko litery. Spróbuj ponownie.");
                                }
                            }
                        }

                        dino.WypiszInformacje();
                        dino.GetSound();
                        nowyDino = dino;
                    }

                    wszystkieDino.Add(nowyDino);

                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna nazwa gatunku. Spróbuj ponownie.");
                }
            }
        }
        public void TryToGuess(List<Dinozaur> wszystkieDino)
        {
            int totalDailyConsumption = 0;

            Console.WriteLine("\n Sprawdzam wszystkie dinozaury:");
            foreach (var dino in wszystkieDino)
            {
                Console.WriteLine($"  Gatunek: {dino.Species}, Rodzaj: {dino.Type}, Liczba: {dino.Number}, Je dziennie: {dino.HowMuchEatPerDay}");

                totalDailyConsumption += dino.Number * dino.HowMuchEatPerDay;
            }

            Console.WriteLine($"Dziennie jedzą = {totalDailyConsumption}");

            if (totalDailyConsumption == 0)
            {
                Console.WriteLine("Żaden dinozaur nie je – nie można obliczyć liczby dni.");
                return;
            }

            int foodStore = this.FoodStore;
            int daysUntilFoodRunsOut = foodStore / totalDailyConsumption;

            Console.WriteLine("\nZgadnij, po ilu dniach skończy się jedzenie!");

            int guess;
            do
            {
                Console.Write("Twoja odpowiedź: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("To nie jest liczba! Spróbuj jeszcze raz.");
                    continue;
                }

                if (guess < daysUntilFoodRunsOut)
                {
                    Console.WriteLine("Za mało!");
                }
                else if (guess > daysUntilFoodRunsOut)
                {
                    Console.WriteLine("Za dużo!");
                }

            } while (guess != daysUntilFoodRunsOut);

            Console.WriteLine("Brawo! Zgadłeś!");
            Console.WriteLine("\n--- PODSUMOWANIE DINOZAURÓW ---");

            int sumaWszystkich = 0;
            int sumaMiesozernych = 0;
            int sumaRoslinozernych = 0;

            int jedzenieMiesozerne = 0;
            int jedzenieRoslinozerne = 0;

            Dictionary<string, int> miesozerneGatunki = new Dictionary<string, int>();

            foreach (var dino in wszystkieDino)
            {
                sumaWszystkich += dino.Number;

                if (dino.Type == 'M')
                {
                    sumaMiesozernych += dino.Number;
                    int ileJe = dino.HowMuchEatPerDay * dino.Number * 3;
                    jedzenieMiesozerne += ileJe;

                    if (!miesozerneGatunki.ContainsKey(dino.Species))
                        miesozerneGatunki[dino.Species] = dino.Number;
                    else
                        miesozerneGatunki[dino.Species] += dino.Number;
                }
                else
                {
                    sumaRoslinozernych += dino.Number;
                    int ileJe = dino.HowMuchEatPerDay * dino.Number * 2;
                    jedzenieRoslinozerne += ileJe;
                }

                foreach (var imie in dino.Imiona)
                {
                    Console.WriteLine($"\nImię: {imie}");
                    Console.WriteLine($"Je dziennie: {dino.HowMuchEatPerDay}");

                    if (dino.Type == 'M')
                    {
                        Console.WriteLine($"Gatunek (mięsożerny): {dino.Species}");
                    }
                    else
                    {
                        if (dino is HerbivorousDino roslinozerny)
                        {
                            Console.WriteLine($"Kolor (hex): {roslinozerny.UlubionyKolorHex}, RGB: ({roslinozerny.UlubionyKolorRGB.R}, {roslinozerny.UlubionyKolorRGB.G}, {roslinozerny.UlubionyKolorRGB.B})");
                            Console.WriteLine("   ////");
                            Console.WriteLine("  //////");
                            Console.WriteLine(" ////////");
                            Console.WriteLine("  ||||\n");
                        }
                    }
                }
            }

            int jedzenieCalkowite = jedzenieMiesozerne + jedzenieRoslinozerne;

            Console.WriteLine($"\n--- SUMY ---");
            Console.WriteLine($"Suma wszystkich dinozaurów: {sumaWszystkich}");
            Console.WriteLine($"Mięsożernych: {sumaMiesozernych}");
            Console.WriteLine($"Roślinożernych: {sumaRoslinozernych}");

            Console.WriteLine($"\nJedzenie dziennie:");
            Console.WriteLine($"Mięsożerne: {jedzenieMiesozerne}");
            Console.WriteLine($"Roślinożerne: {jedzenieRoslinozerne}");
            Console.WriteLine($"Łącznie: {jedzenieCalkowite}");

            Console.WriteLine($"\n--- Gatunki mięsożerne ---");
            Console.WriteLine($"Liczba różnych gatunków: {miesozerneGatunki.Count}");
            foreach (var para in miesozerneGatunki)
            {
                Console.WriteLine($"{para.Key} – {para.Value} sztuk");
            }

            Console.WriteLine($"\n--- Zasoby ---");
            Console.WriteLine($"Początkowa ilość jedzenia: {this.FoodStore}");
            Console.WriteLine($"Po ilu dniach zabraknie: {daysUntilFoodRunsOut}");

            Console.WriteLine("\nJurassic Console Park  zakończył raport.\n");
        }




        public void GetAllSounds(List<Dinozaur> wszystkieDino)
        {
            Console.WriteLine("\nWszystkie odgłosy dinozaurów:");

            foreach (var dino in wszystkieDino)
            {
                Console.WriteLine($"\n{dino.Species}:");

                foreach (var imie in dino.Imiona)
                {
                    string odglos = dino.Type == 'M' ? $"{imie}: Raaaawr!" : $"{imie}: Mniam liść!";
                    Console.WriteLine(" - " + odglos);
                }
            }
        }
    }







}

