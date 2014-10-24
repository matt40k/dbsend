using System;
using NLog;

namespace dbSend.Cmd
{
    internal class Reference
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string _file;
        private string _name;
        private string _password;
        private string _sftpuser;
        private string _sftppass;
        private string _sftpaddress;

        internal string GetFile { get { return _file; } }
        internal string GetName { get { return _name; } }
        internal string GetPassword { get { return _password; } }
        internal string GetSftpUser { get { return _sftpuser; } }
        internal string GetSftpPass { get { return _sftppass; } }
        internal string GetSftpAddress { get { return _sftpaddress; } }

        internal string SetFile { set { _file = value; } }
        internal string SetName { set { _name = value; } }
        internal string SetPassword { set { _password = value; } }
        internal string SetSftpUser { set { _sftpuser = value; } }
        internal string SetSftpPass { set { _sftppass = value; } }
        internal string SetSftpAddress { set { _sftpaddress = value; } }
    }
}
