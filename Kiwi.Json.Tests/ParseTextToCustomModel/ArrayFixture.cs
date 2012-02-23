﻿using System.Collections.Generic;
using NUnit.Framework;

namespace Kiwi.Json.Tests.ParseTextToCustomModel
{
    [TestFixture]
    public class ArrayFixture
    {
        public class SublassedList<T> : List<T>
        {
        }

        [Test]
        public void AbstractEnumerable()
        {
            var list = JSON.ToObject<IEnumerable<int>>(@"[1,2,3]");

            Assert.That(new[] {1, 2, 3}, Is.EqualTo(list));
        }

        [Test]
        public void AbstractList()
        {
            var list = JSON.ToObject<IList<int>>(@"[1,2,3]");

            Assert.That(new[] {1, 2, 3}, Is.EqualTo(list));
        }

        [Test]
        public void Array()
        {
            var array = JSON.ToObject<int[]>(@"[1,2,3]");

            Assert.That(new[] {1, 2, 3}, Is.EqualTo(array));
        }

        [Test]
        public void List()
        {
            var list = JSON.ToObject<List<int>>(@"[1,2,3]");

            Assert.That(new[] {1, 2, 3}, Is.EqualTo(list));
        }

        [Test]
        public void Null()
        {
            var array = JSON.ToObject<int[]>(@"null");

            Assert.That(array, Is.Null);
        }

        [Test]
        public void SubclassedList()
        {
            var list = JSON.ToObject<SublassedList<int>>(@"[1,2,3]");

            Assert.That(new[] {1, 2, 3}, Is.EqualTo(list));
        }
    }
}