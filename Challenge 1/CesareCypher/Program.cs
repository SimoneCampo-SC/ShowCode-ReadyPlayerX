/*
 * From ShowCode - Unicode 20/21 Challenge #1
 * 
 * Author Simone Campo
 * 
 * Challenge Name: Ready Player X
 * Outcome: 100%
 * 
 * Description
 * It 's 2045. Halliday is gone. Every living soul in the OASIS is looking for the Easter egg - the key to Halliday's fortune.
 * We've found something, a few snippets of deciphered text. Is this enough for you to break his cipher?
 * Message 1:
 * Halliday("Crystal Key") == "Pelfgny Xrl"
 * Message 2
 * Halliday("Orb of Osuvox") == "Beo bs Bfhibk"
 * We managed to get a few fragments of some other messages... we'll need the cipher to work on messages with the characters we can see in them, even though we can't get all of their content...
 * We marked the missing characters with *
 * 
 * Fragment 1:
 * *l * *day("ro** 237") == "eb** 237"
 * 
 * Fragment 2:
 * *day("An**ak? $ mil**ons?!") == "Nabenx? $ zvyyvbaf?!"
 * 
 * Fragment 3:
 * **"+- the_distracted_globe -+") == "+- gur_qvfgenpgrq_ty******"
 */
using System;

namespace CesareCypher
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string message = cypher("Ab1");
            Console.WriteLine(message);
        }
        public static string cypher(string message)
        {
            // Try-Catch statement is important as the method makes use of conversions and casting. Therefore, wherever it finds an exception, it will be handled and the error message will be returned;
            try
            {
                // holds the encrypted message
                string encryptMessage;
                bool isLower;
                // array of char populated with the charactes
                char[] arrayMessage = message.ToCharArray();

                // for loop iterates through the array of chars
                for (int i = 0; i < arrayMessage.Length; i++)
                {
                    // Checks whether the character is lower
                    if (Char.IsLower(arrayMessage[i]))
                    {
                        isLower = true;
                    }
                    else
                    {
                        isLower = false;
                    }

                    // using Cating, a new integer variable holds the ascii value of the character in upper case
                    int indexInAscii = (int)Char.ToUpper(arrayMessage[i]);

                    // since A in ascii is equal to 65 and Z is equal to 90, the following statement checks whether the character inserted is inside that range
                    if ((indexInAscii >= 65) &&
                        (indexInAscii <= 90))
                    {
                        // all the characters are trasported by 13 (e.g. A is N, B is M etc.)
                        indexInAscii += 13;
                        // if the result is greater than 90, it should start again from 65
                        if (indexInAscii > 90)
                        {
                            indexInAscii =
                            ((indexInAscii - 90) + 64);
                        }
                        // Once obtained the ascii number of the corresponding character, it is possible to conver it into the char character. 
                        arrayMessage[i] =
                        ((Convert.ToChar(indexInAscii)));

                        // checks whether the original message was Lower
                        if (isLower == true)
                        {
                            arrayMessage[i] = Char.ToLower(arrayMessage[i]);
                        }
                    }
                    // Of course, nothing happens if the user inserts numbers or symbols (See fragments)
                }
                // Once that all the characters have been checked, the array of chars is converted into the strig message
                encryptMessage = new string(arrayMessage);

                // message is ready to be returned
                return encryptMessage;
            }
            catch (Exception ex)
            {
                // Return the message related to the exception
                return ex.Message;
            }
        }
    }
}
