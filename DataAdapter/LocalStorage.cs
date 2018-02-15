using System;
using System.Collections.Generic;
using DataModel;
using System.Linq;
using Unity.Attributes;

namespace DataAdapter
{
    /// <summary>
    /// Implementation of fake Local Storage that inherit IStorage interface
    /// </summary>
    public class LocalStorage : IStorage
    {
        Dictionary<string, Issue> CurrentIssues;

        /// <summary>
        /// Local Storage Constructor used by Dependency Injection framework
        /// </summary>
        /// <param name="input"></param>
        [InjectionConstructor]
        public LocalStorage(Dictionary<string, Issue> input)
        {
            this.CurrentIssues = input;
        }

        /// <summary>
        /// Data adapter that will create new issue in the local storage
        /// </summary>
        /// <param name="newIssue">NewIssue instance</param>
        /// <returns>Id</returns>
        public string CreateIssue(NewIssue newIssue)
        {
            var issueId = Guid.NewGuid().ToString();
            this.CurrentIssues.Add(issueId, new Issue(issueId, newIssue));

            return issueId;
        }

        public string CreateComment(string issueId, NewComment newComment)
        {
            var commentId = Guid.NewGuid().ToString();
            if (this.CurrentIssues.ContainsKey(issueId))
            {
                var comment = new Comment(newComment);
                comment.CommentId = commentId;
                comment.TimeStamp = DateTime.UtcNow;
                this.CurrentIssues[issueId].Comments.Add(comment);

                return commentId;
            }

            return null;
        }

        /// <summary>
        /// Data adapter that will delete an issue based on id from the local storage
        /// </summary>
        /// <param name="id">Issue Id</param>
        /// <returns>true/false</returns>
        public bool DeleteIssue(string id)
        {
            return this.CurrentIssues.Remove(id);
        }

        /// <summary>
        /// Data adapter that will get all issues available in the local storage
        /// based on specified pagination
        /// </summary>
        /// <returns>List of issues</returns>
        /// <param name="startIndex">startIndex.</param>
        /// <param name="count">count.</param>
        public List<Issue> GetIssues(uint startIndex, uint count)
        {
            var curCount = (uint)this.CurrentIssues.Count;
            var countToGet = count;
            if (curCount >= startIndex)
            {
                countToGet = Math.Min(curCount - startIndex, count);
            }
            else
            {
                return null;
            }

            var retval = this.CurrentIssues
                             .Values
                             .Skip((int)startIndex)
                             .Take((int)countToGet);

            return retval.ToList();
        }

        /// <summary>
        /// Data adapter that will get all issues given the search criteria
        /// </summary>
        /// <param name="title"></param>
        /// <param name="priority"></param>
        /// <param name="status"></param>
        /// <param name="assignedTo"></param>
        /// <returns>List of issues</returns>
        public List<Issue> SearchIssues(string title, Priority priority, Status status, string assignedTo)
        {
            IEnumerable<Issue> retval = this.CurrentIssues.Values;

            if (!string.IsNullOrWhiteSpace(title))
            {
                retval = retval.Where(i => i.Title.ToLowerInvariant().Contains(title.ToLowerInvariant()));
            }
            if (priority != Priority.Any)
            {
                retval = retval.Where(i => i.Priority == priority);
            }
            if (status != Status.Any)
            {
                retval = retval.Where(i => i.Status == status);
            }
            if (!string.IsNullOrWhiteSpace(assignedTo))
            {
                retval = retval.Where(i => i.AssignedTo.ToLowerInvariant().Contains(assignedTo.ToLowerInvariant()));
            }

            return retval.ToList();
        }

        /// <summary>
        /// Data adapter that will get an issue based on id from the local storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Issue SearchIssueById(string id)
        {
            return this.CurrentIssues.ContainsKey(id) ? this.CurrentIssues[id] : null;
        }

        /// <summary>
        /// Data adapter that will update an existing issue
        /// </summary>
        /// <param name="updateIssue">Issue to be updated</param>
        /// <returns>Updated issue instance if successul, null otherwise</returns>
        public Issue UpdateIssue(Issue updateIssue)
        {
            if (this.CurrentIssues.ContainsKey(updateIssue.Id))
            {
                var issueToUpdate = this.CurrentIssues[updateIssue.Id];
                issueToUpdate.Title = updateIssue.Title;
                issueToUpdate.Description = updateIssue.Description;
                issueToUpdate.Priority = updateIssue.Priority;
                issueToUpdate.Status = updateIssue.Status;
                issueToUpdate.AssignedTo = updateIssue.AssignedTo;

                return issueToUpdate;
            }

            return null;
        }
    }
}
