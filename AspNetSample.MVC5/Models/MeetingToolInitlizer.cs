using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetSample.MeetingMinutesSystem.Models
{ 
    public class MeetingToolInitlizer: System.Data.Entity.DropCreateDatabaseAlways<MeetingMinutesDB>
    {
            protected override void Seed(MeetingMinutesDB context)
            {
            var meetingMinute = new List<MeetingMinutesOverview>
            {
                    new MeetingMinutesOverview{Id=1,ResponsibleMember="Chen",Content="addTest",IssueDate=new DateTime(2010, 2, 12),Deadline=new DateTime(2010, 2, 22),Status=Status.New },
                    new MeetingMinutesOverview{Id=2,ResponsibleMember="Liang",Content="addTest",IssueDate=new DateTime(2010, 2, 12),Deadline=new DateTime(2010, 2, 22),Status=Status.New },
                };
            meetingMinute.ForEach(s => context.MeetingMinutesOverviews.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
        }
}