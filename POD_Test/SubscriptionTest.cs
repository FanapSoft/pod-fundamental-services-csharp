﻿using NUnit.Framework;
using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;
using POD_Base_Service.Model.ValueObject;
using POD_Base_Service.Result;
using POD_Subscription;
using POD_Subscription.Base.Enum;
using POD_Subscription.Model.ServiceOutput;
using POD_Subscription.Model.ValueObject;

namespace POD_Test
{
    [TestFixture]
    class SubscriptionTest
    {
        public SubscriptionTest()
        {
            Config.ServerType = ServerType.SandBox;
        }

        #region RequiredParameters

        [Test]
        public void AddSubscriptionPlan_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionPlanSrv>();
            var addSubscriptionPlanVo = AddSubscriptionPlanVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName("tstn")
                .SetPrice(100)
                .SetPeriodTypeCode(PeriodType.SUBSCRIPTION_PLAN_PERIOD_TYPE_DAILY)
                .SetPeriodTypeCount(2)
                .SetType(SubscriptionType.SUBSCRIPTION_PLAN_TYPE_BLOCK)
                .SetGuildCode("TOILETRIES_GUILD")
                .SetEntityId(19482)
                .Build();
            SubscriptionService.AddSubscriptionPlan(addSubscriptionPlanVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void SubscriptionPlanList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<SubscriptionPlanSrv>>();
            var subscriptionPlanListVo = SubscriptionPlanListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(10)
                .Build();
            SubscriptionService.SubscriptionPlanList(subscriptionPlanListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateSubscriptionPlan_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionPlanSrv>();
            var updateSubscriptionPlanVo = UpdateSubscriptionPlanVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(85)
                .Build();
            SubscriptionService.UpdateSubscriptionPlan(updateSubscriptionPlanVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void RequestSubscription_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var requestSubscriptionVo = RequestSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetSubscriptionPlanId(0)
                .SetUserId(0)
                .Build();
            SubscriptionService.RequestSubscription(requestSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        } 

        [Test]
        public void ConfirmSubscription_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var confirmSubscriptionVo = ConfirmSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCode("0")
                .SetSubscriptionId(0)
                .Build();
            SubscriptionService.ConfirmSubscription(confirmSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void SubscriptionList_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<SubscriptionFullSrv>>();
            var subscriptionListVo = SubscriptionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(10)
                .SetSubscriptionPlanId(0)
                .Build();
            SubscriptionService.SubscriptionList(subscriptionListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ConsumeSubscription_RequiredParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var consumeSubscriptionVo = ConsumeSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(0)
                .SetUsedAmount(5)
                .Build();
            SubscriptionService.ConsumeSubscription(consumeSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion RequiredParameters

        #region AllParameters

        [Test]
        public void AddSubscriptionPlan_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionPlanSrv>();
            var addSubscriptionPlanVo = AddSubscriptionPlanVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetName("tstn")
                .SetPrice(100)
                .SetPeriodTypeCode(PeriodType.SUBSCRIPTION_PLAN_PERIOD_TYPE_DAILY)
                .SetPeriodTypeCount(2)
                .SetType(SubscriptionType.SUBSCRIPTION_PLAN_TYPE_BLOCK)
                .SetGuildCode("TOILETRIES_GUILD")
                .SetEntityId(19482)
                .SetUsageCountLimit(0)
                .SetUsageAmountLimit(100.9M)
                .SetPermittedGuildCode(new string[] { "ADVERTISEMENT_GUILD", "TOILETRIES_GUILD" })
                .SetPermittedBusinessId(new long[] { 3605, 3612 })
                .SetPermittedProductId(new long[] { })
                .SetCurrencyCode("")
                .Build();
            SubscriptionService.AddSubscriptionPlan(addSubscriptionPlanVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void SubscriptionPlanList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<SubscriptionPlanSrv>>();
            var subscriptionPlanListVo = SubscriptionPlanListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(10)
                .SetId(85)
                .SetPeriodTypeCode(PeriodType.SUBSCRIPTION_PLAN_PERIOD_TYPE_DAILY)
                .SetPeriodTypeCountFrom(0)
                .SetPeriodTypeCountTo(0)
                .SetFromPrice(0)
                .SetToPrice(0)
                .SetEnable(false)
                .SetPermittedGuildCode(new string[] { })
                .SetPermittedBusinessId(new long[] { })
                .SetPermittedProductId(new long[] { })
                .SetCurrencyCode("IRR")
                .SetTypeCode(SubscriptionType.SUBSCRIPTION_PLAN_TYPE_BLOCK)
                .Build();
            SubscriptionService.SubscriptionPlanList(subscriptionPlanListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void UpdateSubscriptionPlan_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionPlanSrv>();
            var updateSubscriptionPlanVo = UpdateSubscriptionPlanVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(85)
                .SetPeriodTypeCode(PeriodType.SUBSCRIPTION_PLAN_PERIOD_TYPE_DAILY)
                .SetPeriodTypeCount(0)
                .SetUsageCountLimit(0)
                .SetName("")
                .SetPrice(0)
                .SetEnable(false)
                .Build();
            SubscriptionService.UpdateSubscriptionPlan(updateSubscriptionPlanVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void RequestSubscription_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var requestSubscriptionVo = RequestSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetSubscriptionPlanId(0)
                .SetUserId(0)
                .Build();
            SubscriptionService.RequestSubscription(requestSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ConfirmSubscription_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var confirmSubscriptionVo = ConfirmSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetCode("0")
                .SetSubscriptionId(0)
                .Build();
            SubscriptionService.ConfirmSubscription(confirmSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void SubscriptionList_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<List<SubscriptionFullSrv>>();
            var subscriptionListVo = SubscriptionListVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetOffset(0)
                .SetSize(10)
                .SetSubscriptionPlanId(0)
                .Build();
            SubscriptionService.SubscriptionList(subscriptionListVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        [Test]
        public void ConsumeSubscription_AllParameters()
        {
            var internalServiceCallVo = InternalServiceCallVo.ConcreteBuilder
                .SetToken("0469eba2ddf84cb49eff254fe353638d")
                .Build();

            var output = new ResultSrv<SubscriptionSrv>();
            var consumeSubscriptionVo = ConsumeSubscriptionVo.ConcreteBuilder
                .SetServiceCallParameters(internalServiceCallVo)
                .SetId(0)
                .SetUsedAmount(5)
                .Build();
            SubscriptionService.ConsumeSubscription(consumeSubscriptionVo,
                response => Listener.GetResult(response, out output));
            Assert.False(output.HasError);
        }

        #endregion AllParameters
    }
}
