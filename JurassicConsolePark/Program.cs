using JurassicConsolePark;
using JurassicConsolePark.Dinosaur;
using System;
using System.Text.RegularExpressions;



class Program
{
    static void Main()
    {
        List<Dinozaur> wszystkieDino = new List<Dinozaur>();
        Park park = new Park();
        Console.WriteLine("WITAJ W PARKU JURAJSKIM!\n");
        char wyborRodzaju = ' ';
        while (true)
        {
            Console.WriteLine("Wybierz rodzaj dinozaurów wpisując 'M' (Mięsożerne) lub 'R' (Roślinożerne):");
            string inputRodzaju = Console.ReadLine().Trim().ToUpper();
            if (inputRodzaju == "M" || inputRodzaju == "R")
            {
                wyborRodzaju = inputRodzaju[0];
                break;
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór. Wpisz tylko 'M' lub 'R'.\n");
            }
        }

        if (wyborRodzaju == 'R')
        {
            HerbivorousDino.DodajRoslinozerne<Herbivorous>('R', wszystkieDino);
            Console.WriteLine("\nCzy chcesz dodać również dinozaury mięsożerne? (T/N)");
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                CarnivorousDino.DodajMiesozerne('M', wszystkieDino);
            }
        }
        else
        {
            CarnivorousDino.DodajMiesozerne('M', wszystkieDino);
            Console.WriteLine("\nCzy chcesz dodać również dinozaury roślinożerne? (T/N)");
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                HerbivorousDino.DodajRoslinozerne<Herbivorous>('R', wszystkieDino);
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
                    park.GetAllSounds(wszystkieDino);
                    break;

                case "B":
                    park.TryToGuess(wszystkieDino);
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


