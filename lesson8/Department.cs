using System;
using System.Collections.Generic;
namespace lesson8
{
    public struct Department
    {
        /// <summary>
        /// название департамента
        /// </summary>
        public string name;
        /// <summary>
        /// дата создания
        /// </summary>
        public DateTime created;
        /// <summary>
        /// коллекция дочерних департаментов
        /// </summary>
        public List<Department> departments;
        /// <summary>
        /// рабочие
        /// </summary>
        public List<Worker>     workers;
        
        public int Count { get;  set; }        

        public Department(string name) : this(name, new List<Department>(), new List<Worker>()) { }
        public Department(string name, List<Worker> workers) : this(name, new List<Department>(), workers) { }
        public Department(string name, List<Department> dep) : this(name, dep, new List<Worker>()) { }
        public Department(string name, List<Department> departments, List<Worker> workers)
        {
            this.name = name;
            this.departments = departments;
            this.workers = workers;
            this.created = DateTime.Now;
            this.Count = workers.Count;            
        }
        /// <summary>
        /// предоставляет возможность изменения названия департамента
        /// </summary>
        /// <param name="name"></param>
        public void Edit(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// Добавляет департамент только с название
        /// <br></br>
        /// также позволяет реализовать добавления вложенных департаментов и рабочих
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="dep">список вложенных деп</param>
        /// <param name="workers">список рабочих</param>
        /// <returns></returns>
        public Department AddDepartment(string name, List<Department>dep=null, List<Worker>workers=null)
        {        
                Department department;
                if (dep == null && workers == null)
                {
                    department = new Department(name);
                }else if(dep == null)
                {
                    department = new Department(name,workers);
                }
                else
                {
                    department = new Department(name, dep);
                    
                }
                departments.Add(department);
                return department;            
            
        }
        public Department AddDepartment(Department dep)
        {            
            departments.Add(dep);
            return dep;
        }
        /// <summary>
        /// Возвращает департамент по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Department FindDepartment(int index)
        {
            if(0 <= index && index <= departments.Count)
            {
                return departments[index];
            }

            return new Department();
        }
        public bool DeleteDepartment(int index)
        {
            if (0 <= index && index <= departments.Count)
            {
                departments.RemoveAt(index);

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Сортирует рабочих по имени
        /// </summary>
        /// <param name="order"></param>
        public void ReorderFName(int order)
        {
            if(order==1)
               workers.Sort(Worker.CompareByFNameAsc);
            else
                workers.Sort(Worker.CompareByFNameDesc);
        }
        /// <summary>
        /// Сортирует рабочих по фамилии
        /// </summary>
        /// <param name="order"></param>
        public void ReorderSName(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareBySNameAsc);
            else
                workers.Sort(Worker.CompareBySNameDesc);
        }
        /// <summary>
        /// Сортирует рабочих по зп
        /// </summary>
        /// <param name="order"></param>
        public void ReorderWage(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareByWageAsc);
            else
                workers.Sort(Worker.CompareByWageDesc);
        }
        /// <summary>
        /// Сортирует рабочих по возрасту
        /// </summary>
        /// <param name="order"></param>
        public void ReorderAge(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareByWageAsc);
            else
                workers.Sort(Worker.CompareByWageDesc);
        }
        /// <summary>
        /// Добавляет рабочего в департамент
        /// </summary>
        /// <param name="fName">имя</param>
        /// <param name="sName">фамилия</param>
        /// <param name="wage">зп</param>
        /// <param name="age">возраст</param>
        /// <param name="id">ид заполняется автоматом</param>
        /// <returns></returns>
        public Worker AddWorker(string fName,string sName, double wage, byte age, int id)
        {
            if(workers.Count < 1_000_000)
            {
                Worker worker = new Worker(fName, sName, name, wage, age, id);
                worker.department = name;
                workers.Add(worker);
            }

            return new Worker();
        }
        public Worker FindWorker(int index)
        {
            if (0 <= index && index <= workers.Count - 1)
            {
                return workers[index];
            }
            return new Worker();
        }
        public Worker EditWorker(int index, string fName, string sName, double wage, byte age, int id)
        {
            Worker work = new Worker()
            {
                first_name  = fName,
                second_name = sName,
                wage        = wage,
                age         = age,
                id          = id
            };
            workers[index] = work;

            return workers[index];            
        }
        public bool DeleteWorker(int index)
        {
            if (0 <= index && index <= workers.Count - 1)
            {
                workers.RemoveAt(index);
                return true;
            }
            return false;
        }
        public void PrintWorkers()
        {
            int index = 0;
            foreach(Worker work in workers)
            {
                Console.WriteLine("индекс рабочего("+ index++ +");"+work.first_name + ";" + work.second_name + ";" + work.age + ";"+ work.wage +";" + work.department);
            }
        }
    }
}
