﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetSample.MeetingMinutesSystem.Models
{
    public class MeetingMinutesOverview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime IssueDate { get; set; }
        public string ResponsibleMember { get; set; }
        public DateTime Deadline { get; set; }
        public Status? Status { get; set; }
        //RYAN: Design issue. The color based on the status should be just View level thingk.
        //We don't actually want to save the StatusColor in the db. Please consider remove this field in the entity.
        //Move the color logic to view side only, not impact Model or Controller.
        public string StatusColor { get; set; }

    }

    public enum Status
    {
        New,
        Ongoing,
        Done,
        Block
    }
}