using System;
using Booking_Service;
using Booking_Service.Model.ServiceOutput;
using Booking_Service.Model.ValueObject;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Demo
{
    public class BookingMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        private string authorization = "";
        public BookingMethodInvoke()
        {
            try
            {
                internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    //.SetScApiKey("")
                    .Build();
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<CitiesSrv>> GetCities()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<CitiesSrv>>();
                var authorizeVo = AuthorizeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAuthorization(authorization)
                    .Build();
                BookingService.GetCities(authorizeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<PoliciesSrv>> GetPolicies()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<PoliciesSrv>>();
                var authorizeVo = AuthorizeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAuthorization(authorization)
                    .Build();
                BookingService.GetPolicies(authorizeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<AmenitiesSrv>> GetAmenities()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AmenitiesSrv>>();
                var authorizeVo = AuthorizeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAuthorization(authorization)
                    .Build();
                BookingService.GetAmenities(authorizeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<PaymentMethodsSrv>> GetPaymentMethods()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<PaymentMethodsSrv>>();
                var authorizeVo = AuthorizeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAuthorization(authorization)
                    .Build();
                BookingService.GetPaymentMethods(authorizeVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<ServiceCallResultSrv<HotelInventoriesSrv>> GetHotelInventory()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<HotelInventoriesSrv>>();
                var hotelInventoryVo = HotelInventoryVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAuthorization(authorization)
                    //.SetLang("")
                    //.SetApiVersion("")
                    //.SetCityId(0)
                    .Build();
                BookingService.GetHotelInventory(hotelInventoryVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> GetHotelAvailability()
        {
            try
            {
                var output = new ResultSrv<string>();
                var hotelAvailabilityVo = HotelAvailabilityVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)

                    .Build();
                BookingService.GetHotelAvailability(hotelAvailabilityVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> GetBookingAvailability()
        {
            try
            {
                var output = new ResultSrv<string>();
                var bookingAvailabilityVo = BookingAvailabilityVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)

                    .Build();
                BookingService.GetBookingAvailability(bookingAvailabilityVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> BookingSubmit()
        {
            try
            {
                var output = new ResultSrv<string>();
                var bookingSubmitVo = BookingSubmitVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)

                    .Build();
                BookingService.BookingSubmit(bookingSubmitVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> BookingVerify()
        {
            try
            {
                var output = new ResultSrv<string>();
                var bookingVo = BookingVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetHotelId("")
                    .SetReferenceId("")
                    .SetApiVersion("")
                    .Build();
                BookingService.BookingVerify(bookingVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> BookingConfirm()
        {
            try
            {
                var output = new ResultSrv<string>();
                var bookingVo = BookingVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetHotelId("")
                    .SetReferenceId("")
                    .SetApiVersion("")
                    .Build();
                BookingService.BookingConfirm(bookingVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public ResultSrv<string> BookingCancel()
        {
            try
            {
                var output = new ResultSrv<string>();
                var bookingVo = BookingVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetHotelId("")
                    .SetReferenceId("")
                    .SetApiVersion("")
                    .Build();
                BookingService.BookingCancel(bookingVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine(
                    $"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
