using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject
{
    public class InvoiceItemInfoVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? InvoiceItemId { get; }
        public string Price { get; }
        public string ItemDescription { get; }
        public decimal? Quantity { get; }

        public InvoiceItemInfoVo(Builder builder)
        {
            InvoiceItemId = builder.GetInvoiceItemId();
            Price = builder.GetPrice();
            ItemDescription = builder.GetItemDescription();
            Quantity = builder.GetQuantity();
        }

        public class Builder
        {
            [Required] private long? invoiceItemId;

            [Required] private string price;

            [Required] private string itemDescription;

            [Required] private decimal? quantity;

            public long? GetInvoiceItemId()
            {
                return invoiceItemId;
            }

            /// <param name="invoiceItemId">شناسه بند فاکتور</param>
            public Builder SetInvoiceItemId(long? invoiceItemId)
            {
                this.invoiceItemId = invoiceItemId;
                return this;
            }

            public string GetPrice()
            {
                return price;
            }

            /// <param name="price">مبلغ بند فاکتور , باید کوچکتر مساوی مقدار قبلی باشد</param>
            public Builder SetPrice(decimal price)
            {
                this.price = price.ToString();
                return this;
            }
            public Builder SetPrice(PriceValue price)
            {
                this.price = price.ToString();
                return this;
            }

            public string GetItemDescription()
            {
                return itemDescription;
            }

            /// <param name="itemDescription">توضیحات هر بند از فاکتور</param>
            public Builder SetItemDescription(string itemDescription)
            {
                this.itemDescription = itemDescription;
                return this;
            }

            public decimal? GetQuantity()
            {
                return quantity;
            }

            /// <param name="quantity">تعداد محصول در هر بند فاکتور , باید کوچکتر مساوی مقدار قبلی باشد</param>
            public Builder SetQuantity(decimal quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public InvoiceItemInfoVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new InvoiceItemInfoVo(this);
            }
        }
    }
}
