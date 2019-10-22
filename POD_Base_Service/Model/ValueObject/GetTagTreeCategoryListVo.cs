using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class GetTagTreeCategoryListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Offset { get; }
        public int? Size { get; }
        public long? Id { get; }
        public string Name { get; }
        public string Query { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetTagTreeCategoryListVo(Builder builder)
        {
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            Id = builder.GetId();
            Name = builder.GetName();
            Query = builder.GetQuery();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private int? offset;
            [Required] private int? size;
            private long? id;
            private string name;
            private string query;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">حد پایین خروجی</param>
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
            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه دسته بندی</param>
            public Builder SetId(long id)
            {
                this.id = id;
                return this;
            }
            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام دسته بندی</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public string GetQuery()
            {
                return query;
            }

            /// <param name="query">عبارت برای جستجو در نام دسته بندی</param>
            public Builder SetQuery(string query)
            {
                this.query = query;
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

            public GetTagTreeCategoryListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetTagTreeCategoryListVo(this);
            }
        }
    }
}
