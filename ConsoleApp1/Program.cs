using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace ConsoleApp1
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new GitHubClient(new ProductHeaderValue("TestApp"))
            {
                Credentials = new Credentials(token: "gaga")
            };
            var repository = await client.Repository.Get("M2xAy", "GitPushTest");


            var sb = new StringBuilder("---");
            sb.AppendLine();
            sb.AppendLine($"date: \"2021-05-01\"");
            sb.AppendLine($"date: \"2021-05-01\"");
            sb.AppendLine($"date: \"2021-05-01\"");
            sb.AppendLine($"date: \"2021-05-01\"");
            sb.AppendLine($"date: \"2021-05-01\"");
            sb.AppendLine($"date: \"Last test\"");
            sb.AppendLine();


            //await  client.Repository.Content.CreateFile(
            //    "M2xAy", "GitPushTest", "Test",
            //    new CreateFileRequest($"First commit", sb.ToString(), "Main"));


            //var sha = updateResult.Commit.Sha;

            var fileDetails = await client.Repository.Content.GetAllContentsByRef("M2xAy", "GitPushTest",
                "Test.csv", "main");

            var updateResult = await client.Repository.Content.UpdateFile("M2xAy", "GitPushTest", "Test.csv",
                new UpdateFileRequest("My updated file", sb.ToString(), fileDetails.First().Sha));
          
           

        }
    }
}
