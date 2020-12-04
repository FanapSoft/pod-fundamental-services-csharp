using System;
using System.Collections.Generic;
using System.Linq;
using Booking_Service.Base;
using Booking_Service.Model.ServiceOutput;
using Booking_Service.Model.ValueObject;
using Newtonsoft.Json;
using POD_Base_Service;
using POD_Base_Service.Base;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using RestSharp;

namespace Booking_Service
{
    public static class BookingService
    {
        public static void GetCities(AuthorizeVo authorizeVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<CitiesSrv>>>> callback)
        {
            PrepareRestClient(ServiceCallProducts.Cities, authorizeVo,Method.GET, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<CitiesSrv>>>(request));
        }
        public static void GetPolicies(AuthorizeVo authorizeVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<PoliciesSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.Policies, authorizeVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<PoliciesSrv>>>(request));
        }
        public static void GetAmenities(AuthorizeVo authorizeVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AmenitiesSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.Amenities, authorizeVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AmenitiesSrv>>>(request));
        }
        public static void GetPaymentMethods(AuthorizeVo authorizeVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<PaymentMethodsSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PaymentMethods, authorizeVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<PaymentMethodsSrv>>>(request));
        }
        public static void GetHotelInventory(HotelInventoryVo hotelInventoryVo, Action<IRestResponse<ResultSrv<ServiceCallResultSrv<HotelInventoriesSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.HotelInventory, hotelInventoryVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<HotelInventoriesSrv>>>(request));
        }
        public static void GetHotelAvailability(HotelAvailabilityVo hotelAvailabilityVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.HotelAvailability, hotelAvailabilityVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        public static void GetBookingAvailability(BookingAvailabilityVo bookingAvailabilityVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BookingAvailability, bookingAvailabilityVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        public static void BookingSubmit(BookingSubmitVo bookingSubmitVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BookingSubmit, bookingSubmitVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        public static void BookingVerify(BookingVo bookingVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BookingVerify, bookingVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        public static void BookingConfirm(BookingVo bookingVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BookingConfirm, bookingVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        public static void BookingCancel(BookingVo bookingVo, Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BookingCancel, bookingVo, PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }
        private static void PrepareRestClient<T>(long entityId, T objectVo, Method method, out RestClient client, out RestRequest request)
        {
            client = new RestClient(BaseUrl.ServiceCallAddress);
            request = new RestRequest(Method.GET);
            request.AddHeader(nameof(Config.TokenIssuer).GetPodName(), Config.TokenIssuer.ToString())
                .AddParameter("scProductId", entityId);

            PrepareParameters(objectVo, request, method);
        }

        private static void PrepareParameters<T>(T objectVo, IRestRequest request, Method method)
        {
            if (method == Method.POST)
            {
                var parameters = objectVo.ToDictionaryHierachy(PodParameterName.ParametersName);
                var apiToken = parameters.FirstOrDefault(_ => _.Key.Equals("Authorization"));
                request.AddHeader(apiToken.Key, apiToken.Value.ToString());
                parameters.Remove(apiToken.Key);

                var serviceCallParameters = parameters.FirstOrDefault(_ => _.Key.Equals("serviceCallParameters")).Value as Dictionary<string, object>;
                foreach (var parameter in serviceCallParameters)
                {
                    if (parameter.Key.Equals("_token_"))
                    {
                        request.AddHeader(parameter.Key, parameter.Value?.ToString());
                    }
                    else request.AddParameter(parameter.Key, parameter.Value);
                }
                parameters.Remove("serviceCallParameters");

                var jasonString = JsonConvert.SerializeObject(parameters, Formatting.Indented);
                request.AddParameter("body", jasonString);
            }
            else
            {
                var parameters = objectVo.FilterNotNull(PodParameterName.ParametersName);
                if (parameters == null) return;
                foreach (var parameter in parameters)
                {
                    if (parameter.Key.Equals("_token_") || parameter.Key.Equals("Authorization"))
                    {
                        request.AddHeader(parameter.Key, parameter.Value);
                    }
                    else request.AddParameter(parameter.Key, parameter.Value);
                }

            }
        }
    }
}
