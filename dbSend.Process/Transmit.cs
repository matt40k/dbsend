using System;
using System.IO;
using System.Threading;
using NLog;
using Renci.SshNet;

namespace dbSend.Process
{
    internal class Transmit
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private SftpClient sftp;
        private readonly Reference reference;

        public Transmit(Reference ref1)
        {
            reference = ref1;
            sftp = new SftpClient(reference.GetSftpAddress, 22, reference.GetSftpUser, reference.GetSftpPass);
        }

        private string[] getFilesToTransmit
        {
            get
            {
                var _path = reference.GetWorkDir;
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

        public bool DoIt
        {
            get
            {
                if (!CheckConnection)
                {
                    Console.WriteLine("SFTP Connection failed");
                    return false;
                }

                var _files = getFilesToTransmit;

                foreach (var _file in _files)
                {
                    logger.Trace("File: " + _file);
                    if (uploadFile(_file))
                    {
                        File.Delete(_file);
                    }
                }

                return true;
            }
        }

        public void UpdateSettings()
        {
            sftp = null;
            sftp = sftp = new SftpClient(reference.GetSftpAddress, 22, reference.GetSftpUser, reference.GetSftpPass);
        }

        private bool uploadFile(string fileToUpload)
        {
            try
            {
                sftp.Connect();
                var mem = File.OpenRead(fileToUpload);

                var asynch = sftp.BeginUploadFile(mem, null, true, null, null);
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
    }
}