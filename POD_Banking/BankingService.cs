using System;
using System.Collections.Generic;
using POD_Banking.Base;
using POD_Banking.Model.ServiceOutput;
using POD_Banking.Model.ValueObject;
using POD_Base_Service;
using POD_Base_Service.Result;
using RestSharp;

namespace POD_Banking
{
    public static class BankingService
    {
        #region Inquiry-Convert

        public static void GetSubmissionCheque(GetSubmissionChequeVo getSubmissionChequeVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetSubmissionChequeSrv>>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetSubmissionCheque, getSubmissionChequeVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetSubmissionChequeSrv>>>>>(request));
        }

        public static void ConvertDepositNumberToSheba(ConvertDepositNumberToShebaVo convertDepositNumberToShebaVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConvertDepositNumberToSheba,
                convertDepositNumberToShebaVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void ConvertShebaToDepositNumber(ConvertShebaToDepositNumberVo convertShebaToDepositNumberVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ConvertShebaToDepositNumber,
                convertShebaToDepositNumberVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void GetShebaInfo(GetShebaInfoVo getShebaInfoVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<GetShebaInfoSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetShebaInfo, getShebaInfoVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<GetShebaInfoSrv>>>>(request));
        }

        #endregion Inquiry-Convert

        #region Deposit-Operation

        public static void PayaService(PayaServiceVo payaServiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<List<CoreBatchTransferPayaSrv>>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.PayaService,
                payaServiceVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<List<CoreBatchTransferPayaSrv>>>>>(request));
        }

        public static void GetDepositInvoice(GetDepositInvoiceVo getDepositInvoiceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetDepositInvoiceSrv>>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetDepositInvoice,
                getDepositInvoiceVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetDepositInvoiceSrv>>>>>(request));
        }
   
        public static void GetDepositBalance(GetDepositBalanceVo getDepositBalanceVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<GetDepositBalanceSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetDepositBalance,
                getDepositBalanceVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<GetDepositBalanceSrv>>>>(request));
        }

        public static void TransferMoney(TransferMoneyVo transferMoneyVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferMoney,
                transferMoneyVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void GetTransferState(GetTransferStateVo getTransferStateVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<GetTransferMoneyStateSrv>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetTransferState,
                getTransferStateVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<GetTransferMoneyStateSrv>>>>(request));
        }

        public static void BillPaymentByDeposit(BillPaymentByDepositVo billPaymentByDepositVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.BillPaymentByDeposit,
                billPaymentByDepositVo, PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        #endregion Deposit-Operation

        #region Card-Operation

        public static void GetDepositNumberByCardNumber(GetDepositNumberByCardNumberVo getDepositNumberByCardNumberVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetDepositNumberByCardNumber,
                getDepositNumberByCardNumberVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void GetShebaByCardNumber(GetShebaByCardNumberVo getShebaByCardNumberVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetShebaByCardNumber, getShebaByCardNumberVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void GetCardInformation(GetCardInformationVo getCardInformationVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetCardInformation, getCardInformationVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void CardToCard(CardToCardVo cardToCardVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CardToCard, cardToCardVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>>(request));
        }

        public static void CardToCardList(CardToCardListVo cardToCardListVo,
            Action<IRestResponse<ResultSrv<ServiceCallResultSrv<BankingSrv<List<CardToCardListSrv>>>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CardToCardList, cardToCardListVo,
                PodParameterName.ParametersName, out var client, out var request, false);
            callback(client.Execute<ResultSrv<ServiceCallResultSrv<BankingSrv<List<CardToCardListSrv>>>>>(request));
        }

        #endregion Card-Operation
    }
}
