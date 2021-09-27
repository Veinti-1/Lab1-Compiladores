using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compiladores
{
    public enum TokenType
    {
        Plus = '+',
        Minus = '-',
        Mult = '*',
        Div = '/',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Num = (char)3
    }
}
