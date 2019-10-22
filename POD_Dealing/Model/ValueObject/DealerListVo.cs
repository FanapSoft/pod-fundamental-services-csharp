using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class DealerListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }
        public bool? Enable { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public DealerListVo(Builder builder)
        {
            DealerBizId = builder.GetDealerBizId();
            Enable = builder.GetEnable();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long? dealerBizId;
            private bool? enable;
            private int? offset;
            private int? size;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public long? GetDealerBizId()
            {
                return dealerBizId;
            }

            /// <param name="dealerBizId ">شناسه کسب و کار واسط </param>
            public Builder SetDealerBizId(long dealerBizId)
            {
                this.dealerBizId = dealerBizId;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال بودن واسط </param>
            public Builder SetEnable(bool enable)
            {
                this.enable = enable;
                return this;
            }
            public int? GetOffset()
            {
                return offset;
            }
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }
            public int? GetSize()
            {
                return size;
            }

            /// <param name="size">اندازه خروجی </param>
            public Builder SetSize(int size)
            {
                this.size = size;
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

            public DealerListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new DealerListVo(this);
            }
        }
    }
}
