using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class CommentBusinessListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BusinessId { get; }
        public long? FirstId { get; }
        public long? LastId { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public CommentBusinessListVo(Builder builder)
        {
            BusinessId = builder.GetBusinessId();
            FirstId = builder.GetFirstId();
            LastId = builder.GetLastId();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? businessId;
            private long? firstId;
            private long? lastId;

            [RequiredIf(nameof(firstId),nameof(lastId))]
            private int? offset;

            [Required]
            private int? size;

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

            public long? GetFirstId()
            {
                return firstId;
            }

            /// <param name="firstId">نباید وارد شوند و نتیجه صعودی مرتب می شود offset و lastId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetFirstId(long firstId)
            {
                this.firstId = firstId;
                return this;
            }

            public long? GetLastId()
            {
                return lastId;
            }

            /// <param name="lastId">نباید وارد شوند و نتیجه نزولی مرتب می شود offset و firstId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetLastId(long lastId)
            {
                this.lastId = lastId;
                return this;
            }

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">نباید وارد شوند و نتیجه نزولی مرتب می شود lastId و firstId در صورتی که این فیلد وارد شود فیلدهای</param>
            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }

            public int? GetSize()
            {
                return size;
            }

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

            public CommentBusinessListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CommentBusinessListVo(this);
            }
        }
    }
}
