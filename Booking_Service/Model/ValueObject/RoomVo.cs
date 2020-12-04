using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace Booking_Service.Model.ValueObject
{
    public class RoomVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? TypeId { get; }
        public RequestedRoomVo Party { get; }
        public List<CustomerVo> Guests { get; }

        public RoomVo(Builder builder)
        {
            TypeId = builder.GetTypeId();
            Party = builder.GetParty();
            Guests = builder.GetGuests();
        }

        public class Builder
        {
            [Required] private int? typeId;
            [Required] private RequestedRoomVo party;
            private List<CustomerVo> guests;

            public int? GetTypeId()
            {
                return typeId;
            }

            public Builder SetTypeId(int typeId)
            {
                this.typeId = typeId;
                return this;
            }
            public RequestedRoomVo GetParty()
            {
                return party;
            }

            public Builder SetParty(RequestedRoomVo party)
            {
                this.party = party;
                return this;
            }
            public List<CustomerVo> GetGuests()
            {
                return guests;
            }

            public Builder SetGuests(List<CustomerVo> guests)
            {
                this.guests = guests;
                return this;
            }
            public RoomVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RoomVo(this);
            }
        }
    }
}
