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
        
        
    }
}



