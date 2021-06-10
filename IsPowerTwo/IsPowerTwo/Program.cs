using System;
using System.Collections.Generic;

namespace IsPowerTwo
{
    public class Program
    {
        public static Stack<byte> stack = new Stack<byte>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            bool answer1 = SecondTry(32);
            bool answer2 = SecondTry(128);
            bool answer3 = SecondTry(122);
        }



        public static bool IsPowerTwo(int number)
        {
            string binary = Convert.ToString(number, 2);

            bool wasOneFound = false;
            foreach(char bin in binary)
            {
                if(bin == '1')
                {
                    if(wasOneFound)
                    {
                        return false;
                    }
                    wasOneFound = true;
                }
            }
            return true;

        }

        public static bool SecondTry(int number)
        {
            int wall = 1;
            while(wall < number)
            {
                wall = wall << 1;
            }

            return wall == number;
        }

        public static int NearestPowerOf2(int number)
        {
            int wall = 1;
            while (wall <= number)
            {
                wall = wall << 1;
            }

            return wall >> 1;
        }

        public static int ClosestPowerOf2(int number)
        {
            int wall = 1;
            while(wall <= number)
            {
                wall = wall << 1;
            }

            if(wall - number > number - (wall >> 1))
            {
                return wall >> 1;
            }
            return wall;
        }

        public static bool NumericalCheckPowerTwo(int number)
        {
            return (int)Math.Log2(number) == Math.Log2(number);
        }

        public static int MakeZero(int number, int index)
        {
            int binaryIndex = 1 << index;
            return number & (int.MaxValue - binaryIndex);
        }

        public static int MakeOne(int number, int index)
        {
            int binaryIndex = 1 << index;
            return number | binaryIndex;
        }

        public static int FlipABit(int number, int index)
        {
            int binaryIndex = 1 << index;
            return number ^ binaryIndex;
        }

        public static int SetABit(int number, int index, bool shouldOne)
        {
            int mask = 1 << index;
            number |= mask;

            if(shouldOne)
            {
                return number;
            }

            return number - mask;
        }

        public static byte[] IntToByteArray(int number)
        {
            byte[] returnValue = new byte[sizeof(int)];
            for(int i = 0; i < returnValue.Length; i ++)
            {
                returnValue[i] = GetByte(number, i);
            }

            return returnValue;
        }

        //public static byte GetAByte(int number, int index)
        //{
        //    int modFactor = (int)Math.Pow(10, index + 1);

        //    return (byte)(number % modFactor / (modFactor/10));
        //}

        public static byte GetByte(int number, int index)
        {
            int shiftLength = index * 8;
            int targetByte = number >> shiftLength;
            int mask = 255;

            return (byte)(targetByte & mask);
        }

        public unsafe static bool IsPalindrome(string word)
        {
            fixed(char* location = word)
            {
                char* current = location;
                char* target = current + word.Length;
                int currentIndex = word.Length - 1;
                while(current < target)
                {
                    if(*current != word[currentIndex])
                    {
                        return false;
                    }
                    currentIndex--;
                    current++;
                }
            }

            return true;
        }

        enum Commands
        {
            Add = 0x0,
            Sub = 0x1,
            Mul = 0x2,
            Div = 0x3,
            Mod = 0x4,
        };

        public static int DoMath(int data)
        {

            byte[] info = IntToByteArray(data);

            int returnValue;

            int command = info[3];

            switch((Commands)command)
            {
                case Commands.Add:
                    returnValue = info[1] + info[0];
                    break;

                case Commands.Sub:
                    returnValue = Subtract(info[1], info[0]);
                    break;

                case Commands.Mul:
                    returnValue = Multiply(info[1], info[0]);
                    break;

                case Commands.Div:
                    returnValue = Divide(info[1], info[0]);
                    break;

                case Commands.Mod:
                    returnValue = Mod(info[1], info[0]);
                    break;

                default:
                    throw new Exception("That command does not exist");
                    break;
            }

            return returnValue;
        }


        public static byte Multiply(byte left, byte right)
        {
            byte returnValue = 0;
            for (int i = 0; i < right; i++)
            {
                returnValue += left;
            }
            return returnValue;
        }

        public static byte Subtract(byte left, byte right)
        {
            return (byte)(left + -1 *right);
        }

        public static byte Divide(byte left, byte right)
        {
            byte currentNum = left;
            byte currentIterations = 0;
            while(currentNum >= right)
            {
                currentIterations++;
                currentNum -= right;
            }
            return currentIterations;
        }

        public static byte Mod(byte left, byte right)
        {
            byte currentNum = left;
            while (currentNum >= right)
            {
                currentNum -= right;
            }
            return currentNum;
        }



        public static void SMath(byte command)
        {
            ~~

        }


        public static void SAdd()
        {
            stack.Push((byte)(stack.Pop() + stack.Pop()));
        }

        public static void SSub()
        {
            stack.Push((byte)Subtract(stack.Pop(), stack.Pop()));
        }

        public static void SMult()
        {
            byte left = stack.Pop();
            byte right = stack.Pop();
            byte returnValue = 0;
            for (int i = 0; i < right; i++)
            {
                returnValue += left;
            }
            stack.Push(returnValue);
        }

        public static void SDiv()
        {
            byte left = stack.Pop();
            byte right = stack.Pop();
            byte currentNum = left;
            byte currentIterations = 0;
            while (currentNum >= right)
            {
                currentIterations++;
                currentNum -= right;
            }
            stack.Push(currentIterations);
        }

        public static void SMod()
        {
            byte left = stack.Pop();
            byte right = stack.Pop();
            byte currentNum = left;
            while (currentNum >= right)
            {
                currentNum -= right;
            }
            stack.Push(currentNum);
        }
    }
}
