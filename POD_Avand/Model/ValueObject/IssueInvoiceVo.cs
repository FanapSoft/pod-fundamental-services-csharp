using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Avand.Model.ValueObject
{
    public class IssueInvoiceVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string RedirectUri { get; }
        public long? UserId { get; }
        public long? BusinessId { get; }
        public decimal? Price { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public IssueInvoiceVo(Builder builder)
        {
            RedirectUri = builder.GetRedirectUri();
            UserId = builder.GetUserId();
            BusinessId = builder.GetBusinessId();
            Price = builder.GetPrice();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Url]
            [Required]
            private string redirectUri;

            [Required]
            private long? userId;

            [Required]
            private long? businessId;

            [Required]
            private decimal? price;

            [Required]
            private InternalServiceCallVo serviceCallParameters;
            public long? GetUserId()
            {
                return userId;
            }

            public Builder SetUserId(long userId)
            {
                this.userId = userId;
                return this;
            }

            public string GetRedirectUri()
            {
                return redirectUri;
            }

            public Builder SetRedirectUri(string redirectUri)
            {
                this.redirectUri = redirectUri;
                return this;
            }

            public long? GetBusinessId()
            {
                return businessId;
            }

            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
                return this;
            }

            public decimal? GetPrice()
            {
                return price;
            }

            public Builder SetPrice(decimal price)
            {
                this.price = price;
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

            public IssueInvoiceVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new IssueInvoiceVo(this);
            }
        }
    }
}
