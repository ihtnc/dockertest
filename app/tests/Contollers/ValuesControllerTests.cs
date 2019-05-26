using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using dockertest.app.api.Controllers;
using FluentAssertions;

namespace dockertest.app.tests.Controllers
{
    public class ValuesControllerTests
    {
        private readonly ValuesController _controller;

        public ValuesControllerTests()
        {
            _controller = new ValuesController();
        }

        [Fact]
        public void Class_Should_Include_ApiControllerAttribute()
        {
            var t = _controller.GetType();
            t.Should().BeDecoratedWith<ApiControllerAttribute>();
        }
    }
}
