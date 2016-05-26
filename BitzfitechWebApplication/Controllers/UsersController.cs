using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitzfitechWebApplication.Models;
using System.Net;
using System.Web.Script.Serialization;

namespace System.Web.Mvc {
    public static class HtmlLists {
        public static IEnumerable<NetflixShow> Shows = new List<NetflixShow> { 
            new NetflixShow {
                Name = "Marco Polo",
                Value = "Marco Polo"
            },
            new NetflixShow {
                Name = "The Walking Dead",
                Value = "The Walking Dead"
            },
            new NetflixShow {
                Name = "Narcos",
                Value = "Narcos"
            },
            new NetflixShow {
                Name = "Orange is the New Black",
                Value = "Orange is the New Black"
            },
            new NetflixShow {
                Name = "Red",
                Value = "Red",
            },
            new NetflixShow {
                Name = "Zombies",
                Value = "Zombies"
            }
        };
    }
}

namespace BitzfitechWebApplication.Controllers
{
    public class UsersController : Controller
    {
        private UserDBContext db = new UserDBContext();
        
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            dynamic obj;
            UsersDB usersdb = db.Users.Find(id);
            if (usersdb == null) {
                return HttpNotFound();
            } else {
                WebClient jsonClient = new WebClient();
                string jsonDataStr = jsonClient.DownloadString(
                    "https://bftjuniorapi20160519024425.azurewebsites.net/api/test");
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                obj = jsonSerializer.Deserialize<object>(jsonDataStr);

                // We will randomize the tweet output
                Random r = new Random();
                int nTweets = r.Next(1, 6);
                var uniqueNums = Enumerable.Range(0, 5)
                    .OrderBy(x => r.Next())
                    .Take(nTweets)
                    .Distinct()
                    .ToList();

                List<string> _tweets = new List<string>();
                for (int i = 0; i < uniqueNums.Count; ++i) {
                    _tweets.Add(obj[uniqueNums.ElementAt(i)]["text"]);  
                }
                ViewBag.Tweets = _tweets;
            }

            return View(usersdb);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {    
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersDB usersdb)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(usersdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(usersdb);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UsersDB usersdb = db.Users.Find(id);
            if (usersdb == null) {
                return HttpNotFound();
            }
            return View(usersdb);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersDB usersdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersdb);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UsersDB usersdb = db.Users.Find(id);
            if (usersdb == null)
            {
                return HttpNotFound();
            }
            return View(usersdb);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersDB usersdb = db.Users.Find(id);
            db.Users.Remove(usersdb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}