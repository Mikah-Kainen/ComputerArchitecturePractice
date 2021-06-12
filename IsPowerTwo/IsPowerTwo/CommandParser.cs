﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IsPowerTwo
{

    public class CommandParser
    {
        public Dictionary<string, byte> CommandToByte = new Dictionary<string, byte>()
        {
            ["nop"] = 0x00,

            ["add"] = 0x01,
            ["sub"] = 0x02,
            ["mul"] = 0x03,
            ["div"] = 0x04,
            ["mod"] = 0x05,
            ["eq"] = 0x06,

            ["goto"] = 0x10,
            ["gotr"] = 0x11,

            ["seti"] = 0x20,
            ["set"] = 0x21,
            ["load"] = 0x22,
            ["str"] = 0x23,
        };

        public Dictionary<string, byte> RegisterToAddress = new Dictionary<string, byte>();

        CommandParser()
        {

        }


        public byte[] ParseCommand(string command)
        {
            byte[] returnArray = new byte[4];
            string[] commandParts = command.Split(' ');

            returnArray[0] = CommandToByte[commandParts[0]];

            return returnArray;
        }
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