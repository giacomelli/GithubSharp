﻿using GithubSharp.Core.Base;
using GithubSharp.Core.Models.PullRequests;

namespace GithubSharp.Core.API
{
    public class PullRequestsRepository : BaseApi
    {
        public PullRequestsRepository(IRequestProxy requestProxy) : base(requestProxy) { }

        public PullRequest[] List(string username, string repositoryName)
        {
            return List(username, repositoryName, null);
        }

        public PullRequest[] List(string username, string repositoryName, string state)
        {
            var url = string.Format("repos/{0}/{1}/pulls{2}", username, repositoryName, string.IsNullOrEmpty(state) ? "" : "?state=" + state);
            AppendPerPageLimit(ref url); 
            return ConsumeJsonUrl<PullRequest[]>(url);
        }

        public PullRequest GetById(string username, string repositoryName, string id)
        {
            var url = string.Format("repos/{0}/{1}/pulls/{2}", username, repositoryName, id);
            return ConsumeJsonUrl<PullRequest>(url);
        }
    }
}
