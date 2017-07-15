using NUnit.Framework;
using System;

namespace Nalarium.Test
{
    public interface IMockProvider
    {
        string Execute(string exampleRequiredParameter, params string[] parameterArray);
    }

    public class MockProvider : IMockProvider
    {
        public string Execute(string exampleRequiredParameter, params string[] parameterArray)
        {
            return $"{exampleRequiredParameter}mock provider";
        }
    }

    public class AlternativeMockProvider : IMockProvider
    {
        private string _param;
        public AlternativeMockProvider(string param)
        {
            _param = param;
        }
        public string Execute(string exampleRequiredParameter, params string[] parameterArray)
        {
            return $"{exampleRequiredParameter}{_param}alternative mock provider";
        }
    }

    public class MockProviderFactory : IProviderFactory<IMockProvider>
    {
        public IMockProvider Create(params string[] parameterArray)
        {
            string hint = null;
            if (parameterArray.Length > 0)
            {
                hint = parameterArray[0].ToLower();
            }

            var param = string.Empty;
            if (parameterArray.Length > 1)
            {
                param = parameterArray[1].ToLower();
            }

            var providerToUseFromConfigStore = "mock";

            IMockProvider provider = null;

            var name = (hint ?? providerToUseFromConfigStore ?? string.Empty).ToLower();
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (name == "mock")
            {
                provider = new MockProvider();
            }
            else if (name == "alt")
            {
                provider = new AlternativeMockProvider(param);
            }
            else
            {
                throw new InvalidOperationException("no");
            }
            return provider;
        }
    }

    [TestFixture]
    public class AbstractFactory
    {
        [SetUp]
        public void Setup()
        {
            Nalarium.AbstractFactory.Set(new MockProviderFactory());
        }

        [Test]
        public void RunFromConfig()
        {
            var provider = Nalarium.AbstractFactory.Resolve<IMockProvider>();
            var result = provider.Execute("hello");

            Assert.AreEqual(result, "hellomock provider");
        }

        [Test]
        public void RunWithOverride()
        {
            var provider = Nalarium.AbstractFactory.Resolve<IMockProvider>("alt", "parameter for alt");
            var result = provider.Execute("hi");

            Assert.AreEqual(result, "hiparameter for altalternative mock provider");
        }

        [TearDown]
        public void Cleanup()
        {
            Nalarium.AbstractFactory.Remove<IMockProvider>();
        }
    }
}
