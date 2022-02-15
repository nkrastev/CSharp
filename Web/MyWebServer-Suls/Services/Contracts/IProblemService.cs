namespace Suls.Services.Contracts
{
    using Suls.ViewModels.Problems;
    using System.Collections.Generic;

    public interface IProblemService
    {
        void AddProblem(string userId, ProblemFormModel model);

        List<ProblemHomePageViewModel> GetProblemsForHome();

        string GetNameById(string id);

        ProblemItemViewModel GetDetailsById(string id);
    }
}
