using Kiwi.Json.Conversion;
using NUnit.Framework;
using SharpTestsEx;

namespace Kiwi.Json.Tests.ParseTextToCustomModel
{
    [TestFixture]
    public class ApplicationModelFixture
    {
        private const string SampleJsonText =
            @"
                    {
                        ""Title"": ""Sample blog"",
                        ""Content"": ""Hello world"",
                        ""Tags"": [""test"",""json""]
                    }";

        public class Blog
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string[] Tags { get; set; }
        }
        public class BlogContentOnly
        {
            public string Content { get; set; }
        }

        public class BlogTagsOnly
        {
            public string[] Tags { get; set; }

        }

        [Test]
        public void ParseFullObject()
        {
            var blog = JsonConvert.Parse<Blog>(SampleJsonText);

            blog.Should().Not.Be.Null();

            blog.Title.Should().Be.EqualTo("Sample blog");
            blog.Content.Should().Be.EqualTo("Hello world");
            blog.Tags.Should().Have.SameSequenceAs(new[] {"test", "json"});
        }

        [Test]
        public void ParsePartialObject1()
        {
            var blog = JsonConvert.Parse<BlogContentOnly>(SampleJsonText);

            blog.Should().Not.Be.Null();

            blog.Content.Should().Be.EqualTo("Hello world");

        }

        [Test]
        public void ParsePartialObject2()
        {
            var blog = JsonConvert.Parse<BlogTagsOnly>(SampleJsonText);

            blog.Should().Not.Be.Null();
            blog.Tags.Should().Have.SameSequenceAs(new[] { "test", "json" });
        }

        [Test]
        public void ParseNull()
        {
            JsonConvert.Parse<Blog>("null")
                .Should().Be.Null();
        }
    }
}