using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Settlement
{
    public class ListSettlementsVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public SettlementStatusCode? StatusCode { get; }
        public string CurrencyCode { get; }
        public double? FromAmount { get; }
        public double? ToAmount { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public int? Offset { get; }
        public string UniqueId { get; }
        public int? Size { get; }
        public long? Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public ToolCode? ToolCode { get; }
        public string ToolId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ListSettlementsVo(Builder builder)
        {
            StatusCode = builder.GetStatusCode();
            CurrencyCode = builder.GetCurrencyCode();
            FromAmount = builder.GetFromAmount();
            ToAmount = builder.GetToAmount();
            FromDate = builder.GetFromDate();
            ToDate = builder.GetToDate();
            Offset = builder.GetOffset();
            UniqueId = builder.GetUniqueId();
            Size = builder.GetSize();
            Id = builder.GetId();
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            ToolCode = builder.GetToolCode();
            ToolId = builder.GetToolId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private SettlementStatusCode? statusCode;
            private string currencyCode;
            private double? fromAmount;
            private double? toAmount;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string fromDate;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string toDate;

            [Required]
            private int? offset;
            private string uniqueId;
            private int? size;
            private long? id;
            private string firstName;
            private string lastName;
            private ToolCode? toolCode;
            private string toolId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public SettlementStatusCode? GetStatusCode()
            {
                return statusCode;
            }
            public Builder SetStatusCode(SettlementStatusCode statusCode)
            {
                this.statusCode = statusCode;
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
            public double? GetFromAmount()
            {
                return fromAmount;
            }
            public Builder SetFromAmount(double fromAmount)
            {
                this.fromAmount = fromAmount;
                return this;
            }
            public double? GetToAmount()
            {
                return toAmount;
            }
            public Builder SetToAmount(double toAmount)
            {
                this.toAmount = toAmount;
                return this;
            }
            public string GetFromDate()
            {
                return fromDate;
            }
            public Builder SetFromDate(string fromDate)
            {
                this.fromDate = fromDate;
                return this;
            }
            public Builder SetFromDate(DateTime fromDate)
            {
                this.fromDate = fromDate.ToShamsiDate();
                return this;
            }
            public string GetToDate()
            {
                return toDate;
            }
            public Builder SetToDate(string toDate)
            {
                this.toDate = toDate;
                return this;
            }
            public Builder SetToDate(DateTime toDate)
            {
                this.toDate = toDate.ToShamsiDate();
                return this;
            }
            public int? GetOffset()
            {
                return offset;
            }
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public string GetUniqueId()
            {
                return uniqueId;
            }
            public Builder SetUniqueId(string uniqueId)
            {
                this.uniqueId = uniqueId;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }
            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }
            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه درخواست</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public string GetFirstName()
            {
                return firstName;
            }

            /// <param name="firstName">نام صاحب حساب</param>
            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }
            public string GetLastName()
            {
                return lastName;
            }

            /// <param name="lastName">نام خانوادگی صاحب حساب</param>
            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public ToolCode? GetToolCode()
            {
                return toolCode;
            }

            /// <param name="toolCode">نوع ابزار برای تسویه</param>
            public Builder SetToolCode(ToolCode toolCode)
            {
                this.toolCode = toolCode;
                return this;
            }
            public string GetToolId()
            {
                return toolId;
            }

            /// <param name="toolId">شماره ابزاری که تسویه به آن واریز گردیده</param>
            public Builder SetToolId(string toolId)
            {
                this.toolId = toolId;
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

            public ListSettlementsVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ListSettlementsVo(this);
            }
        }
    }
}
