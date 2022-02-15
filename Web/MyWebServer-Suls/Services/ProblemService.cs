namespace Suls.Services
{
    using Suls.Data;
    using Suls.Data.Models;
    using Suls.Services.Contracts;
    using Suls.ViewModels.Problems;
    using Suls.ViewModels.Submissions;
    using System.Collections.Generic;
    using System.Linq;

    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext data;

        public ProblemService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void AddProblem(string userId, ProblemFormModel model)
        {
            var problem = new Problem
            {
                Name = model.Name,
                Points = model.Points,
                UserId=userId,
            };

            this.data.Problems.Add(problem);
            this.data.SaveChanges();            
        }

        public List<ProblemHomePageViewModel> GetProblemsForHome()
        {
            var problems = this.data.Problems.Select(x => new ProblemHomePageViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SubmissionCount=x.Submissions.Count(),

            }).ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            var name = this.data.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();

            return name;
        }

        public ProblemItemViewModel GetDetailsById(string id)
        {
            var problemFromDb = this.data.Problems.Where(x => x.Id == id).FirstOrDefault();
            var submissions = this.data.Submissions.Where(x => x.ProblemId == problemFromDb.Id).Select(x => new SubmissionItemViewModel
            {
                Id = x.Id,                
                Username = x.User.Username,
                AchievedResult = x.AchievedResult,
                CreatedOn = x.CreatedOn,
            }).ToList();

            var details = new ProblemItemViewModel
            {
                Id = problemFromDb.Id,
                Name = problemFromDb.Name,
                MaxPoints = problemFromDb.Points,
                Submissions = submissions,
            };

            return details;
        }
    }
}
