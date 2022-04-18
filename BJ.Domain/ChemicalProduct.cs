using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Domain
{
    public class ChemicalProduct : Product
    {
        
        public string LabName { get; set; }
        public Adresse Adresse { get; set; }
        

        public override string ToString()
        {
            return base.ToString() + " Labo : "+LabName ;
        }

        public void GetMyType()
        {
            Console.WriteLine("ChemicalProduct");
        }

        public override void GetMyType2()
        {
            Console.WriteLine("CHEMICAL");
        }

        public override void GetDetails()
        {
            Console.WriteLine(ToString());
        }
    }
}
