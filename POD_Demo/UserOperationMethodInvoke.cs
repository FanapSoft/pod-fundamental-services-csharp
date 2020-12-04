using System;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_UserOperation;
using POD_UserOperation.Model.ServiceOutput;
using POD_UserOperation.Model.ValueObject;

namespace POD_Demo
{
    public class UserOperationMethodInvoke
    {
        private InternalServiceCallVo internalServiceCallVo;
        public UserOperationMethodInvoke()
        {

            internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
               .SetToken("")
               //.SetScVoucherHash()
               //.SetScApiKey("")
               .Build();

        }
        public ResultSrv<CustomerProfileSrv> GetUserProfile()
        {
            try
            {
                var output = new ResultSrv<CustomerProfileSrv>();
                var userProfileVo = UserProfileVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetClientId("")
                    .SetClientSecret("")
                    .Build();
                UserOperationService.GetUserProfile(userProfileVo, response => Listener.GetResult(response, out output));
                return output;
            }
            catch (PodException podException)
            {
                Console.WriteLine($"-- {podException.Code}-an error has occured : {Environment.NewLine}{podException.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public ResultSrv<CustomerProfileSrv> EditProfileWithConfirmation()
        {
            try
            {
                var output = new ResultSrv<CustomerProfileSrv>();
                var editProfileWithConfirmationVo = EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("")
                    .SetFirstName("")
                    //.SetLastName("")
                    //.SetAddress("")
                    //.SetPhoneNumber("")
                    //.SetCellphoneNumber("")
                    //.SetNationalCode("")
                    //.SetGender(EditProfileWithConfirmationVo.GenderType.WOMAN_GENDER)
                    //.SetBirthDate("")
                    //.SetCountry("")
                    //.SetState("")
                    //.SetCity("")
                    //.SetPostalCode("")
                    //.SetSheba("")
                    //.SetProfileImage("")
                    //.SetClientId("")
                    //.SetClientSecret("")
                    //.SetClientMetadata("")
                    //.SetBirthState("")
                    //.SetIdentificationNumber("")
                    //.SetFatherName("")
                    //.SetEmail("")
                    .Build();
                UserOperationService.EditProfileWithConfirmation(editProfileWithConfirmationVo,
                    response => Listener.GetResult(response, out output));
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

        public ResultSrv<List<AddressSrv>> GetListAddress()
        {
            try
            {
                var output = new ResultSrv<List<AddressSrv>>();
                var invoiceSrv = ListAddressVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetOffset(0)
                    //.SetSize("")
                    .Build();
                UserOperationService.GetListAddress(invoiceSrv, response => Listener.GetResult(response, out output));
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
        public ResultSrv<CustomerProfileSrv> ConfirmEditProfile()
        {
            try
            {
                var output = new ResultSrv<CustomerProfileSrv>();
                var confirmEditProfileVo = ConfirmEditProfileVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetCellphoneNumber("")
                    .SetCode(0)
                    .Build();
                UserOperationService.ConfirmEditProfile(confirmEditProfileVo, response => Listener.GetResult(response, out output));
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
