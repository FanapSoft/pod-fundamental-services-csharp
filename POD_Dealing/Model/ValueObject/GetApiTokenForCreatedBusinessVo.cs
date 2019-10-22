using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class GetApiTokenForCreatedBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetApiTokenForCreatedBusinessVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? businessId;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetBusinessId()
            {
                return businessId;
            }

            /// <param name="businessId">شناسه کسب و کار </param>
            public Builder SetBusinessId(long businessId)
            {
                this.businessId = businessId;
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

            public GetApiTokenForCreatedBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetApiTokenForCreatedBusinessVo(this);
            }
        }
    }
}
