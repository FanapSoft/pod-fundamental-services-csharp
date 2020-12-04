using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_VirtualAccount.Model.ValueObject
{
    public class GetFollowersVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetFollowersVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private int? offset;

            [Required] private int? size;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">فاصله از مبداء</param>
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

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public GetFollowersVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetFollowersVo(this);
            }
        }
    }
}
