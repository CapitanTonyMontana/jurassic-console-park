namespace JurassicConsolePark.Dinosaur
{
    public abstract class Dinozaur
    {
        public string Name { get; set; }
        public char Type { get; set; }
        public string Species { get; set; }
        public int Number { get; set; }
        public int HowMuchEatPerDay { get; set; }
        public List<string> Imiona { get; set; } = new List<string>();
       
        public virtual int DailyComsumption => HowMuchEatPerDay * Number;
        
        protected virtual int CountDailyComsumption()
        {
            return Number * HowMuchEatPerDay;
        }
        public virtual int Eat(int foodStore)
        {
            int consumption = Number * HowMuchEatPerDay;
            return foodStore - consumption;
        }       
    }
}
