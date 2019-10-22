using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Product.Base.Enum;

namespace POD_Product.Model.ValueObject
{
    public class BusinessProductListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public long[] Id { get; }
        public string[] UniqueId { get; }
        public string[] CategoryCode { get; }
        public string[] GuildCode { get; }
        public string CurrencyCode { get; }
        public long? FirstId { get; }
        public long? LastId { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public string AttributeTemplateCode { get; }
        public string[] AttributeCode { get; }
        public string[] AttributeValue { get; }
        public OrderType? OrderByLike { get; }
        public OrderType? OrderBySale { get; }
        public OrderType? OrderByPrice { get; }
        public string[] Tags { get; }
        public string[] TagTrees { get; }
        public ProductScope? Scope { get; }
        public string AttributeSearchQuery { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BusinessProductListVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            Id = builder.GetId();
            UniqueId = builder.GetUniqueId();
            CategoryCode = builder.GetCategoryCode();
            GuildCode = builder.GetGuildCode();
            CurrencyCode = builder.GetCurrencyCode();
            FirstId = builder.GetFirstId();
            LastId = builder.GetLastId();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            AttributeTemplateCode = builder.GetAttributeTemplateCode();
            AttributeCode = builder.GetAttributeCode();
            AttributeValue = builder.GetAttributeValue();
            OrderByLike = builder.GetOrderByLike();
            OrderBySale = builder.GetOrderBySale();
            OrderByPrice = builder.GetOrderByPrice();
            Tags = builder.GetTags();
            TagTrees = builder.GetTagTrees();
            Scope = builder.GetScope();
            AttributeSearchQuery = builder.GetAttributeSearchQuery();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long? businessId;
            private long[] id;
            private string[] uniqueId;
            private string[] categoryCode;
            private string[] guildCode;
            private string currencyCode;
            private long? firstId;
            private long? lastId;

            [RequiredIf(nameof(firstId), nameof(lastId))]
            private int? offset;
            private int? size;
            private string attributeTemplateCode;
            private string[] attributeCode;
            private string[] attributeValue;
            private OrderType? orderByLike;
            private OrderType? orderBySale;
            private OrderType? orderByPrice;
            private string[] tags;
            private string[] tagTrees;
            private ProductScope? scope;
            private string attributeSearchQuery;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetBusinessId()
            {
                return businessId;
            }

            /// <param name="businessId">شناسه کسب و کاری که در آن می خواهیم جستجو شود</param>
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }
            public long[] GetId()
            {
                return id;
            }

            /// <param name="id">لیست شناسه محصولات در صورتی که وارد شود بقیه پارامترها در نظر گرفته نمی شوند</param>
            public Builder SetId(long[] id)
            {
                this.id = id;
                return this;
            }
            public string[] GetUniqueId()
            {
                return uniqueId;
            }

            /// <param name="uniqueId">شناسه یکتا</param>
            public Builder SetUniqueId(string[] uniqueId)
            {
                this.uniqueId = uniqueId;
                return this;
            }
            public string[] GetCategoryCode()
            {
                return categoryCode;
            }

            /// <param name="categoryCode">لیست کد دسته یندی محصول</param>
            public Builder SetCategoryCode(string[] categoryCode)
            {
                this.categoryCode = categoryCode;
                return this;
            }
            public string[] GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode"> لیست کد صنف محصول</param>
            public Builder SetGuildCode(string[] guildCode)
            {
                this.guildCode = guildCode;
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
            public long? GetFirstId()
            {
                return firstId;
            }

            /// <param name="firstId">نباید وارد شوند و نتیجه صعودی مرتب می شود offset و lastId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetFirstId(long firstId)
            {
                this.firstId = firstId;
                return this;
            }

            public long? GetLastId()
            {
                return lastId;
            }

            /// <param name="lastId">نباید وارد شوند و نتیجه نزولی مرتب می شود offset و firstId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetLastId(long lastId)
            {
                this.lastId = lastId;
                return this;
            }

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">نباید وارد شوند و نتیجه نزولی مرتب می شود lastId و firstId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
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
            public string GetAttributeTemplateCode()
            {
                return attributeTemplateCode;
            }

            /// <param name="attributeTemplateCode">کد نوع جزئیات محصول</param>
            public Builder SetAttributeTemplateCode(string attributeTemplateCode)
            {
                this.attributeTemplateCode = attributeTemplateCode;
                return this;
            }
            public string[] GetAttributeCode()
            {
                return attributeCode;
            }

            public Builder SetAttributeCode(string[] attributeCode)
            {
                this.attributeCode = attributeCode;
                return this;
            }
            public string[] GetAttributeValue()
            {
                return attributeValue;
            }

            public Builder SetAttributeValue(string[] attributeValue)
            {
                this.attributeValue = attributeValue;
                return this;
            }
            public OrderType? GetOrderByLike()
            {
                return orderByLike;
            }

            public Builder SetOrderByLike(OrderType orderByLike)
            {
                this.orderByLike = orderByLike;
                return this;
            }
            public OrderType? GetOrderBySale()
            {
                return orderBySale;
            }

            public Builder SetOrderBySale(OrderType orderBySale)
            {
                this.orderBySale = orderBySale;
                return this;
            }
            public OrderType? GetOrderByPrice()
            {
                return orderByPrice;
            }

            public Builder SetOrderByPrice(OrderType? orderByPrice)
            {
                this.orderByPrice = orderByPrice;
                return this;
            }
            public string[] GetTags()
            {
                return tags;
            }

            /// <param name="tags">لیست برچسب</param>
            public Builder SetTags(string[] tags)
            {
                this.tags = tags;
                return this;
            }
            public string[] GetTagTrees()
            {
                return tagTrees;
            }

            /// <param name="tagTrees">لیست درخت برچسب</param>
            public Builder SetTagTrees(string[] tagTrees)
            {
                this.tagTrees = tagTrees;
                return this;
            }

            public ProductScope? GetScope()
            {
                return scope;
            }

            public Builder SetScope(ProductScope scope)
            {
                this.scope = scope;
                return this;
            }
            public string GetAttributeSearchQuery()
            {
                return attributeSearchQuery;
            }

            public Builder SetAttributeSearchQuery(string attributeSearchQuery)
            {
                this.attributeSearchQuery = attributeSearchQuery;
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

            public BusinessProductListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BusinessProductListVo(this);
            }
        }
    }
}
