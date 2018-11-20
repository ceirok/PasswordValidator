using System;
using Xunit;
using PasswordValidator;

namespace PasswordValidator.Test
{
    public class Test
    {
        [Fact]
        public void Should_EvaluateToWeak()
        {
            var password = new PasswordValidator("password");
            var evaluatedPassword = password.EvaluatePwStrength();
            Assert.Equal("Weak", evaluatedPassword);
        }

        [Fact]
        public void Should_EvaluateToAverage()
        {
            var password = new PasswordValidator("password123");
            var evaluatedPassword = password.EvaluatePwStrength();
            Assert.Equal("Average", evaluatedPassword);
        }

        [Fact]
        public void Should_EvaluateToStrong()
        {
            var password = new PasswordValidator("Pass&word123");
            var evaluatedPassword = password.EvaluatePwStrength();
            Assert.Equal("Strong", evaluatedPassword);
        }

        [Fact]
        public void Should_ContainSymbol()
        {
            var password = new PasswordValidator("Pass&word123");
            var evaluatedPassword = password.CheckForSymbol();
            Assert.True(evaluatedPassword);
        }

        [Fact]
        public void Shoul_ContainNumbers()
        {
            var password = new PasswordValidator("Password123");
            var password2 = new PasswordValidator("Password");
            var evaluatedPassword = password.CheckForNumber();
            var evaluatedPassword2 = password2.CheckForNumber();
            Assert.True(evaluatedPassword);
            Assert.False(evaluatedPassword2);
        }
    }
}
