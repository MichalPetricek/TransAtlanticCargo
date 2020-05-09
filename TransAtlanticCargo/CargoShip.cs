using System;
using System.Collections.Generic;
using System.Text;

namespace TransAtlanticCargo
{
    class CargoShip
    {
        public CargoShip(int containerPrice = 50, int loadPrice = 1, double loadWastePercent = 0.5)
        {
            ContainerPrice = containerPrice;
            LoadPrice = loadPrice;
            LoadWastePercent = loadWastePercent;
        }
        public int ContainerPrice { get; protected set; }
        public int LoadPrice { get; protected set; }
        public double LoadWastePercent { get; protected set; }
        public List<int> _containerAmmount = new List<int>();
        public string Output { get; protected set; }
        public int Counter { get; protected set; }
        public int RealAmmount { get; protected set; }
        public double VolumePrice { get; protected set; }
        public string Register(int item)
        {
            if (item <= 1000 && item >= 1)
            {
                _containerAmmount.Add(item);
                return item + "t container registered...";
            }
            else
            {
                return item + "t container cannot be registered...";
            }
        }
        
        public int FixedPrice 
        {
            get
            {
                return ContainerPrice * RealAmmount;
            }
        }
        public bool Load(int cargoWeight)
        {
            if (cargoWeight > 0)
            {
                _containerAmmount.Sort();
                _containerAmmount.Reverse();
                while (cargoWeight > 0)
                {
                    for (int i = 0; i < _containerAmmount.Count; i++)
                    {
                        Counter = 0;
                        while (cargoWeight >= _containerAmmount[i])
                        {
                            cargoWeight = cargoWeight - _containerAmmount[i];
                            VolumePrice += _containerAmmount[i] * LoadPrice;
                            Counter++;
                        }
                        if (Counter > 0)
                        {
                            Output += Counter + "x " + _containerAmmount[i] + " t container \n";
                        }
                        RealAmmount += Counter;
                    }
                    break;
                }
                if (cargoWeight > 0)
                {
                    Output += "1x " + _containerAmmount[_containerAmmount.Count - 1] + " t container not fully loaded \n";
                    VolumePrice += cargoWeight * LoadPrice;
                    VolumePrice += (_containerAmmount[_containerAmmount.Count - 1] - cargoWeight) * LoadWastePercent;
                    RealAmmount++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public double TotalPrice
        {
            get
            {
                return VolumePrice + FixedPrice;
            }
        }

        public override string ToString()
        {
            return "Cargo roster: \n" + Output;
        }
    }
}