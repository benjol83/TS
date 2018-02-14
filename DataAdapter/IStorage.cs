using DataModel;
using System.Collections.Generic;

namespace DataAdapter
{
    public interface IStorage
    {
        //GET
        List<Issue> GetIssues();

        //GET
        List<Issue> SearchIssues(string title, Priority priority, Status status, string assignedTo);

        //GET
        Issue SearchIssueById(string id);

        //POST
        string CreateIssue(NewIssue newIssue);

        //POST
        Issue UpdateIssue(Issue issue);
        
        //DELETE
        bool DeleteIssue(string id);
    }
}
