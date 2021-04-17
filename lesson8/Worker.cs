using System;
namespace lesson8
{
    public struct Worker
    {        
        public string first_name;
        public string second_name;
        public string department;
        public double wage;
        public byte age;
        public int id;

        public Worker(string fName,string sName,string dep,double wage,byte age, int id)
        {
            first_name  = fName;
            second_name = sName;
            department  = dep;
            this.wage   = wage;
            this.age    = age;
            this.id     = id;
        }
        public static int CompareByFNameAsc(Worker rec1, Worker rec2)
        {
            return String.Compare(rec1.first_name, rec2.first_name);
        }
        public static int CompareByFNameDesc(Worker rec1, Worker rec2)
        {
            if (String.Compare(rec1.first_name, rec2.first_name) < 0)
            {
                return 1;
            }
            else if (String.Compare(rec1.first_name, rec2.first_name) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static int CompareBySNameAsc(Worker rec1, Worker rec2)
        {
            return String.Compare(rec1.second_name, rec2.second_name);
        }
        public static int CompareBySNameDesc(Worker rec1, Worker rec2)
        {
            if (String.Compare(rec1.second_name, rec2.second_name) < 0)
            {
                return 1;
            }
            else if (String.Compare(rec1.second_name, rec2.second_name) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static int CompareByWageAsc(Worker rec1, Worker rec2)
        {
            if (rec1.wage < rec2.wage) return 1;
            else if (rec1.wage > rec2.wage) return -1;
            else
                return 0;

        }
        public static int CompareByWageDesc(Worker rec1, Worker rec2)
        {
            if (rec1.wage < rec2.wage) return -1;
            else if (rec1.wage > rec2.wage) return 1;
            else
                return 0;

        }
        public static int CompareByAgeAsc(Worker rec1, Worker rec2)
        {
            if (rec1.age < rec2.age) return 1;
            else if (rec1.age > rec2.age) return -1;
            else
                return 0;

        }
        public static int CompareByAgeDesc(Worker rec1, Worker rec2)
        {
            if (rec1.age < rec2.age) return -1;
            else if (rec1.age > rec2.age) return 1;
            else
                return 0;

        }
    }
}
