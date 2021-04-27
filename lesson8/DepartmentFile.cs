using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace lesson8
{
    /// <summary>
    /// Класс для работы с файлами
    /// <br></br>
    /// Реализует возможности сериализации данных
    /// </summary>
    public class DepartmentFile
    {
        public static void SerializeCompanyXml(List<Department> departments, string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Department>));
            Stream st = new FileStream(path, FileMode.Create, FileAccess.Write);
            xml.Serialize(st, departments);
            st.Close();
        }
        public static void SerializeCompanyJson(List<Department> departments, string path)
        {
            string json = JsonConvert.SerializeObject(departments);
            File.WriteAllText(path, json);
        }
    }
}
