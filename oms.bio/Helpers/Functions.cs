using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oms.bio.Helpers
{
    public class MyFunctions
    {
        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        public static List<string> GetControllerNames()
        {
            List<string> controllerNames = new List<string>();
            GetSubClasses<Controller>().ForEach(
                type => controllerNames.Add(type.Name));
            return controllerNames;
        }
    }
}
