﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SupportCli.Core.Helpers
{
    public static class ReflectiveEnumerator
    {
        /// <summary>
        /// Get all implementations of abstract type in assembly
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="constructorArgs">constructor args</param>
        /// <returns>result</returns>
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs)
            where T : class
        {
            var objects = new List<T>();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            return objects;
        }
    }
}