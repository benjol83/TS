using System;
namespace DataModel
{
    public class NewComment
    {
        public string UserId;
        public string Text;
    }

    public class Comment : NewComment
    {
        public string CommentId;
        public DateTime TimeStamp;

        public Comment(NewComment input)
        {
            this.UserId = input.UserId;
            this.Text = input.Text;
        }
    }
}
