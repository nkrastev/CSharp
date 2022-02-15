namespace Suls.Services.Contracts
{
    using Suls.ViewModels.Submissions;

    public interface ISubmissionService
    {
        void AddSubmission(string userId, SubmissionFormModel model);

        void DeleteById(string id);
    }
}
