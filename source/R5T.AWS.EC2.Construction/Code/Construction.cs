using System;

using Microsoft.Extensions.Configuration;

using R5T.AWS.EC2.Configuration;


namespace R5T.AWS.EC2.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            Construction.TryConnectToAwsEc2Host();
        }

        private static void TryConnectToAwsEc2Host()
        {
            var configuration = new ConfigurationBuilder()
                .AddAwsEc2ServerSecretsJsonFile()
                .Build();

            var awsEc2ServerSecrets = configuration.GetSection(nameof(AwsEc2ServerSecrets)).Get<AwsEc2ServerSecrets>();

            using (var client = awsEc2ServerSecrets.GetSftpClientWrapper())
            {
                client.SftpClient.Connect();

                var workingDirectory = client.SftpClient.WorkingDirectory;

                Console.WriteLine($"Working directory:\n{workingDirectory}");
            }
        }
    }
}
