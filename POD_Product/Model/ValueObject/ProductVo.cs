using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using POD_Base_Service.CustomAttribute;

namespace POD_Product.Model.ValueObject
{
    public abstract class ProductVo
    {
        [Required]
        public bool? CanComment { get; set; }

        [Required]
        public bool? CanLike { get; set; }

        [Required]
        public bool? Enable { get; set; }

        [Required]
        public string Description { get; set; }
        public long? ParentProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string Metadata { get; set; }
        public long? BusinessId { get; set; }
        public bool? Unlimited { get; set; }

        [RequiredIf(nameof(Unlimited))]
        public int? AvailableCount { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public decimal? Discount { get; set; }
        public string GuildCode { get; set; }
        public bool? AllowUserInvoice { get; set; }
        public bool? AllowUserPrice { get; set; }
        public string CurrencyCode { get; set; }
        public string[] AttCode { get; set; }
        public string[] AttValue { get; set; }
        public bool[] AttGroup { get; set; }
        public string Tags { get; set; }
        public string TagTrees { get; set; }
        public string TagTreeCategoryName { get; set; }
        public string Content { get; set; }
        public string PreviewImage { get; set; }
        public double? PreferredTaxRate { get; set; }
        public double? QuantityPrecision { get; set; }

        protected ProductVo()
        {

        }

        protected ProductVo(ProductVo product)
        {
            CanComment = product.CanComment;
            CanLike = product.CanLike;
            Enable = product.Enable;
            ParentProductId = product.ParentProductId;
            Name = product.Name;
            Description = product.Description;
            UniqueId = product.UniqueId;
            Metadata = product.Metadata;
            BusinessId = product.BusinessId;
            Unlimited = product.Unlimited;
            AvailableCount = product.AvailableCount;
            Price = product.Price;
            Discount = product.Discount;
            GuildCode = product.GuildCode;
            AllowUserInvoice = product.AllowUserInvoice;
            AllowUserPrice = product.AllowUserPrice;
            CurrencyCode = product.CurrencyCode;
            AttCode = product.AttCode;
            AttValue = product.AttValue;
            AttGroup = product.AttGroup;
            Tags = product.Tags;
            TagTrees = product.TagTrees;
            TagTreeCategoryName = product.TagTreeCategoryName;
            Content = product.Content;
            PreviewImage = product.PreviewImage;
            PreferredTaxRate = product.PreferredTaxRate;
            QuantityPrecision = product.QuantityPrecision;
        }

        protected KeyValuePair<string, string> ValidateAttributes()
        {
            if (AttCode?.Length != AttGroup?.Length || AttCode?.Length != AttValue?.Length)
            {
                return new KeyValuePair<string, string>($"attCode : {AttCode?.Length ?? 0},attGroup : {AttGroup?.Length ?? 0}, attValue: { AttValue?.Length ?? 0}", " - تعداد صفات مطابقت ندارد");
            }
            return new KeyValuePair<string, string>();
        }

        protected KeyValuePair<string, string> ValidateAttributeTempCode(string tempCode,bool addMode=true)
        {
            if (addMode && string.IsNullOrEmpty(tempCode) && (AttGroup != null || AttValue != null || AttCode != null))
            {
                return new KeyValuePair<string, string>("attTemplateCode", "   - مربوطه را وارد نمایید ، در غیر این صورت آنها را نیز پاک کنید attTemplateCode مقدار attGroup ,attValue , attCode برای صفات" );
            }
            if (!string.IsNullOrEmpty(tempCode) && (AttGroup == null && AttValue == null && AttCode == null))
            {
                return new KeyValuePair<string, string>($"attTemplateCode : {tempCode}", " - صفات این کد را وارد نمایید");
            }

            return ValidateAttributes();
        }
    }
}
