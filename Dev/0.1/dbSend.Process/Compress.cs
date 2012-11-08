using System;
using System.IO;
using Ionic.Zip;
using NLog;

namespace dbSend.Process
{
    internal class Compress
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Reference reference;

        internal Compress(Reference ref1)
        {
            reference = ref1;
        }

        internal bool DoIt
        {
            get
            {
                try
                {
                    string fileName = Path.Combine(reference.GetWorkDir, (reference.GetFileName + ".zip"));
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.Password = reference.GetUsrPass;
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.AddFile(reference.GetUsrFile, "dbSend");
                        zip.MaxOutputSegmentSize = reference.GetMaxSegmentSizeInMb * 1024 * 1024;
                        zip.Comment = "Compressed and send using dbSend";
                        zip.Save(fileName);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return false;
                }
                return true;
            }
        }
    }
}
