using System.Reflection;
using System.Text;
using NetArchTest.Rules;
using Northwind.WebUI;
using Xunit;

namespace Solution.ArchitectureTests
{
    public class WebUIArchitectureTests
    {
        private static Assembly WebUiAssembly => typeof(Startup).Assembly;
        
        [Fact]
        public void Controllers_MustHaveNameEndingInController()
        {
            var result = Types.InAssembly(WebUiAssembly)
                .That()
                .ResideInNamespace("Northwind.WebUI.Controllers")
                .And().AreClasses()
                .And().AreNotAbstract()
                .Should().HaveNameEndingWith("Controller")
                .GetResult();
            
            Assert.True(result.IsSuccessful, GetErrorMessage(result));
        }
        
        [Fact]
        public void Controllers_MustNotDependOnInfrastructure()
        {
            var result = Types.InAssembly(WebUiAssembly)
                .That()
                .ResideInNamespace("Northwind.WebUI.Controllers")
                .ShouldNot()
                .HaveDependencyOn("Northwind.Infrastructure")
                .GetResult();
            
            Assert.True(result.IsSuccessful, GetErrorMessage(result));
        }
        
        [Fact]
        public void Controllers_MustNotDependOnPersistence()
        {
            var result = Types.InAssembly(WebUiAssembly)
                .That()
                .ResideInNamespace("Northwind.WebUI.Controllers")
                .ShouldNot()
                .HaveDependencyOn("Northwind.Persistence")
                .GetResult();
            
            Assert.True(result.IsSuccessful, GetErrorMessage(result));
        }
        
        [Fact]
        public void Controllers_MustNotDependOnDomain()
        {
            var result = Types.InAssembly(WebUiAssembly)
                .That()
                .ResideInNamespace("Northwind.WebUI.Controllers")
                .ShouldNot()
                .HaveDependencyOn("Northwind.Domain")
                .GetResult();
            
            Assert.True(result.IsSuccessful, GetErrorMessage(result));
        }

        private static string GetErrorMessage(TestResult result)
        {
            if (result.IsSuccessful)
            {
                return string.Empty;
            }
            
            var builder = new StringBuilder();
            builder.AppendLine("Failing types:");

            foreach (var typeName in result.FailingTypeNames)
            {
                builder.AppendLine($"  - {typeName}");
            }

            return builder.ToString();

        }
    }
}