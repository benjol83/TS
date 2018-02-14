using DataAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace TSTest.Mock
{
    class MockLocalStorage : IStorage
    {
        public static readonly NewIssue mockNewIssue1 = new NewIssue()
            {
                Title = "Issue 1",
                Description = "Description 1",
                Priority = Priority.High,
                Status = Status.InProgress,
                AssignedTo = "Dev 8"
            };

        public static readonly Issue mockIssue1 = new Issue(
                "issueid1", 
                mockNewIssue1
            );

        public static readonly NewIssue mockNewIssue2 = new NewIssue()
            {
                Title = "Issue 2",
                Description = "Description 2",
                Priority = Priority.Low,
                Status = Status.Active,
                AssignedTo = "None"
            };

        public static readonly Issue mockIssue2 = new Issue(
                "issueid2",
                mockNewIssue2
            );

        public static readonly NewIssue mockNewIssue3 = new NewIssue()
            {
                Title = "Issue 3",
                Description = "Description 3",
                Priority = Priority.Low,
                Status = Status.Closed,
                AssignedTo = "Dev 3"
            };

        public static readonly Issue mockIssue3 = new Issue(
                "issueid3",
                mockNewIssue3
            );

        public Func<NewIssue, string> CreateNewIssueImpl;
        public Func<string, bool> DeleteIssueImpl;
        public Func<List<Issue>> GetIssuesImpl;
        public Func<string, Issue> SearchIssueByIdImpl;
        public Func<string, Priority, Status, string, List<Issue>> SearchIssuesImpl;
        public Func<Issue, Issue> UpdateIssueImpl;

        public string CreateIssue(NewIssue newIssue)
        {
            return CreateNewIssueImpl(newIssue);
        }

        public bool DeleteIssue(string id)
        {
            return DeleteIssueImpl(id);
        }

        public List<Issue> GetIssues()
        {
            return GetIssuesImpl();
        }

        public Issue SearchIssueById(string id)
        {
            return SearchIssueByIdImpl(id);
        }

        public List<Issue> SearchIssues(string title, Priority priority, Status status, string assignedTo)
        {
            return SearchIssuesImpl(title, priority, status, assignedTo);
        }

        public Issue UpdateIssue(Issue issue)
        {
            return UpdateIssueImpl(issue);
        }
    }
}
