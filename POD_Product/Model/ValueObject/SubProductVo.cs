using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Product.Model.ValueObject
{
    public class SubProductVo : ProductVo
    {
        public static Builder ConcreteBuilder => new Builder();

        public long? GroupId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public SubProductVo(Builder builder) : base(builder)
        {
            GroupId = builder.GetGroupId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder : ProductVo
        {
            [Required] private long? groupId;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetGroupId()
            {
                return groupId;
            }

            public Builder SetGroupId(long groupId)
            {
                this.groupId = groupId;
                return this;
            }

            /// <param name="parentProductId">شناسه محصول مرجع</param>
            public Builder SetParentProductId(long parentProductId)
            {
                ParentProductId = parentProductId;
                return this;
            }

            /// <param name="name">نام محصول</param>
            public Builder SetName(string name)
            {
                Name = name;
                return this;
            }

            /// <param name="description">شرح محصول</param>
            public Builder SetDescription(string description)
            {
                Description = description;
                return this;
            }

            /// <param name="uniqueId">شناسه یکتا</param>
            public Builder SetUniqueId(string uniqueId)
            {
                UniqueId = uniqueId;
                return this;
            }

            /// <param name="canComment">امکان نظر دادن برروی محصول </param>
            public Builder SetCanComment(bool canComment)
            {
                CanComment = canComment;
                return this;
            }

            /// <param name="canLike">امکان لایک کردن محصول</param>
            public Builder SetCanLike(bool canLike)
            {
                CanLike = canLike;
                return this;
            }

            public Builder SetEnable(bool enable)
            {
                Enable = enable;
                return this;
            }

            /// <param name="metadata">اطلاعات بیشتر در مورد محصول</param>
            public Builder SetMetadata(string metadata)
            {
                Metadata = metadata;
                return this;
            }

            public Builder SetBusinessId(long businessId)
            {
                BusinessId = businessId;
                return this;
            }

            public Builder SetUnlimited(bool unlimited)
            {
                Unlimited = unlimited;
                return this;
            }

            /// <summary>
            /// این مقدار با فروش یا اجاره کاهش می ­یابد
            /// </summary>
            /// <param name="availableCount">موجودی محصول</param>
            public Builder SetAvailableCount(int availableCount)
            {
                AvailableCount = availableCount;
                return this;
            }

            /// <param name="price">قیمت محصول به ریال</param>
            public Builder SetPrice(decimal price)
            {
                Price = price;
                return this;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="discount">ضریب تخفیف</param>
            /// <returns></returns>
            public Builder SetDiscount(decimal discount)
            {
                Discount = discount;
                return this;
            }

            /// <param name="guildCode">کد صنف محصول</param>
            public Builder SetGuildCode(string guildCode)
            {
                GuildCode = guildCode;
                return this;
            }

            public Builder SetAllowUserInvoice(bool allowUserInvoice)
            {
                AllowUserInvoice = allowUserInvoice;
                return this;
            }

            /// <param name="allowUserPrice">اجازه ورود مبلغ توسط مشتری هنگام صدور فاکتور توسط مشتری</param>
            public Builder SetAllowUserPrice(bool allowUserPrice)
            {
                AllowUserPrice = allowUserPrice;
                return this;
            }

            public Builder SetCurrencyCode(string currencyCode)
            {
                CurrencyCode = currencyCode;
                return this;
            }

            public Builder SetAttCode(string[] attCode)
            {
                AttCode = attCode;
                return this;
            }

            public Builder SetAttValue(string[] attValue)
            {
                AttValue = attValue;
                return this;
            }

            public Builder SetAttGroup(bool[] attGroup)
            {
                AttGroup = attGroup;
                return this;
            }

            public Builder SetTags(string[] tags)
            {
                Tags = string.Join(",", tags);
                return this;
            }

            public Builder SetTagTrees(string[] tagTrees)
            {
                TagTrees = string.Join(",", tagTrees);
                ;
                return this;
            }

            /// <param name="tagTreeCategoryName">دسته درخت برچسب</param>
            public Builder SetTagTreeCategoryName(string tagTreeCategoryName)
            {
                TagTreeCategoryName = tagTreeCategoryName;
                return this;
            }

            /// <param name="content">متن، آدرس، رمز یا هر گونه مطلبی که فقط پس از خرید محصول به کاربر نمایش داده می شود.</param>
            public Builder SetContent(string content)
            {
                Content = content;
                return this;
            }

            /// <param name="previewImage">آدرس تصویر محصول</param>
            public Builder SetPreviewImage(string previewImage)
            {
                PreviewImage = previewImage;
                return this;
            }

            /// <param name="preferredTaxRate">نرخ مالیات - دیفالت = 0/09</param>
            public Builder SetPreferredTaxRate(double preferredTaxRate)
            {
                PreferredTaxRate = preferredTaxRate;
                return this;
            }

            /// <param name="quantityPrecision">تعداد اعشار موجودی</param>
            public Builder SetQuantityPrecision(double quantityPrecision)
            {
                QuantityPrecision = quantityPrecision;
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

            public SubProductVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();
                var attCodeError = ValidateAttributes();
                if (attCodeError.Key != null) hasErrorFields.Add(attCodeError);

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new SubProductVo(this);
            }
        }
    }
}
