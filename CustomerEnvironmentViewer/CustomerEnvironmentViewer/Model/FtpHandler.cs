using System;
using System.Collections.Generic;
using System.Linq;
using FluentFTP;

namespace CustomerEnvironmentViewer
{
    public static class FtpHandler
    {

        private const string ROOTDIR = "/home/rostik/CEV/{0}";

        public static List<string> GetServerDirectories(string workingDir)
        {
            FtpListItem[] directoryList;
            string fullDir = string.Format(ROOTDIR, workingDir);

            try
            {
                using (FtpClient client = new FtpClient("supsrv4", "rostik", "rostik"))
                {
                    client.Connect();
                    client.SetWorkingDirectory(fullDir);
                    directoryList = client.GetListing();
                    List<string> directoryCollection = directoryList.Select(x => x.Name).ToList();

                    return directoryCollection;
                }
            }
            catch (FtpException fe) 
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
