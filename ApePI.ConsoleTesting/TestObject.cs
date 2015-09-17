using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApePI.ConsoleTesting
{
    internal class TestObject
    {
        public string Test { get { return "hi"; } }

        public NestedTestObject Nested { get { return new NestedTestObject(); } }

        public class NestedTestObject
        {
            public int Number { get { return 1; } }
        }
    }
}