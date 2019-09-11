using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialAPI
{
    class DataModel
    {
       // public int FB { get; set; }
        public string symbol { get; set; }
        public Financials[]  financials = new Financials[100];

    }
}
