using System;
using NUnit.Framework;

namespace ModTest
{
        [TestFixture]
        public class MyIntTest
        {
            [Test]
            public void testCreate()
            {
                Assert.AreEqual((new MyInt(123)).ToString(), "123");
                Assert.AreEqual((new MyInt(123)).longValue(), 123);

                Assert.AreEqual((new MyInt(-123)).ToString(), "-123");
                Assert.AreEqual((new MyInt(-123)).longValue(), -123);

                Assert.AreEqual((new MyInt("123")).ToString(), "123");
                Assert.AreEqual((new MyInt("123")).longValue(), 123);

                Assert.AreEqual((new MyInt("-123")).ToString(), "-123");
                Assert.AreEqual((new MyInt("-123")).longValue(), -123);

                Assert.AreEqual((new MyInt(new byte[] { 0, 1, 2, 3 })).ToString(), "123");
                Assert.AreEqual((new MyInt(new byte[] { 0, 1, 2, 3 })).longValue(), 123);

                Assert.AreEqual((new MyInt(new byte[] { 1, 1, 2, 3 })).ToString(), "-123");
                Assert.AreEqual((new MyInt(new byte[] { 1, 1, 2, 3 })).longValue(), -123);

                Assert.AreEqual((new MyInt(0)).ToString(), "0");
                Assert.AreEqual((new MyInt(0)).longValue(), 0);

                Assert.AreEqual((new MyInt(-0)).ToString(), "0");
                Assert.AreEqual((new MyInt(-0)).longValue(), 0);

                Assert.AreEqual((new MyInt("0")).ToString(), "0");
                Assert.AreEqual((new MyInt("0")).longValue(), 0);

                Assert.AreEqual((new MyInt("-0")).ToString(), "0");
                Assert.AreEqual((new MyInt("-0")).longValue(), 0);

                Assert.AreEqual((new MyInt(new byte[] { 0, 0 })).ToString(), "0");
                Assert.AreEqual((new MyInt(new byte[] { 0, 0 })).longValue(), 0);

                Assert.AreEqual((new MyInt(new byte[] { 1, 0 })).ToString(), "0");
                Assert.AreEqual((new MyInt(new byte[] { 1, 0 })).longValue(), 0);
            }

            [Test]
            public void testCompareTo()
            {
                Assert.IsTrue((new MyInt(new byte[] { 1, 1, 2 })).compareTo(new MyInt(-12)));
                Assert.IsTrue((new MyInt("-0")).compareTo(new MyInt(new byte[] { 0, 0, 0, 0 })));
                Assert.IsTrue((new MyInt(4213)).compareTo(new MyInt("04213")));
                Assert.IsFalse((new MyInt(130)).compareTo(new MyInt(new byte[] { 1, 1, 3, 0 })));
            }

            [Test]
            public void testAbs()
            {
                Assert.AreEqual((new MyInt(new byte[] { 1, 1, 3 })).abs().longValue(), 13);
                Assert.AreEqual((new MyInt("-0250")).abs().longValue(), 250);
                Assert.AreEqual((new MyInt(520)).abs().longValue(), 520);
                Assert.AreEqual((new MyInt("-12")).abs().longValue(), 12);
            }

            [Test]
            public void testMaxMin()
            {
                MyInt a = new MyInt(200);
                MyInt b = new MyInt(199);
                MyInt c = new MyInt("201");
                MyInt d = new MyInt(-200);

                Assert.AreEqual(b.max(a), a.max(b));
                Assert.AreEqual(a.max(b), a);
                Assert.AreEqual(c.max(a), c);
                Assert.AreEqual(c.max(b), c);
                Assert.AreEqual(b.max(d), b);
                Assert.AreEqual(c.max(c), c);

                Assert.AreEqual(b.min(d), d.min(b));
                Assert.AreEqual(a.min(b), b);
                Assert.AreEqual(a.min(c), a);
                Assert.AreEqual(d.min(a), d);
                Assert.AreEqual(c.min(d), d);
                Assert.AreEqual(c.min(c), c);
            }

