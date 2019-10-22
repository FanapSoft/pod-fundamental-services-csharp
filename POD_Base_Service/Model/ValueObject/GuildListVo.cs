using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class GuildListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Name { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GuildListVo(Builder builder)
        {
            Name = builder.GetName();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string name;
            [Required] private int? offset;
            [Required] private int? size;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetName()
            {
                return name;
            }

            public Builder SetName(string name)
            {
                this.name = name.Trim();
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

            public GuildListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GuildListVo(this);
            }
        }
    }
}
