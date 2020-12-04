
namespace Booking_Service.Model.ValueObject
{
    public class RequestedRoomVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Adults { get; }
        public int? Children { get; }

        public RequestedRoomVo(Builder builder)
        {
            Adults = builder.GetAdults();
            Children = builder.GetChildren();
        }

        public class Builder
        {
            private int? adults;
            private int? children;

            public int? GetAdults()
            {
                return adults;
            }

            public Builder SetAdults(int adults)
            {
                this.adults = adults;
                return this;
            }
            public int? GetChildren()
            {
                return children;
            }

            public Builder SetChildren(int children)
            {
                this.children = children;
                return this;
            }
            public RequestedRoomVo Build()
            {
                return new RequestedRoomVo(this);
            }
        }
    }
}
