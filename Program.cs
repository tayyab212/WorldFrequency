using System;
using System.Linq;

namespace WorldFrequency
{
    class Program
    {
        public static void Main()
        {
            CalculateMostFrequentNWords();
            //Take Sentance and Word. Will find word frequency in the world.
            CountWordFrequncy();

            // Highest frequency of character in senence 
            CalculateHighestFrequency();
        }

        public static void CalculateHighestFrequency()
        {
            string str;
            int[] ch_fre = new int[255];
            int i = 0, max, l;
            int ascii;

            Console.Write("\n\nFind maximum occurring character in a string :\n");
            Console.Write("--------------------------------------------------\n");
            Console.Write("Input the string : ");
            str = Console.ReadLine();
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
        }

        public static void CountWordFrequncy()
        {

            Console.Write("Enter the Sentence: ");
            string sentence = Console.ReadLine();

            Console.Write("Enter the Word: ");
            string word = Console.ReadLine();

            int cnt = 0;
            int i = 0;
            while ((i = sentence.IndexOf(word, i)) != -1)
            {
                i += word.Length;
                cnt++;
            }
            Console.Write($"The Word {word} is appearing for number of times {cnt} ");
        }

        public static void CalculateMostFrequentNWords()
        {
            Console.WriteLine("Please Enter Sentence");
            string words = Console.ReadLine();

            Console.WriteLine("Please enter worlds length");
            int length = int.Parse(Console.ReadLine());

            var orderedWords = words
              .Split(' ')
              .GroupBy(x => x)
              .Select(x => new
              {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Take(length);
            var query = (from item in orderedWords select new { word = item.KeyField, count = item.Count });
            query.ToList();
            foreach (var item in query)
            {
                Console.Write($"The word {item.word} is appearing for number of times {item.count} \n\n");

            }
        }

    }
}
