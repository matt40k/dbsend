﻿using System;

namespace dbSend.Cmd
{
    internal class ReadArgs
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Reference reference;

        internal ReadArgs(Reference ref1)
        {
            reference = ref1;
        }

        internal void Read(string[] args)
        {
            if (args.Length == 0)
            {
            }
            else
            {
                for (var i = 0; i < args.Length; i++)
                {
                    var str = args[i].ToUpper();
                    if (str.StartsWith("/FILE"))
                    {
                        reference.SetFile = GetParameterValue(args, "/FILE");
                    }
                    if (str.StartsWith("/NAME"))
                    {
                        reference.SetName = GetParameterValue(args, "/NAME");
                    }
                    if (str.StartsWith("/PASSWORD"))
                    {
                        reference.SetPassword = GetParameterValue(args, "/PASSWORD");
                    }
                    if (str.StartsWith("/SFTPUSER"))
                    {
                        reference.SetSftpUser = GetParameterValue(args, "/SFTPUSER");
                    }
                    if (str.StartsWith("/SFTPPASS"))
                    {
                        reference.SetSftpPass = GetParameterValue(args, "/SFTPPASS");
                    }
                    if (str.StartsWith("/SFTPADDRESS"))
                    {
                        reference.SetSftpAddress = GetParameterValue(args, "/SFTPADDRESS");
                    }
                }
            }
        }

        private string GetParameterValue(string[] commandParameters, string parameterName)
        {
            try
            {
                for (var i = 0; i < commandParameters.Length; i++)
                {
                    var str = commandParameters[i];
                    if (str.ToUpper().StartsWith(parameterName.ToUpper()))
                    {
                        if (parameterName == str)
                        {
                            return "";
                        }
                        return str.Substring(parameterName.Length + 1);
                    }
                }
            }
            catch (Exception er1)
            {
                logger.Error(er1);
            }
            return "";
        }
    }
}