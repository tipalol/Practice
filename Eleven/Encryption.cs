using System;
using System.Collections.Generic;
namespace Eleven
{
    public class Encryption
    {
        Dictionary<char, char> secretTable = new Dictionary<char, char>();
        public string Encrypt(string str)
        {
            string result = "";

            foreach (char c in str)
            {
                try
                {
                    result += secretTable[c];
                } catch (Exception)
                {
                    result += c;
                }
            }

            return result;
        }
        public Encryption()
        {
            secretTable.Add('a', 'z');
            secretTable.Add('b', 'y');
            secretTable.Add('c', 'x');
            secretTable.Add('d', 'w');
            secretTable.Add('e', 'v');
            secretTable.Add('f', 'u');
            secretTable.Add('g', 't');
            secretTable.Add('h', 's');
            secretTable.Add('i', 'r');
            secretTable.Add('j', 'q');
            secretTable.Add('k', 'p');
            secretTable.Add('l', 'o');
            secretTable.Add('m', 'n');
            secretTable.Add('n', 'm');
            secretTable.Add('o', 'l');
            secretTable.Add('p', 'k');
            secretTable.Add('q', 'j');
            secretTable.Add('r', 'i');
            secretTable.Add('s', 'h');
            secretTable.Add('t', 'g');
            secretTable.Add('u', 'f');
            secretTable.Add('v', 'e');
            secretTable.Add('w', 'd');
            secretTable.Add('x', 'c');
            secretTable.Add('y', 'b');
            secretTable.Add('z', 'a');
            secretTable.Add(' ', ' ');
        }
    }
}
