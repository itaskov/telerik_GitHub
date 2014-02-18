//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Test
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] vowels1 = { "a", "e", "i", "o", "u" };

//            try
//            {
//                Console.WriteLine(GetValueFromArray(vowels1, 10));
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Exception cached");
//            }
//        }

//        static string GetValueFromArray(string[] array, int index)
//        {
//            try
//            {
//                return array[index];
//            }
//            catch (System.IndexOutOfRangeException ex)
//            {
//                Console.WriteLine("Index is out of range: {0}", index);
//                throw;
//            }
//        }
//    }

//}
