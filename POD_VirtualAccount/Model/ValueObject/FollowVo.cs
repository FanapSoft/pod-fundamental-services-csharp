 using System.ComponentModel.DataAnnotations;
 using System.Linq;
 using POD_Base_Service.Base;
 using POD_Base_Service.Exception;
 using POD_Base_Service.Model.ValueObject;

 namespace POD_VirtualAccount.Model.ValueObject
 {
     public class FollowVo
     {
         public static Builder ConcreteBuilder => new Builder();
         public long? BusinessId { get; }
         public bool? Follow { get; }
         public InternalServiceCallVo ServiceCallParameters { get; }

         public FollowVo(Builder builder)
         {
             BusinessId = builder.GetBusinessId();
             Follow = builder.GetFollow();
             ServiceCallParameters = builder.GetServiceCallParameters();
         }

         public class Builder
         {
             [Required]
             private long? businessId;

             [Required]
             private bool? follow;

             [Required]
             private InternalServiceCallVo serviceCallParameters;

             public long? GetBusinessId()
             {
                 return businessId;
             }

             public Builder SetBusinessId(long businessId)
             {
                 this.businessId = businessId;
                 return this;
             }

             public bool? GetFollow()
             {
                 return follow;
             }

             public Builder SetFollow(bool follow)
             {
                 this.follow = follow;
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

             public FollowVo Build()
             {
                 var hasErrorFields = this.ValidateByAttribute();

                 if (hasErrorFields.Any())
                 {
                     throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                 }

                 return new FollowVo(this);
             }
         }
     }
 }
