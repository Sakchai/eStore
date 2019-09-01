using System;
using System.Collections.Generic;
using EasyCaching.InMemory;
using QNet.Core.Caching;
using QNet.Tests;
using NUnit.Framework;

namespace QNet.Core.Tests.Caching
{
    [TestFixture]
    public class MemoryCacheManagerTests
    {
        private MemoryCacheManager _cacheManager;

        [SetUp]
        public void Setup()
        {
            _cacheManager = new MemoryCacheManager(new DefaultInMemoryCachingProvider("QNet.tests",
                new List<IInMemoryCaching> {new InMemoryCaching("QNet.tests", new InMemoryCachingOptions())},
                new InMemoryOptions()));
        }

        [Test]
        public void Can_set_and_get_object_from_cache()
        {
            _cacheManager.Set("some_key_1", 3, int.MaxValue);
            _cacheManager.Get("some_key_1", () => 0).ShouldEqual(3);
        }

        [Test]
        public void Can_validate_whetherobject_is_cached()
        {
            _cacheManager.Set("some_key_1", 3, int.MaxValue);
            _cacheManager.Set("some_key_2", 4, int.MaxValue);

            _cacheManager.IsSet("some_key_1").ShouldEqual(true);
            _cacheManager.IsSet("some_key_3").ShouldEqual(false);
        }

        [Test]
        public void Can_clear_cache()
        {
            _cacheManager.Set("some_key_1", 3, int.MaxValue);

            _cacheManager.Clear();

            _cacheManager.IsSet("some_key_1").ShouldEqual(false);
        }

        [Test]
        public void Can_perform_lock()
        {
            const string key = "QNet.Task";
            var expiration = TimeSpan.FromMinutes(2);

            var actionCount = 0;
            var action = new Action(() =>
            {
                _cacheManager.IsSet(key).ShouldBeTrue();

                _cacheManager.PerformActionWithLock(key, expiration,
                    () => Assert.Fail("Action in progress"))
                    .ShouldBeFalse();

                if (++actionCount % 2 == 0)
                    throw new ApplicationException("Alternating actions fail");
            });

            _cacheManager.PerformActionWithLock(key, expiration, action)
                .ShouldBeTrue();
            actionCount.ShouldEqual(1);

            Assert.Throws<ApplicationException>(() =>
                _cacheManager.PerformActionWithLock(key, expiration, action));
            actionCount.ShouldEqual(2);

            _cacheManager.PerformActionWithLock(key, expiration, action)
                .ShouldBeTrue();
            actionCount.ShouldEqual(3);
        }
    }
}
