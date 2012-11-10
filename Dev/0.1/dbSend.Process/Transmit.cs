using System;
using System.IO;
using System.Threading;
using NLog;
using Renci.SshNet;

namespace dbSend.Process
{
    class Transmit
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Reference reference;
        private SftpClient sftp;

        public Transmit(Reference ref1)
        {
            reference = ref1;
            sftp = new SftpClient(reference.GetSftpAddress, 22, reference.GetSftpUser, reference.GetSftpPass);
        }

        public void UpdateSettings()
        {
            sftp = null;
            sftp = sftp = new SftpClient(reference.GetSftpAddress, 22, reference.GetSftpUser, reference.GetSftpPass);
        }

        private string[] getFilesToTransmit
        {
            get
            {
                string _path = reference.GetWorkDir;
                return Directory.GetFiles(_path, "*.z*", SearchOption.TopDirectoryOnly);
            }
        }

        public bool CheckConnection
        {
            get
            {
                try
                {
                    sftp.Connect();
                    sftp.Disconnect();
                }
                catch (Exception ex1)
                {
                    logger.Error(ex1);
                    return false;
                }
                return true;
            }
        }

        private bool uploadFile(string fileToUpload)
        {
            try
            {
                sftp.Connect();
                var mem = File.OpenRead(fileToUpload);
                var asynch = sftp.BeginUploadFile(mem, @"/", true, null, null);
                var sftpASynch = asynch as Renci.SshNet.Sftp.SftpUploadAsyncResult;


                while (!sftpASynch.IsCompleted)
                {
                    //Console.Write(string.Format("Uploaded {0:#########} KB", sftpASynch.UploadedBytes / 1024));
                    Thread.Sleep(100);
                }

                sftp.EndUploadFile(asynch);

                mem.Close();
                sftp.Disconnect();
            }
            catch (Exception ex1)
            {
                logger.Error(ex1);
                return false;
            }
            return true;
        }

        public bool DoIt
        {
            get
            {
                if (!CheckConnection)
                {
                    Console.WriteLine("SFTP Connection failed");
                    return false;
                }

                string[] _files = getFilesToTransmit;

                foreach (string _file in _files)
                {
                    if (uploadFile(_file))
                    {
                        File.Delete(_file);
                    }
                }

                return true;
            }
        }
    }
}
