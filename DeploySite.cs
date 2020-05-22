using Statiq.Common;
using Statiq.Core;
using Statiq.Web.GitHub;

namespace CovidSafeWatch
{
    public class DeploySite : Pipeline
    {
        public DeploySite()
        {
            Deployment = true;

            OutputModules = new ModuleList
            {
                new DeployGitHubPages("covidsafewatch", "website", Config.FromSetting<string>("GITHUB_TOKEN")).ToBranch("master")
            };
        }
    }
}