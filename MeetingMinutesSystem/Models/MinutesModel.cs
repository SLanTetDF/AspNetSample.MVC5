using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingMinutesSystem.Models
{
    public class MinutesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime IssueDate { get; set; }
        public string ResponsibleMember { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        public Status? Status { get; set; }
        //RYAN: Design issue. The color based on the status should be just View level thingk.
        //We don't actually want to save the StatusColor in the db. Please consider remove this field in the entity.
        //Move the color logic to view side only, not impact Model or Controller.

    }

    public enum Status
    {
        [Display(Name = "New")]
        New,
        [Display(Name = "Ongoing")]
        Ongoing,
        [Display(Name = "Done")]
        Done,
        [Display(Name = "Block")]
        Block
    }
}