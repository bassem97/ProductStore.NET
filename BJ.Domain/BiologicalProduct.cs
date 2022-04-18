using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Domain
{
    public class BiologicalProduct : Product
    {
        public string Herbs { get; set; }
        public override string ToString()
        {
            return base.ToString() + " Herbs : " + Herbs;
        }
        public void GetMyType()
        {
            Console.WriteLine("BiologicalProduct");
        }
        public override void GetMyType2()
        {
            Console.WriteLine("BIOLOGICAL");
        }
        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }
    }
}
