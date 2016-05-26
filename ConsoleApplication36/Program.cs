using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReference
{
    class Spravochnik
    {
        int nomer;
        string adress;
        string name;

        public override string ToString()
        {
            return String.Format("Абонент по имени:{0}\nзарегистрирован за номером:{1}\nпроживает по адресу:{2}", name, nomer, adress);
        }

        public Spravochnik(int n, string a, string na)
        {
            this.nomer = n;
            this.adress = a;
            this.name = na;
        }

        public bool Findname(Spravochnik sp)
        {
            return sp.name == name; ;
        }

        public bool Findnumber(Spravochnik sp)
        {
            return sp.nomer == nomer; ;
        }

        public bool Findadrees(Spravochnik sp)
        {
            return sp.adress == adress;
        }
    }

    class EntryMainPoint
    {
        public static void Main()
        {
            string selection;
            string command;
            int number;
            string name;
            string adress;

            List<Spravochnik> mylist = new List<Spravochnik>();

            Console.WriteLine("Консольный справочник с функциями\nудаление\nдобавления\nпоиска по адресу,имени,номеру");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nПродолжить и добавить абонента нажмите p\nВыйти e\n");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "p":
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Введите имя абонента:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            name = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Введите номер абонента:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            number = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Введите адрес абонента:");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            adress = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            mylist.Add(new Spravochnik(number, adress, name));

                            Console.WriteLine(@"Выберете дальнейшее действие
Найти c возможностью удаления
1:      по номеру 
2:      по адресу
3:      по имени
4:      Вернуться в главное меню");
                            command = Console.ReadLine();
                            switch (command)
                            {
                                case "1":
                                    Console.WriteLine("Введите номер абонента для поиска:");
                                    int nomer = int.Parse(Console.ReadLine());
                                    Spravochnik spp = new Spravochnik(nomer, "", "");
                                    Spravochnik sp = mylist.Find(new Predicate<Spravochnik>(spp.Findnumber));
                                    if (sp != null)
                                    {
                                        Console.WriteLine(sp);
                                        Console.WriteLine("Хотите его удалить?y/n");
                                        string remove = Console.ReadLine();
                                        switch (remove)
                                        {
                                            case "y":
                                                mylist.RemoveAll(new Predicate<Spravochnik>(spp.Findnumber));
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Абонент с таким номером не найден:");
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("Введите адресс абонента для поиска:");
                                    string adress1 = Console.ReadLine();
                                    Spravochnik spp1 = new Spravochnik(0, adress1, "");
                                    Spravochnik sp1 = mylist.Find(new Predicate<Spravochnik>(spp1.Findadrees));
                                    if (sp1 != null)
                                    {
                                        Console.WriteLine(sp1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Абонент с таким адресом не найден:");
                                    }
                                    break;

                                case "3":
                                    Console.WriteLine("Введите имя для поиска:");
                                    string names = Console.ReadLine();
                                    Spravochnik sppp = new Spravochnik(0, "", names);
                                    mylist.FindAll(new Predicate<Spravochnik>(sppp.Findname)).ForEach(delegate (Spravochnik s) { Console.WriteLine(s); });
                                    break;

                                default:
                                    ;
                                    break;
                            }

                        }
                        while (command != "4");
                        break;

                    case "e":

                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}