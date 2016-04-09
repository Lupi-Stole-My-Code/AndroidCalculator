using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AndroidCalculator
{
    public static class Calc
    {
        static double Memory = 0.0;
        static bool MemoryNull;
        static bool isA = false;
        static double A = 0.0;
        static bool isOperation = false;
        static int operation;
        public enum Operation {Add = 1, Sub = 2, Multi = 3, Div = 4, Sqrt = 5, Sqare = 6};

        public static void reset()
        {
            isA = false;
            isOperation = false;
            A = 0.0;
        }

        public static void MemoryClear()
        {
            MemoryNull = true;
            Memory = 0.0;
        }

        public static void MemoryAddTo(double num)
        {
            if(!MemoryNull)
            {
                MemoryNull = true;
                Memory = 0.0;
            }
            Memory += num;
        }

        public static void MemorySubTo(double num)
        {
            if (!MemoryNull)
            {
                MemoryNull = true;
                Memory = 0.0;
            }
            Memory -= num;
        }

        public static double MemoryRecall()
        {
            return Memory;
        }

        public static void ExecAddition(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Add;
            isOperation = true;
        }

        public static void ExecSubstraction(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Sub;
            isOperation = true;
        }

        public static void ExecMultiplication(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Multi;
            isOperation = true;
        }

        public static void ExecDivision(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Div;
            isOperation = true;
        }

        public static bool getResult(double B,out double result, out string comment)
        {
            if(isA && isOperation)
            {
                switch(operation)
                {
                    case (int)Operation.Add:
                        result = A + B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: +";
                        return true;
                        break;
                    case (int)Operation.Sub:
                        result = A - B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: -";
                        return true;
                        break;
                    case (int)Operation.Multi:
                        result = A * B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: *";
                        return true;
                        break;
                    case (int)Operation.Div:
                        result = A / B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: /";
                        return true;
                        break;
                }
            }
            else
            {
                result = -1.0;
                comment = "Debug: A=" + A.ToString() + " ; B=" + B.ToString() + " ; " + "OP=" + operation.ToString();
                return false;
            }
            comment = "IMPOSSIBLE";
            result = 666.66;
            return false;

        }

        public static double ExecSquareRoot(double A)
        {
            return Math.Sqrt(A);
        }

        public static double ExecEscalation(double A)
        {
            return A * A;
        }

        public static double Sinus(double A)
        {
            return Math.Sin(ToRadians(A));
        }

        public static double Cosinus(double A)
        {
            return Math.Cos(ToRadians(A));
        }

        public static double Tangens(double A)
        {
            return Math.Tan(ToRadians(A));
        }

        public static double Invert(double A)
        {
            return 1.0 / A;
        }

        static double ToRadians(double a)
        {
            return (Math.PI / 180.0) * a;
        }
    }
}