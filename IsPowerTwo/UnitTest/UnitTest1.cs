
using IsPowerTwo;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(64)]
        [InlineData(3)]
        public void DoesIsPowerOf2Work(int number)
        {
            Assert.Equal(Program.IsPowerTwo(number), Program.NumericalCheckPowerTwo(number));
        }


        [Theory]
        [InlineData(64)]
        [InlineData(3)]
        public void DoesSecondTryWork(int number)
        {
            Assert.Equal(Program.SecondTry(number), Program.NumericalCheckPowerTwo(number));
        }

        [Theory]
        [InlineData(64)]
        [InlineData(32)]
        public void IsPower2(int number)
        {
            Assert.True(Program.NumericalCheckPowerTwo(number));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(57)]
        public void IsNotPower2(int number)
        {
            Assert.False(Program.NumericalCheckPowerTwo(number));
        }

        [Theory]
        [InlineData(4, 4)]
        [InlineData(3, 2)]
        [InlineData(255, 128)]
        [InlineData(0, 0)]
        [InlineData(257, 256)]
        public void DoesNearestPowerOf2Work(int number, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.NearestPowerOf2(number));
        }

        [Theory]
        [InlineData(4, 4)]
        [InlineData(3, 4)]
        [InlineData(255, 256)]
        [InlineData(0, 0)]
        [InlineData(257, 256)]
        [InlineData(13, 16)]

        public void DoesClosestPowerOf2Work(int number, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.ClosestPowerOf2(number));
        }

        [Theory]
        [InlineData(255, 0, 254)]
        [InlineData(0, 1, 0)]
        [InlineData(255, 2, 251)]
        [InlineData(255, 3, 247)]

        public void DoesMakeZeroWork(int number, int index, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.MakeZero(number, index));
        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(255, 1, 255)]
        [InlineData(0, 2, 4)]
        [InlineData(0, 3, 8)]

        public void DoesMakeOneWork(int number, int index, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.MakeOne(number, index));
        }

        [Theory]
        [InlineData(255, 0, 254)]
        [InlineData(0, 1, 2)]
        [InlineData(0, 6, 64)]
        [InlineData(64, 7, 192)]

        public void DoesFlipDigit(int number, int index, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.FlipABit(number, index));
        }


        //[Theory]
        //[InlineData(1, 0, 1)]
        //[InlineData(20, 1, 2)]
        //[InlineData(54321, 2, 3)]

        //public void DoesGetAByteWork(int number, int index, int expectedResult)
        //{
        //    Assert.Equal(expectedResult, Program.GetAByte(number, index));
        //}

        [Theory]
        [InlineData(0x01, 0, 0x01)]
        [InlineData(0x20, 0, 0x20)]
        [InlineData(0x54321, 1, 0x43)]
        [InlineData(0x123987, 2, 0x12)]

        public void DoesGetByteWork(int number, int index, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.GetByte(number, index));
        }


        [Theory]
        [InlineData(0x1111, new byte[]{0x11, 0x11, 0x00, 0x00})]
        [InlineData(0x123456, new byte[]{0x56, 0x34, 0x12, 0x00})]
        [InlineData(0x1, new byte[]{0x1, 0x00, 0x00, 0x00})]

        public void DoesIntToByteArrayWork(int number, byte[] expectedResult)
        {
            Assert.Equal(expectedResult, Program.IntToByteArray(number));
        }


        [Theory]
        [InlineData(2, 4)]
        [InlineData(35, 2)]
        [InlineData(0, 100)]
        [InlineData(5, 5)]
        public void DoesMultiplyWork(byte left, byte right)
        {
            Assert.Equal(Program.Multiply(left, right), left * right);
        }


        [Theory]
        [InlineData(2, 4)]
        [InlineData(35, 2)]
        [InlineData(0, 100)]
        [InlineData(5, 5)]
        public void DoesSubtractWork(byte left, byte right)
        {
            Assert.Equal(Program.Subtract(left, right), left - right);
        }


        [Theory]
        [InlineData(2, 4)]
        [InlineData(35, 2)]
        [InlineData(0, 100)]
        [InlineData(5, 5)]
        public void DoesDivideWork(byte left, byte right)
        {
            Assert.Equal(Program.Divide(left, right), left / right);
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(35, 2)]
        [InlineData(0, 100)]
        [InlineData(5, 5)]
        public void DoesModWork(byte left, byte right)
        {
            Assert.Equal(Program.Mod(left, right), left % right);
        }

        [Fact]
        public void DoesDoMathWork()
        {
            Assert.Equal(0xB, Program.DoMath(0x00000506));
            Assert.Equal(0x2, Program.DoMath(0x01000402));
            Assert.Equal(0xA, Program.DoMath(0x02000502));
            Assert.Equal(0x3, Program.DoMath(0x03000602));
            Assert.Equal(0x1, Program.DoMath(0x04000703));
        }


        [Theory]
        [InlineData("abcba", true)]
        [InlineData("y", true)]
        [InlineData("bro", false)]

        public void DoesIsPalindromeWork(string data, bool expected)
        {
            Assert.Equal(expected, Program.IsPalindrome(data));
        }

        [Theory]
        [InlineData(10, 2)]
        [InlineData(6, 3)]

        public void DoesSMathWork(byte left, byte right)
        {
            Stack<byte> testStack = new Stack<byte>();
            for(int i = 0; i < 5; i ++)
            {
                testStack.Push(right);
                testStack.Push(left);
            }

            Program.SMath(Program.Commands.Add);
            Assert.Equal(testStack.Pop(), left + right);

            Program.SMath(Program.Commands.Sub);
            Assert.Equal(testStack.Pop(), left - right);

            Program.SMath(Program.Commands.Mul);
            Assert.Equal(testStack.Pop(), left * right);

            Program.SMath(Program.Commands.Div);
            Assert.Equal(testStack.Pop(), left / right);

            Program.SMath(Program.Commands.Mod);
            Assert.Equal(testStack.Pop(), left % right);
        }

        /*


        set r1 0x0
        set r2 0x1
        set r3 0xA

        1
        add r1 r1 r2

        eq r5 r1 r3
        breq 2 r5
        goto 1

        2

        end
        goto end

        */

    }
}
