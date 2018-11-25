using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace StratisTipbot
{
    public static class CredentialsRetrieval
    {
        public static async Task<ConnectionCredentials> GetCredentialsAsync()
        {
            var lines = await File.ReadAllLinesAsync("credentials.auth");
            return new ConnectionCredentials(lines[0], lines[1]);
        }
    }
}
