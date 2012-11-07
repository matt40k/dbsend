using System;
using NLog;

namespace dbSend.Process
{
    class Reference
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string usrFile;
        private string usrPass;

        private string sftpAddress;
        private string sftpUser;
        private string sftpPass;

        private int maxSegmentSizeInMb;

        private string fileName;
        private string workDir;

        internal string GetWorkDir
        {
            get
            {
                logger.Trace("GET workDir " + workDir);
                return workDir;
            }
        }

        internal string GetFileName
        {
            get
            {
                logger.Trace("GET fileName " + fileName);
                return fileName;
            }
        }
        internal string GetUsrFile
        {
            get
            {
                logger.Trace("GET usrFile " + usrFile);
                return usrFile;
            }
        }
        internal string GetUsrPass
        {
            get
            {
                logger.Trace("GET usrPass " + usrPass);
                return usrPass;
            }
        }

        internal string GetSftpAddress
        {
            get
            {
                logger.Trace("GET GetSftpAddress " + GetSftpAddress);
                return GetSftpAddress;
            }
        }
        internal string GetSftpUser
        {
            get
            {
                logger.Trace("GET sftpUser " + sftpUser);
                return sftpUser;
            }
        }
        internal string GetSftpPass
        {
            get
            {
                logger.Trace("GET sftpPass " + sftpPass);
                return sftpPass;
            }
        }
        internal int GetMaxSegmentSizeInMb
        {
            get
            {
                logger.Trace("GET maxSegmentSizeInMb " + maxSegmentSizeInMb);
                return maxSegmentSizeInMb;
            }
        }


        internal string SetUsrFile
        {
            set
            {
                logger.Trace(value);
                usrFile = value;
            }
        }
        internal string SetPass
        {
            set
            {
                logger.Trace(value);
                usrPass = value;
            }
        }
        internal string SetSftpAddress
        {
            set
            {
                logger.Trace(value);
                sftpAddress = value;
            }
        }
        internal string SetSftpUser
        {
            set
            {
                logger.Trace(value);
                sftpUser = value;
            }
        }
        internal string SetSftpPass
        {
            set
            {
                logger.Trace(value);
                sftpPass = value;
            }
        }
        internal int SetMaxSegmentSizeInMb
        {
            set
            {
                logger.Trace(value);
                maxSegmentSizeInMb = value;
            }
        }
        internal string SetFileName
        {
            set
            {
                logger.Trace(value);
                fileName = value;
            }
        }
        internal string SetWorkDir
        {
            set
            {
                logger.Trace(value);
                workDir = value;
            }
        }
    }
}
