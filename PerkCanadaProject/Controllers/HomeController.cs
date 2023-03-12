using PerkCanadaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace PerkCanadaProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult NewsStories()
        {
            try
            {
                var url = XDocument.Load("http://www.cbc.ca/cmlink/rss-topstories");

                var newslist = from item in url.Descendants("item")
                               select new CBCNewsStory
                               {
                                   Title = item.Element("title").Value,
                                   Description = item.Element("description").Value,
                                   AuthorName = item.Element("author").Value,
                                   PubDate = item.Element("pubDate").Value,
                                   Link = item.Element("link").Value
                               };

                return View(newslist.ToList());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}