using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaSachHuflit.Models;

namespace NhaSachHuflit.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class QuanLySachController : Controller
    {
        private CSDL db = new CSDL();

        // GET: Admin/QuanLySach
        public ActionResult Index(int? page)
        {
            
            QuanLySach q = new QuanLySach();
            List<Sach> l = q.Dss();
            int number = 0;

            ViewBag.Dem = l.Count() / 8;
            if (page != null) { number = page.GetValueOrDefault() * 8; }
            List<Sach> dssach = l.OrderBy(s => s.id).Skip(number).Take(8).ToList();
            return View(dssach);
        }

        public ActionResult Details2(int id)
        {

            QuanLySach q = new QuanLySach();
            Sach sach = q.XemChiTiet(id);
            return View(sach);
        }

        // GET: Admin/QuanLySach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/QuanLySach/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDanhMuc");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Admin/QuanLySach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,gia,tensp,hinh,mota,ttc_kichthuoc,ttc_ngayxuatban,ttc_loaibia,ttc_sotrang,ttc_nhaxuatban,motasanpham,MaDM,MaNXB")] Sach sach, HttpPostedFileBase hinh)
        {
            if (ModelState.IsValid)
            {
                if (hinh != null)
                {
                    var fileName = Path.GetFileName(hinh.FileName);
                    sach.hinh = fileName;
                    string path = Path.Combine(Server.MapPath("~/Hinh"), fileName);
                    hinh.SaveAs(path);
                }
                db.Sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDanhMuc", sach.MaDM);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Admin/QuanLySach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDanhMuc", sach.MaDM);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // POST: Admin/QuanLySach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,gia,tensp,hinh,mota,ttc_kichthuoc,ttc_ngayxuatban,ttc_loaibia,ttc_sotrang,ttc_nhaxuatban,motasanpham,MaDM,MaNXB")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDanhMuc", sach.MaDM);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Admin/QuanLySach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/QuanLySach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Sach.Find(id);
            db.Sach.Remove(sach);
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
