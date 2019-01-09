using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordsToCheck = new List<string>
            {
                "",
                "a",
                "!",
                "a!",
                "aba",
                "abababababa",
                "bbbbabbbb",
                "Bob",
                "boB",
                "bob!",
                "b ob",
                "bob ",
                "b!o$b"
            };
            foreach(var word in wordsToCheck)
            {
                Console.WriteLine($"{word} : {CheckPalindrome(word)}");
            }
            Console.ReadLine();
        }

        public static bool CheckPalindrome(string input)
        {
            // Should be able to do this with two pointers, one at begin, one at end. Move these towards the middle and if they are ever not equal, it's not a palindrome
            // Stop when begin >= end

            // If a string contains punctuation... we either should be returning false, or moving the pointer to the next char. Depends on spec
            input = input.ToLower();
            int inputLength = input.Length;
            int begin = 0;
            int end = inputLength - 1;
            bool checkedACharacter = false;
            while(begin <= end)
            {
                char beginChar = input[begin];
                char endChar = input[end];

                //Handle punctuation according to spec
                bool fineToCheck = true;
                if(!char.IsLetter(beginChar))
                {
                    begin++;
                    fineToCheck = false;
                }
                if(!char.IsLetter(endChar))
                {
                    end--;
                    fineToCheck = false;
                }
                if(fineToCheck)
                {
                    if(!beginChar.Equals(endChar))
                    {
                        //Not palindrome 
                        return false;
                    }
                    checkedACharacter = true;
                    begin++;
                    end--;
                }
            }
            if(checkedACharacter)
            {
                return true;
            }
            return false;
        }
    }
}
