using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Billing.Model.ValueObject.Voucher
{
    public class DeactivateVoucherVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? VoucherId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public DeactivateVoucherVo(Builder builder)
        {
            VoucherId = builder.GetVoucherId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private long? voucherId;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetVoucherId()
            {
                return voucherId;
            }

            /// <param name="voucherId ">شناسه بن </param>
            public Builder SetVoucherId(long voucherId)
            {
                this.voucherId = voucherId;
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

            public DeactivateVoucherVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DeactivateVoucherVo(this);
            }
        }
    }
}
