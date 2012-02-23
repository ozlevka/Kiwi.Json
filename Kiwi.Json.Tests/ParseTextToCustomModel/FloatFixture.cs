using NUnit.Framework;

namespace Kiwi.Json.Tests.ParseTextToCustomModel
{
    [TestFixture]
    public class FloatFixture
    {
        [Test]
        public void Float()
        {
            Assert.That(
                JSON.ToObject<float>("123.45e-1"),
                Is.EqualTo(123.45e-1f)
                );
        }
    }
}