using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class AddTagTreeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Name { get; }
        public long? CategoryId { get; }
        public long? ParentId { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AddTagTreeVo(Builder builder)
        {
            Name = builder.GetName();
            CategoryId = builder.GetCategoryId();
            ParentId = builder.GetParentId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string name;
            [Required] private long? categoryId;
            private long? parentId;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetName()
            {
                return name;
            }

            /// <param name="name">نام برچسب</param>
            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public long? GetCategoryId()
            {
                return categoryId;
            }

            /// <param name="categoryId">شناسه دسته بندی درخت برچسب</param>
            public Builder SetCategoryId(long categoryId)
            {
                this.categoryId = categoryId;
                return this;
            }
            public long? GetParentId()
            {
                return parentId;
            }

            /// <param name="categoryId">شناسه والد برچسب</param>
            public Builder SetParentId(long parentId)
            {
                this.parentId = parentId;
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

            public AddTagTreeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddTagTreeVo(this);
            }
        }
    }
}
