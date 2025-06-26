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
            Printer.Checkig();
            int totalDailyConsumption = allDino.Sum(d => d.Number * d.HowMuchEatPerDay);
            Printer.DailyEats(totalDailyConsumption);
            if (totalDailyConsumption == 0)
            {
                Printer.NoOneOfThemEat();
                return;
            }
            int daysUntilFoodRunsOut = this.FoodStore / totalDailyConsumption;
            Printer.Guess();
            int guess;
            do
            {
                Printer.YourAnswer();
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Printer.NotNumber();
                    continue;
                }
                if (guess < daysUntilFoodRunsOut)
                    Printer.ToLow();
                else if (guess > daysUntilFoodRunsOut)
                    Printer.ToMuch();
            }
            while (guess != daysUntilFoodRunsOut);
            Printer.Bravo();

            PrintSummary(allDino, daysUntilFoodRunsOut);
        }
        private void PrintSummary(List<Dinozaur> allDino, int daysUntilFoodRunsOut)
        {
            Printer.Summary();
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
            Printer.SUMS();
            Printer.AllDinoSums(totalCount);
            Printer.CarniSums(carnivoreCount);
            Printer.HerbiSums(herbivoreCount);
            Printer.DailyEats2();
            Printer.DailyCarniEats(carnivoreFood);
            Printer.DailyHerbiEats(herbivoreFood);
            Printer.Together(totalFood);
            foreach (var pair in carnivoreSpecies)
            {
                Printer.Count(pair);
            }
            Printer.Resources();
            Printer.InitialNumber(FoodStore);
            Printer.DaysUntilFood(daysUntilFoodRunsOut);
            Printer.End();
        }
        public void GetAllSounds(List<Dinozaur> allDino)
            {
                foreach (var dino in allDino)
              {
                Printer.Species(dino.Species);
                foreach (var name in dino.Names)
                 {
                    Printer.Sound(name, dino.Type);
                 }
              }
            }
        public static void AddHerbivorous<T>(char type, List<Dinozaur> allDino)
       where T : Enum
        {
            Printer.AvailableHerbi();
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("- " + name);
            }
            while (true)
            {
                Printer.SpeciesType();
                string speciesInput = Console.ReadLine();
                if (Enum.TryParse(typeof(T), speciesInput, true, out object parsedEnum) &&
                    Enum.IsDefined(typeof(T), parsedEnum))
                {
                    T chosenSpecies = (T)parsedEnum;
                    Printer.ChosenSpecies(chosenSpecies);
                    int numberDino;
                    while (true)
                    {
                        Printer.HowMany();
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out numberDino) && numberDino > 0)
                        {
                            break; 
                        }
                        else
                        {
                            Printer.IncorrectNumber();
                        }
                    }
                    var dino = new HerbivorousDino((Herbivorous)(object)chosenSpecies)
                    {
                        Type = 'R',
                        Number = numberDino
                    };
                    for (int i = 1; i <= numberDino; i++)
                    {
                        Printer.GiveName(i);
                        string name = Console.ReadLine();
                        if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                            dino.Names.Add(name);
                    }
                    allDino.Add(dino);
                    break;
                }
                else
                {
                    Printer.InccorrectSpecies();
                }
            }
        }
        public static void AddCarnivorous(char type, List<Dinozaur> allDino)
        {
            int numberDino;
            while (true)
            {
                Printer.HowManyCarni();
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberDino) && numberDino > 0)
                {
                    break; 
                }
                else
                {
                    Printer.IncorrectNumber();
                }
            }
            var dino = new CarnivorousDino
            {
                Type = 'M',
                Number = numberDino
            };
            for (int i = 1; i <= numberDino; i++)
            {
                Printer.GiveName(i);
                string name = Console.ReadLine();
                if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    dino.Names.Add(name);
            }
            allDino.Add(dino);
        }
    }
}




