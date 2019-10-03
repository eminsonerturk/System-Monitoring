using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main.SunucuEnvanter
{
    public class Cryptography
    {
        static string[] alphabet = { "a", "b", "c", "ç", "d", "e", "f", "g", "ğ", "h", "ı", "i", "j", "k", "l", "m",
                                "n", "o", "ö", "p", "r", "s", "ş", "t", "u", "ü", "v", "y", "z", "x", "w", "q", "A",
                                "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O",
                                "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z", "X", "W", "Q", "!","*", "+",
                                "-", "#", "&", "$", ",", ";", ".", "?", "/", "(", ")", "%", "{", "}", "[", "]", "=",
                                "'", "^", "_", ">", "<", "|", "@", "€", "~", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; //Character table

        static int a = 7;                                                                                                        //Constants of function ---> (a*index + b)
        static int b = 5;
        static int lengthOfalpahabet = alphabet.Length + 1;

        public static string EncryptMessage(string message)
        {
            string encrypted = "";

            string[] wordArray = message.Split(' ');                                                 //Split each word in message

            for (int i = 0; i < wordArray.Length; i++)
            {
                if (i % 2 == 0)                                                                     //First, third, fifth, ... , words in sentence encryption method  
                {
                    //7*k+5 ile başlar

                    for (int j = 0; j < wordArray[i].Length; j++)
                    {
                        int index = GetIndexofLetter(wordArray[i][j].ToString());                  //Find index of alphabet this character

                        if (j % 2 == 0)                                                            //First, third, fifth, ..., character in word
                            encrypted += GetLetterForAdd(index);                                   //Apply (a*index + b)

                        else                                                                       //Second, fourth, ..., character in word
                            encrypted += GetLetterForMınus(index);                                 //Apply (a*index - b)
                    }
                }
                else                                                                               //Second, fourth, ..., words in sentence encryption method
                {
                    //7*k-5 ile başlar

                    for (int j = 0; j < wordArray[i].Length; j++)
                    {
                        int index = GetIndexofLetter(wordArray[i][j].ToString());

                        if (j % 2 == 0)                                                           //First, third, ..., character in word
                            encrypted += GetLetterForMınus(index);                                //Apply (a*index - b)

                        else                                                                      //Second, fourth, ..., character in word
                            encrypted += GetLetterForAdd(index);                                  //Apply (a*index + b)
                    }
                }
                encrypted += " ";
            }
            return encrypted;                                                                     //Return encrypted message
        }

        public static string DecryptedMessage(string message)
        {
            string decrypted = "";

            string[] wordArray = message.Split(' ');                                              //Split each word in encrypted message

            for (int i = 0; i < wordArray.Length; i++)
            {
                if (i % 2 == 0)                                                                   //First, third, fifth, ... , words in sentence decryption method  
                {
                    //çıkararak geri dönmeye başla
                    for (int j = 0; j < wordArray[i].Length; j++)
                    {
                        int index = GetIndexofLetter(wordArray[i][j].ToString());                 //Find index of alphabet this character

                        if (j % 2 == 0)                                                           //First, third, fifth, ..., character in word
                        {
                            index -= b;
                            while (index % 7 != 0)
                            {
                                index += lengthOfalpahabet;
                            }
                            decrypted += alphabet[(index / 7) - 1];
                        }
                        else                                                                      //Second, fourth, ..., character in word
                        {
                            index += b;
                            while (index % 7 != 0)
                            {
                                index += lengthOfalpahabet;
                            }
                            decrypted += alphabet[(index / 7) - 1];
                        }
                    }
                }
                else                                                                              //Second, fourth, ..., words in sentence encryption method
                {
                    //toplayarak geri dönmeye başla
                    for (int j = 0; j < wordArray[i].Length; j++)
                    {
                        int index = GetIndexofLetter(wordArray[i][j].ToString());

                        if (j % 2 == 0)                                                           //First, third, fifth, ..., character in word
                        {
                            index += b;
                            while (index % 7 != 0)
                            {
                                index += lengthOfalpahabet;
                            }
                            decrypted += alphabet[(index / 7) - 1];
                        }
                        else                                                                      //Second, fourth, ..., character in word
                        {
                            index -= b;
                            while (index % 7 != 0)
                            {
                                index += lengthOfalpahabet;
                            }
                            decrypted += alphabet[(index / 7) - 1];
                        }
                    }
                }
                decrypted += " ";
            }
            return decrypted;                                                                     //Return decrypted message
        }

        public static int GetIndexofLetter(string letter)
        {
            for (int i = 0; i < lengthOfalpahabet - 1; i++)
            {
                if (letter == alphabet[i])
                    return i + 1;
            }
            return 0;
        }

        public static string GetLetterForMınus(int index)
        {
            int encIndex = (a * index - b) % lengthOfalpahabet;
            while (encIndex < 0)
            {
                encIndex += lengthOfalpahabet;
            }
            return alphabet[encIndex - 1];
        }

        public static string GetLetterForAdd(int index)
        {
            int encIndex = (a * index + b) % lengthOfalpahabet;
            return alphabet[encIndex - 1];
        }

    }
}
