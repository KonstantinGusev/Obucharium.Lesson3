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
                            Console.WriteLine("\nВведите количество абонентов которое вы собираетесь ввести\n");
                            int a = int.Parse(Console.ReadLine());
                            for (int i=0; i < a; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("\nВведите имя абонента:\n");

                                name = Console.ReadLine();
                                name = name.ToUpper();

                                Console.WriteLine("\nВведите номер абонента:\n");
                                
                                number = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("\nВведите адрес абонента:\n");

                                adress = Console.ReadLine();
                                adress = adress.ToUpper();
                                mylist.Add(new Spravochnik(number, adress, name));

                                foreach (object g in mylist)
                                {
                                    Console.WriteLine("\n"+g);
                                }
                            }
                            

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@"Выберете дальнейшее действие
Найти c возможностью удаления
1:      по номеру 
2:      по адресу
3:      по имени
4:      добавить еще абонентов
5:      Вернуться в главное меню");
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
                                    Console.WriteLine("Введите адрес абонента для поиска:");
                                    string adress1 = Console.ReadLine();
                                    adress1 = adress1.ToUpper();
                                    Spravochnik spp1 = new Spravochnik(0, adress1, "");
                                    Spravochnik sp1 = mylist.Find(new Predicate<Spravochnik>(spp1.Findadrees));

                                    if (sp1 != null)
                                    {
                                        Console.WriteLine(sp1);
                                        Console.WriteLine("Хотите его удалить?y/n");
                                        
                                        string remove = Console.ReadLine();

                                        switch (remove)
                                        {
                                            case "y":
                                                mylist.RemoveAll(new Predicate<Spravochnik>(spp1.Findnumber));
                                                break;
                                        }
                                    }
                                    else {
                                        Console.WriteLine("Абонент с таким адресом не найден:");
                                            }
                                    break;
                                   

                                case "3":
                                    Console.WriteLine("Введите имя для поиска:");
                                    string names = Console.ReadLine();
                                    names = names.ToUpper();
                                    Console.WriteLine(names);
                                    Spravochnik sppp = new Spravochnik(0, "", names);
                                    mylist.FindAll(new Predicate<Spravochnik>(sppp.Findname)).ForEach(delegate (Spravochnik s) { Console.WriteLine(s); });
                                    if (sppp != null)
                                    {
                                        Console.WriteLine(sppp);
                                        Console.WriteLine("Хотите его удалить?y/n");

                                        string remove = Console.ReadLine();

                                        switch (remove)
                                        {
                                            case "y":
                                                mylist.RemoveAll(new Predicate<Spravochnik>(sppp.Findnumber));
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Абонент с таким адресом не найден:");
                                    }
                                    break;

                                default:
                                    ;
                                    break;
                            }

                        }
                        while (command != "5");
                        break;

                    case "e":

                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}