            [Test]
            public void testAdd()
            {
                MyInt a = new MyInt(549);
                MyInt b = new MyInt(475);

                Assert.AreEqual(a.add(b).longValue(), 1024);

                MyInt c = new MyInt("10000003454");

                Assert.AreEqual(b.add(c).ToString(), "10000003929");

                MyInt d = new MyInt(-500);
                Assert.AreEqual(d.add(a).longValue(), 49);

                Assert.AreEqual(d.add(b).longValue(), -25);

                Assert.AreEqual((new MyInt(0)).add(new MyInt(-0)).longValue(), 0);

                MyInt e = new MyInt(-3554);
                Assert.AreEqual(c.add(e).ToString(), "9999999900");

                Assert.AreEqual(e.add(d).longValue(), -4054);
            }

            [Test]
            public void testSubstract()
            {
                MyInt a = new MyInt(678);
                MyInt b = new MyInt(1250);
                MyInt c = new MyInt(-3535);
                MyInt d = new MyInt(-4000);

                Assert.AreEqual(a.substract(b).longValue(), -572);
                Assert.AreEqual(b.substract(a).longValue(), 572);
                Assert.AreEqual(c.substract(b).longValue(), -4785);
                Assert.AreEqual(b.substract(c).longValue(), 4785);
                Assert.AreEqual(d.substract(c).longValue(), -465);
                Assert.AreEqual(c.substract(d).longValue(), 465);
            }

            [Test]
            public void testMultiply()
            {
                MyInt a = new MyInt(456);
                MyInt b = new MyInt(4356);
                MyInt c = new MyInt(-5493);
                MyInt d = new MyInt(-3205);

                Assert.AreEqual(a.multiply(b).longValue(), 1986336);
                Assert.AreEqual(b.multiply(c).longValue(), -23927508);
                Assert.AreEqual(c.multiply(d).longValue(), 17605065);
            }

            [Test]
            public void testDivide()
            {
                MyInt a = new MyInt(15760);
                MyInt b = new MyInt(30);
                MyInt c = new MyInt(-3056);
                MyInt d = new MyInt(0);
                MyInt e = new MyInt(-1);
                MyInt f = new MyInt(-50530);

                Assert.AreEqual(a.divide(b).longValue(), 525);
                Assert.AreEqual(b.divide(a).longValue(), 0);
                Assert.AreEqual(d.divide(e).longValue(), 0);
                Assert.AreEqual(c.divide(d).longValue(), 0);
                Assert.AreEqual(c.divide(c).longValue(), 1);
                Assert.AreEqual(f.divide(c).longValue(), 16);
                Assert.AreEqual(a.divide(c).longValue(), -5);

            }

            [Test]
            public void testGcd()
            {
                MyInt a = new MyInt(32);
                MyInt b = new MyInt(170);
                MyInt c = new MyInt(17);
                MyInt d = new MyInt(-50);
                MyInt f = new MyInt(-1);
                MyInt e = new MyInt(1);
                MyInt g = new MyInt(0);
                MyInt h = new MyInt(15);

                Assert.AreEqual(b.gcd(c).longValue(), 17);
                Assert.AreEqual(a.gcd(c).longValue(), 1);
                Assert.AreEqual(b.gcd(d).longValue(), 10);
                Assert.AreEqual(c.gcd(f).longValue(), 1);
                Assert.AreEqual(d.gcd(h).longValue(), 5);
                Assert.AreEqual(b.gcd(b).longValue(), 170);
                Assert.AreEqual(b.gcd(b.abs()).longValue(), 170);
                Assert.AreEqual(f.gcd(f).longValue(), 1);
                Assert.AreEqual(g.gcd(e).longValue(), 1);
            }
        }
    }


