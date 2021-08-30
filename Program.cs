using System;
using System.Collections.Generic;
using System.Linq;
using WorldFrequency.Interfaces;
using WorldFrequency.Models;

namespace WorldFrequency
{
    public class Program : IWordFrequencyAnalyzer
    {
        public static void Main()
        {
            Program program = new Program();

            Console.Write("\n\nFind maximum occurring character in a string :\n");
            Console.Write("--------------------------------------------------\n");
            Console.Write("Input the string : ");

            string str = Console.ReadLine();
            // Highest frequency of character in senence 
            program.CalculateHighestFrequency(str);

            //Take Sentacce and and length 



            Console.WriteLine("Please Enter Sentence");
            string sentence = Console.ReadLine();

            Console.WriteLine("Please enter worlds length");
            int n = int.Parse(Console.ReadLine());
            program.CalculateMostFrequentNWords(sentence, n);


            Console.Write("Enter the Sentence: ");
            string text = Console.ReadLine();
            Console.Write("Enter the Word: ");
            string word = Console.ReadLine();

            //Take Sentance and Word. Will find word frequency in the world.
            program.CalculateFrequencyForWord(text, word);

        }

        public int CalculateHighestFrequency(string str)
        {

            int[] ch_fre = new int[255];
            int i = 0, max, l;
            int ascii;

            Console.Write("\n\nFind maximum occurring character in a string :\n");
            Console.Write("--------------------------------------------------\n");
            Console.Write("Input the string : ");
            //str = Console.ReadLine();
            l = str.Length;

            for (i = 0; i < 255; i++)  //Set frequency of all characters to 0
            {
                ch_fre[i] = 0;
            }
            /* Read for frequency of each characters */
            i = 0;
            while (i < l)
            {
                ascii = (int)str[i];
                ch_fre[ascii] += 1;

                i++;
            }
            // Console.Write("{0}  ",(char)65);
            max = 0;
            for (i = 0; i < 255; i++)
            {
                if (i != 32)
                {
                    if (ch_fre[i] > ch_fre[max])
                        max = i;
                }
            }
            Console.Write("The Highest frequency of character '{0}' is appearing for number of times : {1} \n\n", (char)max, ch_fre[max]);
            return ch_fre[max];
        }

        public int CalculateFrequencyForWord(string text, string word)
        {

            //Console.Write("Enter the Sentence: ");
            //text = Console.ReadLine();

            //Console.Write("Enter the Word: ");
            //word = Console.ReadLine();

            int cnt = 0;
            int i = 0;
            while ((i = text.IndexOf(word, i)) != -1)
            {
                i += word.Length;
                cnt++;
            }
            Console.Write($"The Word {word} is appearing for number of times {cnt} ");
            return cnt;
        }

        public IEnumerable<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {

            var orderedWords = text
              .Split(' ')
              .GroupBy(x => x)
              .Select(x => new
              {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Take(n);
            var query = (from item in orderedWords select new WordFrequency { Word = item.KeyField, Frequency = item.Count });
            foreach (var item in query)
            {
                Console.Write($"The word {item.Word} is appearing for number of times {item.Frequency} \n\n");
            }
            return query.ToList();
        }


    }
}
