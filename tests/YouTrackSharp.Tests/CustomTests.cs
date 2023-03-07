using Xunit;
using YouTrackSharp.Issues;

namespace YouTrackSharp.Tests
{
    public class CustomTests
    {

        public static Connection Connect()
        {
            return new BearerTokenConnection("https://youtrack.warhorsestudios.cz",
                "perm:Y3Jhc2guaGFuZGxlcg==.NjAtMjU=.ZfUTI02DlxXPzgCd8eSwZNRTeLKSer");
        }

        private static IIssuesService GetIssueService()
        {
            return Connect().CreateIssuesService();
        }

        [Fact]
        public static void TryGetIssue()
        {
            var issueService = GetIssueService();

            var issue = issueService.GetIssue("KCD2-209006").Result;
        }

        [Fact]
        public static void TryCreateIssue()
        {
            var projectName = "TP";

            var issueService = GetIssueService();

            var newIssue = new Issue { Summary = "YoutrackSharpIssue" };

            var result = issueService.CreateIssue(projectName, newIssue).Result;
        }


        [Fact]
        public static void ApplyCommand()
        {
            var issueService = GetIssueService();

            issueService.ApplyCommand("TP-48090", "Type Task").Wait();
        }


        [Fact]
        public static void AddComment()
        {
            var issueService = GetIssueService();

            issueService.AddCommentForIssue("TP-48090", "Some fluffy comment text").Wait();
        }
    }
}