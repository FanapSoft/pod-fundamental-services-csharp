using System;
using System.Collections.Generic;
using POD_Banking;
using POD_Banking.Base.Enum;
using POD_Banking.Model.ServiceOutput;
using POD_Banking.Model.ValueObject;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Demo
{
    public class BankingMethodInvoke
    {
        private string xml = @"{put your xml}";

        private const string userName = "";

        private InternalServiceCallVo internalServiceCallVo;
        public BankingMethodInvoke()
        {
            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                //.SetScVoucherHash({Put your VoucherHash})
                .SetScApiKey("")
                .Build();
        }


        #region Inquiry-Convert

        public ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetSubmissionChequeSrv>>>> GetSubmissionCheque()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetSubmissionChequeSrv>>>>();
                var getSubmissionChequeVo = GetSubmissionChequeVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetDeposit("")
                    //optional
                    .SetMinAmount(0)
                    .SetMaxAmount(0)
                    .SetBankCode(BankCode.همه_بانک_ها)
                    .SetChequeStatus(ChequeStatus.همه)
                    .SetChequeNumber("")
                    .SetStartDate(new DateTime(2019, 12, 15))
                    .SetEndDate(new DateTime(2019, 12, 15))
                    .SetStartSubmisionDate(new DateTime(2019, 12, 15))
                    .SetEndSubmitionDate(new DateTime(2019, 12, 15))
                    .SetRowCount(10)
                    .Build();
                BankingService.GetSubmissionCheque(getSubmissionChequeVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> ConvertDepositNumberToSheba()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var convertDepositNumberToShebaVo = ConvertDepositNumberToShebaVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetDepositNumber("")
                    .Build();
                BankingService.ConvertDepositNumberToSheba(convertDepositNumberToShebaVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> ConvertShebaToDepositNumber()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var convertShebaToDepositNumberVo = ConvertShebaToDepositNumberVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetSheba("")
                    .Build();
                BankingService.ConvertShebaToDepositNumber(convertShebaToDepositNumberVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<GetShebaInfoSrv>>> GetShebaInfo()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<GetShebaInfoSrv>>>();
                var getShebaInfoVo = GetShebaInfoVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetSheba("")
                    .SetPrivateKey(xml)
                    //.SetShenaseVariz("")
                    .Build();
                BankingService.GetShebaInfo(getShebaInfoVo, response => Listener.GetResult(response, out output));
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


        #endregion Inquiry-Convert

        #region Deposit-Operation

        public ResultSrv<ServiceCallResultSrv<BankingSrv<List<CoreBatchTransferPayaSrv>>>> PayaService()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<List<CoreBatchTransferPayaSrv>>>>();
                var getDepositInvoiceVo = PayaServiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetSourceDepositNumber("")
                    .SetBatchPayaItemInfos(new List<BatchPayaItemInfoVo>
                    {
                         BatchPayaItemInfoVo.ConcreteBuilder.SetBillNumber("12345").SetAmount(100).SetBeneficiaryFullName("تست ۱").SetDescription("تست۱۱").SetDestShebaNumber("").Build(),
                         BatchPayaItemInfoVo.ConcreteBuilder.SetBillNumber("123456").SetAmount(100).SetBeneficiaryFullName("تست ۲").SetDescription("تست۲۲").SetDestShebaNumber("").Build()
                    })
                    .SetFileUniqueIdentifier("")
                    //.SetTransferMoneyBillNumber("")
                    .Build();
                BankingService.PayaService(getDepositInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetDepositInvoiceSrv>>>> GetDepositInvoice()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<List<GetDepositInvoiceSrv>>>>();
                var getDepositInvoiceVo = GetDepositInvoiceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetDepositNumber("")
                    .SetStartDate(DateTime.Now)
                    .SetEndDate(DateTime.Now)
                    .SetFirstIndex(0)
                    .SetCount(10)
                    //.SetSheba("")
                    .SetPrivateKey(xml)
                    .Build();
                BankingService.GetDepositInvoice(getDepositInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> TransferMoney()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var getDepositInvoiceVo = TransferMoneyVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetPaymentId("100")
                    .SetSourceDepositNumber("")
                    .SetDestDepositNumber("")
                    //.SetSourceSheba("")
                    //.SetDestSheba("")
                    .SetAmount(10)
                    .SetSourceComment("تست")
                    .SetDestComment("تست۱")
                    .SetDestFirstName("")
                    .SetDestLastName("")
                    .Build();
                BankingService.TransferMoney(getDepositInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<GetDepositBalanceSrv>>> GetDepositBalance()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<GetDepositBalanceSrv>>>();
                var getDepositInvoiceVo = GetDepositBalanceVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetSheba("")
                    //optional or sheba
                    //.SetDepositNumber("")
                    .Build();
                BankingService.GetDepositBalance(getDepositInvoiceVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<GetTransferMoneyStateSrv>>> GetTransferState()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<GetTransferMoneyStateSrv>>>();
                var getTransferStateVo = GetTransferStateVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetPaymentId("10")
                    .SetDate(DateTime.Now)
                    .Build();
                BankingService.GetTransferState(getTransferStateVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> BillPaymentByDeposit()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var getDepositInvoiceVo = BillPaymentByDepositVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetBillNumber("1234")
                    .SetDepositNumber("")
                    .SetPaymentId("")
                    .Build();
                BankingService.BillPaymentByDeposit(getDepositInvoiceVo, response => Listener.GetResult(response, out output));
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


        #endregion Deposit-Operation

        #region Card-Operation

        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> GetDepositNumberByCardNumber()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var getDepositNumberByCardNumberVo = GetDepositNumberByCardNumberVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetCardNumber("")
                    .SetPrivateKey(xml)
                    .Build();
                BankingService.GetDepositNumberByCardNumber(getDepositNumberByCardNumberVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> GetShebaByCardNumber()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var getShebaByCardNumberVo = GetShebaByCardNumberVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetCardNumber("")
                    .Build();
                BankingService.GetShebaByCardNumber(getShebaByCardNumberVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> GetCardInformation()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var getCardInformationVo = GetCardInformationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetSrcCardNumber("")
                    .SetDestCardNumber("")
                    //optional
                    //.SetEmail("")
                    .Build();
                BankingService.GetCardInformation(getCardInformationVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<string>>> CardToCard()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<string>>>();
                var cardToCardVo = CardToCardVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetAmount(10)
                    .SetCvv2("")
                    .SetSrcCardNumber("")
                    .SetPassword("")
                    .SetDestCardNumber("")
                    .SetExpireMonth(0)
                    .SetExpireYear("")
                    .SetAuthorizationCode("0")
                    .SetWithReferenceNumber(false)
                    //optional
                    //.SetCardName("")
                    //.SetSrcComment("tst1")
                    //.SetDestComment("tst2")
                    //.SetEmail("TEST@TEST.COM")
                    .SetExtraData("DeviceId", "UserAgent", "127.0.0.1", PlatformType.ANDROID, "OS", "imei")
                    //.SetOriginalAddress("127.0.0.1")
                    .Build();
                BankingService.CardToCard(cardToCardVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<BankingSrv<List<CardToCardListSrv>>>> CardToCardList()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<BankingSrv<List<CardToCardListSrv>>>>();
                var cardToCardListVo = CardToCardListVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetUserName(userName)
                    .SetPrivateKey(xml)
                    .SetMinAmount(10)
                    .SetMaxAmount(20)
                    .SetSourceCardNumber("")
                    .SetStartDate(DateTime.Now)
                    .SetEndDate(DateTime.Now)
                    //optional
                    //.SetSourceDepositNumber("")
                    //.SetDestinationCardNumber("")
                    //.SetRefrenceNumber("")
                    //.SetSequenceNumber("")
                    //.SetSourceNote("")
                    //.SetDestinationNote("")
                    .Build();
                BankingService.CardToCardList(cardToCardListVo, response => Listener.GetResult(response, out output));
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

        #endregion Card-Operation
    }
}
