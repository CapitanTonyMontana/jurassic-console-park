namespace JurassicConsolePark.Dinosaur
{
    public class Carnivorous : Dinozaur
    {
        public CarnivorousBreed Breed { get; set; }
        
        public Carnivorous()
        {
            Random rand = new Random();
            HowMuchEatPerDay = rand.Next(8, 16);
        }

        public void WypiszInformacje()
        {
            Console.WriteLine($"\nMięsożerne dinozaury: {Species} (ilość: {Number})");
            Console.WriteLine("Imiona:");
            foreach (var imie in Imiona)
            {
                Console.WriteLine($"- {imie}");
            }
        }

        public void GetSound()
        {
            Console.WriteLine("Raaaawr! ");
        }
    }
}



