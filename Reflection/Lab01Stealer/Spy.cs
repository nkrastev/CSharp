using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] namesOfFields)
        {
            StringBuilder sb = new StringBuilder();
            
            //get class type
            Type nameOfTheClass = Type.GetType(classToInvestigate);
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            //get fields
            FieldInfo[] allFields = nameOfTheClass.GetFields(
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(nameOfTheClass, new object[] { });

            foreach (FieldInfo item in allFields.Where(f=>namesOfFields.Contains(f.Name)))
            {                
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }            

            return sb.ToString().TrimEnd();
        }
    }
}
