using NUnit.Framework;

namespace Nalarium.Test
{
    [TestFixture]
    public class Parser
    {
        [Test]
        public void ParseBoolean()
        {
            Assert.IsTrue(Nalarium.Parser.ParseBoolean(1));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("1"));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("1.0"));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("true"));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("True"));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("active"));
            Assert.IsTrue(Nalarium.Parser.ParseBoolean("on"));
            Assert.IsFalse(Nalarium.Parser.ParseBoolean("12"));
            Assert.IsFalse(Nalarium.Parser.ParseBoolean(12));
        }

        [Test]
        public void ParseByte()
        {
            Assert.AreEqual((byte)1, Nalarium.Parser.ParseByte(1));
            Assert.AreEqual((byte)1, Nalarium.Parser.ParseByte("1"));
            Assert.AreEqual((byte)0, Nalarium.Parser.ParseByte(null));
            Assert.AreEqual((byte)0, Nalarium.Parser.ParseByte("burrito"));
        }

        [Test]
        public void ParseDateTime()
        {
            Assert.AreEqual("2/3/2010 12:00:00 AM", Nalarium.Parser.ParseDateTime("2010-02-03").ToString());
        }

        [Test]
        public void ParseDouble()
        {
            Assert.AreEqual(1d, Nalarium.Parser.ParseDouble(1));
            Assert.AreEqual(1d, Nalarium.Parser.ParseDouble("1"));
            Assert.AreEqual(0d, Nalarium.Parser.ParseDouble(null));
            Assert.AreEqual(0d, Nalarium.Parser.ParseDouble("burrito"));
        }

        [Test]
        public void ParseInt32()
        {
            Assert.AreEqual(1, Nalarium.Parser.ParseInt32(1));
            Assert.AreEqual(1, Nalarium.Parser.ParseInt32("1"));
            Assert.AreEqual(0, Nalarium.Parser.ParseInt32(null));
            Assert.AreEqual(0d, Nalarium.Parser.ParseInt32("burrito"));
        }


        [Test]
        public void ParseInt64()
        {
            Assert.AreEqual(1L, Nalarium.Parser.ParseInt64(1));
            Assert.AreEqual(1L, Nalarium.Parser.ParseInt64("1"));
            Assert.AreEqual(0L, Nalarium.Parser.ParseInt64(null));
            Assert.AreEqual(0L, Nalarium.Parser.ParseInt64("burrito"));
        }

        [Test]
        public void ParseSingle()
        {
            Assert.AreEqual(1f, Nalarium.Parser.ParseSingle(1));
            Assert.AreEqual(1f, Nalarium.Parser.ParseSingle("1"));
            Assert.AreEqual(0f, Nalarium.Parser.ParseSingle(null));
            Assert.AreEqual(0f, Nalarium.Parser.ParseSingle("burrito"));
        }

        [Test]
        public void ParseString()
        {
            Assert.AreEqual("1", Nalarium.Parser.ParseString(1));
            Assert.AreEqual(string.Empty, Nalarium.Parser.ParseString(null));
        }

        [Test]
        public void ParseUInt16()
        {
            Assert.AreEqual((ushort)1, Nalarium.Parser.ParseUInt16(1));
            Assert.AreEqual((ushort)1, Nalarium.Parser.ParseUInt16("1"));
            Assert.AreEqual((ushort)0, Nalarium.Parser.ParseUInt16(null));
            Assert.AreEqual((ushort)0, Nalarium.Parser.ParseInt64("burrito"));
        }

        [Test]
        public void ParseUInt32()
        {
            Assert.AreEqual((uint)1, Nalarium.Parser.ParseUInt32(1));
            Assert.AreEqual((uint)1, Nalarium.Parser.ParseUInt32("1"));
            Assert.AreEqual((uint)0, Nalarium.Parser.ParseUInt32(null));
            Assert.AreEqual((uint)0, Nalarium.Parser.ParseUInt32("burrito"));
        }

        [Test]
        public void ParseUInt64()
        {
            Assert.AreEqual((ulong)1, Nalarium.Parser.ParseUInt64(1));
            Assert.AreEqual((ulong)1, Nalarium.Parser.ParseUInt64("1"));
            Assert.AreEqual((ulong)0, Nalarium.Parser.ParseUInt64(null));
            Assert.AreEqual((ulong)0, Nalarium.Parser.ParseUInt64("burrito"));
        }

        [Test]
        public void ParseMaxString()
        {
            Assert.AreEqual("asdfasdfasdf", Nalarium.Parser.ParseMaxString("asdfasdfasdf"));
            Assert.AreEqual("this is my default", Nalarium.Parser.ParseMaxString(null, "this is my default"));
            Assert.AreEqual("asdfa", Nalarium.Parser.ParseMaxString("asdfasdfasdf", max: 5));
        }

        [Test]
        public void ParseGenericInt32()
        {
            Assert.AreEqual(12, Nalarium.Parser.Parse<int>("12"));
            Assert.AreEqual(0, Nalarium.Parser.Parse<int>("burrito"));
        }
    }
}