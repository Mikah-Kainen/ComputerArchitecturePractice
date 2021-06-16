using SharedLibrary.Instructions.MathInstructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public static class Dictionaries
    {
        public static Dictionary<Type, Tokens> GetTokenFromType = new Dictionary<Type, Tokens>()
        {
            //[Tokens.NOP]
            [typeof(ADD)] = Tokens.ADD,
            //[Tokens.SUB]
            //[Tokens.MULT]
            //[Tokens.DIV]
            //[Tokens.MOD]
            //[Tokens.EQ]
            //[Tokens.SETI]
            //[Tokens.SET]
            //[Tokens.LOAD]
            //[Tokens.GOTO]
            //[Tokens.GOTR]
            //[Tokens.STR]
        };
    }
}
