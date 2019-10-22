using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;

namespace POD_Base_Service.Model.ValueObject
{
    public class GetTagTreeListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? CategoryId { get; }
        public long? ParentId { get; }
        public int? LevelCount { get; }
        public int? FromLevel { get; }
        public long? Id { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetTagTreeListVo(Builder builder)
        {
            LevelCount = builder.GetLevelCount();
            CategoryId = builder.GetCategoryId();
            ParentId = builder.GetParentId();
            LevelCount = builder.GetLevelCount();
            FromLevel = builder.GetFromLevel();
            Id = builder.GetId();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? categoryId;
            private long? parentId;

            [Required]
            private int? levelCount;

            [RequiredIf(nameof(parentId))]
            private int? fromLevel;
            private long? id;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

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
            public int? GetLevelCount()
            {
                return levelCount;
            }

            /// <param name="levelCount">تعداد سطوح خروجی از والد و یا سطح ارسال شده</param>
            public Builder SetLevelCount(int? levelCount)
            {
                this.levelCount = levelCount;
                return this;
            }
            public int? GetFromLevel()
            {
                return fromLevel;
            }

            /// <param name="fromLevel">درخت خروجی از این سطح به بعد داده میشود</param>
            public Builder SetFromLevel(int? fromLevel)
            {
                this.fromLevel = fromLevel;
                return this;
            }
            public long? GetId()
            {
                return id;
            }

            /// <param name="id">شناسه برچسب درختی</param>
            public Builder SetId(long? id)
            {
                this.id = id;
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

            public GetTagTreeListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();
                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetTagTreeListVo(this);
            }
        }
    }
}
