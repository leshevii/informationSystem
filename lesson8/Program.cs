using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace lesson8
{
    class MainClass
    {
        public static List<Department> parents = new List<Department>();
        public static int level = 0;

        /// <summary>
        /// Сериализует департамент
        /// </summary>
        /// <param name="dep">Экземляр структуры department</param>
        /// <param name="path">Путь к файлу</param>
        public static void SerializeDepartment(Department dep,string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Department));
            Stream st = new FileStream(path, FileMode.Create, FileAccess.Write);
            xml.Serialize(st, dep);
            st.Close();
        }
        public static void AddWorker(ref Department dep)
        {
            string fName, sName;
            double wage;
            byte   age;

            Console.WriteLine("Добавить Рабочего");
            Console.WriteLine("да/нет");
            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Введите имя");
                fName = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                sName = Console.ReadLine();
                Console.WriteLine("Введите з/п");
                wage = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите  возраст");
                age = Convert.ToByte(Console.ReadLine());

                dep.AddWorker(fName,sName,wage,age,dep.workers.Count);
            }
        }
        public static void Reorder(ref Department dep)
        {
            Console.WriteLine("Отсортировать рабочих по");
            Console.WriteLine("Имени    (0)");
            Console.WriteLine("Фамилии  (1)");
            Console.WriteLine("Зар.плате(2)");
            Console.WriteLine("Возраст  (3)");
            int num;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    Console.WriteLine("По возрастанию/убыванию 1/0");
                    num = Convert.ToInt32(Console.ReadLine());
                    dep.ReorderFName(num);
                    Console.WriteLine("Рабочие отсортированы");
                    break;
                case 1:
                    Console.WriteLine("По возрастанию/убыванию 1/0");
                    num = Convert.ToInt32(Console.ReadLine());
                    dep.ReorderSName(num);
                    Console.WriteLine("Рабочие отсортированы");
                    break;
                case 2:
                    Console.WriteLine("По возрастанию/убыванию 0/1");
                    num = Convert.ToInt32(Console.ReadLine());
                    dep.ReorderWage(num);
                    Console.WriteLine("Рабочие отсортированы");
                    break;
                case 3:
                    Console.WriteLine("По возрастанию/убыванию 0/1");
                    num = Convert.ToInt32(Console.ReadLine());
                    dep.ReorderWage(num);
                    Console.WriteLine("Рабочие отсортированы");
                    break;
            }
        }
        public static void EditWorker(ref Department dep)
        {
            string fName, sName;
            double wage;
            byte age;

            Console.WriteLine("Редактировать рабочего");
            Console.WriteLine("Введите индекс рабочего");
            int num = Convert.ToInt32(Console.ReadLine());

             if (0 <= num && num < dep.workers.Count)
            {
                Console.WriteLine("Введите имя");
                fName = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                sName = Console.ReadLine();
                Console.WriteLine("Введите зп");
                wage = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите возраст");
                age = Convert.ToByte(Console.ReadLine());

                dep.EditWorker(num, fName, sName, wage, age, num);
            }
        }
        public static void DeletWorker(ref Department dep)
        {
            if (dep.workers.Count != 0)
            {
                Console.WriteLine("Введите индекс рабочего");
                int ind = Convert.ToInt32(Console.ReadLine());

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
        public static void EditDepartment(ref Department dep)
        {
            Console.WriteLine("Введите новое название департамента");
            dep.Edit(Console.ReadLine());
        }
        public static void DeleteDepartment(ref Department dep)
        {
            Console.WriteLine("Введите индекс департамента для удаления");
            int index = 0;
            foreach(Department local in dep.departments)
            {
                Console.WriteLine($"Индекс({index++}) " + local.name);
            }
            int ind = Convert.ToInt32(Console.ReadLine());

            if (0 <= ind && ind < dep.departments.Count)
            {
                dep.DeleteDepartment(ind);
            }
            Console.WriteLine("Департамент удален");
        }
        public static void AddDepartment(ref Department dep)
        {
            Console.WriteLine("Добавить дочерний департамент в - " + dep.name);
            Console.WriteLine("да/нет");
            if (Console.ReadLine().ToLower() == "да")
            {                
                Console.WriteLine("Введите название дочернего департамента для "  + dep.name);
                Department localDep = new Department(Console.ReadLine());
                dep.AddDepartment(localDep);
                AddWorker(ref localDep);
                AddDepartment(ref localDep);

                Console.WriteLine("Добавить департамент для текущего: " + dep.name);
                Console.WriteLine("да/нет");
                if (Console.ReadLine() == "да")
                {
                    while (true)
                    {
                        Console.WriteLine("Введите название для департамента: " + dep.name);
                        dep.AddDepartment(Console.ReadLine());                        
                        Console.WriteLine("Продолжить ввод департаментов для текущего департамента: " + dep.name);
                        Console.WriteLine("да/нет");
                        if (Console.ReadLine().ToLower() != "да") break;
                    }
                }
            }                  
            
        }
        /// <summary>
        /// Осуществляет форматированный вывод дерева департаментов
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="depth"></param>
        public static void PrintDepartment(Department dep, int depth=1)
        {            
            for(int i = 0; i < depth; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|-"+dep.name);            
            Console.WriteLine();
            foreach (Department local in dep.departments)
            {
                PrintDepartment(local, depth + 4);
            }            
        }
        /// <summary>
        /// Выводит все дочерние департаменты текущего переданного Department
        /// </summary>
        /// <param name="dep">Текущий Department</param>
        public static void PrintNestedDepartments(Department dep)
        {
            if (dep.departments.Count != 0)
            {
                Console.WriteLine("Выберите департамент:");
                int i = 0;
                Console.WriteLine((i++) + $":Текущий Департамент: {{ {dep.name} }} выберите его если хотите просмотреть свединия по нему");
                foreach (Department d in dep.departments)
                {
                    Console.WriteLine((i++) + $":{d.name}");
                }
            }
            else
            {
                Console.WriteLine($"0:Текущий Департамент: {{ {dep.name} }} выберите его если хотите просмотреть свединия по нему");
            }
        }
        /// <summary>
        /// Формирует основное меню
        /// </summary>
        /// <param name="dep"></param>
        public static void InputUser(Department dep)
        {
            Console.WriteLine("------------------------------------------------------");
            PrintDepartment(dep);
            Console.WriteLine("------------------------------------------------------");
            PrintNestedDepartments(dep);

            int index = Convert.ToInt32(Console.ReadLine());
            if (index != 0)
            {
                level++;                
                parents.Add(dep);                
                InputUser(dep.departments[index - 1]);                
            }
            else
            {                
                Console.WriteLine("РАБОЧИЕ ДЕПАРТАМЕНТА: (" + dep.name+")");                
                if (dep.workers.Count == 0)
                {
                    Console.WriteLine("В ДЕПАРТАМЕНТЕ НЕТ РАБОЧИХ");                    
                }
                else
                {
                    Console.WriteLine("---------------------------------");
                    dep.PrintWorkers();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Удалить рабочего:      0");
                    Console.WriteLine("Редактироват рабочего: 1");
                    Console.WriteLine("Отсортировать рабочих: 8");
                }                
                Console.WriteLine("----------МЕНЮ----------");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Добавить рабочего:     2");
                Console.WriteLine("Добавить департамент:  3");
                Console.WriteLine("Удалить  департамент:  4");
                Console.WriteLine("Изменить департамент:  5");
                Console.WriteLine("Назад:                 6");
                Console.WriteLine("Главный департамент:   7");
                Console.WriteLine("Выйти:                 9");
                Console.WriteLine("------КОНЕЦ  МЕНЮ-------");                
                int ind = Convert.ToInt32(Console.ReadLine());
                switch (ind)
                {
                    case 0:
                        DeletWorker(ref dep);
                        InputUser(dep);
                        break;
                    case 1:
                        EditWorker(ref dep);
                        InputUser(dep);
                        break;
                    case 2:
                        AddWorker(ref dep);
                        InputUser(dep);
                        break;
                    case 3:
                        AddDepartment(ref dep);
                        InputUser(dep);
                        break;
                    case 4:
                        DeleteDepartment(ref dep);
                        InputUser(dep);
                        break;
                    case 5:
                        EditDepartment(ref dep);
                        InputUser(dep);
                        break;
                    case 6:
                        if (level != 0)
                        {
                            Department loc = parents[--level];
                            parents.RemoveAt(level);
                            InputUser(loc);
                        }
                        else
                        {
                            InputUser(dep);
                        }
                        break;
                    case 7:
                        for (int i = 1; i < parents.Count; i++)
                        {
                            parents.RemoveAt(i);
                        }
                        if(parents.Count != 0)
                            InputUser(parents[0]);
                        else
                            InputUser(dep);
                        break;
                    case 8:
                        Reorder(ref dep);
                        InputUser(dep);
                        break;
                }                
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Создайте Департамент:");
            Console.WriteLine("Задайте название Департамент:");

            Department dep = new Department(Console.ReadLine());            

            AddDepartment(ref dep);            
            InputUser(dep);
            Console.WriteLine("Серилизовать данные да/нет?");

            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Серилизовать данные в xml(0),json(1),в обоих форматах(2)?");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num==0)
                     SerializeDepartment(dep, Directory.GetCurrentDirectory() + "/uuu.xml");
                else if (num == 1)
                {
                    string json = JsonConvert.SerializeObject(dep);
                    File.WriteAllText(Directory.GetCurrentDirectory()+"/uuu.json",json);
                }
                else
                {
                    SerializeDepartment(dep, Directory.GetCurrentDirectory() + "/uuu.xml");
                    string json = JsonConvert.SerializeObject(dep);
                    File.WriteAllText(Directory.GetCurrentDirectory() + "/uuu.json", json);
                }
            }
        }
    }
}
