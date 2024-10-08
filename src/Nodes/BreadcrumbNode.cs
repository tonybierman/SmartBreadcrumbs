using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;

namespace SmartBreadcrumbs.Nodes
{
    public abstract class BreadcrumbNode
    {

        #region Properties

        public string Title { get; set; }

        public string OriginalTitle { get; }

        public object RouteValues { get; set; }

        public bool OverwriteTitleOnExactMatch { get; set; }

        public string IconClasses { get; set; }

        public BreadcrumbNode Parent { get; set; }

        #endregion

        internal BreadcrumbNode(BreadcrumbAttribute attr) :
            this(attr.Title, attr.OverwriteTitleOnExactMatch, attr.IconClasses, attr.AreaName)
        {

        }

        //protected BreadcrumbNode(string title, bool overwriteTitleOnExactMatch = false, string iconClasses = null, string areaName = null, List<object> routeParams = null)
        //{
        //    Title = title;
        //    OriginalTitle = Title;
        //    OverwriteTitleOnExactMatch = overwriteTitleOnExactMatch;
        //    IconClasses = iconClasses;

        //    // Initialize routeParams if it's null
        //    routeParams ??= new List<object>();

        //    // Add areaName if it's not null or whitespace
        //    if (!string.IsNullOrWhiteSpace(areaName))
        //    {
        //        routeParams.Add(new { area = areaName.Trim() });
        //    }

        //    RouteValues = routeParams;
        //}

        protected BreadcrumbNode(string title, bool overwriteTitleOnExactMatch = false, string iconClasses = null, string areaName = null)
        {
            Title = title;
            OriginalTitle = Title;
            OverwriteTitleOnExactMatch = overwriteTitleOnExactMatch;
            IconClasses = iconClasses;

            RouteValues = new
            {
                area = areaName?.Trim() ?? string.Empty
            };
        }

        #region Public Methods

        public abstract string GetUrl(IUrlHelper urlHelper);

        #endregion

    }
}
