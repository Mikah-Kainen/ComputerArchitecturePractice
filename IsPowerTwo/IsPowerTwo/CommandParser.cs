using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsPowerTwo
{

    public class TokenData
    {
        public string Input { get; private set; }
        public Tokens Token { get; set; }

        public TokenData(string input, Tokens token)
        {
            Input = input;
            Token = token;
        }

    }

    public class CommandParser
    {
        //public Dictionary<string, byte> CommandToByte = new Dictionary<string, byte>()
        //{
        //    ["nop"] = 0x00,

        ////    ["add"] = 0x01,
        //    ["sub"] = 0x02,
        //    ["mul"] = 0x03,
        //    ["div"] = 0x04,
        //    ["mod"] = 0x05,
        //    ["eq"] = 0x06,

        //    ["goto"] = 0x10,
        //    ["gotr"] = 0x11,

        //    ["seti"] = 0x20,
        //    ["set"] = 0x21,
        //    ["load"] = 0x22,
        //    ["str"] = 0x23,
        //};

        public Dictionary<string, short> GotoTracker;
        public Dictionary<Tokens, Regex> GetRegex;

        Dictionary<string, Tokens> getToken;

        short currentLocation;
        int totalTokens => (int)Tokens.EMPTY + 1;

        //public Dictionary<string, byte> RegisterToAddress = new Dictionary<string, byte>();
        //[(A-Z)*(a-z)*]*:
        public CommandParser()
        {
            //ADD + (R\d +) +(R\d +) +(R\d +) https://regexr.com/
            //^(?i)(ADD) +(R\d+) +(R\d+) +(R\d+) https://regex101.com/
            Regex re = new Regex(@"^Add +(R\d{1,2}) +(R\d{1,2}) +(R\d{1,2})");
            var match = re.Match(" Add R12 R34 R 2");
            for (int i = 1; i < match.Groups.Count; i++)
            {
                Console.WriteLine(match.Groups[i].ToString());
            }

            getToken = new Dictionary<string, Tokens>();
            GotoTracker = new Dictionary<string, short>();
            GetRegex = new Dictionary<Tokens, Regex>();

            for(int i = 0; i < totalTokens; i ++)
            {
                getToken.Add(((Tokens)i).ToString(), (Tokens)i);
            }

            GetRegex.Add(Tokens.ADD,   new Regex(@" *(?i)(ADD)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.SUB,   new Regex(@" *(?i)(SUB)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.MULT,  new Regex(@" *(?i)(MULT) +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.DIV,   new Regex(@" *(?i)(DIV)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.MOD,   new Regex(@" *(?i)(MOD)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.EQ,    new Regex(@" *(?i)(EQ)   +(R\d+) +(R\d+) +(R\d+)"));

            GetRegex.Add(Tokens.GOTO,  new Regex(@" *(?i)(ADD)  +(\d+):$"));
            GetRegex.Add(Tokens.GOTR,  new Regex(@" *(?i)(ADD)  +(R\d+) +(R\d+) +(R\d+)"));

            GetRegex.Add(Tokens.ADD,   new Regex(@" *(?i)(ADD)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.ADD,   new Regex(@" *(?i)(ADD)  +(R\d+) +(R\d+) +(R\d+)"));
            GetRegex.Add(Tokens.ADD,   new Regex(@" *(?i)(ADD)  +(R\d+) +(R\d+) +(R\d+)"));
        }

        public string[] SplitCommands(string input)
        {
            string[] commands = input.Split('\n');

            return commands;
        }

        public Tokens GetToken(string input)
        {
            if (getToken.ContainsKey(input))
            {
                return getToken[input];
            }

            List<Regex> superTemp = new List<Regex>();
            foreach(var kvp in getToken)
            {
                Regex current = new Regex(@"^( *(?i)(" + kvp.Key + @"))");
                superTemp.Add(current);
                if(current.IsMatch(input))
                {
                    return kvp.Value;
                }
            }

            Regex isLabel = new Regex(@":$");
            if(isLabel.IsMatch(input))
            {
                GotoTracker.Add(input, currentLocation);
                return Tokens.LABEL;
            }
            
            return Tokens.EMPTY;
        }
        public TokenData GetTokenData(string input)
        {
            if (getToken.ContainsKey(input))
            {
                return new TokenData(input, getToken[input]);
            }

            List<Regex> superTemp = new List<Regex>();
            foreach (var kvp in getToken)
            {
                Regex current = new Regex(@"^( *(?i)(" + kvp.Key + @"))");
                superTemp.Add(current);
                if (current.IsMatch(input))
                {
                    return new TokenData(input, kvp.Value);
                }
            }

            Regex isLabel = new Regex(@":$");
            if (isLabel.IsMatch(input))
            {
                GotoTracker.Add(input, currentLocation);
                return new TokenData(input, Tokens.LABEL);
            }

            return new TokenData(input, Tokens.EMPTY);
        }

        //public int ParseTokenData(TokenData input)
        //{

        //}


        //public void UseFunctions(string[] commands)
        //{
        //    foreach(string command in commands)
        //    {
        //        foreach(Regex reg in RegexOptions)
        //        {
        //            if(reg.Equals(command))
        //            {
        //                GetFunction[reg]((string)reg.Match(command));
        //                break;
        //            }
        //        }
        //    }
        //}
    }




        /*
        Add Sub Mul Div
        And Or Xor Not Eq
        Goto Goeq 
        Set

        */



        


        /*
        nop 0

        add 1
        sub 2
        mul 3
        div 4
        mod 5
        eq 6

        goto 10
        gotr 11

        seti 20
        set 21
        load 22
        str 23


        Keyboard Input
            -RKeypressed
            -RKeyvalue

        Random
            -RRequest
            -RValue

        WriteChar
            -RRequest
            -RValue


        
         //sharplab
         //gobolt.org
         
        //rA = stackPointer
0x0004     set r4 rA            // 0x06 0x04 0x0A 0xff
                                
0x0008     seti r0 0            // 0x20 0x00 0x0000
0x000C    seti r1 1             // 0x20 0x01 0x0001
0x0010    seti r2 100           // 0x20 0x02 0x0100
0x0014    seti r3 0xab          // 0x20 0x03 0x00AB
                                
                                
          loop:                  
                                
0x0018    set rA r0             //0x21 0x0A 0x00 0xff
0x001C    sub rA rA r1          //0x02 0x0A 0x0A 0x01
                                
0x0020    add r0 r0 r1          //0x01 0x00 0x00 0x01
0x0024    eq r6 r0 r2           //0x06 0x06 0x00 0x02
0x0028    gotr leave r6         //0x11 0x002C 0x06 0xff
                                
0x002C    goto loop             //0x10 0x0014 0xff
                                
        leave:                  
                                
0x0030  seti r5 0               //0x20 0x05 0x0000
        loop2                   
                                
0x0034  load r0 r4              //0x22 0x00 0x04 0xff
0x0038  add r5 r5 r0            //0x01 0x05 0x05 0x00
0x003C  add r4 r4 r1            //0x01 0x04 0x04 0x01
        
0x0040  eq r6 r29 r4            //0x06 0x06 0x0A 0x04
0x0044  gotr finalCount r6      //0x11 0x0048 0x06
0x0048  goto loop2              //0x10 0x0030 0xff


        finalCount:
0x004C  str r3 r5               //0x23 0x03 0x05 0xff

        end:
0x0050  goto end                //0x10 0x004C 0xff

        */

        /*
        rA = stackPointer
        rB = randomRequest
        rC = randomValue
 
        0x0004     set r4 rA      
                                   
        0x0008     seti r0 0       
        0x000C    seti r1 1        
        0x0010    seti r2 100      
        0x0014    seti r3 0xab     



        loop:            
                           
        seti rB 1 
        0x0018    set rA rB        
        0x001C    sub rA rA r1     
                                   
        0x0020    add r0 r0 r1     
        0x0024    eq r6 r0 r2      
        0x0028    gotr leave r6    
                                   
        0x002C    goto loop

                leave:             
                                   
        0x0030  seti r5 0          
                loop2              
                                   
        0x0034  load r0 r4         
        0x0038  add r5 r5 r0       
        0x003C  add r4 r4 r1       
                
        0x0040  eq r6 r29 r4       
        0x0044  gotr finalCount r6 
        0x0048  goto loop2


                finalCount:
        0x004C  str r3 r5

                end:
        0x0050  goto end

                */
}
