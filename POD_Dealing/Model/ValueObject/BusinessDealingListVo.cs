using System.ComponentModel.DataAnnotations;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class BusinessDealingListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }
        public bool? Enable { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BusinessDealingListVo(Builder builder)
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

            public BusinessDealingListVo Build()
            {
                return new BusinessDealingListVo(this);
            }
        }
    }
}
