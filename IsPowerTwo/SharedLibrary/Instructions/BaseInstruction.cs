using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class BaseInstruction
    {
        protected static string space = " +";
        protected static string ignoreCase = "?i";
        protected static string start = "^";
        protected static string end = "$";
        protected static string comment = "?:;.*";
        protected static string register = @"R[0,2][0,9]|R3[0,1]";
        protected static string number = @"\d{3}";
        protected static string hexValue = @"(?:0x)?\d{0,2}";
        protected static string padding = @"(?:0x)?f{0,4}";
        protected static string memoryAddress = @"(?:0x)?\d{0,4}";

        public static Dictionary<Tokens, Regex> GetRegex = new Dictionary<Tokens, Regex>()
        {
            [Tokens.NOP] = new Regex($@"{start}{ignoreCase}NOP{space}{padding}{space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.ADD] = new Regex($@"{start}{ignoreCase}ADD{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.SUB] = new Regex($@"{start}{ignoreCase}SUB{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.MULT] = new Regex($@"{start}{ignoreCase}MULT{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.DIV] = new Regex($@"{start}{ignoreCase}DIV{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.MOD] = new Regex($@"{start}{ignoreCase}MOD{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.EQ] = new Regex($@"{start}{ignoreCase}EQ{space}({register}){space}({register}){space}({register}){comment}{end}"),
            [Tokens.SETI] = new Regex($@"{start}{ignoreCase}SETI{space}({register}){space}({hexValue}){space}{padding}{comment}{end}"),
            [Tokens.SET] = new Regex($@"{start}{ignoreCase}SET{space}({register}){space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.LOAD] = new Regex($@"{start}{ignoreCase}LOAD{space}({register}){space}({memoryAddress}){space}{padding}{comment}{end}"),
            [Tokens.GOTO] = new Regex($@"{start}{ignoreCase}GOTO{space}({memoryAddress}){space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.GOTR] = new Regex($@"{start}{ignoreCase}GOTR{space}({register}){space}({memoryAddress}){space}{padding}{comment}{end}"),
            [Tokens.STR] = new Regex($@"{start}{ignoreCase}LOAD{space}({register}){space}({memoryAddress}){space}{padding}{comment}{end}"),
        };

        public abstract Regex Pattern { get; }
        public abstract string Op {get; }
        public abstract byte OpByte {get;}
        public abstract bool Parse(string input);

        public abstract byte[] Emit();

    }
}
