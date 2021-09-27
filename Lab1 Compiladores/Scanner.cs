using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compiladores
{
    class Scanner
    {
        private string _regexp = "";
        private int _index;
        private int _currState;
        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _currState = 0;
        }
        public Token GetToken()
        {
            Token Tresult = new Token()
            {
                Value = ""
            };
            bool tokenFound = false;
            while (!tokenFound)
            {
                char peek = _regexp[_index];
                char peekNum;
                switch (_currState)
                {
                    case 0:
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _regexp[_index];
                        }
                        switch (peek)
                        {
                            case (char)TokenType.Plus:
                            case (char)TokenType.Minus:
                            case (char)TokenType.Mult:
                            case (char)TokenType.Div:
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.EOF:
                                tokenFound = true;
                                Tresult.Tag = (TokenType)peek;
                                break;
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                // Numeros
                                peekNum = _regexp[_index + 1];
                                switch (peekNum)
                                {
                                    case (char)TokenType.Plus:
                                    case (char)TokenType.Minus:
                                    case (char)TokenType.Mult:
                                    case (char)TokenType.Div:
                                    case (char)TokenType.LParen:
                                    case (char)TokenType.RParen:
                                    case (char)TokenType.EOF:
                                        tokenFound = true;
                                        Tresult.Tag = TokenType.Num;
                                        Tresult.Value += peek;
                                        break;
                                    default:
                                        _currState = 1;
                                        Tresult.Value += peek;
                                        break;
                                }
                                break;
                            default:
                                throw new Exception("Lex Error");
                        }
                        break;
                    case 1:
                        switch (peek)
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                peekNum = _regexp[_index + 1];
                                switch (peekNum)
                                {
                                    case (char)TokenType.Plus:
                                    case (char)TokenType.Minus:
                                    case (char)TokenType.Mult:
                                    case (char)TokenType.Div:
                                    case (char)TokenType.LParen:
                                    case (char)TokenType.RParen:
                                    case (char)TokenType.EOF:
                                        tokenFound = true;
                                        Tresult.Tag = TokenType.Num;
                                        Tresult.Value += peek;
                                        break;
                                    default:
                                        _currState = 1;
                                        Tresult.Value += peek;
                                        break;
                                }
                                break;
                            default:
                                throw new Exception("Lex Error");
                        }
                        break;
                    default:
                        break;
                }
                _index++;
            }

            _currState = 0;
            return Tresult;
        }
    }
}
