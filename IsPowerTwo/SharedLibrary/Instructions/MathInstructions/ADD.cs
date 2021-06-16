using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace SharedLibrary.Instructions.MathInstructions
{
    public class ADD : BaseInstruction
    {
        public ADD()
        {
            Layout = new MathLayout(this.GetType());
        }

        //public byte Destination;
        //public byte LeftRegister;
        //public byte RightRegister;

        //public override Regex Pattern => GetRegex[Tokens.ADD];

        //public override string Op => Tokens.ADD.ToString();

        //public override byte OpByte => 0x01;

        //public ADD()
        //{
        //}

        //public override byte[] Emit()
        //{
        //    return new byte[] { OpByte, Destination, LeftRegister, RightRegister };
        //}

        //public override bool Parse(string input)
        //{
        //    string[] parse = Pattern.Split(input);
        //    if(parse.Length != 5)
        //    {
        //        throw new SystemException("IDK WHAT THIS COMMAND IS");
        //    }

        //    Destination = byte.Parse(parse[1]);
        //    LeftRegister = byte.Parse(parse[2]);
        //    RightRegister = byte.Parse(parse[3]);

        //    return true;
        //}
    }
}
