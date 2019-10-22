using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Product.Base.Enum;

namespace POD_Product.Model.ValueObject
{
    public class SearchSubProductVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long[] ProductGroupId { get; }
        public string Query { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public string[] AttributeCode { get; }
        public string[] AttributeValue { get; }
        public string OrderByAttributeCode { get; }
        public OrderType? OrderByDirection { get; }
        public string[] Tags { get; }
        public string[] TagTrees { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SearchSubProductVo(Builder builder)
        {
            ProductGroupId = builder.GetProductGroupId();
            Query = builder.GetQuery();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            AttributeCode = builder.GetAttributeCode();
            AttributeValue = builder.GetAttributeValue();
            OrderByAttributeCode = builder.GetOrderByAttributeCode();
            OrderByDirection = builder.GetOrderByDirection();
            Tags = builder.GetTags();
            TagTrees = builder.GetTagTrees();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long[] productGroupId;
            private string query;
            private int? offset;
            private int? size;
            private string[] attributeCode;
            private string[] attributeValue;
            private string orderByAttributeCode;
            private OrderType? orderByDirection;
            private string[] tags;
            private string[] tagTrees;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long[] GetProductGroupId()
            {
                return productGroupId;
            }

            /// <param name="productGroupId">شناسه کسب و کاری که در آن می خواهیم جستجو شود</param>
            public Builder SetProductGroupId(long[] productGroupId)
            {
                this.productGroupId = productGroupId;
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
            public string GetOrderByAttributeCode()
            {
                return orderByAttributeCode;
            }

            /// <param name="orderByAttributeCode">کد مشخسه ای که روی آن مرتب سازی انجام شده است</param>
            public Builder SetOrderByAttributeCode(string orderByAttributeCode)
            {
                this.orderByAttributeCode = orderByAttributeCode;
                return this;
            }
            public OrderType? GetOrderByDirection()
            {
                return orderByDirection;
            }

            public Builder SetOrderByDirection(OrderType orderByDirection)
            {
                this.orderByDirection = orderByDirection;
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
            public string GetQuery()
            {
                return query;
            }

            /// <param name="query">عبارت جستجو که در نام و توضیحات محصول جستجو خواهد شد</param>
            public Builder SetQuery(string query)
            {
                this.query = query;
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

            public SearchSubProductVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SearchSubProductVo(this);
            }
        }
    }
}
