using System;
using System.IO;
using NLog;

namespace dbSend.Process
{
    public class Entry
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Reference reference;

        public Entry()
        {
            reference = new Reference();

            SetMaxSegSizeInMb();
            SetWorkDir();
        }

        public bool TestSftp
        {
            get
            {
                var transmit = new Transmit(reference);
                return transmit.CheckConnection;
            }
        }

        public bool DoIt
        {
            get
            {
                // Add some (more) checking of reference data

                var compress = new Compress(reference);
                if (!compress.DoIt)
                {
                    logger.Error("Compression failed");
                    return false;
                }

                var transmit = new Transmit(reference);
                if (!transmit.DoIt)
                {
                    logger.Error("Upload failed");
                    return false;
                }

                return true;
            }
        }

        public string GetRandomPassword
        {
            get
            {
                var ranPass = Randomizor.PasswordGenerator;
                reference.SetPass = ranPass;
                return ranPass;
            }
        }

        public string GetFileName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(reference.GetFileName))
                {
                    reference.SetFileName = Path.GetFileNameWithoutExtension(reference.GetUsrFile);
                }
                return reference.GetFileName;
            }
        }

        private void SetMaxSegSizeInMb()
        {
            reference.SetMaxSegmentSizeInMb = 10;
        }

        private void SetWorkDir()
        {
            var tmpDir = Path.GetTempPath();
            var tWorkDir = Path.Combine(tmpDir, "dbSend");
            if (Directory.Exists(tWorkDir))
            {
                try
                {
                    Directory.Delete(tWorkDir, true);
                }
                catch (Exception ex1)
                {
                    logger.Error("ERROR DELETING " + tWorkDir);
                    logger.Error(ex1);
                }
            }
            try
            {
                Directory.CreateDirectory(tWorkDir);
            }
            catch (Exception ex2)
            {
                logger.Error("ERROR CREATING " + tWorkDir);
                logger.Error(ex2);
            }
            reference.SetWorkDir = tWorkDir;
        }

        public bool SetUploadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                reference.SetUsrFile = fileName;
                return true;
            }
            logger.Error("FileDoesNotExist: " + fileName);
            return false;
        }

        public bool SetFileName(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                reference.SetFileName = fileName;
                return true;
            }
            logger.Error("Filename entered is Null");
            return false;
        }

        public bool SetPassword(string pass)
        {
            if (!string.IsNullOrWhiteSpace(pass))
            {
                reference.SetPass = pass;
                return true;
            }
            logger.Error("Password entered is Null");
            return false;
        }

        public bool SetSftpUser(string user)
        {
            if (!string.IsNullOrWhiteSpace(user))
            {
                reference.SetSftpUser = user;
                return true;
            }
            logger.Error("SFTP user entered is Null");
            return false;
        }

        public bool SetSftpPass(string pass)
        {
            if (!string.IsNullOrWhiteSpace(pass))
            {
                reference.SetSftpPass = pass;
                return true;
            }
            logger.Error("SFTP password entered is Null");
            return false;
        }

        public bool SetSftpAddress(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                reference.SetSftpAddress = address;
                return true;
            }
            logger.Error("SFTP address entered is Null");
            return false;
        }
    }
}