using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace HomeLoanRepaymentCal.Pages
{
    public partial class HomeLoanRepaymentCalculatorComponent
    {
        private string Calculate(string initialPrinciple, string interestRate, string n)
        {
            double p = Convert.ToDouble(initialPrinciple);
            double iR = Convert.ToDouble(interestRate);
            double loanTerm = Convert.ToDouble(n);

            string totalRepayment = string.Empty;
            // Convert rate to decimal.
            iR /= 100;
            // Convert to months.
            double monthly = loanTerm * 12;
            double monthlyInterestRate = iR / 12;
            // (1+interestrate)^(monthly)
            double rate = Math.Pow(1 + monthlyInterestRate, monthly);

            return totalRepayment = (p * ((monthlyInterestRate * rate) / (rate - 1))).ToString("0.##");
        }
    }
}
