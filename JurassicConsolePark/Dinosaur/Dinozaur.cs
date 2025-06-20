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




        public virtual int Eat(int foodStore)
        {
            int consumption = Number * HowMuchEatPerDay;
            return foodStore - consumption;
        }

        public void WypiszInformacje()
        {
            Console.WriteLine("\nPodsumowanie:");
            Console.WriteLine($"Rodzaj: {(Type == 'R' ? "Roślinożerny" : "Mięsożerny")}");
            Console.WriteLine($"Gatunek: {Species}");
            Console.WriteLine($"Liczba: {Number}");
            Console.WriteLine($"Imie: {Name}");
        }

        public void GetSound()
        {
            Console.WriteLine($"{Name} Raaawr!");
        }
    }
}
