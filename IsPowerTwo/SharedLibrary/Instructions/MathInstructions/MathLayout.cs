using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions.MathInstructions
{
    public class MathLayout : ILayout
    {
        Regex regex;

        public MathLayout()
        {
            regex = new Regex($@"{start}{ignoreCase}ADD{space}{register}{space}{register}{space}{register}{comment}{end}");
        }

        public byte[] Parse(string input)
        {

        }

    }
}
