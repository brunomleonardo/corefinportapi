using api.coreapi.Controllers;
using dal.apifinport.Context;
using dal.apifinport.Interfaces;
using entities.apifinport.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace pjtest.apifinport
{
    public class TickerControllerTest
    {
        protected TickersController ControllerUnderTest { get; }
        protected Mock<ITickerService> TickerServiceMock { get; }
        protected FinPortContext context { get;  }

        public TickerControllerTest()
        {
            TickerServiceMock = new Mock<ITickerService>();
            ControllerUnderTest = new TickersController(context, TickerServiceMock.Object);
        }

        public class ReadByAbbvAsync: TickerControllerTest
        {
            [Fact]
            public async void Should_return_by_abbv_and_statusOk()
            {
                ////Arrange
                //var excpetedTickers = new string[]
                //{
                //    "APPF",
                //    "APPN",
                //    "APPS",
                //};
                //TickerServiceMock
                //    .Setup(x => x.ReadByAbbvAsync("app"))
                //    .ReturnsAsync(excpetedTickers);
                ////Act
                //var result = await ControllerUnderTest.ReadByAbbv("app");

                ////Assert
                //var okResult = Assert.IsType<OkObjectResult>(result);
                //Assert.Same(excpetedTickers, okResult.Value);


            }
        }
    }
}
