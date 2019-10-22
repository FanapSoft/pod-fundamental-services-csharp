using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Subscription.Base.Enum;

namespace POD_Subscription.Model.ValueObject
{
    public class AddSubscriptionPlanVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Name { get; }
        public decimal? Price { get; }
        public PeriodType? PeriodTypeCode { get; }
        public int? PeriodTypeCount { get; }
        public long? UsageCountLimit { get; }
        public decimal? UsageAmountLimit { get; }
        public SubscriptionType? Type { get; }
        public string GuildCode { get; }
        public string[] PermittedGuildCode { get; }
        public long[] PermittedBusinessId { get; }
        public long[] PermittedProductId { get; }
        public string CurrencyCode { get; }
        public long? EntityId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AddSubscriptionPlanVo(Builder builder)
        {
            Name = builder.GetName();
            Price = builder.GetPrice();
            PeriodTypeCode = builder.GetPeriodTypeCode();
            PeriodTypeCount = builder.GetPeriodTypeCount();
            UsageCountLimit = builder.GetUsageCountLimit();
            UsageAmountLimit = builder.GetUsageAmountLimit();
            Type = builder.GetType();
            GuildCode = builder.GetGuildCode();
            PermittedGuildCode = builder.GetPermittedGuildCode();
            PermittedBusinessId = builder.GetPermittedBusinessId();
            PermittedProductId = builder.GetPermittedProductId();
            CurrencyCode = builder.GetCurrencyCode();
            EntityId = builder.GetEntityId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string name;
            [Required] private decimal? price;
            [Required] private PeriodType? periodTypeCode;
            [Required] private int? periodTypeCount;
            private long? usageCountLimit;
            private decimal? usageAmountLimit;
            [Required] private SubscriptionType? type;
            [Required] private string guildCode;
            private string[] permittedGuildCode;
            private long[] permittedBusinessId;
            private long[] permittedProductId;
            private string currencyCode;
            [Required] private long? entityId;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام طرح</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public decimal? GetPrice()
            {
                return price;
            }

            /// <param name="price">قیمت طرح</param>
            public Builder SetPrice(decimal price)
            {
                this.price = price;
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
            public int? GetPeriodTypeCount()
            {
                return periodTypeCount;
            }

            /// <param name="periodTypeCount">تعداد مورد نظر از بازه زمانی</param>
            public Builder SetPeriodTypeCount(int periodTypeCount)
            {
                this.periodTypeCount = periodTypeCount;
                return this;
            }
            public long? GetUsageCountLimit()
            {
                return usageCountLimit;
            }

            /// <param name="usageCountLimit">محدودیت تعداد دفعات استفاده</param>
            public Builder SetUsageCountLimit(long usageCountLimit)
            {
                this.usageCountLimit = usageCountLimit;
                return this;
            }
            public decimal? GetUsageAmountLimit()
            {
                return usageAmountLimit;
            }

            /// <param name="usageAmountLimit">محدودیت میزان استفاده</param>
            public Builder SetUsageAmountLimit(decimal usageAmountLimit)
            {
                this.usageAmountLimit = usageAmountLimit;
                return this;
            }
            public new SubscriptionType? GetType()
            {
                return type;
            }

            /// <param name="type">نوع طرح مسدودی یا نقدی</param>
            public Builder SetType(SubscriptionType type)
            {
                this.type = type;
                return this;
            }
            public string GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">کد صنف برای صدور فاکتور جهت تسویه</param>
            public Builder SetGuildCode(string guildCode)
            {
                this.guildCode = guildCode;
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
            public long? GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">شناسه محصول</param>
            public Builder SetEntityId(long entityId)
            {
                this.entityId = entityId;
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

            public AddSubscriptionPlanVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddSubscriptionPlanVo(this);
            }
        }
    }
}
