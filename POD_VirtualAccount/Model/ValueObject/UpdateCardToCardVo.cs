using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class UpdateCardToCardVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public string CardNumber { get; }

        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateCardToCardVo(Builder builder)
        {
            Id = builder.GetId();
            CardNumber = builder.GetCardNumber();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? id;

            [Required] private string cardNumber;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه کارت به کارت</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }

            public string GetCardNumber()
            {
                return cardNumber;
            }

            /// <param name="cardNumber">شماره کارت جدید برای واریز</param>
            public Builder SetCardNumber(string cardNumber)
            {
                this.cardNumber = cardNumber;
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

            public UpdateCardToCardVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateCardToCardVo(this);
            }
        }
    }
}
