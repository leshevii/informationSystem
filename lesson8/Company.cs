using System;
using System.Collections.Generic;
namespace lesson8
{
    public class Company
    {
        /// <summary>
        /// название компании
        /// </summary>
        public string name;
        /// <summary>
        /// списко департаментов
        /// </summary>
        public List<Department> departments;

        public Company(string name)
        {
            this.name = name;
            departments = new List<Department>();
        }
        /// <summary>
        /// Возвращает департамент по индексу
        /// <br></br>
        /// в противном случае если нет департаментов
        /// <br></br>
        /// возвращаеться пустой департамент
        /// </summary>
        /// <param name="index">индекс департамента</param>
        /// <returns></returns>
        public Department GetDepartmentById(int index)
        {
            if(0<=index && index < departments.Count)
            {                
                return departments[index];
            }                                   
            return new Department();
        }
        /// <summary>
        /// Печать департаментов с учетом уровня их влаженнности
        /// </summary>
        /// <param name="dep">департамент(экземпляр)</param>
        /// <param name="depth">уровень вложенности(использую для отступов)</param>
        public static void PrintDepartment(Department dep, int depth = 1)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|-" + dep.name);
            Console.WriteLine();
            foreach (Department local in dep.departments)
            {
                PrintDepartment(local, depth + 4);
            }
        }
        /// <summary>
        /// добовляет департамент только инициализируя его название
        /// </summary>
        /// <param name="name">название департамента</param>
        public void AddDepartment(string name)
        {
            departments.Add(new Department(name));
        }
        /// <summary>
        /// удаляет департамент по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        public void DeleteDepartment(int index)
        {
            departments.RemoveAt(index);
        }
        /// <summary>
        /// печатает структуру компании 
        /// </summary>
        public void PrintStructureCompany()
        {            
            foreach(Department dep in departments)
            {
                PrintDepartment(dep);
            }
        }
        /// <summary>
        /// печать вложенных департаментов
        /// </summary>
        /// <param name="dep"></param>
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
        /// печать департаментов для компании
        /// </summary>
        public void PrintDepartmentsForCurrent()
        {
            if (departments.Count != 0)
            {
                Console.WriteLine("Выберите департамент:");
                int i = 0;
                Console.WriteLine($"Компания: {{ {name} }}");
                foreach (Department d in departments)
                {
                    Console.WriteLine((i++) + $":{d.name}");
                }
            }            
        }
    }
}
