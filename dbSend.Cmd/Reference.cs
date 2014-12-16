namespace dbSend.Cmd
{
    internal class Reference
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        internal string GetFile { get; private set; }
        internal string GetName { get; private set; }
        internal string GetPassword { get; private set; }
        internal string GetSftpUser { get; private set; }
        internal string GetSftpPass { get; private set; }
        internal string GetSftpAddress { get; private set; }

        internal string SetFile
        {
            set { GetFile = value; }
        }

        internal string SetName
        {
            set { GetName = value; }
        }

        internal string SetPassword
        {
            set { GetPassword = value; }
        }

        internal string SetSftpUser
        {
            set { GetSftpUser = value; }
        }

        internal string SetSftpPass
        {
            set { GetSftpPass = value; }
        }

        internal string SetSftpAddress
        {
            set { GetSftpAddress = value; }
        }
    }
}