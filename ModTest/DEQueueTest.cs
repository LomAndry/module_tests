using NUnit.Framework;

namespace ModTest
{
    class DEQueueTest
    {
        DEQueue<string> q;

        [SetUp]
        public void init()
        {
            q = new DEQueue<string>();
        }

        [Test]
        public void checkEmptyQueue()
        {
            Assert.IsNull(q.back());
            Assert.IsNull(q.front());
            Assert.IsNull(q.popBack());
            Assert.IsNull(q.popFront());
        }

        [Test]
        public void checkPush()
        {
            q.pushFront("1");
            Assert.AreEqual(q.front(), "1");
            Assert.AreEqual(q.back(), "1");

            q.pushFront("2");
            Assert.AreEqual(q.front(), "2");
            Assert.AreEqual(q.back(), "1");

            q.pushBack("3");
            Assert.AreEqual(q.front(), "2");
            Assert.AreEqual(q.back(), "3");
        }

        [Test]
        public void checkPop()
        {
            q.pushBack("1");
            q.pushBack("2");
            q.pushBack("3");

            Assert.AreEqual(q.popFront(), "1");
            Assert.AreEqual(q.popBack(), "3");
            Assert.AreEqual(q.popFront(), "2");
        }

        [Test]
        public void checkSize()
        {
            Assert.AreEqual(q.size(), 0);

            q.pushBack("1");
            q.pushBack("2");
            q.pushBack("3");

            Assert.AreEqual(q.size(), 3);
            q.pushFront("4");
            Assert.AreEqual(q.size(), 4);
            q.popBack();
            Assert.AreEqual(q.size(), 3);
            q.popFront();
            Assert.AreEqual(q.size(), 2);
        }

        [Test]
        public void checkClear()
        {
            q.pushBack("1");
            q.pushFront("2");

            Assert.AreEqual(q.front(), "2");
            Assert.AreEqual(q.back(), "1");
            Assert.AreEqual(q.size(), 2);

            q.clear();

            Assert.IsNull(q.front());
            Assert.IsNull(q.back());
            Assert.AreEqual(q.size(), 0);
        }

        [Test]
        public void checkToArray()
        {
            q.pushBack("1");
            q.pushBack("2");

            Assert.AreEqual(q.toArray(), new string[] { "1", "2" });

            q.popBack();

            q.pushFront("3");

            q.pushBack("4");

            Assert.AreEqual(q.toArray(), new string[] { "3", "1", "4" });

            q.clear();

            Assert.AreEqual(q.toArray(), new string[] { });
        }
    }
}
