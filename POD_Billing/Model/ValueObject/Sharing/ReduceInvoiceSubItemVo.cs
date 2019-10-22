using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject.Sharing
{
    public class ReduceInvoiceSubItemVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string Price { get; }
        public string Description { get; }
        public decimal? Quantity { get; }

        public ReduceInvoiceSubItemVo(Builder builder)
        {
            Id = builder.GetId();
            Price = builder.GetPrice();
            Description = builder.GetDescription();
            Quantity = builder.GetQuantity();
        }

        public class Builder
        {
            [Required] private long? id;

            [Required] private string price;

            [Required] private string description;

            [Required] private decimal? quantity;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">اگر شناسه محصول را نمی‌دانید مقدار صفر را ارسال نمایید</param>
            public Builder SetId(long? id)
            {
                this.id = id;
                return this;
            }

            public string GetPrice()
            {
                return price;
            }

            public Builder SetPrice(decimal price)
            {
                this.price = price.ToString(CultureInfo.InvariantCulture);
                return this;
            }

            /// <summary>
            /// در صورتی که شناسه محصول صفر نباشد می توانید ازین تابع استفاده نمایید
            /// </summary>
            public Builder SetPrice(PriceValue price)
            {
                this.price = price.ToString();
                return this;
            }

            public string GetDescription()
            {
                return description;
            }

            /// <param name="description">توضیحات هر بند از فاکتور</param>
            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }

            public decimal? GetQuantity()
            {
                return quantity;
            }

            public Builder SetQuantity(decimal quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public ReduceInvoiceSubItemVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ReduceInvoiceSubItemVo(this);
            }
        }
    }
}
