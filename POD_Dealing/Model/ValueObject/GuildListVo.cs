using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Dealing.Model.ValueObject
{
    public class GuildListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Name { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public string Token { get; }

        public GuildListVo(Builder builder)
        {
            Name = builder.GetName();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            Token = builder.GetToken();
        }

        public class Builder
        {
            private string name;
            [Required] private int? offset;
            [Required] private int? size;
            [Required] private string token;

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
            public string GetToken()
            {
                return token;
            }

            /// <param name="token"> توکنی که از پنل کسب و کار دریافت شده است - ApiToken</param>
            public Builder SetToken(string token)
            {
                this.token = token;
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
