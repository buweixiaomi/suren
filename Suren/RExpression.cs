using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren
{
    public class RExpression
    {
        private class ExecItem
        {
            public decimal Value { get; set; }
        }
        private string expression;
        Dictionary<string, decimal?> paras;
        public RExpression(string exp, Dictionary<string, decimal?> paras)
        {
            this.expression = exp;
            this.paras = paras;
            if (this.paras == null)
            {
                this.paras = new Dictionary<string, decimal?>();
            }
        }

        public decimal? Execute()
        {
            return null;
        }
    }
}
