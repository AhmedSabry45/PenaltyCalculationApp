using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Exceptions;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using PenaltyCalculation.Web.Services;
using PenaltyCalculation.Web.Services.Abstract;
using PenaltyCalculation.Web.Services.Concrete;
using System;
using Xunit;

namespace PenaltyCalculation.Web.Tests
{
    public class ServiceCollectionNamedTests
    {
        private readonly ServiceCollection serviceCollection;
        private readonly ServiceProvider serviceProvider;

        public ServiceCollectionNamedTests()
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(TurkeyPenaltyCalculationService), "TR", ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), "AE", ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(ChinaPenaltyCalculationService), CountryEnum.TW.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(GermanPenaltyCalculationService), CountryEnum.DE.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(DenmarkPenaltyCalculationService), CountryEnum.DK.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(UnitedStatePenaltyCalculationService), CountryEnum.US.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(FrancePenaltyCalculationService), CountryEnum.FR.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(ItalyPenaltyCalculationService), CountryEnum.IT.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(JapanPenaltyCalculationService), CountryEnum.JP.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(KoreaPenaltyCalculationService), CountryEnum.KR.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(RussiaPenaltyCalculationService), CountryEnum.RU.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(IndiaPenaltyCalculationService), CountryEnum.IN.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(EgyptPenaltyCalculationService), CountryEnum.EG.GetName(), ServiceLifetime.Transient);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
        [Fact]
        public void NamedServicesTests()
        {
           

            var myServiceTR = serviceProvider.GetService<IPenaltyCalculationService>("TR");

            Assert.NotNull(myServiceTR);
            Assert.IsType<TurkeyPenaltyCalculationService>(myServiceTR);

            var myServiceUAE = serviceProvider.GetService<IPenaltyCalculationService>("AE");

            Assert.NotNull(myServiceUAE);
            Assert.IsType<UnitedArabEmiratesPenaltyCalculationService>(myServiceUAE);
        }

        [Fact]
        public void SameNamedServiceThrowsException()
        {
            Assert.Throws<AlreadyRegisteredNameForServiceTypeException>(() => serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), "TR", ServiceLifetime.Transient));
        }

        [Fact]
        public void NotExistingNamedServiceThrowsException()
        {
            Assert.Throws<NotExistingNamedServiceException>(() => serviceProvider.GetService<IPenaltyCalculationService>("USA"));
        }
    }
}
