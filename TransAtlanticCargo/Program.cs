using System;
using static System.Console;

namespace TransAtlanticCargo
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.Default;

            CargoShip cargo1 = new CargoShip(50, 1, 0.5);


            foreach (var weight in new int[] { 850, 400, 250, 50, 10 })
                WriteLine(cargo1.Register(weight));

            int cargoWeight = 3733; //načtení dat od např. uživatele

            WriteLine($"\nTotal cargo weight: {cargoWeight} tonnes.");

            Write("I am loading a container ship... ");

            if (cargo1.Load(cargoWeight)) WriteLine("Loading complete!");
            else WriteLine("Loading failed!");

            WriteLine("Request to print the roster received...");
            WriteLine(cargo1);

            Write($"*Receipt* Fixed price: €{cargo1.FixedPrice}; ");
            Write($"Volume price: €{cargo1.VolumePrice}; ");
            WriteLine($"Total cost: €{cargo1.FixedPrice + cargo1.VolumePrice}");
        }
    }
}
