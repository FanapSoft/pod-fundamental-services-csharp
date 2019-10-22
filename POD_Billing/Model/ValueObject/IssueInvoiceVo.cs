using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject
{
    public class IssueInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? UserId { get; }
        public List<ProductInfo> ProductsInfo { get; }
        public string GuildCode { get; }
        public double? PreferredTaxRate { get; }
        public long? AddressId { get; }
        public string RedirectUrl { get; }
        public string BillNumber { get; }
        public string Description { get; }
        public string Deadline { get; }
        public string CurrencyCode { get; }
        public string VoucherHash { get; }
        public bool? VerificationNeeded { get; }
        public string VerifyAfterTimeout { get; }
        public bool? Preview { get; }
        public string Metadata { get; }
        public bool? Safe { get; }
        public bool? PostVoucherEnabled { get; }
        public bool? HasEvent { get; }
        public string EventTitle { get; }
        public string EventTimeZone { get; }
        public string EventReminders { get; }
        public string EventDescription { get; }
        public string EventMetadata { get; }
        public string Ott { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public IssueInvoiceVo(Builder builder)
        {
            UserId = builder.GetUserId();
            GuildCode = builder.GetGuildCode();
            Ott = builder.GetOtt();
            PreferredTaxRate = builder.GetPreferredTaxRate();
            AddressId = builder.GetAddressId();
            ProductsInfo = builder.GetProductsInfo();
            RedirectUrl = builder.GetRedirectURL();
            BillNumber = builder.GetBillNumber();
            Description = builder.GetDescription();
            Deadline = builder.GetDeadline();
            CurrencyCode = builder.GetCurrencyCode();
            VoucherHash = builder.GetVoucherHash();
            VerificationNeeded = builder.GetVerificationNeeded();
            VerifyAfterTimeout = builder.GetVerifyAfterTimeout();
            Preview = builder.GetPreview();
            Metadata = builder.GetMetadata();
            Safe = builder.GetSafe();
            PostVoucherEnabled = builder.GetPostVoucherEnabled();
            HasEvent = builder.GetHasEvent();
            EventTitle = builder.GetEventTitle();
            EventTimeZone = builder.GetEventTimeZone();
            EventReminders = builder.GetEventReminders();
            EventDescription = builder.GetEventDescription();
            EventMetadata = builder.GetEventMetadata();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string guildCode;

            [Required]
            private string ott;

            private long? userId;

            [Required]
            private List<ProductInfo> productsInfo;

            [Range(0, 1)]
            private double? preferredTaxRate;
            private long? addressId;
            [Url] private string redirectUrl;
            private string billNumber;
            private string description;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string deadline;
            private string currencyCode;
            private string[] voucherHash;
            private bool? verificationNeeded;
            private string verifyAfterTimeout;
            private bool? preview;
            private string metadata;
            private bool? safe;
            private bool? postVoucherEnabled;
            private bool? hasEvent;
            private string eventTitle;
            private string eventTimeZone;
            private string[] eventReminders;
            private string eventDescription;
            private string eventMetadata;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetUserId()
            {
                return userId;
            }

            public Builder SetUserId(long? userId)
            {
                this.userId = userId;
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

            public double? GetPreferredTaxRate()
            {
                return preferredTaxRate;
            }

            public Builder SetPreferredTaxRate(double preferredTaxRate)
            {
                this.preferredTaxRate = preferredTaxRate;
                return this;
            }

            public long? GetAddressId()
            {
                return addressId;
            }

            public Builder SetAddressId(long addressId)
            {
                this.addressId = addressId;
                return this;
            }

            public string GetRedirectURL()
            {
                return redirectUrl;
            }

            public Builder SetRedirectURL(string redirectUrl)
            {
                this.redirectUrl = redirectUrl;
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
            public string GetOtt()
            {
                return ott;
            }

            public Builder SetOtt(string ott)
            {
                this.ott = ott;
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
            public string GetVoucherHash()
            {
                return voucherHash?.ToString();
            }

            public Builder SetVoucherHash(string[] voucherHash)
            {
                this.voucherHash = voucherHash;
                return this;
            }
            public bool? GetVerificationNeeded()
            {
                return verificationNeeded;
            }

            public Builder SetVerificationNeeded(bool verificationNeeded)
            {
                this.verificationNeeded = verificationNeeded;
                return this;
            }
            public string GetVerifyAfterTimeout()
            {
                return verifyAfterTimeout;
            }

            public Builder SetVerifyAfterTimeout(string verifyAfterTimeout)
            {
                this.verifyAfterTimeout = verifyAfterTimeout;
                return this;
            }
            public bool? GetPreview()
            {
                return preview;
            }

            /// <param name="preview">در صورتی که true ارسال شود، یک پیش نمایش از فاکتور بازگردانده میشود و فاکتور ثبت نمی گردد.</param>
            public Builder SetPreview(bool preview)
            {
                this.preview = preview;
                return this;
            }
            public string GetMetadata()
            {
                return metadata;
            }

            public Builder SetMetadata(string metadata)
            {
                this.metadata = metadata;
                return this;
            }
            public bool? GetSafe()
            {
                return safe;
            }

            public Builder SetSafe(bool safe)
            {
                this.safe = safe;
                return this;
            }
            public bool? GetPostVoucherEnabled()
            {
                return postVoucherEnabled;
            }

            public Builder SetPostVoucherEnabled(bool postVoucherEnabled)
            {
                this.postVoucherEnabled = postVoucherEnabled;
                return this;
            }
            public bool? GetHasEvent()
            {
                return hasEvent;
            }

            public Builder SetHasEvent(bool hasEvent)
            {
                this.hasEvent = hasEvent;
                return this;
            }
            public string GetEventTitle()
            {
                return eventTitle;
            }

            public Builder SetEventTitle(string eventTitle)
            {
                this.eventTitle = eventTitle;
                return this;
            }
            public string GetEventTimeZone()
            {
                return eventTimeZone;
            }

            public Builder SetEventTimeZone(string eventTimeZone)
            {
                this.eventTimeZone = eventTimeZone;
                return this;
            }
            public string GetEventReminders()
            {
                return eventReminders?.ToString();
            }

            public Builder SetEventReminders(string[] eventReminders)
            {
                this.eventReminders = eventReminders;
                return this;
            }
            public string GetEventDescription()
            {
                return eventDescription;
            }

            public Builder SetEventDescription(string eventDescription)
            {
                this.eventDescription = eventDescription;
                return this;
            }
            public string GetEventMetadata()
            {
                return eventMetadata;
            }

            public Builder SetEventMetadata(string eventMetadata)
            {
                this.eventMetadata = eventMetadata;
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

            public IssueInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new IssueInvoiceVo(this);
            }
        }
    }
}
