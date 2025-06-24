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
        public void TryToGuess(List<Dinozaur> wszystkieDino)
        {
            Console.WriteLine("\n--- Sprawdzam wszystkie dinozaury ---");
            int totalDailyConsumption = wszystkieDino.Sum(d => d.Number * d.HowMuchEatPerDay);
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

            WypiszPodsumowanie(wszystkieDino, daysUntilFoodRunsOut);
        }
            private void WypiszPodsumowanie(List<Dinozaur> wszystkieDino, int daysUntilFoodRunsOut) 
        {
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

                    if (dino is HerbivorousDino roslinozerny)
                    {
                        roslinozerny.PokazKolorLisci();
                        sumaRoslinozernych += dino.Number;
                        jedzenieRoslinozerne += dino.Number * dino.HowMuchEatPerDay * 2;
                    }
                    else
                    {
                        sumaMiesozernych += dino.Number;
                        jedzenieMiesozerne += dino.Number * dino.HowMuchEatPerDay * 3;

                        if (!miesozerneGatunki.ContainsKey(dino.Species))
                            miesozerneGatunki[dino.Species] = dino.Number;
                        else
                            miesozerneGatunki[dino.Species] += dino.Number;
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
                Console.WriteLine("\nJurassic Console Park zakończył raport.\n");
        }

            public void GetAllSounds(List<Dinozaur> wszystkieDino)
            {

                foreach (var dino in wszystkieDino)
                {
                    Console.WriteLine($"\n{dino.Species}");

                    foreach (var imie in dino.Imiona)
                    {
                        string odglos = dino.Type == 'M' ? $"{imie}: Raaaawr!" : $"{imie}: Mniam liść!";
                        Console.WriteLine(" - " + odglos);
                    }
                }
            }
        }
    }




