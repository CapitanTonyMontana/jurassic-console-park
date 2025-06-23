using System.Text.RegularExpressions;

namespace JurassicConsolePark.Dinosaur
{
    public class CarnivorousDino : Dinozaur
    {
        public CarnivorousDino()
        {
            Type = 'M';
           
            Random rand = new Random();
            HowMuchEatPerDay = rand.Next(8, 16);

        }
        protected override int CountDailyComsumption()
        {
            return base.CountDailyComsumption()* 3;
        }
        public static void DodajMiesozerne(char rodzaj, List<Dinozaur> wszystkieDino)
        {
            Console.WriteLine("Ile dinozaurów tego gatunku chcesz dodać?");
            if (int.TryParse(Console.ReadLine(), out int liczbaDino) && liczbaDino > 0)
            {
                var dino = new CarnivorousDino
                {
                    Type = 'M',
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
        }
        
    }
}



