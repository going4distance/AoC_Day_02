using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code: 2018, Day 2.");
            string path = @"C:\Users\computer\source\repos\AdventOfCode-Day02\AOCinput.txt";
            /*  if (File.Exists(path)){
                    Console.WriteLine("The file exists!");      }
                else{
                    Console.WriteLine("There is no Spoon!");    }   */

        // Begin Part 1
            //Part1(path);

        // Begin Part 2
            Part2(path);
            
            Console.WriteLine("\nPress ENTER to quit.");
            Console.ReadLine();
        }  // END OF MAIN   //========================================
           //=============================================================================

            /// <summary>
            /// Given a set of ID-codes (letters only) from a file, count how many have exactly 2 of a letter, 
            /// and count how many have exactly 3 of a letter.  Multiply these 2 counts to create the CHECKSUM, what is it?
            /// </summary>
            /// <param name="myPath"></param>
        public static void Part1(string myPath)
        {
            StreamReader sr = new StreamReader(myPath);
            string currentLine;
            int twocount = 0;
            int threecount = 0;
            // Read lines from the file until the end is reached.
            while ((currentLine = sr.ReadLine()) != null)
            {
                List<LetterCount> currentRow = new List<LetterCount>();

                foreach (char letty in currentLine)
                {   // This loop puts everything in an object list, which gives a count for # of each different letter.
                    int indexChar = currentRow.FindIndex(i => i.myletter == letty);
                    if (indexChar > -1)
                    {   // Letter already in the list, increase the count
                        currentRow[indexChar].mycount++;
                    }
                    else
                    {   // Letter not in the list yet, add it
                        currentRow.Add(new LetterCount(letty));
                    }
                }

                if (currentRow.Exists(i => i.mycount == 2))
                {   // if exactly 2 of a letter  ==> 2count++
                    twocount++;
                }
                if (currentRow.Exists(i => i.mycount == 3))
                {   // if exactly 3 of a letter  ==> 3count++
                    threecount++;
                }
            }// Reached End of File.txt
            sr.Close();

            // Calculate CHECKSUM & output
            int checkSUM = twocount * threecount;
            Console.WriteLine("\nThe CHECKSUM = {0} \n", checkSUM);
        }   // End of Part1 method.

        /// <summary>
        /// Given a set of ID-codes (letters only) from a file.
        /// Two of the ID's will vary by only a single character, in the same position for each.  Which letters do they have in common?
        /// </summary>
        /// <param name="myPath"></param>
        public static void Part2(string myPath)
        {
            StreamReader sr = new StreamReader(myPath);
            string currentLine;
            List<string> MasterList = new List<string>();
            // Read lines from the file until the end is reached.
            while ((currentLine = sr.ReadLine()) != null)
            {
                MasterList.Add(currentLine);
            }// Reached End of File.txt
            sr.Close();

            bool matchFound = false;    string theMatch = "";
            for(int col = 0; col < 26; col++)
            {
                List<string> workList = new List<string>(MasterList);
                // Remove char
                for (int x=0; x < workList.Count; x++)
                {
                    workList[x] = workList[x].Remove(col, 1);
                }
                // Compare strings  
                for (int x = 0; x < workList.Count; x++)
                {
                    // Compare [x] to each other.
                    for(int y=x+1; y < workList.Count; y++)
                    {
                        if(workList[x] == workList[y])
                        {   // A match has been found!!
                            theMatch = workList[x];
                            matchFound = true;  
                            break;
                        }
                    }
                }
                if (matchFound)
                { // if match ==> break loop and display the answer
                    break;
                }
            }
            Console.WriteLine("The matching letters are: {0}", theMatch);
        }   // End of Part2 method.
    }   // End of Class-Program =================================================

    class LetterCount
    {
        public LetterCount(char _letter)
        {
            myletter = _letter;
            mycount = 1;
        }

        public char myletter;
        public int mycount;
    }  // END OF LetterCount-class      //===============================================
}
