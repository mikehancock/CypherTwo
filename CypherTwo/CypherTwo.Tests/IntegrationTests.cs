﻿namespace CypherTwo.Tests
{
    using System;
    using System.Net.Http;

    using CypherTwo.Core;

    using NUnit.Framework;

    [TestFixture]
    public class IntegrationTests
    {
        private INeoClient neoClient;

        private ISendRestCommandsToNeo neoApi;

        private IJsonHttpClientWrapper httpClientWrapper;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            this.httpClientWrapper = new JsonHttpClientWrapper(new HttpClient());
            this.neoApi = new NeoRestApiClient(this.httpClientWrapper, "http://localhost:7474/");
            this.neoClient = new NeoClient(this.neoApi);
            this.neoClient.Initialise();
        }

        [Test]
        public void InitialiseThrowsExecptionWithInvalidUrl()
        {
            this.neoApi = new NeoRestApiClient(this.httpClientWrapper, "http://localhost:1111/");
            this.neoClient = new NeoClient(this.neoApi);
            Assert.Throws<InvalidOperationException>(() => this.neoClient.Initialise());
        }
    }
}