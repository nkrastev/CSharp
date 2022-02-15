namespace Suls.ViewModels.Submissions
{
    using System;

    public class SubmissionItemViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
