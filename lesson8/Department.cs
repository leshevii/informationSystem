using System;
using System.Collections.Generic;
namespace lesson8
{
    public struct Department
    {
        public string name;
        public DateTime created;
        public List<Department> departments;
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

        public void Edit(string name)
        {
            this.name = name;
        }

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

        public void ReorderFName(int order)
        {
            if(order==1)
               workers.Sort(Worker.CompareByFNameAsc);
            else
                workers.Sort(Worker.CompareByFNameDesc);
        }
        public void ReorderSName(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareBySNameAsc);
            else
                workers.Sort(Worker.CompareBySNameDesc);
        }
        public void ReorderWage(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareByWageAsc);
            else
                workers.Sort(Worker.CompareByWageDesc);
        }
        public void ReorderAge(int order)
        {
            if (order == 1)
                workers.Sort(Worker.CompareByWageAsc);
            else
                workers.Sort(Worker.CompareByWageDesc);
        }

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
