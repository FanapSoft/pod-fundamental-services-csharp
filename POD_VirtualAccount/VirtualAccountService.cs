using System;
using System.Collections.Generic;
using POD_Base_Service;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_VirtualAccount.Base;
using POD_VirtualAccount.Model.ServiceOutput;
using POD_VirtualAccount.Model.ValueObject;
using RestSharp;

namespace POD_VirtualAccount
{
    public static class VirtualAccountService
    {
        public static void IssueCreditInvoiceAndGetHash(IssueCreditInvoiceAndGetHashVo issueCreditInvoiceAndGetHashVo,
            Action<IRestResponse<ResultSrv<string>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.IssueCreditInvoiceAndGetHash, issueCreditInvoiceAndGetHashVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<string>>(request));
        }

        public static void VerifyCreditInvoice(VerifyCreditInvoiceVo verifyCreditInvoiceVo,
            Action<IRestResponse<ResultSrv<CreditInvoiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.VerifyCreditInvoice, verifyCreditInvoiceVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<CreditInvoiceSrv>>(request));
        }

        public static void TransferFromOwnAccounts(TransferFromOwnAccountsVo transferFromOwnAccountsVo,
            Action<IRestResponse<ResultSrv<UserAmountSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferFromOwnAccounts, transferFromOwnAccountsVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<UserAmountSrv>>(request));
        }

        public static void TransferFromOwnAccountsList(TransferFromOwnAccountsListVo transferFromOwnAccountsListVo,
            Action<IRestResponse<ResultSrv<List<TransferCreditSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferFromOwnAccountsList, transferFromOwnAccountsListVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<TransferCreditSrv>>>(request));
        }

        public static void TransferToContact(TransferToContactVo transferToContactVo,
            Action<IRestResponse<ResultSrv<TransferToContactSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferToContact, transferToContactVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<TransferToContactSrv>>(request));
        }

        public static void TransferToContactList(TransferToContactListVo transferToContactListVo,
            Action<IRestResponse<ResultSrv<List<TransferToContactSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferToContactList, transferToContactListVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<TransferToContactSrv>>>(request));
        }

        public static void Follow(FollowVo followVo,
            Action<IRestResponse<ResultSrv<bool>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.Follow, followVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<bool>>(request));
        }

        public static void GetBusiness(InternalServiceCallVo internalServiceCallVo,
            Action<IRestResponse<ResultSrv<BusinessSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetBusiness, internalServiceCallVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<BusinessSrv>>(request));
        }

        public static void GetFollowers(GetFollowersVo getFollowersVo,
            Action<IRestResponse<ResultSrv<List<UserSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetFollowers, getFollowersVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<UserSrv>>>(request));
        }

        public static void TransferToFollower(TransferToFollowerVo transferToFollowerVo,
            Action<IRestResponse<ResultSrv<UserAmountSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferToFollower, transferToFollowerVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<UserAmountSrv>>(request));
        }

        public static void TransferToFollowerAndCashout(TransferToFollowerAndCashoutVo transferToFollowerAndCashoutVo,
            Action<IRestResponse<ResultSrv<UserAmountSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferToFollowerAndCashout, transferToFollowerAndCashoutVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<UserAmountSrv>>(request));
        }

        public static void TransferToFollowerList(TransferToFollowerListVo transferToFollowerListVo,
            Action<IRestResponse<ResultSrv<List<TransferToFollowerSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferToFollowerList, transferToFollowerListVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<TransferToFollowerSrv>>>(request));
        }

        public static void TransferByInvoice(TransferByInvoiceVo transferByInvoiceVo,
            Action<IRestResponse<ResultSrv<UserAmountSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.TransferByInvoice, transferByInvoiceVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<UserAmountSrv>>(request));
        }

        public static void ListTransferByInvoice(ListTransferByInvoiceVo listTransferByInvoiceVo,
            Action<IRestResponse<ResultSrv<List<TransferToFollowerSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.ListTransferByInvoice, listTransferByInvoiceVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<TransferToFollowerSrv>>>(request));
        }

        public static void GetAccountBill(GetGuildAccountBillVo getGuildAccountBillVo,
            Action<IRestResponse<ResultSrv<List<AccountBillItemSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetGuildAccountBill, getGuildAccountBillVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<AccountBillItemSrv>>>(request));
        }

        public static void GetAccountBill(GetWalletAccountBillVo getWalletAccountBillVo,
            Action<IRestResponse<ResultSrv<List<AccountBillItemSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetWalletAccountBill, getWalletAccountBillVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<AccountBillItemSrv>>>(request));
        }

        public static void GetAccountBill(GetAccountBillAsFileVo getAccountBillAsFileVo,
            Action<IRestResponse<ResultSrv<ExportServiceSrv>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.GetAccountBillAsFile, getAccountBillAsFileVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<ExportServiceSrv>>(request));
        }

        public static void CardToCardList(CardToCardListVo cardToCardListVo,
            Action<IRestResponse<ResultSrv<List<CardToCardPoolSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.CardToCardList, cardToCardListVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<CardToCardPoolSrv>>>(request));
        }

        public static void UpdateCardToCard(UpdateCardToCardVo updateCardToCardVo,
            Action<IRestResponse<ResultSrv<List<CardToCardPoolSrv>>>> callback)
        {
            BaseService.PrepareRestClient(ServiceCallProducts.UpdateCardToCard, updateCardToCardVo,
                PodParameterName.ParametersName, out var client, out var request);
            callback(client.Execute<ResultSrv<List<CardToCardPoolSrv>>>(request));
        }
    }
}
