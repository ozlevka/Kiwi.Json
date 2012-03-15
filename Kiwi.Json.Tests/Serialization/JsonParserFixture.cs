﻿using System;
using Kiwi.Json.Untyped;
using NUnit.Framework;
using SharpTestsEx;

namespace Kiwi.Json.Tests.Serialization
{
    [TestFixture]
    public class JsonParserFixture
    {
        [Test]
        public void Date()
        {
            JsonConvert.Read(@"""2011-09-01T13:59:16""")
                .Should().Be.InstanceOf<IJsonDate>()
                .And.Value.Value.Should().Be.EqualTo(new DateTime(2011, 09, 01, 13, 59, 16));
        }

        [Test]
        public void Double()
        {
            JsonConvert.Read("0.1")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(0.1);

            JsonConvert.Read("1.23")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(1.23);
            JsonConvert.Read("-1.23")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(-1.23);
            JsonConvert.Read("1.23e45")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(1.23e45);
            JsonConvert.Read("-1.23e45")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(-1.23e45);
            JsonConvert.Read("-1.23e-45")
                .Should().Be.InstanceOf<IJsonDouble>()
                .And.Value.Value.Should().Be.EqualTo(-1.23e-45);
        }

        [Test]
        public void Integer()
        {
            JsonConvert.Read("0")
                .Should().Be.InstanceOf<IJsonInteger>()
                .And.Value.Value.Should().Be.EqualTo(0);

            JsonConvert.Read("123")
                .Should().Be.InstanceOf<IJsonInteger>()
                .And.Value.Value.Should().Be.EqualTo(123);

            JsonConvert.Read("-123")
                .Should().Be.InstanceOf<IJsonInteger>()
                .And.Value.Value.Should().Be.EqualTo(-123);
        }

        [Test]
        public void String()
        {
            JsonConvert.Read(@"""hello Json""")
                .Should().Be.InstanceOf<IJsonString>()
                .And.Value.Value.Should().Be.EqualTo("hello Json");

            JsonConvert.Read(@"""\r\n\t\f\""\u1234""")
                .Should().Be.InstanceOf<IJsonString>()
                .And.Value.Value.Should().Be.EqualTo("\r\n\t\f\"\x1234");
        }
    }
}