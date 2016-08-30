using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwdWDecorator.Decorator;

namespace TestApp
{
    [TestClass]
    public class UnitTest1
    {
        private const string testString = "That is decorator sample";

        [TestMethod]
        public void testString_compute_MD5()
        {
            //one time md5 hashing

            MD5Decorator md5 = new MD5Decorator();
            string hashed = md5.Hash(testString);
            Assert.AreEqual(hashed, "f5ef6d6ef75f4bd3a72992b4967efeea");
        }

        [TestMethod]
        public void testString_compute_SHA1()
        {
            //one time sha1 hashing

            SHADecorator sha = new SHADecorator();
            string hashed = sha.Hash(testString);
            Assert.AreEqual(hashed, "9022b3000447d070f44f50f15ba4c723d38a74dc");
        }

        [TestMethod]
        public void testString_compute_1xSHA_1xMD5()
        {
            //one time sha1 hashing
            //and one time md5 from sha1

            SHADecorator sha = new SHADecorator();
            MD5Decorator md5 = new MD5Decorator();
            md5.SetComponent(sha);
            string hashed = md5.Hash(testString);
            Assert.AreEqual(hashed, "b900d870382099b498f94e2fe7038688");
        }

        [TestMethod]
        public void testString_compute_1xSHA_2xMD5_2xSHA_1xMD5()
        {
            //one time sha1 hashing
            //two time md5 from sha1
            //two time sha1 from md5
            //one time sha1 from md5

            SHADecorator sha = new SHADecorator();
            MD5Decorator md5 = new MD5Decorator();
            MD5Decorator md5_1 = new MD5Decorator();
            SHADecorator sha_1 = new SHADecorator();
            SHADecorator sha_2 = new SHADecorator();
            MD5Decorator md5_2 = new MD5Decorator();
            md5.SetComponent(sha);
            md5_1.SetComponent(md5);
            sha_1.SetComponent(md5_1);
            sha_2.SetComponent(sha_1);
            md5_2.SetComponent(sha_2);
            string hashed = md5_2.Hash(testString);
            Assert.AreEqual(hashed, "a49294b40f8845162bfdc8ca4b4a1b14");
        }
    }
}
