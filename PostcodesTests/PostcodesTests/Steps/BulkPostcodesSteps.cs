using FluentAssertions;
using NUnit.Framework;
using PostcodesTests.Models;
using PostcodesTests.Setup;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using TechTalk.SpecFlow;

namespace PostcodesTests.Steps
{
    [Binding, Scope(Feature = "Bulk Postcodes")]
    public sealed class BulkPostcodesSteps
    {

        private IRestResponse _getResponse;

        public BulkPostcodesSteps()
        {

        }


        [Given(@"I send a request")]
        public void GivenISendARequest()
        {
            Postcode postcode = new Postcode()
            {

            };
            postcode.postcodes = new List<String>();
            postcode.postcodes.Add("NW10 9TE");
            postcode.postcodes.Add("NW3 2EG");

            _getResponse = new HttpSetup().SetMethod(Method.POST).SetResource("postcodes/").AddJsonContent(postcode).Execute();
 

        }

        [Then(@"I get a response")]
        public void ThenIGetAResponse()
        {
            _getResponse.Should().NotBeNull();
        }


    }
}
