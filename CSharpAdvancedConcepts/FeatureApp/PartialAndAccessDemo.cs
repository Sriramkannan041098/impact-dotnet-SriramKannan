using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.FeatureApp
{
    public class PartialAndAccessDemo
    {

        public void Demonstrate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;  
            // Supports in displaying emojis in console output
            //since Console doest have emoji glyph so, it wont support in printing icons

            try
            {
                /* Partial Class Demonstration */
                Employee emp = new Employee("Sriram Kannan", "Software Engineer");
                emp.DisplayEmpInfo();
                /*
                   Here, partially defined private method CreateEmployee() from outside the Employee class.
                   Prints the passed Employee details via DisplayEmpInfo() once after executing CreateEmployee().
                */


                /*Access Modifier Demonstrates the access levels of different members*/
                AccessModifierMatrix matrix = new AccessModifierMatrix(
                    "Public Value", 
                    "Private Value", 
                    "Protected Value", 
                    "Internal Value"
                    );
                matrix.DisplayAccessModifiers();



                /*Record*/
                Console.WriteLine("\nRecord Demonstration:");
                Address add1 = new Address ("Chennai", "Saligramam", 600093 );
                Address add2 = new Address("Chennai", "Saligramam", 600093);
                Address add3 = new Address ("Trichy", "Thillai Nagar", 620018);

                Console.WriteLine($"Compare add1 and add2: {add1 == add2}");
                Console.WriteLine($"Compare add1 and add3: {add1 == add3}");
                /* This compare the object of different Records */
                //Console.WriteLine($"Compare Street Names: {add1.StreetName == add2.StreetName}");
                
                

                /*Copy records with "with"*/
                Address add4 = add1 with { StreetName = "Vadapalani" };
                Console.WriteLine($"\nOriginal data of add1 Record: \n{add1}");
                Console.WriteLine($"Copied and Modified data of add4 Record: \n{add4}");



                /*Playlist Indexer*/    
                Console.WriteLine("\nPlaylist Indexer Demonstration:");
                Playlist listen = new Playlist(4);
                listen[0] = "🎙️The Diary of a CEO";
                listen[1] = "🎙️The Happiness Lab";
                listen[2] = "🎙️The Michelle Obama Podcast";
                listen[3] = "🎙️The Tim Ferriss Show";  

                for(int i = 0; i < listen.Length; i++)
                {
                    Console.WriteLine($"Podcast {i}: {listen[i]}");
                }

                try
                {
                    Console.WriteLine(
                        $"Invalid Song: {listen[6]}"
                    );
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(
                        $"Playlist Error: {ex.Message}"
                    );
                }



                /*String Indexer*/
                Console.WriteLine("\nString Indexer Demonstration:");
                StringIndexer text = new StringIndexer("CSharp");

                Console.WriteLine($"Character at index 0: {text[0]}");
                Console.WriteLine($"Character at index 3: {text[3]}");

                try
                {
                    Console.WriteLine(text[10]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(
                        $"String Error: {ex.Message}"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }
    }
}
