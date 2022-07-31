using System;

namespace ACII_convertor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new ACIIArtCreator("C:/Users/Shukrullo/Desktop/test3.jpg");
            test.Go("C:/Users/Shukrullo/Desktop/ACII.txt");
        }
    }
}
