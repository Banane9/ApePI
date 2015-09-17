using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApePI.ConsoleTesting
{
    internal class Program
    {
        public string TestS { get; private set; }

        public int this[int index] { get { return index; } set { } }

        private static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8080/");
            httpListener.Start();

            Console.WriteLine(Convert.ChangeType("10", typeof(double)));

            //var pathNode = new PathNode(typeof(TestObject));

            var propertyGetParameters = typeof(Program).GetProperty("TestS").GetMethod.GetParameters();
            var propertySetParameters = typeof(Program).GetProperty("TestS").SetMethod.GetParameters();
            var getIndexerParameters = typeof(Program).GetProperties().Single(prop => prop.GetIndexParameters().Length > 0).GetMethod.GetParameters();
            var setIndexerParameters = typeof(Program).GetProperties().Single(prop => prop.GetIndexParameters().Length > 0).SetMethod.GetParameters();

            var voidReturn = typeof(Program).GetMethod("Void").Invoke(null, new object[0]);

            var overloadedMethod = typeof(Program).GetMethods().Where(methodInfo => methodInfo.Name == "Test");

            while (true)
            {
                var request = httpListener.GetContext().Request;
                var rawUrl = request.RawUrl;
                Console.WriteLine(WebUtility.UrlDecode(rawUrl));
            }

            httpListener.Close();
            Console.WriteLine();
        }

        public string Test(int i)
        {
            return "test " + i;
        }

        public int Test(string i)
        {
            return i.Length;
        }

        public static void Void()
        {
            return;
        }
    }
}