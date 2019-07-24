using System;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_UserOperation;
using POD_UserOperation.Model.ServiceOutput;
using POD_UserOperation.Model.ValueObject;

namespace Demo
{
    public class UserOperationMethodInvoke
    {
        public ResultSrv<CustomerProfileSrv> GetUserProfile()
        {
            try
            {
                var output= new ResultSrv<CustomerProfileSrv>();
                var accessTokenVo = UserProfileVo.ConcreteBuilder
                   .SetToken("{Put your Toekn}")
                   .SetClientId("{Put your ClientId}")
                   .SetClientSecret("{Put your ClientSecret}")
                   .Build();
                UserOperationService.GetUserProfile(accessTokenVo, response => Listener.GetResult(response, out output));
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
                    .SetToken("{Put your Token}")
                    .SetNickName("{Put your NickName}")
                    //.SetFirstName("{Put your FirstName}") 
                    //.SetLastName("{Put your LastName}")
                    //.SetAddress("{Put your Address}")
                    //.SetPhoneNumber("{Put your PhoneNumber}")
                    //.SetCellphoneNumber("{Put your CellphoneNumber}")
                    //.SetNationalCode("{Put your NationalCode}")
                    //.SetGender(EditProfileWithConfirmationVo.GenderType.WOMAN_GENDER)
                    //.SetBirthDate("{Put your BirthDate}")
                    //.SetCountry("{Put your Country}")
                    //.SetState("{Put your last name}")
                    //.SetCity("{Put your City}")
                    //.SetPostalCode("{Put your PostalCode}")
                    //.SetSheba("{Put your Sheba}")
                    //.SetProfileImage("{Put your ProfileImage}")
                    //.SetClientId("{Put your ClientId}")
                    //.SetClientSecret("{Put your ClientSecret}")
                    //.SetClientMetadata("{Put your ClientMetadata}")
                    //.SetBirthState("{Put your BirthState}")
                    //.SetIdentificationNumber("{Put your IdentificationNumber}")
                    //.SetFatherName("{Put your FatherName}")
                    //.SetEmail("{Put your Email}")
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
    }
}
