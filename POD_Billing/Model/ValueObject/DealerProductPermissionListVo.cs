
namespace POD_Billing.Model.ValueObject
{
    public class DealerProductPermissionListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? EntityId { get; }
        public long? DealingBusinessId { get; }
        public bool? Enable { get; }
        public int? Offset { get; }
        public int? Size { get; }

        public DealerProductPermissionListVo(Builder builder)
        {
            EntityId = builder.GetEntityId();
            DealingBusinessId = builder.GetDealingBusinessId();
            Enable = builder.GetEnable();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
        }

        public class Builder
        {
            private long? entityId;
            private long? dealingBusinessId;
            private bool? enable;
            private int? offset;
            private int? size;

            public long? GetEntityId()
            {
                return entityId;
            }

            /// <param name="entityId">شناسه محصولی که واسط آن هستم </param>
            public Builder SetEntityId(long entityId)
            {
                this.entityId = entityId;
                return this;
            }
            public long? GetDealingBusinessId()
            {
                return dealingBusinessId;
            }


            /// <param name="dealingBusinessId">شناسه کسب و کار که واسط محصول آن هستم</param>
            public Builder SetDealingBusinessId(long dealingBusinessId)
            {
                this.dealingBusinessId = dealingBusinessId;
                return this;
            }
            public bool? GetEnable()
            {
                return enable;
            }

            /// <param name="enable">فعال بودن واسط</param>
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

            /// <param name="size">اندازه خروجی</param>
            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }

            public DealerProductPermissionListVo Build()
            {
                return new DealerProductPermissionListVo(this);
            }
        }
    }
}
