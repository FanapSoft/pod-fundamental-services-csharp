using POD_Neshan;
using System;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_Neshan.Model.ServiceOutput;
using POD_Neshan.Model.ValueObject;
using POD_Base_Service.Result;

namespace POD_Demo
{
    public class NeshanMethodInvoke
    {
        private ExternalServiceCallVo externalServiceCallVo;

        public NeshanMethodInvoke()
        {
            externalServiceCallVo = ExternalServiceCallVo.ConcreteBuilder
                .SetToken("")
                .SetScApiKey("")
                //.SetScVoucherHash(new []{"kjljk"})
                .Build();
        }

        public ResultSrv<ServiceCallResultSrv<SearchSrv>> Search()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<SearchSrv>>();
                var searchVo = SearchVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetLat(11111111111110)
                    .SetLng(11111111111110)
                    .SetTerm("حرم")
                    .Build();
                NeshanService.Search(searchVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<ReverseSrv>> ReverseGeo()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<ReverseSrv>>();
                var reverseGeoVo = ReverseGeoVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetLat(59.6157432)
                    .SetLng(36.2880443)
                    .Build();
                NeshanService.ReverseGeo(reverseGeoVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<DirectionSrv>> Direction()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<DirectionSrv>>();
                var directionVo = DirectionVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetOrigin(new PointD(59.6157432, 36.2880443))
                    .SetDestination(new PointD(36.307656, 59.530862))
                    //.SetWayPoints(new Point[0])
                    //.SetAvoidTrafficZone(false)
                    //.SetAvoidOddEvenZone(false)
                    //.SetAlternative(false)
                    .Build();
                NeshanService.Direction(directionVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<DirectionSrv>> NoTrafficDirection()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<DirectionSrv>>();
                var directionVo = DirectionVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetOrigin(new PointD(59.6157432, 36.2880443))
                    .SetDestination(new PointD(36.307656, 59.530862))
                    //.SetWayPoints(new Point[0])
                    //.SetAvoidTrafficZone(false)
                    //.SetAvoidOddEvenZone(false)
                    //.SetAlternative(false)
                    .Build();
                NeshanService.NoTrafficDirection(directionVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>> DistanceMatrix()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>();
                var distanceMatrixVo = DistanceMatrixVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetOrigins(new[] { new PointD(59.6157432, 36.2880443), new PointD(36.304889, 59.544595) })
                    .SetDestinations(new[] { new PointD(36.307656, 59.530862), new PointD(36.296865, 59.554208) })
                    .Build();
                NeshanService.DistanceMatrix(distanceMatrixVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>> NoTrafficDistanceMatrix()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<DistanceMatrixSrv>>();
                var distanceMatrixVo = DistanceMatrixVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetOrigins(new[] { new PointD(59.6157432, 36.2880443), new PointD(36.304889, 59.544595) })
                    .SetDestinations(new[] { new PointD(36.307656, 59.530862), new PointD(36.296865, 59.554208) })
                    .Build();
                NeshanService.NoTrafficDistanceMatrix(distanceMatrixVo, response => Listener.GetResult(response, out output));
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
        public ResultSrv<ServiceCallResultSrv<MapMatchingSrv>> MapMatching()
        {
            try
            {
                var output = new ResultSrv<ServiceCallResultSrv<MapMatchingSrv>>();
                var mapMatchingVo = MapMatchingVo.ConcreteBuilder
                    .SetServiceCallParameters(externalServiceCallVo)
                    .SetPath(new[] { new PointD(36.299394, 59.606211), new PointD(36.297950, 59.604258), new PointD(36.297206, 59.603507) })
                    .Build();
                NeshanService.MapMatching(mapMatchingVo, response => Listener.GetResult(response, out output));
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
