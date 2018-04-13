using System;
using System.Linq;
using FluentFTP;

namespace CustomerEnvironmentViewer
{
    public static class FtpHandler
    {
        public static FtpListItem[] GetServerDirectories(string workingDir)
        {
            FtpListItem[] directoryList;

            try
            {
                using (FtpClient client = new FtpClient("ftp.sourcekor.com", "rkrysko@sourcekor.com", "Toy300zx!"))
                {
                    client.Connect();
                    client.SetWorkingDirectory(workingDir);
                    directoryList = client.GetListing();

                    return directoryList;
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
