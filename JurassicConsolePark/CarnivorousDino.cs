using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Carnivorous
{
    Tyrannosaurus,
    Velociraptor,
    Allosaurus
}
namespace Jurassic_Console_Park
{
    public class CarnivorousDino : Dinozaur
    {

        public override int Eat(int foodStore)
        {
            int consumption = Liczba * HowMuchEatPerDay;
            return foodStore - consumption;
        }

        public CarnivorousDino()


        {
            Random rand = new Random();
            HowMuchEatPerDay = rand.Next(8, 16);
        }

        public void WypiszInformacje()
        {
            Console.WriteLine($"\nMięsożerne dinozaury: {Gatunek} (ilość: {Liczba})");
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



