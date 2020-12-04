using System;
using POD_AI;
using POD_AI.Base.Enum;
using POD_AI.Model.ServiceOutput;
using POD_AI.Model.ValueObject;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Demo
{
    public class AIMethodInvoke
    {
        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<SpeechToTextContentSrv>>> SpeechToText()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<SpeechToTextContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash()
                    .Build();

                var speechToTextVo = SpeechToTextVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetLinkFile("")
                    .Build();
                AIService.SpeechToText(speechToTextVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<ImageProcessingAuthenticationContentSrv>>> ImageProcessingAuthentication()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<ImageProcessingAuthenticationContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash()
                    .Build();

                var imageProcessingAuthenticationVo = ImageProcessingAuthenticationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetImage1("")
                    .SetImage2("")
                    .SetMode(ImageComparisonMode.Easy)
                    .Build();
                AIService.ImageProcessingAuthentication(imageProcessingAuthenticationVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUTransferMoneyContentSrv>>> NLUTransferMoney()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUTransferMoneyContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var nLUVo = NLUVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetText("مبلغ 1 تومان از حساب 80000 به حساب 100000 واریز کن")
                    .Build();
                AIService.NLUTransferMoney(nLUVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUPayBillContentSrv>>> NLUPayBill()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUPayBillContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var nLUVo = NLUVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetText("قبض با شماره شناسایی 456456 را پرداخت کن")
                    .Build();
                AIService.NLUPayBill(nLUVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUMobilePhoneChargingContentSrv>>> NLUMobilePhoneCharging()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUMobilePhoneChargingContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var nLUVo = NLUVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetText("شماره موبایل 456456 را به مبلغ 1 تومان شارژ کن")
                    .Build();
                AIService.NLUMobilePhoneCharging(nLUVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUGetBalanceContentSrv>>> NLUGetBalance()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUGetBalanceContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var nLUVo = NLUVo.ConcreteBuilder
                   .SetServiceCallParameters(internalServiceCallVo)
                   .SetText("موجودی شماره حساب 123545 را بده")
                   .Build();
                AIService.NLUGetBalance(nLUVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUIOTContentSrv>>> NLUIOT()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<AIPlatformSrv<NLUIOTContentSrv>>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var nLUVo = NLUVo.ConcreteBuilder
                   .SetServiceCallParameters(internalServiceCallVo)
                   .SetText("PLAY")
                   .Build();
                AIService.NLUIOT(nLUVo, response => Listener.GetResult(response, out output));
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

        public ResultSrv<ServiceCallResultSrv<LicensePlateReaderConyentSrv>> LicensePlateReader()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<LicensePlateReaderConyentSrv>>();

                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("")
                    .SetScApiKey("")
                    //.SetScVoucherHash({Put your VoucherHash})
                    .Build();

                var licensePlateReaderVo = LicensePlateReaderVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetImage("")
                    .SetIsCrop(false)
                    .Build();
                AIService.LicensePlateReader(licensePlateReaderVo, response => Listener.GetResult(response, out output));
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
