using System;
using System.IO;
namespace lesson8
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            if (Menu.Start())
            {
                var name = Menu.Input("Компании");
                int num = 0;
                Company company = new Company(name);
                while (true)
                {
                    Menu.PrintMainMenu();
                    if ((num = Menu.InputUser()) != -1)
                    {
                        switch (num)
                        {
                            case 1:
                                Menu.PrintMenuSelectDepart(ref company);
                                break;
                            case 2:
                                company.AddDepartment(Menu.Input("Департамента"));
                                Console.WriteLine("Компания: " + company.name);
                                Console.WriteLine("Департаменты: ");
                                company.PrintStructureCompany();
                                break;
                            case 3:
                                Menu.DeleteDepartment(ref company);
                                break;
                        }

                        if (num == 0) break;
                    }
                    else
                    {
                        Console.WriteLine("Введите число заново");
                    }

                }

                Console.WriteLine("Сериализавоть данные да/нет");
                if(Console.ReadLine().ToLower().Trim() == "да")
                {
                    DepartmentFile.SerializeCompanyXml(company.departments, Directory.GetCurrentDirectory() + "/uuu.xml");
                    DepartmentFile.SerializeCompanyJson(company.departments, Directory.GetCurrentDirectory() + "/uuu.json");

                    Console.WriteLine("Данные успешно сериализованны");
                    Console.WriteLine(Directory.GetCurrentDirectory() + "/uuu.xml");
                    Console.WriteLine(Directory.GetCurrentDirectory() + "/uuu.json");
                    Console.ReadKey();                    
                }
            }
        }
    }
}
