using System;
using System.Collections.Generic;

namespace IsPowerTwo
{
    public unsafe class Program
    {
        public static Stack<byte> stack = new Stack<byte>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CommandParser test = new CommandParser();
            test.GetToken("HI");
        }



        public static bool IsPowerTwo(int number)
        {
            string binary = Convert.ToString(number, 2);

            bool wasOneFound = false;
            foreach (char bin in binary)
            {
                if (bin == '1')
                {
                    if (wasOneFound)
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
            while (wall < number)
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
            while (wall <= number)
            {
                wall = wall << 1;
            }

            if (wall - number > number - (wall >> 1))
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

            if (shouldOne)
            {
                return number;
            }

            return number - mask;
        }

        public static byte[] IntToByteArray(int number)
        {
            byte[] returnValue = new byte[sizeof(int)];
            for (int i = 0; i < returnValue.Length; i++)
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
            fixed (char* location = word)
            {
                char* current = location;
                char* target = current + word.Length;
                int currentIndex = word.Length - 1;
                while (current < target)
                {
                    if (*current != word[currentIndex])
                    {
                        return false;
                    }
                    currentIndex--;
                    current++;
                }
            }

            return true;
        }

        public enum Commands
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

            switch ((Commands)command)
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
            return (byte)(left - right);
        }

        public static byte Divide(byte left, byte right)
        {
            byte currentNum = left;
            byte currentIterations = 0;
            while (currentNum >= right)
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

        public static void SMath(Commands command)
        {
            switch (command)
            {
                case Commands.Add:
                    SAdd();
                    break;

                case Commands.Sub:
                    SSub();
                    break;

                case Commands.Mul:
                    SMult();
                    break;

                case Commands.Div:
                    SDiv();
                    break;

                case Commands.Mod:
                    SMod();
                    break;
            }
        }

        public static void SAdd()
        {
            stack.Push((byte)(stack.Pop() + stack.Pop()));
        }

        public static void SSub()
        {
            byte left = stack.Pop();
            byte right = stack.Pop();
            byte returnValue = (byte)(left + ~(right - 1));
            stack.Push(returnValue);
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

        public unsafe static int GetSum(byte* pointer, byte length)
        {
            int returnValue = 0;
            for (int i = 0; i < length; i++)
            {
                returnValue += *pointer;
                pointer++;
            }

            return returnValue;
        }





        /*
        Add Sub Mul Div
        And Or Xor Not Eq
        Goto Goeq 
        Set

       



        Regex re = new Regex(@"^Add +(R/d{1,2}) +(R/d{1,2}) +(R/d{1,2})");
        var match = re.Match(" Add R12 R34 R 2");
        for(int i = 1; i < match.Groups.Count; i ++)
        {
            Console.WriteLine(match.Groups[i].ToString());
        }

      
        nop 0

        add 1
        sub 2
        mul 3
        div 4
        mod 5
        eq 6

        goto 10
        gotr 11

        seti 20
        set 21
        load 22
        str 23


        Keyboard Input
            -RKeypressed
            -RKeyvalue

        Random
            -RRequest
            -RValue

        WriteChar
            -RRequest
            -RValue


        
         //sharplab
         //gobolt.org
         
        //rA = stackPointer
0x0004     set r4 rA            // 0x06 0x04 0x0A 0xff
                                
0x0008     seti r0 0            // 0x20 0x00 0x0000
0x000C    seti r1 1             // 0x20 0x01 0x0001
0x0010    seti r2 100           // 0x20 0x02 0x0100
0x0014    seti r3 0xab          // 0x20 0x03 0x00AB
                                
                                
          loop:                  
                                
0x0018    set rA r0             //0x21 0x0A 0x00 0xff
0x001C    sub rA rA r1          //0x02 0x0A 0x0A 0x01
                                
0x0020    add r0 r0 r1          //0x01 0x00 0x00 0x01
0x0024    eq r6 r0 r2           //0x06 0x06 0x00 0x02
0x0028    gotr leave r6         //0x11 0x002C 0x06 0xff
                                
0x002C    goto loop             //0x10 0x0014 0xff
                                
        leave:                  
                                
0x0030  seti r5 0               //0x20 0x05 0x0000
        loop2                   
                                
0x0034  load r0 r4              //0x22 0x00 0x04 0xff
0x0038  add r5 r5 r0            //0x01 0x05 0x05 0x00
0x003C  add r4 r4 r1            //0x01 0x04 0x04 0x01
        
0x0040  eq r6 r29 r4            //0x06 0x06 0x0A 0x04
0x0044  gotr finalCount r6      //0x11 0x0048 0x06
0x0048  goto loop2              //0x10 0x0030 0xff


        finalCount:
0x004C  str r3 r5               //0x23 0x03 0x05 0xff

        end:
0x0050  goto end                //0x10 0x004C 0xff

        */

        /*
        rA = stackPointer
        rB = randomRequest
        rC = randomValue
 
        0x0004     set r4 rA      
                                   
        0x0008     seti r0 0       
        0x000C    seti r1 1        
        0x0010    seti r2 100      
        0x0014    seti r3 0xab     



        loop:            
                           
        seti rB 1 
        0x0018    set rA rB        
        0x001C    sub rA rA r1     
                                   
        0x0020    add r0 r0 r1     
        0x0024    eq r6 r0 r2      
        0x0028    gotr leave r6    
                                   
        0x002C    goto loop

                leave:             
                                   
        0x0030  seti r5 0          
                loop2              
                                   
        0x0034  load r0 r4         
        0x0038  add r5 r5 r0       
        0x003C  add r4 r4 r1       
                
        0x0040  eq r6 r29 r4       
        0x0044  gotr finalCount r6 
        0x0048  goto loop2


                finalCount:
        0x004C  str r3 r5

                end:
        0x0050  goto end

                */
    }
}
