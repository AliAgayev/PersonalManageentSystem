using PersonalManagamentSystem.DAL;
using PersonalManagamentSystem.Models;
using PersonalManagamentSystem.ServiceOperations;
using System;

namespace PersonalManagamentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //PersonalManager.AddPersonal();
            //WorkTimeManager.AddWorkTime();
            //PersonalManager.ShowPersonalForPosition();
            //  PersonalManager.DeletePersonal();
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("                       SORGULAMA PROQRAMI                  ");
            Console.WriteLine("1. Bir isci melumatlarinin gosterilmesi ");
            Console.WriteLine("2. Mueyyen bir vezifeye gore iscilerin melumatlarinin gosterilmesi");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("                       YENILEME PROQRAMI                  ");
            Console.WriteLine("3. Yeni iscinin elave edilmesi");
            Console.WriteLine("4. Isci melumatlarinin yenilenmesi");
            Console.WriteLine("5.Isci melumatlarinin silinmesi ");
            Console.WriteLine("6. Sistemden cixis");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");

            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    PersonalManager.ShowPersonal();
                    Menu();
                    break;
                case 2:
                    PersonalManager.ShowPersonalForPosition();
                    Menu();
                    break;
                case 3:
                    PersonalManager.AddPersonal();
                    Menu();
                    break;
                case 4:
                    //Manager<Model>.serviceCall();
                    //menu();
                    break;
                case 5:
                    PersonalManager.DeletePersonal();
                    Menu();
                    break;
                case 6:
                    return;
                default:
                    break;
            }
        }
    }
}
