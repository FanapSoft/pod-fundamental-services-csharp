
namespace POD_Billing.Model.ValueObject
{
    public class DealerListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? DealerBizId { get; }
        public bool? Enable { get; }
        public int? Offset { get; }
        public int? Size { get; }

        public DealerListVo(Builder builder)
        {
            DealerBizId = builder.GetDealerBizId();
            Enable = builder.GetEnable();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
        }

        public class Builder
        {
            private long? dealerBizId;
            private bool? enable;
            private int? offset;
            private int? size;

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
            public DealerListVo Build()
            {
                return new DealerListVo(this);
            }
        }
    }
}
