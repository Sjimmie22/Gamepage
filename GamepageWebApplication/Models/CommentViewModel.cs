namespace GamepageWebApplication.Models
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }

        public int ClipID { get; set; }

        public int UserID { get; set; }

        public string CommentText { get; set; }

        public string Maker { get; set; }
    }
}
