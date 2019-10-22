using System.Collections.Generic;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Product.Model.ValueObject
{
    public class MultiProductVo : ProductVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string AttTemplateCode { get; }
        public double? Lat { get; }
        public double? Lng { get; }

        public MultiProductVo(Builder builder) : base(builder)
        {
            AttTemplateCode = builder.GetAttTemplateCode();
            Lat = builder.GetLat();
            Lng = builder.GetLng();
        }

        public class Builder : ProductVo
        {
            private string attTemplateCode;
            private double? lat;
            private double? lng;

            public string GetAttTemplateCode()
            {
                return attTemplateCode;
            }

            public Builder SetAttTemplateCode(string attTemplateCode)
            {
                this.attTemplateCode = attTemplateCode;
                return this;
            }

            public double? GetLat()
            {
                return lat;
            }

            /// <param name="lat">عرض جغرافیایی</param>
            public Builder SetLat(double lat)
            {
                this.lat = lat;
                return this;
            }

            public double? GetLng()
            {
                return lng;
            }

            /// <param name="lng">طول جغرافیایی</param>
            public Builder SetLng(double lng)
            {
                this.lng = lng;
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

            public MultiProductVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();
                var attCodeError = ValidateAttributes();
                if (attCodeError.Key != null) hasErrorFields.Add(attCodeError);

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new MultiProductVo(this);
            }
        }
    }
}
