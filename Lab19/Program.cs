using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public string Name { get; set; }
        public string Cpu { get; set; }
        public double Frequency { get; set; }
        public int Ram { get; set; }
        public int Hdd { get; set; }
        public int Gpu { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComp = new List<Computer>()
            {
                new Computer(){ Name="Lenovo IdeaCentre G5 14IMB05", Cpu="AMD Ryzen 5", Frequency=3.7, Ram=8, Hdd=256, Gpu=2, Cost=40000, Quantity=10},
                new Computer(){ Name="Lenovo IdeaCentre 5 14ARE05", Cpu="Intel Core i5", Frequency=2.9, Ram=16, Hdd=512, Gpu=6, Cost=79000, Quantity=10},
                new Computer(){ Name="ASUS G35CG-1170KF018T", Cpu="Intel Core i7", Frequency=3.6, Ram=32, Hdd=2000, Gpu=10, Cost=299000, Quantity=0},
                new Computer(){ Name="HP OMEN GT12-1003ur", Cpu="Intel Core i5", Frequency=2.6, Ram=16, Hdd=512, Gpu=8, Cost=129000, Quantity=3},
                new Computer(){ Name="ZET GAMING WARD H126", Cpu="AMD Ryzen 7", Frequency=3.8, Ram=32, Hdd=1000, Gpu=16, Cost=215000, Quantity=1},
                new Computer(){ Name="HP Pavilion TP01-2034ur", Cpu="AMD Ryzen 7", Frequency=3.8, Ram=16, Hdd = 256, Gpu=2, Cost=59000, Quantity=50},
                new Computer(){ Name="DEXP Aquilon O234", Cpu="Intel Celeron", Frequency=2, Ram=4, Hdd=120, Gpu=1, Cost=13000, Quantity=42},
                new Computer(){ Name="HP M01-F1067ur", Cpu="AMD Ryzen 5", Frequency=3.7, Ram=8, Hdd=128, Gpu=2, Cost=42000, Quantity=7},
                new Computer(){ Name="HP M01-F1066ur", Cpu="AMD Ryzen 5", Frequency=3.7, Ram=16, Hdd=128, Gpu=2, Cost=48000, Quantity=5},
            };

            #region 1
            Console.Write("Введите процессор:");
            string cpu = Console.ReadLine();
            List<Computer> comp = listComp
                        .Where(d => d.Cpu == cpu)
                        .ToList();

            Console.WriteLine($"Компьютеры с процессором {cpu}:");
            foreach (var d in comp)
            {
                Console.WriteLine($"{d.Name}");
            }
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region 2
            Console.Write("Введите объем ОЗУ:");
            int ram = Convert.ToInt32(Console.ReadLine());
            comp = listComp
                .Where(d => d.Ram >= ram)
                .ToList();
            Console.WriteLine($"Компьютеры с объемом ОЗУ не менее {ram}:");
            foreach (var d in comp)
            {
                Console.WriteLine($"{d.Name}");
            }
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region 3
            comp = listComp
                        .OrderBy(d => d.Cost)
                        .ToList();

            Console.WriteLine($"Cписок, отсортированный по увеличению стоимости:");
            foreach (var d in comp)
            {
                Console.WriteLine($"{d.Name} {d.Cpu} {d.Frequency} {d.Ram} {d.Hdd} {d.Gpu} {d.Cost} {d.Quantity}");
            }
            Console.ReadKey();
            Console.WriteLine();
            #endregion


            #region 4
            var cpuGroup = from c in listComp
                           group c by c.Cpu;

            foreach (var g in cpuGroup)
            {
                Console.WriteLine($"Компьютеры с процессором {g.Key}:");
                foreach (var n in g)
                    Console.WriteLine(n.Name);
                Console.WriteLine();
            }
            Console.ReadKey();
            #endregion

            #region 5
            var minCost = comp.First();
            var maxCost = comp.Last();
            Console.WriteLine($"Самый дорогой компьютер: {maxCost.Name} (Стоимость: {maxCost.Cost})");
            Console.WriteLine($"Самый бюджетный компьютер: {minCost.Name} (Стоимость: {minCost.Cost})");
            Console.ReadKey();
            Console.WriteLine();
            #endregion

            #region 6
            bool stock = listComp.Any(q => q.Quantity > 30);
            if (stock)
                Console.WriteLine("Есть хотя бы один компьютер в количестве не менее 30 штук");
            else
                Console.WriteLine("Нет ни одного компьютера в количестве не менее 30 штук");
            Console.ReadKey();
            #endregion
        }
    }
}
