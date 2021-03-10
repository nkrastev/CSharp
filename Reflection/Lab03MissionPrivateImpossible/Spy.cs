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

            foreach (FieldInfo item in allFields.Where(f => namesOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classForSpy = Type.GetType(className);

            FieldInfo[] classFields = classForSpy.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classForSpy.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classForSpy.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);           

            foreach (FieldInfo item in classFields) 
            {
                sb.AppendLine($"{item.Name} must be private!");
            }

            foreach (MethodInfo item in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }

            foreach (MethodInfo item in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }


            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();            

            Type classForSpy = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {classForSpy}");            
            sb.AppendLine($"Base Class: {classForSpy.BaseType.Name}");

            MethodInfo[] allPrivateMethods = classForSpy.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo item in allPrivateMethods)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
