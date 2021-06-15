using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace SharedLibrary.Instructions.MathInstructions
{
    public class ADD : BaseInstruction
    {
        public byte Destination;
        public byte AddLeft;
        public byte AddRight;

        public override Regex Pattern => GetRegex[Tokens.ADD];

        public override string Op => Tokens.ADD.ToString();

        public override byte OpByte => throw new NotImplementedException();

        public ADD()
        {
        }

        public override byte[] Emit()
        {
            return new byte[] { OpByte, Destination, AddLeft, AddRight };
        }

        public override bool Parse(string input)
        {
            string[] parse = Pattern.Split(input);
            if(parse.Length < 5)
            {
                return false;
            }

            Destination; 

            return true;
        }
    }
}
