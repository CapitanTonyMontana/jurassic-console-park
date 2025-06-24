using JurassicConsolePark;
using JurassicConsolePark.Dinosaur;
class Program
{
    static void Main()
    {
        List<Dinozaur> allDino = new List<Dinozaur>();
        Park park = new Park();
        Console.WriteLine("WITAJ W PARKU JURAJSKIM!\n");
        char selectType = ' ';
        while (true)
        {
            Console.WriteLine("Wybierz rodzaj dinozaurów wpisując 'M' (Mięsożerne) lub 'R' (Roślinożerne):");
            string inputType = Console.ReadLine().Trim().ToUpper();
            if (inputType == "M" || inputType == "R")
            {
                selectType = inputType[0];
                break;
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór. Wpisz tylko 'M' lub 'R'.\n");
            }
        }
        if (selectType == 'R')
        {
            Park.AddHerbivorous<Herbivorous>('R', allDino);
            Console.WriteLine("\nCzy chcesz dodać również dinozaury mięsożerne? (T/N)");
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                Park.AddCarnivorous('M', allDino);
            }
        }
        else
        {
            Park.AddCarnivorous('M', allDino);
            Console.WriteLine("\nCzy chcesz dodać również dinozaury roślinożerne? (T/N)");
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                Park.AddHerbivorous<Herbivorous>('R', allDino);
            }
        }
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("A: Usłysz dźwięki dinozaurów");
            Console.WriteLine("B: Zagraj w zgadywanie (TryToGuess)");
            Console.WriteLine("C: Zakończ program");
            Console.Write("Wybierz opcję (A/B/C): ");
            string wybor = Console.ReadLine().Trim().ToUpper();
            switch (wybor)
            {
                case "A":
                    Console.WriteLine("\nWszystkie odgłosy dinozaurów:");
                    park.GetAllSounds(allDino);
                    break;

                case "B":
                    park.TryToGuess(allDino);
                    break;

                case "C":
                    Console.WriteLine("Do zobaczenia w Parku Jurajskim!");
                    return;

                default:
                    Console.WriteLine("Niepoprawna opcja. Wybierz A, B lub C.");
                    break;
            }
        }
    }
}


