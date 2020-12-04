using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class IssueCreditInvoiceAndGetHashVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public decimal? Amount { get; }
        public long? UserId { get; }
        public string BillNumber { get; }
        public string Wallet { get; }
        public string RedirectUrl { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public IssueCreditInvoiceAndGetHashVo(Builder builder)
        {
            Amount = builder.GetAmount();
            UserId = builder.GetUserId();       
            BillNumber = builder.GetBillNumber();
            Wallet = builder.GetWallet();
            RedirectUrl = builder.GetRedirectUrl();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private decimal? amount;

            [Required]
            private long? userId;

            [Required]
            private string billNumber;

            [Required]
            private string wallet;

            [Required] [Url]
            private string redirectUrl;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public decimal? GetAmount()
            {
                return amount;
            }

            /// <param name="amount">مبلغ جهت شارژ کیف پول</param>
            public Builder SetAmount(decimal amount)
            {
                this.amount = amount;
                return this;
            }

            public long? GetUserId()
            {
                return userId;
            }

            /// <param name="userId">شناسه کاربر</param>
            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }

            public string GetBillNumber()
            {
                return billNumber;
            }

            /// <param name="billNumber">شماره قبض</param>
            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }

            public string GetRedirectUrl()
            {
                return redirectUrl;
            }

            public string GetWallet()
            {
                return wallet;
            }

            /// <param name="wallet">کد کیف پول</param>
            public Builder SetWallet(string wallet)
            {
                this.wallet = wallet;
                return this;
            }

            /// <param name="redirectUrl">آدرس بازگشت</param>
            public Builder SetRedirectUrl(string redirectUrl)
            {
                this.redirectUrl = redirectUrl;
                return this;
            }

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public IssueCreditInvoiceAndGetHashVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new IssueCreditInvoiceAndGetHashVo(this);
            }
        }
        public string GetLink(string hashCode)
        {
            var link = Config.ServerType == ServerType.SandBox ?
                $"http://sandbox.pod.ir:8080/nzh/payAnyCreditInvoice?hash={hashCode}&gateway=LOC"
                : $"{BaseUrl.FileServerAddress}/nzh/payAnyCreditInvoice?hash={hashCode}&gateway=PEP";
            return link;
        }
    }
}
