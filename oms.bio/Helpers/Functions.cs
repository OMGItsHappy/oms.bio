using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using oms.bio.Controllers;
using System.ComponentModel;
using oms.bio.Models;

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

        public static List<Methods> GetMethods (string controllerName){
            Assembly asm = Assembly.GetExecutingAssembly();

            var methods = asm.GetTypes()
            .Where(type=> typeof(Controller).IsAssignableFrom(type)) //filter controllers
            .Where(type => type.Name == controllerName)
            .SelectMany(type => type.GetMethods())
            .Where(method => method.IsPublic && ! method.IsDefined(typeof(NonActionAttribute)) && method.ReturnType == typeof(IActionResult));

            List<Methods> methodsData = new List<Methods>();

            foreach (var method in methods)
            {
                //https://stackoverflow.com/questions/5015830/get-the-value-of-displayname-attribute


                Methods m = new Methods { MethodName = method.Name };

                var item = method.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .Cast<DisplayNameAttribute>().FirstOrDefault();
                if (item != null) m.MethodDisplayName = item.DisplayName;
                else m.MethodDisplayName=method.Name;

                methodsData.Add(m);
                
            }

            return methodsData;

            }

    }
}
