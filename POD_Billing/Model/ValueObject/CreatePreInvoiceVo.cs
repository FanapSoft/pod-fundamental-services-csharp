using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Billing.Model.ServiceOutput;

namespace POD_Billing.Model.ValueObject
{
    public class CreatePreInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Token { get; }
        public string Ott { get; }
        public string RedirectUri { get; }
        public long? UserId { get; }
        public List<ProductInfo> ProductsInfo { get; }
        public string GuildCode { get; }
        public string BillNumber { get; }
        public string Description { get; }
        public string Deadline { get; }
        public string CurrencyCode { get; }
        public double? PreferredTaxRate { get; }
        public bool? VerificationNeeded { get; }
        public string CallUrl { get; }


        public CreatePreInvoiceVo(Builder builder)
        {
            Token = builder.GetToken();
            Ott = builder.GetOtt();
            RedirectUri = builder.GetOtt();
            UserId = builder.GetUserId();
            ProductsInfo = builder.GetProductsInfo();
            GuildCode = builder.GetGuildCode();
            BillNumber = builder.GetBillNumber();
            Description = builder.GetDescription();
            Deadline = builder.GetDeadline();
            CurrencyCode = builder.GetCurrencyCode();
            PreferredTaxRate = builder.GetPreferredTaxRate();
            VerificationNeeded = builder.GetVerificationNeeded();
            CallUrl = builder.GetCallUrl();
        }

        public class Builder
        {
            //[Required]
            private string token;

            [Required]
            private string ott;

            [Url]
            [Required]
            private string redirectUri;

            [Required]
            private long? userId;

            [Required]
            private List<ProductInfo> productsInfo;
            private string guildCode;
            private string billNumber;
            private string description;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string deadline;
            private string currencyCode;

            [Range(0, 1)]
            private double? preferredTaxRate;
            private bool? verificationNeeded;

            [Url]
            private string callUrl;

            public string GetToken()
            {
                return token;
            }

            public Builder SetToken(string token)
            {
                this.token = token;
                return this;
            }

            public string GetOtt()
            {
                return ott;
            }

            public Builder SetOtt(string ott)
            {
                this.ott = ott;
                return this;
            }

            public string GetRedirectUri()
            {
                return redirectUri;
            }

            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public long? GetUserId()
            {
                return userId;
            }

            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }
            public List<ProductInfo> GetProductsInfo()
            {
                return productsInfo;
            }

            public Builder SetProductsInfo(List<ProductInfo> productsInfo)
            {
                this.productsInfo = productsInfo;
                return this;
            }
            public string GetGuildCode()
            {
                return guildCode;
            }

            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }

            public string GetBillNumber()
            {
                return billNumber;
            }

            public Builder SetBillNumber(string billNumber)
            {
                this.billNumber = billNumber;
                return this;
            }

            public string GetDescription()
            {
                return description;
            }

            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }

            public string GetDeadline()
            {
                return deadline;
            }

            public Builder SetDeadline(string deadline)
            {
                this.deadline = deadline;
                return this;
            }
            public Builder SetDeadline(DateTime deadline)
            {
                this.deadline = deadline.ToShamsiDate();
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            public double? GetPreferredTaxRate()
            {
                return preferredTaxRate;
            }

            public Builder SetPreferredTaxRate(double preferredTaxRate)
            {
                this.preferredTaxRate = preferredTaxRate;
                return this;
            }

            public Builder SetVerificationNeeded(bool verificationNeeded)
            {
                this.verificationNeeded = verificationNeeded;
                return this;
            }

            public bool? GetVerificationNeeded()
            {
                return verificationNeeded;
            }

            public Builder SetCallUrl(string callUrl)
            {
                this.callUrl = callUrl;
                return this;
            }

            public string GetCallUrl()
            {
                return callUrl;
            }

            public CreatePreInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CreatePreInvoiceVo(this);
            }
        }
        /// <summary>
        /// برای نمایش فاکتور به کاربر باید او را به آدرس موجود در خروجی هدایت نمایید
        /// </summary>
        /// <param name="hashCode">بدست آورید CreatePreInvoice این کد را باید از طریق اجرای سرویس </param>
        public LinkSrv GetLink(string hashCode)
        {
            if(string.IsNullOrEmpty(hashCode))
            {
                throw PodException.BuildException(new InvalidParameter(new KeyValuePair<string, string>("HashCode", "The field is required.")));
            }
            return new LinkSrv() { HashCode = hashCode, RedirectUrl = $"{BaseUrl.PrivateCallAddress}/v1/pbc/preinvoice/{hashCode}" };
        }
    }
}
