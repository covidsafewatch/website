using System;
using System.Collections.Generic;
using System.Text;

namespace CovidSafeWatch
{
    // YAML front matter
    public static class SiteKeys
    {
        public const string NoContainer = nameof(NoContainer);
        public const string NoSidebar = nameof(NoSidebar);
        public const string Topic = nameof(Topic);
        public const string NoChildPages = nameof(NoChildPages);
        public const string BreadcrumbTitle = nameof(BreadcrumbTitle); // The title of a page when displayed in the breadcrumbs

        public const string BreachesPrivacy = nameof(BreachesPrivacy); // true || false
        public const string DisclosedAt = nameof(DisclosedAt); // datetime
        public const string ResolvedAt = nameof(ResolvedAt); // datetime
        public const string JiraCaseNumber = nameof(JiraCaseNumber); 
        public const string CVEIdentifier = nameof(CVEIdentifier);
        public const string Status = nameof(Status); // Unresolved, Acknowledged, Resolved, Invalid
        public const string IssueMaintainer = nameof(IssueMaintainer); // github username of the person who is maintainer of the issue 

    }
}
