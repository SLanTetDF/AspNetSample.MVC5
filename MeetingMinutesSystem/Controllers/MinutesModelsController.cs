using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetingMinutesSystem.Models;

namespace MeetingMinutesSystem.Controllers
{
    public class MinutesModelsController : Controller
    {
        private MeetingMinutesDB db = new MeetingMinutesDB();

        // GET: MeetingMinutesOverviews
        //RYAN: Find out the duplicate code in this method and fix it.
        //You should be sensitive enough to the duplicate code.
        //Refactor this method, it can be more clear than now.
        public ActionResult Index()
        {
            var data = GetMeetingMinutes();

            UpdateFilter();

            return View(data);
        }

        /// <summary>
        /// Filter the minute by drop list
        /// </summary>
        /// <param name="issueDate"></param>
        /// <param name="status"></param>
        /// <param name="responsibleMember"></param>
        /// <returns></returns>
        public ActionResult Filter(string issueDate, string status, string responsibleMember)
        {
            var data = GetMeetingMinutes();

            UpdateFilter();

            var minutes = (from s in data
                           where s.IssueDate.ToString() == issueDate || string.IsNullOrEmpty(issueDate)
                           where s.Status.ToString() == status || string.IsNullOrEmpty(status)
                           where s.ResponsibleMember == responsibleMember || string.IsNullOrEmpty(responsibleMember)
                           select s).ToList();


            return View("Index", minutes);
        }

        /// <summary>
        /// Create a new meeting minute 
        /// </summary>
        /// <returns></returns>
        public ViewResult AddRow()
        {
            var newMeetingMinute = new MinutesModel()
            {
                Id = Guid.NewGuid(),
                Content = string.Empty,
                IssueDate = DateTime.Now,
                ResponsibleMember = string.Empty,
                Deadline = DateTime.Now,
                Status = Status.New
            };

            UpdateFilter();

            db.MeetingMinutesData.Add(newMeetingMinute);
            db.SaveChanges();
            return View("Index", GetMeetingMinutes());
        }

        /// <summary>
        /// Update select items of Filter
        /// </summary>
        private void UpdateFilter()
        {
            ViewBag.IssueDate = (from minute in db.MeetingMinutesData select minute.IssueDate).ToList();
            ViewBag.Status = (from minute in db.MeetingMinutesData select minute.Status).ToList();
            ViewBag.ResponsibleMember = (from minute in db.MeetingMinutesData select minute.ResponsibleMember).ToList();
        }

        [HttpPost]
        public ActionResult Save(string command, IEnumerable<MinutesModel> model)
        {
            UpdateFilter();

            if (model != null)
            {
                if (command == "Save")
                {
                    foreach (var minute in model)
                    {
                        if (ModelState.IsValid)
                        {
                            db.Entry(minute).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                }
                else
                {
                    var data = db.MeetingMinutesData.Find(new Guid(command));
                    if (data != null)
                    {
                        db.MeetingMinutesData.Remove(data);
                        db.SaveChanges();
                    }

                }
            }
            return View("Index", GetMeetingMinutes());
        }

        /// <summary>
        /// Delete the minute by minute id
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete()
        {
            UpdateFilter();

            string idDelete = Request["deleteId"];
            var data = db.MeetingMinutesData.Find(new Guid(idDelete));
            if (data != null)
            {
                db.MeetingMinutesData.Remove(data);
                db.SaveChanges();
            }

            return View("Index", GetMeetingMinutes());
        }

        /// <summary>
        /// Get all the Minutes from database
        /// </summary>
        /// <returns></returns>
        private List<MinutesModel> GetMeetingMinutes()
        {
            return db.MeetingMinutesData.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            //RYAN: can you explain when will disposing is true and when disposing is false?
            //Sam: After the view has been render
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
