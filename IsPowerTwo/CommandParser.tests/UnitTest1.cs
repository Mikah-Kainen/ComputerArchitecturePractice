using IsPowerTwo;

using System;
using System.Collections.Generic;
using Xunit;
using SharedLibrary;

namespace CommandParser.tests
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("ADD", Tokens.ADD)]
        [InlineData(" ADD", Tokens.ADD)]
        [InlineData("   ADD", Tokens.ADD)]
        [InlineData("adD", Tokens.ADD)]
        [InlineData("eat", Tokens.EMPTY)]
        [InlineData("dad", Tokens.EMPTY)]
        [InlineData("AddSubBurp", Tokens.ADD)]
        [InlineData("BurpAddSub", Tokens.EMPTY)]
        [InlineData("\nADD", Tokens.EMPTY)]
        [InlineData("AS LKBSDKJL123DSFJ:", Tokens.LABEL)]
        [InlineData("DSLFKJSDFFK::::::LSfkLFKJ", Tokens.EMPTY)]

        public void DoesGetTokenWork(string input, Tokens expected)
        {
            IsPowerTwo.CommandParser test = new IsPowerTwo.CommandParser();

            Assert.Equal(expected, test.GetToken(input));
        }


        [Theory]
        [InlineData("Add R01 R02 R02", new byte[4] { 1, 1, 2, 2})]
        [InlineData("adD r1 r24 r31", new byte[4] { 1, 1, 24, 31})]
        [InlineData("ADD r1 r3 r2 ;asfdafadf", new byte[4] { 1, 1, 3, 2})]
        //[InlineData("ADDD r1 r1 r2", new byte[0] { })]

        public void DoesAddParseWork(string command, byte[] expected)
        {
            IsPowerTwo.CommandParser test = new IsPowerTwo.CommandParser();

            Tokens commandToken = test.GetToken(command);
            Assert.Equal(expected, test.ParseCommand[commandToken](command));
        }

        [Theory]
        [InlineData("ADDD r1 r1 r2")]
        
        public void DoesAddParseThrowProperly(string command)
        {
            IsPowerTwo.CommandParser test = new IsPowerTwo.CommandParser();

            Action shouldThrow = () => { test.ParseCommand[test.GetToken(command)](command); };
            Assert.Throws<SystemException>(shouldThrow);
        }
    }
}
