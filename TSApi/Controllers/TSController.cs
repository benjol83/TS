﻿using DataAdapter;
using DataModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Unity;

namespace TSApi.Controllers
{
    public class TSController : ApiController
    {
        IStorage myStorage
        {
            get { return TSUnityContainer.GetContainer().Resolve<IStorage>(); }
        }

        /// <summary>
        /// Get all issues available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Issue> GetIssues(uint startIndex, uint count)
        {
            var retval = myStorage.GetIssues(startIndex, count);
            return retval;
        }

        /// <summary>
        /// Search an issue by Id
        /// </summary>
        /// <param name="issueId"></param>
        [HttpGet]
        public Issue SearchIssueById(string issueId)
        {
            var retval = myStorage.SearchIssueById(issueId);

            return retval;
        }

        /// <summary>
        /// Search issues based on given criteria
        /// </summary>
        /// <param name="title"></param>
        /// <param name="priority"></param>
        /// <param name="status"></param>
        /// <param name="assignedTo"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Issue> SearchIssue(string title = "", Priority priority = Priority.Any, Status status = Status.Any, string assignedTo = "")
        {
            var retval = myStorage.SearchIssues(title, priority, status, assignedTo);

            return retval;
        }

        /// <summary>
        /// Create a new issue
        /// </summary>
        /// <param name="newIssue"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateIssue([FromBody]NewIssue newIssue)
        {
            var newIssueId = myStorage.CreateIssue(newIssue);

            return newIssueId;
        }

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <returns>The comment id</returns>
        /// <param name="issueId">Issue identifier.</param>
        /// <param name="newComment">New comment.</param>
        [HttpPost]
        public string CreateComment(string issueId, [FromBody]NewComment newComment)
        {
            var newCommentId = myStorage.CreateComment(issueId, newComment);
            if (string.IsNullOrWhiteSpace(newCommentId))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return newCommentId;
        }

        /// <summary>
        /// Update existing issue
        /// </summary>
        /// <param name="issueToUpdate"></param>
        /// <returns></returns>
        [HttpPost]
        public Issue UpdateIssue([FromBody]Issue issueToUpdate)
        {
            var updatedIssue = myStorage.UpdateIssue(issueToUpdate);
            if (updatedIssue == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return updatedIssue;
        }

        /// <summary>
        /// Delete an issue
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteIssue(string issueId)
        {
            myStorage.DeleteIssue(issueId);

            return Ok();
        }
    }
}
