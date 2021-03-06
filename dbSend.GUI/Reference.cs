﻿using dbSend.Process;

namespace dbSend.GUI
{
    public class Reference
    {
        private readonly Entry entry;

        public Reference()
        {
            entry = new Entry();
        }

        internal string SetFileName
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    entry.SetUploadFile(value);
                }
            }
        }

        internal string GetName
        {
            get { return entry.GetFileName; }
        }

        internal string SetName
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    entry.SetFileName(value);
                }
            }
        }

        internal string GetPassword
        {
            get { return entry.GetRandomPassword; }
        }

        internal string SetPassword
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    entry.SetPassword(value);
                }
            }
        }

        internal bool IsSftpConnectionOk
        {
            get { return entry.TestSftp; }
        }

        internal bool DoIt
        {
            get { return entry.DoIt; }
        }

        internal bool SetSftpUser(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return entry.SetSftpUser(value);
            }
            return false;
        }

        internal bool SetSftpPass(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return entry.SetSftpPass(value);
            }
            return false;
        }

        internal bool SetSftpAddress(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return entry.SetSftpAddress(value);
            }
            return false;
        }
    }
}