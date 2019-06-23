using InteractiveUsers.Models;
using Shapeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraggableInteractiveDivs.Controllers
{
    public class HomeController : Controller
    {
        private BoardContext db = new BoardContext();
        // GET: Home
        public ActionResult Index(int? id, string type)
        {
            if (type == "Edit")
            {
                var cardProp = db.Cards.Where(n => n.CardID == id.Value).FirstOrDefault();
                ViewBag.CardId = cardProp.CardID;
                ViewBag.CardTitle = cardProp.Title;
                ViewBag.CardText = cardProp.Text;
            }

            //ViewBag.CategoryList = getCategoryList();
            ViewBag.CardsList = getCardList();
            return View(db.Cards);
        }

        public ActionResult SecondApproach()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult UpdateCard(Card card)
        //{
        //    using (BoardContext db = new BoardContext())
        //    {
        //        Card updatedCard = (from c in db.Cards
        //                            where c.CardID == card.CardID
        //                            select c).FirstOrDefault();
        //        updatedCard.Title = card.Title;
        //        updatedCard.Text = card.Text;
        //        //updatedCard.CategoryName = card.CategoryName;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult AddCardSignal(Card card)
        {

            if (ModelState.IsValid)
            {

                db.Cards.Add(card);
                db.SaveChanges();

                return Json(card.CardID, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult Index([Bind(Include = "CategoryName,Title,Text,Vote")]
                ViewModel viewView, Card card)
        {
            if (ModelState.IsValid)
            {
                // Create a new Card
                Card newCard = new Card
                {

                    Title = viewView.Title,
                    Text = viewView.Text
                };

                db.Cards.Add(newCard);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Message = "N/A";
            //ViewBag.CategoryList = getCategoryList();
            ViewBag.CardsList = getCardList();

            return View(viewView);
        }

        //aoife start
        public List<Card> getCardList()
        {
            List<Card> card = new List<Card>();
            //getting cards in db
            card = db.Cards.ToList();

            var cards = new List<Card>();
            foreach (var item in card)
            {
                if (item.Title != null || item.Text != null)
                    cards.Add(item);
            }
            return cards;
        }


    }
}
