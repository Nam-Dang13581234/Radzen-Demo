using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace HomeLoanRepaymentCal.Pages
{
    public partial class HomeLoanRepaymentCalculatorComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        string _loanAmount;
        protected string loanAmount
        {
            get
            {
                return _loanAmount;
            }
            set
            {
                if (!object.Equals(_loanAmount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "loanAmount", NewValue = value, OldValue = _loanAmount };
                    _loanAmount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _interestRate;
        protected string interestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                if (!object.Equals(_interestRate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "interestRate", NewValue = value, OldValue = _interestRate };
                    _interestRate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _totalLoanTerm;
        protected string totalLoanTerm
        {
            get
            {
                return _totalLoanTerm;
            }
            set
            {
                if (!object.Equals(_totalLoanTerm, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "totalLoanTerm", NewValue = value, OldValue = _totalLoanTerm };
                    _totalLoanTerm = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _totalPayment;
        protected string totalPayment
        {
            get
            {
                return _totalPayment;
            }
            set
            {
                if (!object.Equals(_totalPayment, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "totalPayment", NewValue = value, OldValue = _totalPayment };
                    _totalPayment = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            loanAmount = "";

            interestRate = "";

            totalLoanTerm = "";

            totalPayment = "";
        }

        protected async System.Threading.Tasks.Task CalculateBtnClick(MouseEventArgs args)
        {
            var calculateResult = Calculate(loanAmount,interestRate,totalLoanTerm);
            totalPayment = calculateResult;
        }
    }
}
