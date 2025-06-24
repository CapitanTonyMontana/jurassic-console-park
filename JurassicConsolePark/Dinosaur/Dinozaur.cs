namespace JurassicConsolePark.Dinosaur
{
    public abstract class Dinozaur
    {
        public string Species { get; set; } = string.Empty;
        public List<string> Names { get; set; } = new List<string>();
  
        public char Type { get; set; }
        public int Number { get; set; }
        public int HowMuchEatPerDay { get; set; }
        protected virtual int CountDailyComsumption()
        {
            return Number * HowMuchEatPerDay;
        }
              
    }
}
