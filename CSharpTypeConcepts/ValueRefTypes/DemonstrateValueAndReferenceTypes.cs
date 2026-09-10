using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTypeConcepts.EnumFlags
{
    using CSharpTypeConcepts.SecNamespaces;
    using System;

    public class DemonstrateValueAndReferenceTypes
    {
        private int FirstNum { get; set;  } 
        private int SecondNum { get; set; }

        private int[] arrayOne;
        private int[] arrayTwo;

        public CoordinateStruct coordinate1;
        public CoordinateStruct coordinate2;
        public CoordinateClass coordinate3;
        public CoordinateClass coordinate4;

        public DemonstrateValueAndReferenceTypes(int number, int arrayLenght)
        {
            //Console.WriteLine("Demonstrate ValueAndReferenceTypes instance created.");
            FirstNum = number;
            SecondNum = number * 2;

            arrayOne = new int[arrayLenght];
            arrayTwo = new int[arrayLenght];

            coordinate1 = new CoordinateStruct(10, 20);
            coordinate2 = coordinate1;
            coordinate2.X = 100;

            coordinate3 = new CoordinateClass(10, 20);
            coordinate4 = coordinate3;
            coordinate4.X = 100;          

        }

        public void DemostrateMethod()
        {
            try 
            { 
                Console.WriteLine($"FirstNum: {FirstNum}, SecondNum: {SecondNum} \n");

                /* Since int is a value type, 
                 * SecondNum receives a seperate copy of FirstNum's value
                 * So, changes in SecondNum won't revert back to FirstNum
                 */

                for (int i = 1; i < arrayOne.Length; i++)
                {
                    arrayOne[i] = FirstNum * i;
                }
                //Console.WriteLine(arrayTwo);   // Since array is  ref type, it wont print.
                Console.WriteLine($"Array One: {string.Join(", ", arrayOne)}");

                arrayTwo = arrayOne;
                Console.WriteLine($"Array Two: {string.Join(", ", arrayTwo)} \n");

                arrayTwo[2] = FirstNum / arrayOne.Length;
                Console.WriteLine($"Updated Array Two: {string.Join(", ", arrayTwo)}");
                Console.WriteLine($"Updated Array One: {string.Join(", ", arrayOne)}");

                /*
                 *  Since array is a reference type,
                 *  changing arrayTwo also changes arrayOne 
                 *  because they both reference the same array in memory.
                 */
                Console.WriteLine("\nStruct and Class Demonstration:");
                Console.WriteLine($"coordinate Struct: ({coordinate1.X}, {coordinate1.Y})");
                Console.WriteLine($"coordinate Struct: ({coordinate2.X}, {coordinate2.Y})\n");
                /*Coordinate Struct is value type.
                  So,coordinate2 has seperate copy of coordinate1. 
                  Thus changes made in coordinate2 won't affect coordinate1
                 */

                Console.WriteLine($"coordinate Class: ({coordinate3.X}, {coordinate3.Y})");
                Console.WriteLine($"coordinate Class: ({coordinate4.X}, {coordinate4.Y})");
                /*Coordinate class is reference type.
                  So,coordinate4 references the same object as coordinate3. 
                  Thus changes made in coordinate4 will affect coordinate3
                 */


                /* 
                   Struct:
                     A value type that stores its data directly and is typically used for small, lightweight objects.
                   Class:
                     A reference type where variables hold a reference to an object stored on the heap.
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}


