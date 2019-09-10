using System;

using Renci.SshNet;

using R5T.AWS.EC2.Configuration;
using R5T.NetStandard.SSH;


namespace R5T.AWS.EC2
{
    public static class AwsEc2ServerSecretsExtensions
    {
        public static ConnectionInfo GetConnectionInfo(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var connectionInfo = Utilities.GetConnectionInfo(
                awsEc2ServerSecrets.Host,
                awsEc2ServerSecrets.UserID,
                awsEc2ServerSecrets.Password,
                awsEc2ServerSecrets.PrivateKeyFilePath);
            return connectionInfo;
        }

        /// <summary>
        /// Gets a <see cref="SftpClientWrapper"/> for which the Connect() method has NOT been called.
        /// </summary>
        public static SftpClientWrapper GetUnconnectedSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var connectionInfo = awsEc2ServerSecrets.GetConnectionInfo();

            var clientWrapper = new SftpClientWrapper(connectionInfo);
            return clientWrapper;
        }

        /// <summary>
        /// Gets a connected <see cref="SftpClientWrapper"/>.
        /// </summary>
        public static SftpClientWrapper GetSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var clientWrapper = awsEc2ServerSecrets.GetUnconnectedSftpClientWrapper();

            clientWrapper.SftpClient.Connect();

            return clientWrapper;
        }
    }
}
