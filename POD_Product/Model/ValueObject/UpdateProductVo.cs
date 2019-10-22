using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Product.Model.ValueObject
{
    public class UpdateProductVo:ProductVo
    {
        public static Builder ConcreteBuilder => new Builder();

        public string Version { get; }
        public long? EntityId { get; }
        public string AttTemplateCode { get; }
        public string[] Categories { get; }
        public long? GroupId { get; }
        public bool? ChangePreview { get; }
        public double? Lat { get; }
        public double? Lng { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateProductVo(Builder builder) : base(builder)
        {
            Version = builder.GetVersion();
            EntityId = builder.GetEntityId();
            AttTemplateCode = builder.GetAttTemplateCode();
            Categories = builder.GetCategories();
            GroupId = builder.GetGroupId();
            ChangePreview = builder.GetChangePreview();
            Lat = builder.GetLat();
            Lng = builder.GetLng();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder:ProductVo
        {
            [Required]
            private long? entityId;
            private string version;
            private string attTemplateCode;
            private string[] categories;
            private long? groupId;

            [Required]
            private bool? changePreview;
            private double? lat;
            private double? lng;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">شناسه محصول مرجع</param>
            public Builder SetEntityId(long entityId)
            {
                this.entityId = entityId;
                return this;
            }
            public string GetVersion()
            {
                return version;
            }

            /// <param name="version">شماره نسخه محصول</param>
            public Builder SetVersion(string version)
            {
                this.version = version;
                return this;
            }
            public string GetAttTemplateCode()
            {
                return attTemplateCode;
            }

            public Builder SetAttTemplateCode(string attTemplateCode)
            {
                this.attTemplateCode = attTemplateCode;
                return this;
            }

            public string[] GetCategories()
            {
                return categories;
            }

            /// <param name="categories">لیست کد دسته محصول</param>
            public Builder SetCategories(string[] categories)
            {
                this.categories = categories;
                return this;
            }
            public long? GetGroupId()
            {
                return groupId;
            }

            public Builder SetGroupId(long groupId)
            {
                this.groupId = groupId;
                return this;
            }
            public bool? GetChangePreview()
            {
                return changePreview;
            }

            /// <param name="changePreview">وارد شود true در صورت نیاز به ویرایش تصویر محصول</param>
            public Builder SetChangePreview(bool changePreview)
            {
                this.changePreview = changePreview;
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
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public UpdateProductVo Build()
            {
                var hasErrorFields = this.ValidateFieldAndPropertyByAttribute();
                var attCodeError = ValidateAttributeTempCode(attTemplateCode,false);
                if (attCodeError.Key != null) hasErrorFields.Add(attCodeError);

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateProductVo(this);
            }
        }
    }
}
