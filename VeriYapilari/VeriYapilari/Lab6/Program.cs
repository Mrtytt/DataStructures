using System;
using System.Collections.Generic;

class Ornek
{
    public int Tip;
    public int Islenen;
    public char Islem;
    private int oncelik;

    public int Oncelik
    {
        get { return oncelik; }
        set
        {
            oncelik = value;
            switch (Islem)
            {
                case '+':
                case '-':
                    oncelik = 1;
                    break;
                case '*':
                case '/':
                    oncelik = 2;
                    break;
                case '^':
                    oncelik = 3;
                    break;
                default:
                    oncelik = -1;
                    break;
            }
        }
    }

    public Ornek(char islem)
    {
        this.Tip = 1;
        this.Islem = islem;
        this.Oncelik = -1; 
    }

    public Ornek(int islenen)
    {
        this.Tip = 2;
        this.Islenen = islenen;
    }
}

class InfixToPostfixConverter
{
    static List<Ornek> InfixToPostfix(string exp)
    {
        List<Ornek> result = new List<Ornek>();
        Stack<Ornek> stack = new Stack<Ornek>();

        foreach (char c in exp)
        {
            if (char.IsLetterOrDigit(c))
            {
                result.Add(new Ornek(c - '0'));
            }
            else if (c == '(')
            {
                stack.Push(new Ornek(c));
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek().Islem != '(')
                {
                    result.Add(stack.Pop());
                }
                if (stack.Count > 0 && stack.Peek().Islem == '(')
                {
                    stack.Pop();
                }
            }
            else
            {
                Ornek yeniIslem = new Ornek(c);

                while (stack.Count > 0 && yeniIslem.Oncelik <= stack.Peek().Oncelik)
                {
                    result.Add(stack.Pop());
                }
                stack.Push(yeniIslem);
            }
        }

        while (stack.Count > 0)
        {
            result.Add(stack.Pop());
        }

        return result;
    }

    static void Main()
    {
        string exp = "a+b*(c^d-e)^(f+g*h)-i";
        var postfix = InfixToPostfix(exp);

        foreach (var item in postfix)
        {
            if (item.Tip == 2)
            {
                Console.Write((char)(item.Islenen + '0'));
            }
            else
            {
                Console.Write(item.Islem);
            }
        }
        Console.ReadKey();
    }
}
