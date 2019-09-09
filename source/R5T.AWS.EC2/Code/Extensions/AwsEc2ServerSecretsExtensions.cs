using System;

using R5T.AWS.EC2.Configuration;
using R5T.NetStandard.SSH;


namespace R5T.AWS.EC2
{
    public static class AwsEc2ServerSecretsExtensions
    {
        public static SftpClientWrapper GetSftpClientWrapper(this AwsEc2ServerSecrets awsEc2ServerSecrets)
        {
            var client = new SftpClientWrapper(
                awsEc2ServerSecrets.Host,
                awsEc2ServerSecrets.UserID,
                awsEc2ServerSecrets.Password,
                awsEc2ServerSecrets.PrivateKeyFilePath);
            return client;
        }
    }
}
