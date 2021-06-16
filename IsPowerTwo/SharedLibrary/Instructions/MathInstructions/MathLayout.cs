using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.MathInstructions
{
    public class MathLayout : ILayout
    {
        public Regex Pattern;
        public byte[] AssembledBytes;

        public MathLayout(Type type)
        {
            Tokens token = Dictionaries.GetTokenFromType[type];
            Pattern = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}{token.ToString()}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}");

            AssembledBytes = new byte[Pattern.GetGroupNumbers().Length];
            AssembledBytes[0] = (byte)token; // gets the OpByte and stores it in AssembledBytes
        }

        //public byte[] Emit()
        //{
        //    return AssembledBytes;
        //}

        public bool Parse(string input)
        {
            string[] parse = Pattern.Split(input);
            if (parse.Length != 5)
            {
                throw new SystemException("IDK WHAT THIS COMMAND IS");
            }

            for (int i = 1; i < 4; i ++)
            {
                AssembledBytes[i] = byte.Parse(parse[i]);
            }

            return true;
        }
        public byte[] Parser(string input)
        {
            Parse(input);
            return AssembledBytes;
        }

    }
}
