using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QuoteHdrsController : Controller
    {
        private KruegerQuotesEntities db = new KruegerQuotesEntities();

        // GET: QuoteHdrs
        public async Task<ActionResult> Index()
        {
            QuoteFilterViewModel model = new QuoteFilterViewModel();

            model.Companies = await db.Companies.ToDictionaryAsync(c => c.CompanyID, c => c.CompanyName);
            model.Quotes = await db.QuoteHdrs.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(QuoteFilterViewModel model)
        {
            model.Companies = await db.Companies.ToDictionaryAsync(c => c.CompanyID, c => c.CompanyName);
            model.Quotes = await db.QuoteHdrs.Where(q => q.CompanyID == model.CompanyId).ToListAsync();

            return View(model);
        }

        // GET: QuoteHdrs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteHdr quoteHdr = await db.QuoteHdrs.FindAsync(id);
            if (quoteHdr == null)
            {
                return HttpNotFound();
            }
            return View(quoteHdr);
        }

        // GET: QuoteHdrs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "ContactFirstName");
            ViewBag.DeliveryTermId = new SelectList(db.DeliveryTerms, "Id", "DeliveryTerm1");
            ViewBag.TrailerID = new SelectList(db.Trailers, "TrailerID", "ItemNo");
            ViewBag.RegistrationId = new SelectList(db.Registrations, "RegistrationID", "RegistrationDescription");
            ViewBag.TransportationId = new SelectList(db.Transportations, "TransportationID", "TransportationDescription");
            return View();
        }

        // POST: QuoteHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuoteID,QuoteRef,UserID,CompanyID,CustomerID,TrailerID,ItemNo,ItemDescriptionShort,ItemDescriptionLong,ItemSalesDescription,DrawingNo,Hours,TareWeight,Length,Width,Height,SellPrice,CostMaterial,CreatedDateTime,AllowReprint,DeliveryTermId,QuoteFile,SpecialRequirement,Discount,Quantity,SpecReqSellPrice,SpecReqSellCost,CostedBy,Timestamp,RegistrationId,TransportationId,WarrantyPeriod,Comment,CubicCapacity,QuoteRefId,DiscountAmount,DiscountType,ShowRequirementOnQuote,SpecialRequirementB,SpecReqSellPriceB,SpecReqSellCostB")] QuoteHdr quoteHdr)
        {
            if (ModelState.IsValid)
            {
                db.QuoteHdrs.Add(quoteHdr);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", quoteHdr.CompanyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "ContactFirstName", quoteHdr.CustomerID);
            ViewBag.DeliveryTermId = new SelectList(db.DeliveryTerms, "Id", "DeliveryTerm1", quoteHdr.DeliveryTermId);
            ViewBag.TrailerID = new SelectList(db.Trailers, "TrailerID", "ItemNo", quoteHdr.TrailerID);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "RegistrationID", "RegistrationDescription", quoteHdr.RegistrationId);
            ViewBag.TransportationId = new SelectList(db.Transportations, "TransportationID", "TransportationDescription", quoteHdr.TransportationId);
            return View(quoteHdr);
        }

        // GET: QuoteHdrs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteHdr quoteHdr = await db.QuoteHdrs.FindAsync(id);
            if (quoteHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", quoteHdr.CompanyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "ContactFirstName", quoteHdr.CustomerID);
            ViewBag.DeliveryTermId = new SelectList(db.DeliveryTerms, "Id", "DeliveryTerm1", quoteHdr.DeliveryTermId);
            ViewBag.TrailerID = new SelectList(db.Trailers, "TrailerID", "ItemNo", quoteHdr.TrailerID);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "RegistrationID", "RegistrationDescription", quoteHdr.RegistrationId);
            ViewBag.TransportationId = new SelectList(db.Transportations, "TransportationID", "TransportationDescription", quoteHdr.TransportationId);
            return View(quoteHdr);
        }

        // POST: QuoteHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuoteID,QuoteRef,UserID,CompanyID,CustomerID,TrailerID,ItemNo,ItemDescriptionShort,ItemDescriptionLong,ItemSalesDescription,DrawingNo,Hours,TareWeight,Length,Width,Height,SellPrice,CostMaterial,CreatedDateTime,AllowReprint,DeliveryTermId,QuoteFile,SpecialRequirement,Discount,Quantity,SpecReqSellPrice,SpecReqSellCost,CostedBy,Timestamp,RegistrationId,TransportationId,WarrantyPeriod,Comment,CubicCapacity,QuoteRefId,DiscountAmount,DiscountType,ShowRequirementOnQuote,SpecialRequirementB,SpecReqSellPriceB,SpecReqSellCostB")] QuoteHdr quoteHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quoteHdr).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", quoteHdr.CompanyID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "ContactFirstName", quoteHdr.CustomerID);
            ViewBag.DeliveryTermId = new SelectList(db.DeliveryTerms, "Id", "DeliveryTerm1", quoteHdr.DeliveryTermId);
            ViewBag.TrailerID = new SelectList(db.Trailers, "TrailerID", "ItemNo", quoteHdr.TrailerID);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "RegistrationID", "RegistrationDescription", quoteHdr.RegistrationId);
            ViewBag.TransportationId = new SelectList(db.Transportations, "TransportationID", "TransportationDescription", quoteHdr.TransportationId);
            return View(quoteHdr);
        }

        // GET: QuoteHdrs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteHdr quoteHdr = await db.QuoteHdrs.FindAsync(id);
            if (quoteHdr == null)
            {
                return HttpNotFound();
            }
            return View(quoteHdr);
        }

        // POST: QuoteHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuoteHdr quoteHdr = await db.QuoteHdrs.FindAsync(id);
            db.QuoteHdrs.Remove(quoteHdr);
            await db.SaveChangesAsync();
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
