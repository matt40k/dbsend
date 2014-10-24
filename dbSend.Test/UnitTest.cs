using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dbSend.Process;

namespace dbSend.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetRandomPassword()
        {
            Entry entry = new Entry();
            string passWord = entry.GetRandomPassword;
            Assert.IsNotNull(passWord);
        }

        [TestMethod]
        public void Null_FileName_Fails()
        {
            string fileName = "";
            Entry entry = new Entry();
            Assert.IsFalse(entry.SetFileName(fileName));
        }

        [TestMethod]
        public void Null_File_Fails()
        {
            string file = "";
            Entry entry = new Entry();
            Assert.IsFalse(entry.SetUploadFile(file));
        }
    }
}
