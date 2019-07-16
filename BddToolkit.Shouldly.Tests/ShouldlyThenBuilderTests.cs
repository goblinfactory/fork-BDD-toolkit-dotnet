using System;
using ITLIBRIUM.BddToolkit.Scenarios;
using Shouldly;
using Xunit;

namespace ITLIBRIUM.BddToolkit.Shouldly.Tests
{
    public class ShouldlyThenBuilderTests
    {
        [Fact]
        public void AssertPassWhenExceptionTypeIsEqualToExpected()
        {
            Should.NotThrow(() => BddScenario
                .ExcludeFromReports()
                .Using<Fixture>()
                .When(f => f.BusinessRuleWasBroken())
                .Then().Throws<BusinessException>()
                .Test());
            
            Should.NotThrow(() => BddScenario
                .ExcludeFromReports()
                .Using<Fixture>()
                .When(f => f.BusinessRuleWasBroken())
                .Then().ThrowsExactly<BusinessException>()
                .Test());
        }

        [Fact]
        public void AssertPassWhenExceptionTypeIsAssignableToExpected()
        {
            Should.NotThrow(() => BddScenario
                .ExcludeFromReports()
                .Using<Fixture>()
                .When(f => f.BusinessRuleWasBroken())
                .Then().Throws<Exception>()
                .Test());
        }

        [Fact]
        public void AssertFailWhenExceptionTypeIsNotAssignableToExpected()
        {
            Should.Throw<AggregateAssertException>(() => BddScenario
                .ExcludeFromReports()
                .Using<Fixture>()
                .When(f => f.BusinessRuleWasBroken())
                .Then().Throws<InvalidOperationException>()
                .Test());
        }

        [Fact]
        public void AssertFailWhenExceptionTypeIsNotEqualToExpected()
        {
            Should.Throw<AggregateAssertException>(() => BddScenario
                .ExcludeFromReports()
                .Using<Fixture>()
                .When(f => f.BusinessRuleWasBroken())
                .Then().ThrowsExactly<Exception>()
                .Test());
        }

        private class Fixture
        {
            public void BusinessRuleWasBroken() => throw new BusinessException();
        }

        private class BusinessException : Exception
        {
        }
    }
}