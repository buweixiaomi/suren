using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public class HExpression
    {

        /// <summary>
        ///0:未设定 1常量  2:变量 3:表达式
        /// </summary>
        public int HType { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public HExpression Current { get; set; }
        public HOperator Operator { get; set; }
        public HExpression RightExp { get; set; }
        private HExpression() { }
        public static HExpression Parse(string mExpression)
        {
            var exp = new HExpression();
            List<string> exitems = new List<string>();
            StringBuilder lastread = new StringBuilder();
            bool checkerror = false;
            for (var k = 0; k < mExpression.Length; k++)
            {
                checkerror = true;
                var cr = mExpression[k].ToString();
                if (string.IsNullOrWhiteSpace(cr)) continue;
                switch (cr)
                {
                    case "-":
                        if (lastread.Length > 0)
                        {
                            exitems.Add(lastread.ToString());
                            lastread.Clear();
                        }
                        if (exitems.Count == 0 || exitems.Last() == "(")
                        {
                            checkerror = false;
                            lastread.Append(cr);
                            break;
                        }
                        else
                        {
                            exitems.Add(cr);
                        }
                        break;
                    case "+":
                    case "*":
                    case "/":
                    case "(":
                    case ")":
                        if (lastread.Length > 0)
                        {
                            exitems.Add(lastread.ToString());
                            lastread.Clear();
                        }
                        exitems.Add(cr);
                        break;
                    default:
                        checkerror = false;
                        lastread.Append(cr);
                        break;
                }
                if (checkerror && lastread.Length > 0)
                {
                    return null;
                }
            }
            if (lastread.Length > 0)
            {
                exitems.Add(lastread.ToString());
                lastread.Clear();
            }

            Regex paraReg = new Regex("^@[a-zA-Z_\\$][a-zA-Z0-9_\\$]{0,50}$");
            Regex constReg = new Regex("^[\\-]{0,1}[0-9]{1,20}(\\.[0-9]{1,10}){0,1}$");
            Regex opReg = new Regex("^[\\+\\-\\*/\\()]$");

            Stack<HExpression> exps = new Stack<HExpression>();
            HExpression lastExp = exp;
            foreach (var a in exitems)
            {
                if (paraReg.IsMatch(a))
                {
                    if (lastExp.HType == 0)
                    {
                        var eitem = lastExp;
                        eitem.HType = 2;
                        eitem.Name = a;
                    }
                    else if (lastExp.Operator == HOperator.None)
                    {
                        return null;
                    }
                    else if (lastExp.RightExp != null)
                    {
                        return null;
                    }
                    else
                    {
                        var eitem = new HExpression();
                        lastExp.RightExp = eitem;
                        lastExp = eitem;
                        eitem.HType = 2;
                        eitem.Name = a;
                    }
                }
                else if (constReg.IsMatch(a))
                {
                    if (lastExp.HType == 0)
                    {
                        var eitem = lastExp;
                        eitem.HType = 1;
                        eitem.Name = a;
                        eitem.Value = ToDouble(a);
                    }
                    else if (lastExp.Operator == HOperator.None)
                    {
                        return null;
                    }
                    else if (lastExp.RightExp != null)
                    {
                        return null;
                    }
                    else
                    {
                        var eitem = new HExpression();
                        lastExp.RightExp = eitem;
                        lastExp = eitem;
                        eitem.HType = 1;
                        eitem.Name = a;
                        eitem.Value = ToDouble(a);
                    }
                }
                else if (opReg.IsMatch(a))
                {
                    switch (a)
                    {
                        case "+":
                            if (lastExp.HType == 0 || lastExp.Operator != HOperator.None)
                                return null;
                            lastExp.Operator = HOperator.Plus;
                            break;
                        case "-":
                            if (lastExp.HType == 0 || lastExp.Operator != HOperator.None)
                                return null;
                            lastExp.Operator = HOperator.Minus;
                            break;
                        case "*":
                            if (lastExp.HType == 0 || lastExp.Operator != HOperator.None)
                                return null;
                            lastExp.Operator = HOperator.Multiply;
                            break;
                        case "/":
                            if (lastExp.HType == 0 || lastExp.Operator != HOperator.None)
                                return null;
                            lastExp.Operator = HOperator.Divide;
                            break;
                        case "(":
                            if (lastExp.HType == 0)
                            {
                                var eitem = new HExpression();
                                lastExp.HType = 3;
                                lastExp.Current = eitem;
                                exps.Push(lastExp);
                                lastExp = eitem;
                            }
                            else if (lastExp.Operator != HOperator.None && lastExp.RightExp == null)
                            {
                                var eitem = new HExpression();
                                eitem.HType = 3;
                                eitem.Current = new HExpression();
                                lastExp.RightExp = eitem;
                                exps.Push(eitem);
                                lastExp = eitem.Current;
                            }
                            else
                            {
                                return null;
                            }
                            break;
                        case ")":
                            if (exps.Count == 0)
                                return null;
                            if (lastExp.HType == 0 || (lastExp.Operator != HOperator.None && lastExp.RightExp == null))
                                return null;
                            lastExp = exps.Pop();
                            break;
                        default:
                            return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            return exp;
        }
        private static double ToDouble(string s)
        {
            var d = 0d;
            if (double.TryParse(s, out d))
                return d;
            return 0;
        }

        Dictionary<string, double?> Paras;
        public double? Execute(Dictionary<string, double?> paras)
        {
            this.Paras = paras;
            if (this.Paras == null) this.Paras = new Dictionary<string, double?>();
            var v = CalcOp(this, HOperator.None, null, true);
            return v;
        }




        private double? CalcReal(HExpression exp)
        {
            double? v = null;
            switch (exp.HType)
            {
                case 1:
                    v = exp.Value;
                    break;
                case 2:
                    if (Paras.ContainsKey(exp.Name))
                        v = Paras[exp.Name];
                    else
                        v = null;
                    break;
                case 3:
                    v = CalcOp(exp.Current, exp.Current.Operator, exp.RightExp, true);
                    break;
                default:
                    throw new Exception("Error Expression!");
            }
            return v;
        }

        private double? CalcOp(HExpression left, HOperator op, HExpression rigth, bool autonext)
        {
            double? leftv = null;
            double? rightv = null;
            if (op == HOperator.None)
            {
                leftv = CalcReal(left);
                return leftv;
            }
            else
            {
                if (left.Operator == HOperator.None)
                {
                    leftv = CalcOp(left, left.Operator, left.RightExp, true);
                }
            }

            if (autonext && (op == HOperator.Plus || op == HOperator.Minus)
                && (rigth.Operator == HOperator.Divide || rigth.Operator == HOperator.Multiply))
            {
                rightv = CalcOp(rigth, rigth.Operator, rigth.RightExp, false);
            }
            else
            {
                rightv = CalcReal(rigth);
            }
            if (rightv == null) return null;

            switch (op)
            {
                case HOperator.None:
                    return null;
                case HOperator.Plus:
                    return leftv + rightv;
                case HOperator.Minus:
                    return leftv - rightv;
                case HOperator.Multiply:
                    return leftv * rightv;
                case HOperator.Divide:
                    return leftv / rightv;
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            BuildExpString(sb, 0, this);
            return sb.ToString();
        }
        private static void BuildExpString(StringBuilder sb, int spacecount, HExpression ex)
        {
            switch (ex.HType)
            {
                case 1:
                    sb.Append(ex.Value);
                    break;
                case 2:
                    sb.Append(ex.Name);
                    break;
                case 3:
                    sb.Append("(");
                    BuildExpString(sb, spacecount + 1, ex.Current);
                    sb.Append(")");
                    break;
                default:
                    return;
            }
            if (ex.Operator != HOperator.None)
            {
                sb.Append(" +-*/"[(int)ex.Operator]);
                if (ex.RightExp != null)
                    BuildExpString(sb, spacecount, ex.RightExp);
            }
        }
    }


    public enum HOperator
    {
        None,
        Plus,
        Minus,
        Multiply,
        Divide
    }

}
