using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetSample.MeetingMinutesSystem.Models;

namespace AspNetSample.MeetingMinutesSystem.Controllers
{
    public class MeetingMinutesOverviewsController : Controller
    {
        private MeetingMinutesDB db = new MeetingMinutesDB();

        // GET: MeetingMinutesOverviews
        public ActionResult Index(string key)
        {
            ViewResult view;
            if (key == string.Empty || key == null)
            {
                var data = db.MeetingMinutesOverviews.ToList();

                foreach (var item in data)
                {
                    SetStatusColor(item);
                }

                view = View(data);
            }
            else
            {
                ViewBag.CurrentFilter = key;

                var minutes = from s in db.MeetingMinutesOverviews
                              select s;
                if (!String.IsNullOrEmpty(key))
                {
                    minutes = minutes.Where(s => s.IssueDate.ToString().Contains(key)
                                           || s.ResponsibleMember.Contains(key)
                                           || s.Status.ToString().Contains(key));
                }
                foreach (var item in minutes)
                {
                    SetStatusColor(item);

                }

                view = View(minutes);
            }

            return view;
        }

        private void SetStatusColor(MeetingMinutesOverview mintue)
        {
            if (mintue.Status == Status.Ongoing)
            {
                mintue.StatusColor = "orange";
            }
            else if (mintue.Status == Status.Done)
            {
                mintue.StatusColor = "green";
            }
            else if (mintue.Status == Status.Block)
            {
                mintue.StatusColor = "red";
            }
        }
        // GET: MeetingMinutesOverviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingMinutesOverview meetingMinutesOverview = db.MeetingMinutesOverviews.Find(id);
            if (meetingMinutesOverview == null)
            {
                return HttpNotFound();
            }
            return View(meetingMinutesOverview);
        }

        // GET: MeetingMinutesOverviews/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,IssueDate,ResponsibleMember,Deadline,Status")] MeetingMinutesOverview meetingMinutesOverview)
        {
            if (ModelState.IsValid)
            {
                db.MeetingMinutesOverviews.Add(meetingMinutesOverview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingMinutesOverview);
        }

        // GET: MeetingMinutesOverviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingMinutesOverview meetingMinutesOverview = db.MeetingMinutesOverviews.Find(id);
            if (meetingMinutesOverview == null)
            {
                return HttpNotFound();
            }
            return View(meetingMinutesOverview);
        }

        // POST: MeetingMinutesOverviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,IssueDate,ResponsibleMember,Deadline,Status")] MeetingMinutesOverview meetingMinutesOverview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingMinutesOverview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingMinutesOverview);
        }

        // GET: MeetingMinutesOverviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingMinutesOverview meetingMinutesOverview = db.MeetingMinutesOverviews.Find(id);
            if (meetingMinutesOverview == null)
            {
                return HttpNotFound();
            }
            return View(meetingMinutesOverview);
        }

        // POST: MeetingMinutesOverviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingMinutesOverview meetingMinutesOverview = db.MeetingMinutesOverviews.Find(id);
            db.MeetingMinutesOverviews.Remove(meetingMinutesOverview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {         
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
