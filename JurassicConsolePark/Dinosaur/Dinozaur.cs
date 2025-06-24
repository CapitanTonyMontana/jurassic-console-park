namespace JurassicConsolePark.Dinosaur
{
    public abstract class Dinozaur
    {
        public string Species { get; set; }
        public List<string> Imiona { get; set; } = new List<string>();
        public string Name { get; set; }
        public char Type { get; set; }
        public int Number { get; set; }
        public int HowMuchEatPerDay { get; set; }
        protected virtual int CountDailyComsumption()
        {
            return Number * HowMuchEatPerDay;
        }
              
    }
}
