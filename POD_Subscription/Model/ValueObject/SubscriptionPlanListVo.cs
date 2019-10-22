using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Subscription.Base.Enum;

namespace POD_Subscription.Model.ValueObject
{
    public class SubscriptionPlanListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public PeriodType? PeriodTypeCode { get; }
        public int? PeriodTypeCountFrom { get; }
        public int? PeriodTypeCountTo { get; }
        public decimal? FromPrice { get; }
        public decimal? ToPrice { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public bool? Enable { get; }
        public string[] PermittedGuildCode { get; }
        public long[] PermittedBusinessId { get; }
        public long[] PermittedProductId { get; }
        public string CurrencyCode { get; }
        public SubscriptionType? TypeCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SubscriptionPlanListVo(Builder builder)
        {
            Id = builder.GetId();
            PeriodTypeCode = builder.GetPeriodTypeCode();
            PeriodTypeCountFrom = builder.GetPeriodTypeCountFrom();
            PeriodTypeCountTo = builder.GetPeriodTypeCountTo();
            FromPrice = builder.GetFromPrice();
            ToPrice = builder.GetToPrice();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            Enable = builder.GetEnable();
            PermittedGuildCode = builder.GetPermittedGuildCode();
            PermittedBusinessId = builder.GetPermittedBusinessId();
            PermittedProductId = builder.GetPermittedProductId();
            CurrencyCode = builder.GetCurrencyCode();
            TypeCode = builder.GetTypeCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long? id;
            private PeriodType? periodTypeCode;
            private int? periodTypeCountFrom;
            private int? periodTypeCountTo;
            private decimal? fromPrice;
            private decimal? toPrice;
            [Required] private int? offset;
            [Required] private int? size;
            private bool? enable;
            private string[] permittedGuildCode;
            private long[] permittedBusinessId;
            private long[] permittedProductId;
            private string currencyCode;
            private SubscriptionType? typeCode;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه طرح</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public PeriodType? GetPeriodTypeCode()
            {
                return periodTypeCode;
            }

            /// <param name="periodTypeCode">کد نوع بازه زمانی</param>
            public Builder SetPeriodTypeCode(PeriodType periodTypeCode)
            {
                this.periodTypeCode = periodTypeCode;
                return this;
            }
            public int? GetPeriodTypeCountFrom()
            {
                return periodTypeCountFrom;
            }

            /// <param name="periodTypeCountFrom">کف تعداد مورد نظر از بازه زمانی</param>
            public Builder SetPeriodTypeCountFrom(int periodTypeCountFrom)
            {
                this.periodTypeCountFrom = periodTypeCountFrom;
                return this;
            }
            public int? GetPeriodTypeCountTo()
            {
                return periodTypeCountTo;
            }

            /// <param name="periodTypeCountTo">سقف تعداد مورد نظر از بازه زمانی</param>
            public Builder SetPeriodTypeCountTo(int periodTypeCountTo)
            {
                this.periodTypeCountTo = periodTypeCountTo;
                return this;
            }
            public decimal? GetFromPrice()
            {
                return fromPrice;
            }

            /// <param name="fromPrice">حد پایین قیمت</param>
            public Builder SetFromPrice(decimal fromPrice)
            {
                this.fromPrice = fromPrice;
                return this;
            }
            public decimal? GetToPrice()
            {
                return toPrice;
            }

            /// <param name="toPrice">حد بالای قیمت</param>
            public Builder SetToPrice(decimal toPrice)
            {
                this.toPrice = toPrice;
                return this;
            }
            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">حد پایین خروجی</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }

            /// <param name="size">اندازه خروجی</param>
            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال/غیرفعال بودن طرح</param>
            public Builder SetEnable(bool enable)
            {
                this.enable = enable;
                return this;
            }
            public string[] GetPermittedGuildCode()
            {
                return permittedGuildCode;
            }

            /// <param name="permittedGuildCode">لیست کد صنف های مجاز جهت استفاده</param>
            public Builder SetPermittedGuildCode(string[] permittedGuildCode)
            {
                this.permittedGuildCode = permittedGuildCode;
                return this;
            }
            public long[] GetPermittedBusinessId()
            {
                return permittedBusinessId;
            }

            /// <param name="permittedBusinessId">شناسه کسب و کارهای مجاز جهت استفاده</param>
            public Builder SetPermittedBusinessId(long[] permittedBusinessId)
            {
                this.permittedBusinessId = permittedBusinessId;
                return this;
            }
            public long[] GetPermittedProductId()
            {
                return permittedProductId;
            }

            /// <param name="permittedProductId">لیست شناسه محصولات مجاز جهت استفاده</param>
            public Builder SetPermittedProductId(long[] permittedProductId)
            {
                this.permittedProductId = permittedProductId;
                return this;
            }
            public string GetCurrencyCode()
            {
                return currencyCode;
            }

            /// <param name="currencyCode">کد ارز</param>
            public Builder SetCurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            public SubscriptionType? GetTypeCode()
            {
                return typeCode;
            }

            /// <param name="typeCode">کد نوع طرح</param>
            public Builder SetTypeCode(SubscriptionType typeCode)
            {
                this.typeCode = typeCode;
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

            public SubscriptionPlanListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SubscriptionPlanListVo(this);
            }
        }
    }
}
