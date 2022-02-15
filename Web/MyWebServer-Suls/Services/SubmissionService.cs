namespace Suls.Services
{
    using Suls.Data;
    using Suls.Data.Models;
    using Suls.Services.Contracts;
    using Suls.ViewModels.Submissions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext data;

        public SubmissionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void AddSubmission(string userId, SubmissionFormModel model)
        {
            var problem = this.data.Problems.Where(x=>x.Id==model.ProblemId).FirstOrDefault();

            var submission = new Submission
            {
                UserId = userId,
                ProblemId = model.ProblemId,
                Code = model.Code,
                AchievedResult = new Random().Next(0, problem.Points),
                CreatedOn = DateTime.Now,
            };

            this.data.Submissions.Add(submission);
            this.data.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var submission = this.data.Submissions.Where(x=>x.Id== id).FirstOrDefault();
            if (submission!=null)
            {
                this.data.Submissions.Remove(submission);
                this.data.SaveChanges();
            }
        }
    }
}
