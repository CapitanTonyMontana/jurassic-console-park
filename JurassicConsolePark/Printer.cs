

namespace JurassicConsolePark
{
    internal class Printer
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("WITAJ W PARKU JURAJSKIM!\n");
        }
        public static void ChooseType()
        {
            Console.WriteLine("Wybierz rodzaj dinozaurów wpisując 'M' (Mięsożerne) lub 'R' (Roślinożerne:");
        }
        public static void IncorrectChoice()
        {
            Console.WriteLine("Niepoprawny wybór. Wpisz tylko 'M' lub 'R'.\n");
        }
        public static void AddCarni()
        {
            Console.WriteLine("\nCzy chcesz dodać również dinozaury mięsożerne? (T/N)");
        }
        public static void AddHerbi()
        {
            Console.WriteLine("\nCzy chcesz dodać również dinozaury roślinożerne? (T/N)");
        }
        public static void Menu()
        {
            Console.WriteLine("\n--- MENU ---"); ;
        }
        public static void A()
        {
            Console.WriteLine("A: Usłysz dźwięki dinozaurów");
        }
        public static void B()
        {
            Console.WriteLine("B: Zagraj w zgadywanie (TryToGuess)");
        }
        public static void C()
        {
            Console.WriteLine("C: Zakończ program");
        }
        public static void ABC()
        {
            Console.Write("Wybierz opcję (A/B/C): ");
        }
        public static void AllSounds()
        {
            Console.WriteLine("\nWszystkie odgłosy dinozaurów:");
        }
        public static void SeeYou()
        {
            Console.WriteLine("Do zobaczenia w Parku Jurajskim!");
        }
        public static void IncorrectOption()
        {
            Console.WriteLine("Niepoprawna opcja. Wybierz A, B lub C.");
        }
        public static void Checkig()
        {
            Console.WriteLine("\n--- Sprawdzam wszystkie dinozaury ---");
        }
        public static void DailyEats(int totalDailyConsumption)
        {
            Console.WriteLine($"Dziennie jedzą = {totalDailyConsumption}");
        }
        public static void NoOneOfThemEat()
        {
            Console.WriteLine("Żaden dinozaur nie je – nie można obliczyć liczby dni.");
        }
        public static void Guess()
        {
            Console.WriteLine("\nZgadnij, po ilu dniach skończy się jedzenie!");
        }
        public static void YourAnswer()
        {
            Console.Write("Twoja odpowiedź: ");
        }
        public static void NotNumber()
        {
            Console.WriteLine("To nie jest liczba! Spróbuj jeszcze raz.");
        }
        public static void ToMuch()
        {
            Console.WriteLine("Za dużo!");
        }
        public static void ToLow()
        {
            Console.WriteLine("Za mało!");
        }
        public static void Bravo()
        {
            Console.WriteLine("Brawo! Zgadłeś!");
        }
        public static void Summary()
        {
            Console.WriteLine("\n--- PODSUMOWANIE DINOZAURÓW ---");
        }
        public static void SUMS()
        {
            Console.WriteLine($"\n--- SUMY ---");
        }
        public static void AllDinoSums(int totalCount)
        {
            Console.WriteLine($"Suma wszystkich dinozaurów: {totalCount}");
        }
        public static void CarniSums(int carnivoreCount)
        {
            Console.WriteLine($"Mięsożernych: {carnivoreCount}");
        }
        public static void HerbiSums(int herbivoreCount)
        {
            Console.WriteLine($"Roślinożernych: {herbivoreCount}");
        }
        public static void DailyEats2()
        {
            Console.WriteLine($"\nJedzenie dziennie:");
        }
        public static void DailyCarniEats(int carnivoreFood)
        {
            Console.WriteLine($"Mięsożerne: {carnivoreFood}");
        }
        public static void DailyHerbiEats(int herbivoreFood)
        {
            Console.WriteLine($"Roślinożerne: {herbivoreFood}");
        }
        public static void Together(int totalFood)
        {
            Console.WriteLine($"Łącznie: {totalFood}");
        }
        public static void Count(KeyValuePair<string, int> pair)
        {
            Console.WriteLine($"sztuk {pair.Key} – {pair.Value}");
        }
        public static void Resources()
        {
            Console.WriteLine($"\n--- Zasoby ---");
        }
        public static void InitialNumber(int FoodStorage)
        {
            Console.WriteLine($"Początkowa ilość jedzenia: {FoodStorage}");
        }
        public static void DaysUntilFood(int daysUntilFoodRunsOut)
        {
            Console.WriteLine($"Po ilu dniach zabraknie: {daysUntilFoodRunsOut}");
        }
        public static void End()
        {
            Console.WriteLine("\nJurassic Console Park zakończył raport.\n");
        }
        public static void Species(string species)
        {
            Console.WriteLine($"\n{species}");
        }
        public static void Sound(string name, char type)
        {
            string sound = type == 'M' ? $"{name}: Raaaawr!" : $"{name}: Mniam liść!";
            Console.WriteLine($" - {sound}");
        }
        public static void AvailableHerbi()
        {
            Console.WriteLine($"\nDostępne gatunki roślinożerne:");
        }
        public static void SpeciesType()
        {
            Console.WriteLine("\nWpisz nazwę gatunku:");
        }
        public static void ChosenSpecies<T>(T species) where T : Enum
        {
            Console.WriteLine($"Wybrano gatunek: {species}");
        }

        public static void HowMany()
        {
            Console.WriteLine("\nIle dinozaurów tego gatunku chcesz dodać?:");
        }

        public static void IncorrectNumber()
        {
            Console.WriteLine("Niepoprawna liczba. Podaj dodatnią liczbę całkowitą.");
        }

        public static void InccorrectSpecies()
        {
            Console.WriteLine("Niepoprawna nazwa gatunku.");
        }
        public static void HowManyCarni()
        {
            Console.WriteLine("Ile dinozaurów tego rodzaju chcesz dodać?:");
        }
        public static void GiveName(int i)
        {
             Console.Write($"Podaj imię dla dinozaura #{i}: ");        
        }
    }
}

