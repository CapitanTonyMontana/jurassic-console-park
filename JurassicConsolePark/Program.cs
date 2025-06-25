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
                Printer.Incorrectchoice();
            }
        }
        if (selectType == 'R')
        {
            Park.AddHerbivorous<Herbivorous>('R', allDino);
            Printer.Addcarni();
            if (Console.ReadLine().Trim().ToUpper() == "T")
            {
                Park.AddCarnivorous('M', allDino);
            }
        }
        else
        {
            Park.AddCarnivorous('M', allDino);
            Printer.Addherbi();
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
                    Printer.Allsounds();
                    park.GetAllSounds(allDino);
                    break;

                case "B":
                    park.TryToGuess(allDino);
                    break;

                case "C":
                    Printer.Seeyou();
                    return;

                default:
                    Printer.Incorrectoption();
                    break;
            }
        }
    }
}


