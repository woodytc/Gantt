using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Gantt.Models
{
    public class GanttRequest
    {
        public GanttMode Mode { get; set; }
        public GanttAction Action { get; set; }

        public Task UpdatedTask { get; set; }
        public Link UpdatedLink { get; set; }
        public long SourceId { get; set; }

        /// <summary>
        /// Create new GanttData object and populate it
        /// </summary>
        /// <param name="form">Form collection</param>
        /// <returns>New GanttData</returns>
        public static List<GanttRequest> Parse(FormCollection form, string ganttMode)
        {
            // save current culture and change it to InvariantCulture for data parsing
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var dataActions = new List<GanttRequest>();
            var prefixes = form["ids"].Split(',');

            foreach (var prefix in prefixes)
            {
                var request = new GanttRequest();

                // lambda expression for form data parsing
                Func<string, string> parse = x => form[String.Format("{0}_{1}", prefix, x)];

                request.Mode = (GanttMode)Enum.Parse(typeof(GanttMode), ganttMode, true);
                request.Action = (GanttAction)Enum.Parse(typeof(GanttAction), parse("!nativeeditor_status"), true);
                request.SourceId = Int64.Parse(parse("id"));

                // parse gantt task
                if (request.Action != GanttAction.Deleted && request.Mode == GanttMode.Tasks)
                {
                    request.UpdatedTask = new Task()
                    {
                        Id = (request.Action == GanttAction.Updated) ? (int)request.SourceId : 0,
                        Text = parse("text"),
                        StartDate = DateTime.Parse(parse("start_date")),
                        Duration = Int32.Parse(parse("duration")),
                        Progress = Decimal.Parse(parse("progress")),
                        ParentId = (parse("parent") != "0") ? Int32.Parse(parse("parent")) : (int?)null,
                        SortOrder = (parse("order") != null) ? Int32.Parse(parse("order")) : 0,
                        Type = parse("type")
                    };
                }
                // parse gantt link
                else if (request.Action != GanttAction.Deleted && request.Mode == GanttMode.Links)
                {
                    request.UpdatedLink = new Link()
                    {
                        Id = (request.Action == GanttAction.Updated) ? (int)request.SourceId : 0,
                        SourceTaskId = Int32.Parse(parse("source")),
                        TargetTaskId = Int32.Parse(parse("target")),
                        Type = parse("type")
                    };
                }

                dataActions.Add(request);
            }

            // return current culture back
            Thread.CurrentThread.CurrentCulture = currentCulture;

            return dataActions;
        }
    }

    /// <summary>
    /// Gantt modes
    /// </summary>
    public enum GanttMode
    {
        Tasks,
        Links
    }

    /// <summary>
    /// Gantt actions
    /// </summary>
    public enum GanttAction
    {
        Inserted,
        Updated,
        Deleted,
        Error
    }
}