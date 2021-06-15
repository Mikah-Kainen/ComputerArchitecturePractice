using IsPowerTwo;

using System;
using System.Collections.Generic;
using Xunit;

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
    }
}
