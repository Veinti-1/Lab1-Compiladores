using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compiladores
{
    class Parser
    {
        Scanner scanner;
        Token nextToken;

        private double E()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    double x = T() + EP();
                    return x;
                default:
                    return 0.0;
            }
        }
        private double EP()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Plus:
                    Match(TokenType.Plus);
                    double x = T() + EP();
                    return x;
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    double y = -T() + EP();
                    return y;
                default:
                    return 0.0;
            }
        }
        private double T()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    double x = F() * TP();
                    return x;
                default:
                    return 0.0;
            }
        }
        private double TP()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Mult:
                    Match(TokenType.Mult);
                    double x = F() * TP();
                    return x;
                case TokenType.Div:
                    Match(TokenType.Div);
                    double y = (1 / F()) * TP();
                    return y;
                default:
                    return 1.0;
            }
        }
        private double F()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    double x = -M();
                    return x;
                case TokenType.Num:
                case TokenType.LParen:
                    double y = M();
                    return y;
                default:
                    return 0.0;
            }
        }
        private double M()
        {
            switch (nextToken.Tag)
            {
                case TokenType.Num:
                    return Match(TokenType.Num);
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    double outE = E();
                    Match(TokenType.RParen);
                    return outE;
                default:
                    return 0.0;
            }
        }
        private double Match(TokenType tag)
        {
            double output = 0;
            if (nextToken.Tag == tag)
            {
                if (nextToken.Tag == TokenType.Num)
                {
                    output = Convert.ToDouble(nextToken.Value);
                }
                nextToken = scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de sintaxis, Caracter esperado: " + tag);
            }
            return output;
        }

        public double Parse(string regexp)
        {
            double output = 0;
            scanner = new Scanner(regexp + (char)TokenType.EOF);
            nextToken = scanner.GetToken();
            switch (nextToken.Tag)
            {
                case TokenType.Minus:
                case TokenType.Num:
                case TokenType.LParen:
                    output = E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
            return output;
        }
    }
}
