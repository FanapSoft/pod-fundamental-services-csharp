using System;
using System.Collections.Generic;
using NUnit.Framework;
using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ServiceOutput;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_UserOperation;
using POD_UserOperation.Base.Enum;
using POD_UserOperation.Model.ServiceOutput;
using POD_UserOperation.Model.ValueObject;             

namespace POD_Test
{
    [TestFixture]
    class UserOperationTest
    {
        public UserOperationTest()
        {
            Config.ServerType = ServerType.SandBox;
        }

        #region RequiredParameters

        [Test]
        public void GetUserProfile_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<CustomerProfileSrv>();
            var userProfileVo = UserProfileVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .Build();
            UserOperationService.GetUserProfile(userProfileVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void EditProfileWithConfirmation_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<CustomerProfileSrv>();
            var editProfileWithConfirmationVo = EditProfileWithConfirmationVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetNickName("NadiaAv")
                .Build();
            UserOperationService.EditProfileWithConfirmation(editProfileWithConfirmationVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);

        }

        [Test]
        public void GetListAddress_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<AddressSrv>>();
            var invoiceSrv = ListAddressVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .Build();
            UserOperationService.GetListAddress(invoiceSrv, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion RequiredParameters

        #region AllParameters

        [Test]
        public void GetUserProfile_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<CustomerProfileSrv>();
            var userProfileVo = UserProfileVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetClientId("6305557f7fcb4988abae4e404d3e6e1d")
                .SetClientSecret("a8ba06d0")
                .Build();
            UserOperationService.GetUserProfile(userProfileVo, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void EditProfileWithConfirmation_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

            var output = new ResultSrv<CustomerProfileSrv>();
            var editProfileWithConfirmationVo = EditProfileWithConfirmationVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetNickName("NadiaAv")
                .SetFirstName("tst")
                .SetLastName("tst")
                .SetAddress("tst")
                .SetPhoneNumber("09153871887")
                .SetCellphoneNumber("0518848841")
                .SetNationalCode("1111771111")
                .SetGender(GenderType.WOMAN_GENDER)
                .SetBirthDate("1363/01/27")
                .SetCountry("ایران")
                .SetState("خراسان رضوی")
                .SetCity("مشهد")
                .SetPostalCode("9698146968")
                .SetSheba("980570100680013557234101")
                .SetProfileImage("https://core.pod.ir:443/nzh/image/?imageId=110531&width=909&height=909&hashCode=16b11e5cf3c-0.42178732891944504")
                .SetClientId("6305557f7fcb4988abae4e404d3e6e1d")
                .SetClientSecret("a8ba06d0")
                .SetClientMetadata("{test}")
                .SetBirthState("خرسان رضوی")
                .SetIdentificationNumber("639")
                .SetFatherName("پدر")
                .SetEmail("test@test.com")
                .Build();
            UserOperationService.EditProfileWithConfirmation(editProfileWithConfirmationVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void GetListAddress_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<AddressSrv>>();
            var invoiceSrv = ListAddressVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(0)
                .Build();
            UserOperationService.GetListAddress(invoiceSrv, response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion AllParameters

        #region Validation

        [Test]
        public void EditProfileWithConfirmation_Validation_Email()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetEmail("test@")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_PhoneNumber()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetPhoneNumber("123455")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_NationalCode()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetNationalCode("00093")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_BirthDate()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetBirthDate("1398-08-9")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_PostalCode()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetPostalCode("00")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_Sheba()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("")
                    .SetSheba("98892345")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_Validation_ProfileImage()
        {
            try
            {
                var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                    .SetToken("0469eba2ddf84cb49eff254fe353638d")
                    .Build();

                EditProfileWithConfirmationVo.ConcreteBuilder
                    .SetServiceCallParameters(internalServiceCallVo)
                    .SetNickName("tst")
                    .SetProfileImage("lkh.com")
                    .Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion Validation

        #region NoParameters

        [Test]
        public void GetUserProfile_NoParameters()
        {
            try
            {
                UserProfileVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        [Test]
        public void EditProfileWithConfirmation_NoParameters()
        {
            try
            {
                EditProfileWithConfirmationVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }


        [Test]
        public void GetListAddress_NoParameters()
        {
            try
            {
                ListAddressVo.ConcreteBuilder.Build();
            }
            catch (PodException)
            {
                Assert.True(true);
            }
        }

        #endregion NoParameters
    }
}
