using JurassicConsolePark;
using JurassicConsolePark.Dinosaur;
class Program
{
    static void Main()
    {
        List<Dinozaur> allDino = new List<Dinozaur>();
        Park park = new Park();
        Printer.PrintWelcome();
        char selectType = ' ';
        while (true)
        {
            Printer.ChooseType();
            string inputType = Console.ReadLine().Trim().ToUpper();
            if (inputType == "M" || inputType == "R")
            {
                selectType = inputType[0];
                break;
            }
            else
            {
                Printer.IncorrectChoice();
            }
        }
        if (selectType == 'R')
        {
            Park.AddHerbivorous<Herbivorous>('R', allDino);
            Printer.AddCarni();
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                Park.AddCarnivorous('M', allDino);
            }
        }
        else
        {
            Park.AddCarnivorous('M', allDino);
            Printer.AddHerbi();
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                Park.AddHerbivorous<Herbivorous>('R', allDino);
            }
        }
        while (true)
        {
            Printer.Menu();
            Printer.A();
            Printer.B();
            Printer.C();
            Printer.ABC();
            string choice = Console.ReadLine().Trim().ToUpper();
            switch (choice)
            {
                case "A":
                    Printer.AllSounds();
                    park.GetAllSounds(allDino);
                    break;

                case "B":
                    park.TryToGuess(allDino);
                    break;

                case "C":
                    Printer.SeeYou();
                    return;

                default:
                    Printer.IncorrectOption();
                    break;
            }
        }
    }
}


