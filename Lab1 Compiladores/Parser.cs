using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compiladores
{
    class Parser
    {
        Scanner scanner;
        Token nextToken;
       
        private void E()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }
        private void EP()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Plus:
                    Match(TokenType.Plus);
                    T();
                    EP();
                    break;
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }
        private void T()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    F();
                    TP();
                    break;
                default:
                    break;
            }
        }
        private void TP()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Mult:
                    Match(TokenType.Mult);
                    F();
                    TP();
                    break;
                case TokenType.Div:
                    Match(TokenType.Div);
                    F();
                    TP();
                    break;
                default:
                    break;
            }
        }
        private void F()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    M();
                    break;
                case TokenType.Num:
                case TokenType.LParen:
                    M();
                    break;
                default:
                    break;
            }
        }
        private void M()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Num:
                    Match(TokenType.Num);
                    break;
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    E();
                    Match(TokenType.RParen);
                    break;
                default:
                    break;
            }
        }
        private void Match(TokenType tag)
        {
            if (nextToken.Tag == tag)
            {
                nextToken = scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de sintaxis, Caracter esperado: " + tag);
            }
        }

        public void Parse(string regexp)
        {

            scanner = new Scanner(regexp + (char)TokenType.EOF);
            nextToken = scanner.GetToken();
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
        }
    }
}
