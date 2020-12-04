using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_VirtualAccount;
using POD_VirtualAccount.Base.Enum;
using POD_VirtualAccount.Model.ServiceOutput;
using POD_VirtualAccount.Model.ValueObject;

namespace POD_Demo
{
    public class VirtualAccountMethodInvoke
    {
        private const string GuildCode = "TOILETRIES_GUILD";
        private InternalServiceCallVo internalServiceCallVo;
        public VirtualAccountMethodInvoke()
        {
            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                //.SetScVoucherHash()
                //.SetScApiKey("")
                .Build();
        }
        public string GetBuyCreditLink()
        {
            try
            {
                var buyCreditVo = BuyCreditVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetRedirectUri("")
                    //.SetCallUri("")
                    .Build();
                var link = buyCreditVo.GetLink();
                return link;
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
        public string GetBuyCreditByAmountLink()
        {
            try
            {
                var buyCreditVo = BuyCreditByAmountVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    //.SetRedirectUri("")
                    //.SetCallUri("")
                    .SetAmount(10)
                    .Build();
                var link = buyCreditVo.GetLink();
                return link;
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
        public ResultSrv<string> IssueCreditInvoiceAndGetHash()
        {
            try
            {
                var output = new ResultSrv<string>();
                var issueCreditInvoiceAndGetHashVo = IssueCreditInvoiceAndGetHashVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAmount(100)
                    .SetBillNumber("")
                    .SetRedirectUrl("")
                    .SetUserId(0)
                    .SetWallet("PODLAND_WALLET")
                    .Build();
                VirtualAccountService.IssueCreditInvoiceAndGetHash(issueCreditInvoiceAndGetHashVo, response => Listener.GetResult(response, out output));
                var link = issueCreditInvoiceAndGetHashVo.GetLink(output.Result);
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
        public ResultSrv<CreditInvoiceSrv> VerifyCreditInvoice()
        {
            try
            {
                var output = new ResultSrv<CreditInvoiceSrv>();
                var verifyCreditInvoiceVo = VerifyCreditInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBillNumber("")
                    //.SetId(0)
                    .Build();
                VirtualAccountService.VerifyCreditInvoice(verifyCreditInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<UserAmountSrv> TransferFromOwnAccounts()
        {
            try
            {
                var output = new ResultSrv<UserAmountSrv>();
                var transferFromOwnAccountsVo = TransferFromOwnAccountsVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo).SetGuildAmount(new List<GuildAmount>
                    {
                        GuildAmount.ConcreteBuilder.SetGuildCode(GuildCode).SetAmount(-10).Build(),
                        GuildAmount.ConcreteBuilder.SetGuildCode("HEALTH_GUILD").SetAmount(-10).Build(),
                    })
                    .SetCustomerAmount(20)
                    //optional
                    //.SetCurrencyCode("")
                    //.SetDescription("")
                    //.SetUniqueId("")
                    //.SetWallet("")
                    .Build();
                VirtualAccountService.TransferFromOwnAccounts(transferFromOwnAccountsVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<TransferCreditSrv>> TransferFromOwnAccountsList()
        {
            try
            {
                var output = new ResultSrv<List<TransferCreditSrv>>();
                var transferFromOwnAccountsListVo = TransferFromOwnAccountsListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetFromDate("1398/07/01")
                    //.SetToDate("1398/09/30")
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferFromOwnAccountsList(transferFromOwnAccountsListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<TransferToContactSrv> TransferToContact()
        {
            try
            {
                var output = new ResultSrv<TransferToContactSrv>();
                var transferToContactVo = TransferToContactVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetContactId(0)
                    .SetAmount(10)
                    //optional
                    //.SetCurrencyCode("")
                    //.SetDescription("")
                    //.SetUniqueId("")
                    //.SetWallet("")
                    .Build();
                VirtualAccountService.TransferToContact(transferToContactVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<TransferToContactSrv>> TransferToContactList()
        {
            try
            {
                var output = new ResultSrv<List<TransferToContactSrv>>();
                var transferToContactListVo = TransferToContactListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetContactId(0)
                    //.SetCurrencyCode("")
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferToContactList(transferToContactListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<bool> Follow()
        {
            try
            {
                var output = new ResultSrv<bool>();
                var followVo = FollowVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetBusinessId(0)
                    .SetFollow(true)
                    .Build();
                VirtualAccountService.Follow(followVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<BusinessSrv> GetBusiness()
        {
            try
            {
                var output = new ResultSrv<BusinessSrv>();
                VirtualAccountService.GetBusiness(internalServiceCallVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<UserSrv>> GetFollowers()
        {
            try
            {
                var output = new ResultSrv<List<UserSrv>>();
                var getFollowersVo = GetFollowersVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    .Build();
                VirtualAccountService.GetFollowers(getFollowersVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<UserAmountSrv> TransferToFollower()
        {
            try
            {
                var output = new ResultSrv<UserAmountSrv>();
                var transferToFollowerVo = TransferToFollowerVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetAmount(10)
                    .SetDescription("")
                    .SetGuildCode(GuildCode)
                    .SetUserId(17958)
                    .SetWallet("PODLAND_WALLET")
                    //optional
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferToFollower(transferToFollowerVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<UserAmountSrv> TransferToFollowerAndCashout()
        {
            try
            {
                var output = new ResultSrv<UserAmountSrv>();
                var transferToFollowerAndCashoutVo = TransferToFollowerAndCashoutVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetWallet("PODLAND_WALLET")
                    .SetAmount(10)
                    .SetDescription("")
                    .SetGuildCode(GuildCode)
                    .SetUserId(0)
                    //optional
                    //.SetCurrencyCode("IRR")
                    //.SetToolCode(ToolCode.SETTLEMENT_TOOL_CARD)
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferToFollowerAndCashout(transferToFollowerAndCashoutVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<TransferToFollowerSrv>> TransferToFollowerList()
        {
            try
            {
                var output = new ResultSrv<List<TransferToFollowerSrv>>();
                var transferToFollowerListVo = TransferToFollowerListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(0)
                    //optional
                    //.SetContactId(0)
                    //.SetCurrencyCode("")
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetGuildCode("")
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferToFollowerList(transferToFollowerListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<UserAmountSrv> TransferByInvoice()
        {
            try
            {
                var output = new ResultSrv<UserAmountSrv>();
                var transferByInvoiceVo = TransferByInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetInvoiceId(0)
                    .SetAmount(10)
                    .SetDescription("")
                    .SetGuildCode(GuildCode)
                    .SetWallet("PODLAND_WALLET")
                    //optional
                    //.SetCurrencyCode("")
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.TransferByInvoice(transferByInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<TransferToFollowerSrv>> ListTransferByInvoice()
        {
            try
            {
                var output = new ResultSrv<List<TransferToFollowerSrv>>();
                var listTransferByInvoiceVo = ListTransferByInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetCurrencyCode("")
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetGuildCode("")
                    //.SetInvoiceId(0)
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.ListTransferByInvoice(listTransferByInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<AccountBillItemSrv>> GetGuildAccountBill()
        {
            try
            {
                var output = new ResultSrv<List<AccountBillItemSrv>>();
                var getGuildAccountBillVo = GetGuildAccountBillVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetAmountFrom(0)
                    //.SetAmountTo(0)
                    //.SetBlock(false)
                    //.SetCurrencyCode("")
                    //.SetDateFrom("")
                    //.SetDateTo("")
                    //.SetDebtor(false)
                    //.SetDescription("")
                    //.SetGuildCode("")
                    .Build();
                VirtualAccountService.GetAccountBill(getGuildAccountBillVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<AccountBillItemSrv>> GetWalletAccountBill()
        {
            try
            {
                var output = new ResultSrv<List<AccountBillItemSrv>>();
                var getWalletAccountBillVo = GetWalletAccountBillVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetAmountFrom(0)
                    //.SetAmountTo(0)
                    //.SetBlock(false)
                    //.SetCurrencyCode("")
                    //.SetDateFrom("")
                    //.SetDateTo("")
                    //.SetDebtor(false)
                    //.SetDescription("")
                    //.SetGuildCode("")
                    .Build();
                VirtualAccountService.GetAccountBill(getWalletAccountBillVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ExportServiceSrv> GetAccountBillAsFile()
        {
            try
            {
                var output = new ResultSrv<ExportServiceSrv>();
                var getAccountBillAsFileVo = GetAccountBillAsFileVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCallbackUrl("")
                    .SetLastNRows(3)
                    //optional
                    //.SetGuildCode("")
                    //.SetAmountFrom(0)
                    //.SetAmountTo(0)
                    //.SetBlock(false)
                    //.SetCurrencyCode("")
                    //.SetCurrencyCode("")
                    //.SetDateFrom("")
                    //.SetDateTo("")
                    //.SetDebtor(false)
                    //.SetDescription("")
                    .Build();
                VirtualAccountService.GetAccountBill(getAccountBillAsFileVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<CardToCardPoolSrv>> CardToCardList()
        {
            try
            {
                var output = new ResultSrv<List<CardToCardPoolSrv>>();
                var cardToCardListVo = CardToCardListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    .SetSize(10)
                    //optional
                    //.SetCanEdit(false)
                    //.SetCanceled(false)
                    //.SetCauseCode(CauseCode.CASHOUT_CAUSE_TYPE_INVOICE)
                    //.SetCauseId("")
                    //.SetFromAmount(0)
                    //.SetToAmount(0)
                    //.SetFromDate("")
                    //.SetToDate("")
                    //.SetReferenceNumber("")
                    .SetStatusCode(CardStatusCode.CARD_TO_CARD_STATUS_CREATED)
                    //.SetUniqueId("")
                    .Build();
                VirtualAccountService.CardToCardList(cardToCardListVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<List<CardToCardPoolSrv>> UpdateCardToCard()
        {
            try
            {
                var output = new ResultSrv<List<CardToCardPoolSrv>>();
                var updateCardToCardVo = UpdateCardToCardVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetId(0)
                    .SetCardNumber("")
                    .Build();
                VirtualAccountService.UpdateCardToCard(updateCardToCardVo, response => Listener.GetResult(response, out output));
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
