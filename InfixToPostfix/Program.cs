using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InfixToPostfix
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Stack st = new Stack();
                string input = "", output = "", lp = ""; // "lp" == lower precedent operators

                Console.Write("Infix Notation:   ");
                input = new string(Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)).ToArray());

                foreach (char c in input)
                {
                    lp = "";
                    if (!"+-*/()".Contains(c))
                    {
                        output += c;
                    }
                    else if (c == ')')
                    {
                        while ((char)st.Peek() != '(')
                        {
                            output += st.Pop();
                        }
                        st.Pop();
                    }
                    else
                    {
                        if ("(".Contains(c))
                        {
                            lp = "+-*/";
                        }
                        if ("*/".Contains(c))
                        {
                            lp = "+-";
                        }
                        while (st.Count > 0 && (char)st.Peek() != '(' && !lp.Contains((char)st.Peek()))
                        {
                            output += st.Pop();
                        }
                        st.Push(c);
                    }
                }

                while (st.Count > 0)
                {
                    output += st.Pop();
                }

                Console.WriteLine("PostFix Notation: " + output + "\n");
            }
        }
    }
}