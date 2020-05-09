using System;
using Northwind.Common;

namespace Northwind.Infrastructure
{
    internal class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
