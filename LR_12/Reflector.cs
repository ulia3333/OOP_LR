﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LR_12
{
    static class Reflector
    {
        static public string GetAssemblyName(Type classType)
        {

            return Assembly.GetAssembly(classType).GetName().Name;
        }
        static public bool ContainsPublicConstructors(Type classType)
        {
            return classType.GetConstructors().Length == 0 ? false : true;
        }
        static public IEnumerable<string> GetConstructors(Type classType)
        {
            return classType.GetConstructors().Select(x => x.ToString());
        }
        static public IEnumerable<string> GetPropsFields(Type classType)
        {
            return classType.GetTypeInfo().DeclaredFields.Select(x => x.Name);
        }
        static public IEnumerable<string> GetInterfaces(Type classType)
        {
            return classType.GetTypeInfo().ImplementedInterfaces.Select(x => x.Name);
        }
        static public IEnumerable<string> GetMethodsWithParam(Type classType, Type methodType)
        {
            return classType.GetTypeInfo().DeclaredMethods.Where(x => x.GetParameters().Select(y => y.ParameterType).Contains(methodType)).Select(x => x.Name);
        }
        static public object Invoke(Type classType, string methodName, string filename)
        {
            object rez = null;
            object classObj = Create(classType, new object[] { });


            List<string> paramListString = File.ReadAllText(filename).Split('\n').ToList();


            MethodInfo methodInst = classType.GetMethod(methodName);

            var temp = methodInst.GetParameters();
            List<Type> paramListType = methodInst.GetParameters().Select(x => x.ParameterType).ToList();

            if (paramListString.Count != paramListType.Count) return null;

            var paramListObj = new List<object>();
            for (int i = 0; i < paramListType.Count; i++)
            {
                paramListObj.Add(System.Convert.ChangeType(paramListString[i], paramListType[i]));
            }

            rez = methodInst.Invoke(classObj, paramListObj.ToArray());
            return rez;
        }
        static public object Invoke(Type classType, string methodName)
        {
            object rez = null;
            object classObj = Create(classType, new object[] { });



            MethodInfo methodInst = classType.GetMethod(methodName);

            var temp = methodInst.GetParameters();
            List<Type> paramListType = methodInst.GetParameters().Select(x => x.ParameterType).ToList();

            var paramListObj = new List<object>();
            for (int i = 0; i < paramListType.Count; i++)
            {
                paramListObj.Add(Activator.CreateInstance(paramListType[i]));
            }

            rez = methodInst.Invoke(classObj, paramListObj.ToArray());
            return rez;

        }
        static public string toFile(Type classType, Type methodType = null, string fileName = "info.txt")
        {
            string rez = "";
            rez += "Assembly Name: " + GetAssemblyName(classType) + "\n";
            rez += "Contains public constructors: " + (ContainsPublicConstructors(classType) ? "true" : "false") + "\n";
            if (ContainsPublicConstructors(classType))
            {
                rez += "Public constructors:\n";
                foreach (string word in GetConstructors(classType))
                {
                    rez += "\t" + word + "\n";
                }
            }

            rez += "Fields and properties:\n";
            foreach (string word in GetPropsFields(classType))
            {
                rez += "\t" + word + "\n";
            }

            rez += "Implemented interfaces:\n";
            foreach (string word in GetInterfaces(classType))
            {
                rez += "\t" + word + "\n";
            }

            if (methodType != null)
            {
                rez += $"Methods with {methodType} param:\n";
                foreach (string word in GetMethodsWithParam(classType, methodType))
                {
                    rez += "\t" + word + "\n";
                }
            }

            File.WriteAllText(fileName, rez);

            return rez;
        }
        static public object Create(Type classType, params object[] paramList)
        {
            object obj = null;

            if (classType.IsAbstract) return null;
            obj = Activator.CreateInstance(classType, paramList);


            return obj;
        }

    }
}
