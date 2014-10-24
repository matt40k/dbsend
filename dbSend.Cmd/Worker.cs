using System;
using NLog;
using dbSend.Process;

namespace dbSend.Cmd
{
    class Worker
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Reference reference;

        internal Worker(Reference ref1)
        {
            reference = ref1;
        }

        internal bool DoIt
        {
            get
            {
                string _name = reference.GetName;
                string _file = reference.GetFile;
                string _password = reference.GetPassword;
                string _sftpuser = reference.GetSftpUser;
                string _sftppass = reference.GetSftpPass;
                string _sftpaddress = reference.GetSftpAddress;

                // Invoke dbSend class
                Entry entry = new Entry();

                // Set source file
                if (string.IsNullOrWhiteSpace(_file))
                {
                    logger.Error("Filename is not set");
                    return false;
                }
                else
                {
                    if (!entry.SetUploadFile(_file)) { return false; }
                }

                // Set name
                if (string.IsNullOrWhiteSpace(_name))
                {
                    _name = entry.GetFileName;
                    Console.WriteLine("Name: " + _name);
                }
                if (!entry.SetFileName(_name)) { return false; }

                // Set password (generate if required)
                if (string.IsNullOrWhiteSpace(_password))
                {
                    _password = entry.GetRandomPassword;
                    Console.WriteLine("Password: " + _password);
                }
                else
                {
                    if (!entry.SetPassword(_password)) { return false; }
                }
                
                // Set SFTP details
                if (
                        string.IsNullOrWhiteSpace(_sftpuser) ||
                        string.IsNullOrWhiteSpace(_sftppass) ||
                        string.IsNullOrWhiteSpace(_sftpaddress)
                   )
                {
                    logger.Error("SFTP settings not complete!");
                    Console.WriteLine("ERROR: SFTP settings not complete!");
                    
                    return false; }
                
                if (!entry.SetSftpUser(_sftpuser)) { return false; }
                if (!entry.SetSftpPass(_sftppass)) { return false; }
                if (!entry.SetSftpAddress(_sftpaddress)) { return false; }

                return entry.DoIt;
            }
        }
    }
}
