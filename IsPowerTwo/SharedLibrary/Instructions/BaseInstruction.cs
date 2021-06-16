using SharedLibrary.Instructions.MathInstructions;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SharedLibrary;

namespace SharedLibrary.Instructions
{
    public abstract class BaseInstruction
    {

        public static Dictionary<Tokens, Regex> GetRegex = new Dictionary<Tokens, Regex>()
        {
            [Tokens.NOP] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}NOP{space}{padding}{space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.ADD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}ADD{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.SUB] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SUB{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.MULT] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}MULT{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.DIV] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}DIV{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.MOD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}MOD{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.EQ] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}EQ{space}{register}{space}{register}{space}{register}{comment}{end}"),
            [Tokens.SETI] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SETI{space}{register}{space}{hexValue}{space}{padding}{comment}{end}"),
            [Tokens.SET] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SET{space}{register}{space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.LOAD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}LOAD{space}{register}{space}{memoryAddress}{space}{padding}{comment}{end}"),
            [Tokens.GOTO] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}GOTO{space}{memoryAddress}{space}{padding}{space}{padding}{comment}{end}"),
            [Tokens.GOTR] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}GOTR{space}{register}{space}{memoryAddress}{space}{padding}{comment}{end}"),
            [Tokens.STR] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}LOAD{space}{register}{space}{memoryAddress}{space}{padding}{comment}{end}"),
        };

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

        public virtual Regex Pattern { get { return GetRegex[GetTokenFromType[this.GetType()]]; } }
        public abstract string Op {get; }
        public abstract byte OpByte {get;}
        public abstract bool Parse(string input);

        public abstract byte[] Emit();

    }
}
