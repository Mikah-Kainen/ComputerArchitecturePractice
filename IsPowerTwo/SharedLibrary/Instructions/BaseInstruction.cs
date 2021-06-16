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

        public ILayout Layout;

        public virtual byte[] Parse(string input) => Layout.Parser(input);


        //public static Dictionary<Tokens, Regex> GetRegex = new Dictionary<Tokens, Regex>()
        //{
        //    [Tokens.NOP] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}NOP{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.ADD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}ADD{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.SUB] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SUB{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.MULT] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}MULT{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.DIV] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}DIV{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.MOD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}MOD{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.EQ] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}EQ{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.SETI] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SETI{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.hexValue}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.SET] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}SET{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.LOAD] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}LOAD{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.memoryAddress}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.GOTO] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}GOTO{RegexShortcuts.space}{RegexShortcuts.memoryAddress}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.GOTR] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}GOTR{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.memoryAddress}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //    [Tokens.STR] = new Regex($@"{RegexShortcuts.start}{RegexShortcuts.ignoreCase}LOAD{RegexShortcuts.space}{RegexShortcuts.register}{RegexShortcuts.space}{RegexShortcuts.memoryAddress}{RegexShortcuts.space}{RegexShortcuts.padding}{RegexShortcuts.comment}{RegexShortcuts.end}"),
        //};

        //public static Dictionary<Type, Tokens> GetTokenFromType = new Dictionary<Type, Tokens>()
        //{
        //    //[Tokens.NOP]
        //    [typeof(ADD)] = Tokens.ADD,
        //    //[Tokens.SUB]
        //    //[Tokens.MULT]
        //    //[Tokens.DIV]
        //    //[Tokens.MOD]
        //    //[Tokens.EQ]
        //    //[Tokens.SETI]
        //    //[Tokens.SET]
        //    //[Tokens.LOAD]
        //    //[Tokens.GOTO]
        //    //[Tokens.GOTR]
        //    //[Tokens.STR]
        //};

        //public virtual Regex Pattern { get { return GetRegex[GetTokenFromType[this.GetType()]]; } }
        //public abstract string Op {get; }
        //public abstract byte OpByte {get;}
        //public abstract bool Parse(string input);

        //public abstract byte[] Emit();

    }
}
