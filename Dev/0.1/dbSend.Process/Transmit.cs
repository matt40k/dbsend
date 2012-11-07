using System;
using NLog;
using Renci.SshNet;

namespace dbSend.Process
{
    class Transmit
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Reference reference;

        public Transmit(Reference ref1)
        {
            reference = ref1;
        }

        public bool DoIt
        {
            get
            {
                try
                {
                    using (var client = new SftpClient(reference.GetSftpAddress, 22, reference.GetSftpUser, reference.GetSftpPass))
                    {
                        client.Connect();
                        client.Disconnect();
                    }
                }
                catch (Exception ex1)
                {
                    logger.Error(ex1);
                    return false;
                }
                return true;
            }
        }
    }
}
