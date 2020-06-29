using System;
using System.Collections.Generic;

namespace EncodedMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoded Message
            // https://open.kattis.com/problems/encodedmessage 
            // idea like array transpose 

            int myCount = EnterNumberOfCases();

            var myNewWords = ProgramCore(myCount);

            PrintList(myNewWords);
        }

        
        private static List<string> ProgramCore(int yourCount)
        {
            var ans = new List<string>();
            for (int i = 0; i < yourCount; i++)
            {
                var myString = EnterYourString();

                var myChars = StringToCharArray(myString);

                var myStringArray = CharArrayToStringArray(myChars);

                var myT = Transpose(myStringArray);

                var revMyT = ReverseArrayOrder(myT);

                var result = StringAccumulator(revMyT);
                ans.Add(result);
            }
            return ans;
        }

        private static int EnterNumberOfCases()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumberOfCases();
            }
            return a;
        }
        private static string StringAccumulator(string[] arr)
        {
            var str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str = str + arr[i];
            }
            return str;
        }
        private static string[] ReverseArrayOrder(string[] array)
        {
            string temp;
            for (int i = 0; i < array.Length/2; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
            return array;
        }
        private static string[] Transpose(string[] myArray)
        {
            int basicNum = myArray.Length;
            int sqRoot = (int)Math.Sqrt(basicNum);

            string[] pivots = new string[sqRoot];
            for (int i = 0; i < pivots.Length; i++)
            {
                pivots[i] = MakePivot(i, sqRoot, myArray);
            }
            return pivots;
        }
        private static string MakePivot(int index, int sqRoot, string[] array)
        {
            string str = "";
            for (int i = index; i < array.Length; i = i + sqRoot)
            {
                str = str + array[i];
                //i = i + sqt;
            }
            return str;
        }

        private static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        private static char[] StringToCharArray(string str)
        {
            return str.ToCharArray();
        }
        private static string[] CharArrayToStringArray(char[] myChars)
        {
            var strArray = new string[myChars.Length];
            for (int i = 0; i < myChars.Length; i++)
            {
                strArray[i] = myChars[i].ToString(); 
            }
            return strArray;
        }
        private static string EnterYourString()
        {
            string str = "";
            try
            {
                str = Console.ReadLine();
                if (IsPerfectSquare(str.Length) == false)
                    throw new ArgumentException();
                if (str.Length < 1 || str.Length > 10000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterYourString();
            }
            return str;
        }
        private static bool IsPerfectSquare(int yourNum)
        {
            double num = (double)yourNum;

            double root = Math.Sqrt(num);
            double minRoot = Math.Floor(root);

            double res = root - minRoot;

            if (res == 0)
                return true;
            else return false;
        }
        private static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
