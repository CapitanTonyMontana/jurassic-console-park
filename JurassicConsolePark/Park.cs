using System.Runtime.CompilerServices;
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
        public void TryToGuess(List<Dinozaur> allDino)
        {
            Console.WriteLine("\n--- Sprawdzam wszystkie dinozaury ---");
            int totalDailyConsumption = allDino.Sum(d => d.Number * d.HowMuchEatPerDay);
            Console.WriteLine($"Dziennie jedzą = {totalDailyConsumption}");
            if (totalDailyConsumption == 0)
            {
                Console.WriteLine("Żaden dinozaur nie je – nie można obliczyć liczby dni.");
                return;
            }
            int daysUntilFoodRunsOut = this.FoodStore / totalDailyConsumption;
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
                    Console.WriteLine("Za mało!");
                else if (guess > daysUntilFoodRunsOut)
                    Console.WriteLine("Za dużo!");
            }
            while (guess != daysUntilFoodRunsOut);
            Console.WriteLine("Brawo! Zgadłeś!");

            PrintSummary(allDino, daysUntilFoodRunsOut);
        }
        private void PrintSummary(List<Dinozaur> allDino, int daysUntilFoodRunsOut)
        {
            Console.WriteLine("\n--- PODSUMOWANIE DINOZAURÓW ---");
            int totalCount = 0;
            int carnivoreCount = 0;
            int herbivoreCount = 0;
            int carnivoreFood = 0;
            int herbivoreFood = 0;
            Dictionary<string, int> carnivoreSpecies = new Dictionary<string, int>();

            foreach (var dino in allDino)
            {
                totalCount += dino.Number;

                if (dino is HerbivorousDino herbivore)
                {
                    herbivore.ShowLeafColor();
                    herbivoreCount += dino.Number;
                    herbivoreFood += dino.Number * dino.HowMuchEatPerDay * 2;
                }
                else
                {
                    carnivoreCount += dino.Number;
                    carnivoreFood += dino.Number * dino.HowMuchEatPerDay * 3;

                    if (!carnivoreSpecies.ContainsKey(dino.Species))
                        carnivoreSpecies[dino.Species] = dino.Number;
                    else
                        carnivoreSpecies[dino.Species] += dino.Number;
                }
            }

            int totalFood = carnivoreFood + herbivoreFood;
            Console.WriteLine($"\n--- SUMY ---");
            Console.WriteLine($"Suma wszystkich dinozaurów: {totalCount}");
            Console.WriteLine($"Mięsożernych: {carnivoreCount}");
            Console.WriteLine($"Roślinożernych: {herbivoreCount}");
            Console.WriteLine($"\nJedzenie dziennie:");
            Console.WriteLine($"Mięsożerne: {carnivoreFood}");
            Console.WriteLine($"Roślinożerne: {herbivoreFood}");
            Console.WriteLine($"Łącznie: {totalFood}");
            Console.WriteLine($"\n--- Gatunki mięsożerne ---");
            Console.WriteLine($"Liczba różnych gatunków: {carnivoreSpecies.Count}");
            foreach (var pair in carnivoreSpecies)
            {
                Console.WriteLine($"{pair.Key} – {pair.Value} sztuk");
            }
            Console.WriteLine($"\n--- Zasoby ---");
            Console.WriteLine($"Początkowa ilość jedzenia: {this.FoodStore}");
            Console.WriteLine($"Po ilu dniach zabraknie: {daysUntilFoodRunsOut}");
            Console.WriteLine("\nJurassic Console Park zakończył raport.\n");
        }

        public void GetAllSounds(List<Dinozaur> allDino)
            {
                foreach (var dino in allDino)
                {
                    Console.WriteLine($"\n{dino.Species}");

                    foreach (var name in dino.Names)
                    {
                        string sound = dino.Type == 'M' ? $"{name}: Raaaawr!" : $"{name}: Mniam liść!";
                        Console.WriteLine(" - " + sound);
                    }
                }
            }
        public static void AddHerbivorous<T>(char type, List<Dinozaur> allDino)
    where T : Enum
        {
            Console.WriteLine($"\nDostępne gatunki roślinożerne:");
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("- " + name);
            }
            while (true)
            {
                Console.WriteLine("\nWpisz nazwę gatunku:");
                string speciesInput = Console.ReadLine();

                if (Enum.TryParse(typeof(T), speciesInput, true, out object parsedEnum) &&
                    Enum.IsDefined(typeof(T), parsedEnum))
                {
                    T chosenSpecies = (T)parsedEnum;
                    Console.WriteLine("Wybrano gatunek: " + chosenSpecies);
                    Console.WriteLine("\nIle dinozaurów tego gatunku chcesz dodać?");

                    if (int.TryParse(Console.ReadLine(), out int numberDino) && numberDino > 0)
                    {
                        var dino = new HerbivorousDino((Herbivorous)(object)chosenSpecies)
                        {
                            Type = 'R',
                            Number = numberDino
                        };

                        for (int i = 1; i <= numberDino; i++)
                        {
                            Console.Write($"Podaj imię dla dinozaura #{i}: ");
                            string name = Console.ReadLine();
                            if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                                dino.Names.Add(name);
                        }
                        allDino.Add(dino);
                    }
                    break;
                }
                else Console.WriteLine("Niepoprawna nazwa gatunku.");
            }
        }
        public static void AddCarnivorous(char type, List<Dinozaur> allDino)
        {
            Console.WriteLine("Ile dinozaurów tego gatunku chcesz dodać?");
            if (int.TryParse(Console.ReadLine(), out int numberDino) && numberDino > 0)
            {
                var dino = new CarnivorousDino
                {
                    Type = 'M',
                    Number = numberDino
                };

                for (int i = 1; i <= numberDino; i++)
                {
                    Console.Write($"Podaj imię dla dinozaura #{i}: ");
                    string name = Console.ReadLine();
                    if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                        dino.Names.Add(name);
                }
                allDino.Add(dino);
            }
        }
    }
    }




