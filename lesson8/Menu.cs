using System;
namespace lesson8
{
    /// <summary>
    /// Класс реализует интерфейс консольного приложения
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// предаставляет интерфес для ввода названия
        /// </summary>
        /// <param name="txt">Строка которая используется в приветсвенном меню(название компании, департамента)</param>
        /// <returns></returns>
        public static string Input(string txt)
        {
            Console.WriteLine($"Введите название {txt}");
            var str = Console.ReadLine();
            while (String.IsNullOrEmpty(str))
            {
                Console.WriteLine($"Название {txt} не может быть не заполненно");
                Console.WriteLine($"Введите название {txt}");
                str = Console.ReadLine();
            }
            return str;
        }
        /// <summary>
        /// Считывет данные в корректом формате для типа int                
        /// </summary>
        /// <returns></returns>
        public static int    InputUser()
        {            
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Введен неверный формат");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Введенное число выходит за рамки допустимого");
            }
            return -1;
        }
        /// <summary>
        /// Считывает данные в корректом формате для double
        /// </summary>
        /// <returns></returns>
        public static double InputWage()
        {
            while (true)
            {                
                try
                {
                    var wage = Convert.ToDouble(Console.ReadLine());
                    return wage;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введен неверный формат");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Введенное число выходит за рамки допустимого");
                }
            }
            return -1;
        }
        /// <summary>
        /// Считывает данные в корректом формате для byte
        /// </summary>
        /// <returns></returns>
        public static byte   InputAge()
        {
            while (true)
            {                
                try
                {
                    var age = Convert.ToByte(Console.ReadLine());
                    return age;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введен неверный формат");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Введенное число выходит за рамки допустимого");
                }
            }
            return 0;
        }
        /// <summary>
        /// Выводит преветственное меню
        /// </summary>
        /// <returns></returns>
        public static bool   Start()
        {
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("У вас нет компании для дальнейшей работы создайте компанию: ");
            Console.WriteLine("Создать Компанию ? да/нет");

            if (Console.ReadLine().ToLower() == "да") return true;
            else
            {
                Console.WriteLine("Конец");
                return false;
            }
        }
        /// <summary>
        /// Интерфейс для удаления департаментов в конкретном департаменте
        /// </summary>
        /// <param name="dep"></param>
        public static void   DeleteDepartment(ref Department dep)
        {
            
            if (dep.departments.Count != 0)
            {
                Console.WriteLine("Введите индекс департамента для удаления");
                int index = 0;
                foreach (Department local in dep.departments)
                {
                    Console.WriteLine($"Индекс({index++}) " + local.name);
                }
                int ind;
                while (true)
                {
                    ind = InputUser();
                    if (ind != -1) break;
                }

                if (0 <= ind && ind < dep.departments.Count)
                {
                    dep.DeleteDepartment(ind);
                }
                Console.WriteLine("Департамент удален");
            }
            else
            {
                Console.WriteLine("Нет вложенных департаментов для удаления");
            }
        }
        /// <summary>
        /// Интерфейс для удаления департаментов в компании
        /// </summary>
        /// <param name="company"></param>
        public static void   DeleteDepartment(ref Company company)
        {
            if (company.departments.Count != 0)
            {
                Console.WriteLine($"Введите индекс департамента для удаления в компании:{company.name}");
                int index = 0;
                foreach (Department local in company.departments)
                {
                    Console.WriteLine($"Индекс({index++}) " + local.name);
                }
                int ind;
                while (true)
                {
                    ind = InputUser();
                    if (ind != -1) break;
                }

                if (0 <= ind && ind < company.departments.Count)
                {
                    company.DeleteDepartment(ind);
                }
                Console.WriteLine("Департамент удален");
            }
            else
            {
                Console.WriteLine("В компании нет департаментов");
            }
        }
        /// <summary>
        /// Интерфейс для изменения департамента
        /// </summary>
        /// <param name="dep"></param>
        public static void   EditDepartment(ref Department dep)
        {
            Console.WriteLine("Введите новое название департамента " + dep.name);
            dep.Edit(Console.ReadLine());
            Console.WriteLine("Новое название департамента " + dep.name);
        }
        /// <summary>
        /// интерфейс для добавления рабочего в  департамент
        /// </summary>
        /// <param name="dep"></param>
        public static void   AddWorker(ref Department dep)
        {
            string fName, sName;
            double wage;
            byte age;

            Console.WriteLine("Заполните данные об рабочем");
            Console.WriteLine("Введите имя");
            fName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            sName = Console.ReadLine();
            Console.WriteLine("Введите з/п");
            wage = InputWage();
            Console.WriteLine("Введите  возраст");
            age = InputAge();
            dep.AddWorker(fName, sName, wage, age, dep.workers.Count);
        }
        /// <summary>
        /// интерфейс сортировки рабочих
        /// </summary>
        /// <param name="dep"></param>
        public static void   Reorder(ref Department dep)
        {
            if (dep.workers.Count == 0)
            {
                Console.WriteLine("Нет рабочих для сортировки");
            }
            else
            {
                dep.PrintWorkers();
                Console.WriteLine("Отсортировать рабочих по");
                Console.WriteLine("Имени    (0)");
                Console.WriteLine("Фамилии  (1)");
                Console.WriteLine("Зар.плате(2)");
                Console.WriteLine("Возраст  (3)");
                int num;
                switch (InputUser())
                {
                    case 0:
                        Console.WriteLine("По возрастанию/убыванию 1/0");
                        num = InputUser();
                        dep.ReorderFName(num);
                        Console.WriteLine("Рабочие отсортированы");
                        break;
                    case 1:
                        Console.WriteLine("По возрастанию/убыванию 1/0");
                        num = InputUser();
                        dep.ReorderSName(num);
                        Console.WriteLine("Рабочие отсортированы");
                        break;
                    case 2:
                        Console.WriteLine("По возрастанию/убыванию 0/1");
                        num = InputUser();
                        dep.ReorderWage(num);
                        Console.WriteLine("Рабочие отсортированы");
                        break;
                    case 3:
                        Console.WriteLine("По возрастанию/убыванию 0/1");
                        num = InputUser();
                        dep.ReorderWage(num);
                        Console.WriteLine("Рабочие отсортированы");
                        break;
                }
            }
        }
        /// <summary>
        /// интерфейс редактирования рабочих
        /// </summary>
        /// <param name="dep"></param>
        public static void   EditWorker(ref Department dep)
        {
            if (dep.workers.Count == 0)
            {
                Console.WriteLine("Нет рабочих для редактирования");
            }
            else
            {

                string fName, sName;
                double wage;
                byte age;
                dep.PrintWorkers();
                Console.WriteLine("Редактировать рабочего");
                Console.WriteLine("Введите индекс рабочего");
                int num = InputUser();

                if (0 <= num && num < dep.workers.Count)
                {
                    Console.WriteLine("Введите имя");
                    fName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию");
                    sName = Console.ReadLine();
                    Console.WriteLine("Введите зп");
                    wage = InputWage();
                    Console.WriteLine("Введите возраст");
                    age = InputAge();

                    dep.EditWorker(num, fName, sName, wage, age, num);
                }
            }
        }
        public static void   DeletWorker(ref Department dep)
        {            
            if (dep.workers.Count != 0)
            {
                dep.PrintWorkers();
                Console.WriteLine("Введите индекс рабочего");
                int ind = InputUser();

                if (dep.DeleteWorker(ind))
                {
                    Console.WriteLine("Рабочий удален");
                }
            }
            else
            {
                Console.WriteLine("В данном подразделение нет рабочих");
            }
        }        

        /// <summary>
        /// интерфейс меню для отдельно выбранного департамента
        /// </summary>
        /// <param name="department"></param>
        public static void   PrintMainForOneDepartment(ref Department department)
        {            
            Company.PrintDepartment(department);
            Company.PrintNestedDepartments(department);
            Console.WriteLine("!!! ---------------------ВНИМАНИЕ -------------------- !!!");            
            Console.WriteLine("Выбрать дочерний департамент или работать с текущим да/нет");            
            Console.WriteLine("!!! ---------------------ВНИМАНИЕ -------------------- !!!");
            if (Console.ReadLine().ToLower() == "да")
            {
                if (department.departments.Count != 0)
                {
                    int n;
                    while (true)
                    {
                        Console.WriteLine("Введите индекст департамента");
                        n = InputUser() - 1;

                        if (0 <= n && n <= department.departments.Count) break;
                    }
                    var d = department.FindDepartment(n);
                    PrintMainForOneDepartment(ref d);
                    department.departments[n] = d;
                }
                else
                {
                    Console.WriteLine("В департаменте нет дочерних департаментов");
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("----------МЕНЮ----------");
                    Console.WriteLine("Удалить рабочего:      0");
                    Console.WriteLine("Редактироват рабочего: 1");
                    Console.WriteLine("Отсортировать рабочих: 2");
                    Console.WriteLine("Добавить рабочего:     3");
                    Console.WriteLine("Добавить департамент:  4");
                    Console.WriteLine("Удалить  департамент:  5");
                    Console.WriteLine("Изменить департамент:  6");                    
                    Console.WriteLine("На главную:            8");
                    Console.WriteLine("------КОНЕЦ  МЕНЮ-------");

                    var numU = InputUser();
                    if (numU == 8) break;
                    if (numU != -1)
                    {
                        switch (numU)
                        {
                            case 0:
                                DeletWorker(ref department);
                                break;
                            case 1:
                                EditWorker(ref department);
                                break;
                            case 2:
                                Reorder(ref department);
                                break;
                            case 3:
                                AddWorker(ref department);
                                break;
                            case 4:
                                department.AddDepartment(Input("Департамента"));
                                break;
                            case 5:
                                DeleteDepartment(ref department);
                                break;
                            case 6:
                                EditDepartment(ref department);
                                break;                            
                        }
                    }
                }
            }
        }
        /// <summary>
        /// интерфейс основного меню
        /// </summary>
        public static void   PrintMainMenu()
        {
            Console.WriteLine("----------МЕНЮ-----------");
            Console.WriteLine("Выбрать  департамент:  1");
            Console.WriteLine("Добавить департамент:  2");
            Console.WriteLine("Удалит  деп компании:  3");
            Console.WriteLine("Выйти:                 0");
            Console.WriteLine("------КОНЕЦ  МЕНЮ-------");
        }
        /// <summary>
        /// Меню реализует возможность выбора департамента
        /// </summary>
        /// <param name="company"></param>
        public static void   PrintMenuSelectDepart(ref Company company)
        {
            if (company.departments.Count == 0)
            {
                Console.WriteLine("В компании нету департаментов, необходимо создать департамент");
            }
            else
            {
                Console.WriteLine("Структура компании");
                company.PrintStructureCompany();                
                company.PrintDepartmentsForCurrent();

                int num = InputUser();
                if (num != -1)
                {
                    Department t = company.GetDepartmentById(num);
                    if (!String.IsNullOrEmpty(t.name))
                    {                        
                        PrintMainForOneDepartment(ref t);
                        company.departments[num] = t;
                    }
                }
            }
        }

    }
}
