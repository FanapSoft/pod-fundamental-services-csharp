using POD_AI.Base;
using POD_Base_Service.Result;
using System;
using POD_Base_Service;
using RestSharp;
using POD_AI.Model.ValueObject;
using POD_AI.Model.ServiceOutput;

namespace POD_AI
{
    public static class AIService
    {
        public static void SpeechToText(SpeechToTextVo speechToTextVo,
           Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<SpeechToTextContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.SpeechToText, speechToTextVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<SpeechToTextContentSrv>>>>(request));
        }

        public static void ImageProcessingAuthentication(ImageProcessingAuthenticationVo imageProcessingAuthenticationVo,
          Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<ImageProcessingAuthenticationContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ImageProcessingAuthentication, imageProcessingAuthenticationVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<ImageProcessingAuthenticationContentSrv>>>>(request));
        }

        public static void NLUTransferMoney(NLUVo nLUVo,
          Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUTransferMoneyContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.NLUBanking, nLUVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUTransferMoneyContentSrv>>>>(request));
        }

        public static void NLUPayBill(NLUVo nLUVo,
         Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUPayBillContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.NLUBanking, nLUVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUPayBillContentSrv>>>>(request));
        }

        public static void NLUMobilePhoneCharging(NLUVo nLUVo,
         Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUMobilePhoneChargingContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.NLUBanking, nLUVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUMobilePhoneChargingContentSrv>>>>(request));
        }

        public static void NLUGetBalance(NLUVo nLUVo,
         Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUGetBalanceContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.NLUBanking, nLUVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUGetBalanceContentSrv>>>>(request));
        }

        public static void NLUIOT(NLUVo nLUVo,
          Action<IRestResponse<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUIOTContentSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.NLUIOT, nLUVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUIOTContentSrv>>>>(request));
        }

        public static void LicensePlateReader(LicensePlateReaderVo licensePlateReaderVo,
          Action<IRestResponse<ResultSrv<ServiceCallResultSrv<LicensePlateReaderConyentSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.LicensePlateReader, licensePlateReaderVo,
                PodParameterName.ParametersName, out var client,
                out var request);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<LicensePlateReaderConyentSrv>>>(request));
        }
    }
}
