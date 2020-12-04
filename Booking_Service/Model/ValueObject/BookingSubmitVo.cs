using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace Booking_Service.Model.ValueObject
{
    public class BookingSubmitVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string ApiVersion { get; }
        public string HotelId { get; }
        public string CheckinDate { get; }
        public string CheckoutDate { get; }
        public string EntranceTime { get; }
        public string ReferenceId { get; }
        public string PaymentMethod { get; }
        public CustomerVo Customer { get; }
        public List<CustomerVo> Guests { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string NationalCode { get; }
        public string PhoneNumber { get; }
        public string Country { get; }
        public List<RoomVo> Rooms { get; }
        public string TypeId { get; }
        public int? Count { get; }
        public string Party { get; }
        public long? RatePlanId { get; }
        public string SpecialRequests { get; }
        public string Authorization { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public BookingSubmitVo(Builder builder)
        {
            ApiVersion = builder.GetApiVersion();
            HotelId = builder.GetHotelId();
            CheckinDate = builder.GetCheckinDate();
            CheckoutDate = builder.GetCheckoutDate();
            EntranceTime = builder.GetEntranceTime();
            ReferenceId = builder.GetReferenceId();
            PaymentMethod = builder.GetPaymentMethod();
            Customer = builder.GetCustomer();
            Guests = builder.GetGuests();
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            NationalCode = builder.GetNationalCode();
            PhoneNumber = builder.GetPhoneNumber();
            Country = builder.GetCountry();
            Rooms = builder.GetRooms();
            TypeId = builder.GetTypeId();
            Count = builder.GetCount();
            Party = builder.GetParty();
            RatePlanId = builder.GetRatePlanId();
            SpecialRequests = builder.GetSpecialRequests();
            Authorization = builder.GetAuthorization();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string apiVersion;

            [Required]
            private string hotelId;

            [Required]
            [RegularExpression(RegexFormat.ShamsiDate)]
            private string checkinDate;

            [Required]
            [RegularExpression(RegexFormat.ShamsiDate)]
            private string checkoutDate;
            private string entranceTime;

            [Required]
            private string referenceId;
            private string paymentMethod;

            [Required]
            private CustomerVo customer;
            private List<CustomerVo> guests;
            private string firstName;
            private string lastName;

            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;
            private string phoneNumber;
            private string country;

            [Required]
            private List<RoomVo> rooms;
            private string typeId;
            private int? count;
            private string party;
            [Required] private long? ratePlanId;
            private string specialRequests;
            [Required] private string authorization;
            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetApiVersion()
            {
                return apiVersion;
            }

            public Builder SetApiVersion(string apiVersion)
            {
                this.apiVersion = apiVersion;
                return this;
            }

            public string GetHotelId()
            {
                return hotelId;
            }

            public Builder SetHotelId(string hotelId)
            {
                this.hotelId = hotelId;
                return this;
            }

            public string GetReferenceId()
            {
                return referenceId;
            }

            public Builder SetReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public string GetCheckinDate()
            {
                return checkinDate;
            }

            /// <param name="checkinDate">از تاریخ</param>
            public Builder SetCheckinDate(string checkinDate)
            {
                this.checkinDate = checkinDate;
                return this;
            }

            /// <param name="checkinDate">از تاریخ</param>
            public Builder SetCheckinDate(DateTime checkinDate)
            {
                this.checkinDate = checkinDate.ToShamsiDate();
                return this;
            }

            public string GetCheckoutDate()
            {
                return checkoutDate;
            }

            /// <param name="checkoutDate">تا تاریخ</param>
            public Builder SetCheckoutDate(string checkoutDate)
            {
                this.checkoutDate = checkoutDate;
                return this;
            }

            /// <param name="checkoutDate">تا تاریخ</param>
            public Builder SetCheckoutDate(DateTime checkoutDate)
            {
                this.checkoutDate = checkoutDate.ToShamsiDate();
                return this;
            }
            public string GetEntranceTime()
            {
                return entranceTime;
            }

            public Builder SetEntranceTime(string entranceTime)
            {
                this.entranceTime = entranceTime;
                return this;
            }
            public string GetPaymentMethod()
            {
                return paymentMethod;
            }

            public Builder SetPaymentMethod(string paymentMethod)
            {
                this.paymentMethod = paymentMethod;
                return this;
            }
            public CustomerVo GetCustomer()
            {
                return customer;
            }

            public Builder SetCustomer(CustomerVo customer)
            {
                this.customer = customer;
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
            public string GetFirstName()
            {
                return firstName;
            }

            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }
            public string GetLastName()
            {
                return lastName;
            }

            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public string GetNationalCode()
            {
                return nationalCode;
            }

            public Builder SetNationalCode(string nationalCode)
            {
                this.nationalCode = nationalCode;
                return this;
            }
            public string GetPhoneNumber()
            {
                return phoneNumber;
            }

            public Builder SetPhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }
            public string GetCountry()
            {
                return country;
            }

            public Builder SetCountry(string country)
            {
                this.country = country;
                return this;
            }
            public List<RoomVo> GetRooms()
            {
                return rooms;
            }

            public Builder SetRooms(List<RoomVo> rooms)
            {
                this.rooms = rooms;
                return this;
            }
            public string GetTypeId()
            {
                return typeId;
            }

            public Builder SetTypeId(string typeId)
            {
                this.typeId = typeId;
                return this;
            }
            public int? GetCount()
            {
                return count;
            }

            public Builder SetCount(int count)
            {
                this.count = count;
                return this;
            }
            public string GetParty()
            {
                return party;
            }

            public Builder SetParty(string party)
            {
                this.party = party;
                return this;
            }
            public long? GetRatePlanId()
            {
                return ratePlanId;
            }

            public Builder SetRatePlanId(long ratePlanId)
            {
                this.ratePlanId = ratePlanId;
                return this;
            }
            public string GetSpecialRequests()
            {
                return specialRequests;
            }

            public Builder SetSpecialRequests(string specialRequests)
            {
                this.specialRequests = specialRequests;
                return this;
            }
            public string GetAuthorization()
            {
                return authorization;
            }

            public Builder SetAuthorization(string authorization)
            {
                this.authorization = authorization;
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

            public BookingSubmitVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new BookingSubmitVo(this);
            }
        }
    }
}
