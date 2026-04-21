using Meridian.Core.Providers.Models;

namespace Meridian.Core.Providers
{
    public interface ISourceControlProvider
    {
        // Work Items
        Task<WorkItem> GetWorkItemAsync(string id, CancellationToken cancellationToken = default);
        Task<IEnumerable<WorkItem>> GetWorkItemsAsync(string projectId, CancellationToken cancellationToken = default);
        Task UpdateWorkItemAsync(string id, string status, string comment, CancellationToken cancellationToken = default);

        // Repositories
        Task<Branch> CreateBranchAsync(string repoId, string branchName, string fromBranch, CancellationToken cancellationToken = default);
        Task<IEnumerable<Branch>> GetBranchesAsync(string repoId, CancellationToken cancellationToken = default);
        // Code
        Task<string> SearchCodeAsync(string repoId, string query, CancellationToken cancellationToken = default);
        Task<string> GetFileHistoryAsync(string repoId, string filePath, CancellationToken cancellationToken = default);

        // Pull Requests
        Task<PullRequest> CreatePullRequestAsync(string repoId, string title, string description, string sourceBranch, string targetBranch, CancellationToken cancellationToken = default);
        Task<PullRequest> GetPullRequestAsync(string repoId, string pullRequestId, CancellationToken cancellationToken = default);

    }
}
