using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public enum Priority
    {
        Any,    // 0
        Low,    // 1
        Medium, // 2
        High    // 3
    }

    public enum Status
    {
        Any,        // 0
        Active,     // 1
        InProgress, // 2
        Resolved,   // 3
        Closed      // 4
    }

    public class NewIssue
    {
        /// <summary>
        /// Issue title
        /// </summary>
        [Required]
        public string Title;

        /// <summary>
        /// Issue detailed description
        /// </summary>
        public string Description;

        /// <summary>
        /// Issue priority
        /// </summary>
        public Priority Priority;

        /// <summary>
        /// Issue status
        /// </summary>
        public Status Status;

        /// <summary>
        /// Issue assignment
        /// </summary>
        public string AssignedTo;
    }

    public class Issue : NewIssue
    {
        /// <summary>
        /// Issue Id
        /// </summary>
        [Required]
        public readonly string Id;

        public Issue()
        {
        }

        public Issue(string issueId, NewIssue newIssue)
        {
            this.Id = issueId;
            this.Title = newIssue.Title;
            this.Description = newIssue.Description;
            this.Priority = newIssue.Priority;
            this.Status = newIssue.Status;
            this.AssignedTo = newIssue.AssignedTo;
        }
    }
}
