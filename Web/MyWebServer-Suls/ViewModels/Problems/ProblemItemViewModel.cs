namespace Suls.ViewModels.Problems
{
    using Suls.ViewModels.Submissions;
    using System.Collections.Generic;

    public class ProblemItemViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MaxPoints { get; set; }

        public List<SubmissionItemViewModel> Submissions { get; set; }
    }
}
