using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Product.Model.ValueObject
{
    public class AttributeTemplateListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string[] GuildCode { get; }
        public long? FirstId { get; }
        public long? LastId { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AttributeTemplateListVo(Builder builder)
        {
            GuildCode = builder.GetGuildCode();
            FirstId = builder.GetFirstId();
            LastId = builder.GetLastId();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string[] guildCode;
            private long? firstId;
            private long? lastId;

            [RequiredIf(nameof(firstId),nameof(lastId))]
            private int? offset;
            private int? size;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string[] GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode"> لیست کد صنف محصول</param>
            public Builder SetGuildCode(string[] guildCode)
            {
                this.guildCode = guildCode;
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

            public AttributeTemplateListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AttributeTemplateListVo(this);
            }
        }
    }
}
