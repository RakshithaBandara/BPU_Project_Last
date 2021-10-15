using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPU_Project.Models;
using System.Data.Entity;

namespace BPU_Project.Controllers
{
    public class SalesorderController : Controller
    {
        private ApplicationDbContext _context;
        public SalesorderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Salesorder
       // [Authorize(Roles = "CanManageSalesorders")]
        public ActionResult Index(string option, string search)
        {
            var salesorders = _context.Salesorders.ToList();
            //UserIndex();
            if (User.IsInRole("CanManageSalesorders"))
            {
                //if a user choose the radio button option as Subject  
                if (option == "Salesorder")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    return View(_context.Salesorders.Where(x => x.Salesorder_No == search).OrderByDescending(x => x.Date).ToList());
                }
                else if (option == "Lineitem")
                {
                    return View(_context.Salesorders.Where(x => x.Line_Item == search).OrderByDescending(x => x.Date).ToList());
                }
                else if (option == "ModuleNo")
                {
                    return View(_context.Salesorders.Where(x => x.Module.Contains(search)).OrderByDescending(x => x.Date).ToList());
                }
                else
                {
                    return View(_context.Salesorders.OrderByDescending(x => x.Date).ThenBy(x=> x.Line_Item).ToList());
                }
            }

            else
            {
                // return View("UserIndex");
                return RedirectToAction("UserIndex");
            }

            // var salesorders = _context.Salesorders.ToList();
            //return View(salesorders);
        }

        public ActionResult UserIndex(string option, string search)
        {
            var salesorders = _context.Salesorders.ToList();
            {
                if (option == "Salesorder")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    return View(_context.Salesorders.Where(x => x.Salesorder_No == search).OrderByDescending(x => x.Date).ToList());
                }
                else if (option == "Lineitem")
                {
                    return View(_context.Salesorders.Where(x => x.Line_Item == search).OrderByDescending(x => x.Date).ToList());
                }
                else if (option == "ModuleNo")
                {
                    return View(_context.Salesorders.Where(x => x.Module.Contains(search)).OrderByDescending(x => x.Date).ToList());
                }
                else
                {
                    return View(_context.Salesorders.OrderByDescending(x => x.Date).ToList());
                }
            }
        }

        // var salesorders = _context.Salesorders.ToList();
        //{
        //    return View(_context.Salesorders.ToList());
        // }

        /*var salesorders = _context.Salesorders.ToList();

        //if a user choose the radio button option as Subject  
        if (option == "Salesorder")
        {
            //Index action method will return a view with a student records based on what a user specify the value in textbox  
            return View(_context.Salesorders.Where(x => x.Salesorder_No == search).ToList());
        }
        else if (option == "Lineitem")
        {
            return View(_context.Salesorders.Where(x => x.Line_Item == search).ToList());
        }
        else if (option == "ModuleNo")
        {
            return View(_context.Salesorders.Where(x => x.Module.Contains(search)).ToList());
        }
        else
        {
            //return View(_context.Salesorders.ToList());
            return View(salesorders);
        }
        // var salesorders = _context.Salesorders.ToList();
        // return View(salesorders);
        */


        // GET: Salesorder/Details/5
        public ActionResult Details(int id)
        {
            var salesorders = _context.Salesorders.SingleOrDefault(s => s.Id == id);

            if (salesorders == null)
            {
                return HttpNotFound();
            }
            return View(salesorders);
        }

        // GET: Salesorder/Create
        public ActionResult Create()
        {
            if (User.IsInRole("CanManageSalesorders"))
                return View("Create");

            return RedirectToAction("UserIndex", "Salesorder");
        }

        // POST: Salesorder/Create       
        [HttpPost]
        public ActionResult Create(Salesorder salesorder)
        {
            _context.Salesorders.Add(salesorder);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //             return View("Index");    

        }

        // GET: Salesorder/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("CanManageSalesorders"))
            {
                var salesorder = _context.Salesorders.SingleOrDefault(x => x.Id == id);

                if (salesorder == null)
                    return HttpNotFound();

                return View(salesorder);
            }


            else
            {
                // return View("UserEdit");
                return RedirectToAction("UserEdit", new { id = id});
            }
        }

        // POST: Salesorder/Edit/5
        [HttpPost]
        public ActionResult Edit(Salesorder salesorder)
        {

            var salesordrInDb = _context.Salesorders.Single(s => s.Id == salesorder.Id);

            TryUpdateModel(salesordrInDb);
            _context.SaveChanges();

            //  return RedirectToAction("Index");
            return RedirectToAction("Index", "Salesorder");

        }
        public ActionResult UserEdit(int id)
        {
            var salesorder = _context.Salesorders.SingleOrDefault(x => x.Id == id);

            if (salesorder == null)
                return HttpNotFound();

            return View(salesorder);
        }

        [HttpPost]
        public ActionResult UserEdit(Salesorder salesorder)
        {
            var salesordrInDb = _context.Salesorders.Single(s => s.Id == salesorder.Id);

            TryUpdateModel(salesordrInDb);
            _context.SaveChanges();

            //  return RedirectToAction("Index");
            return RedirectToAction("IndexPending", "Salesorder");
        }


        // GET: Salesorder/Delete/5
        [Authorize(Roles = "CanManageSalesorders")]
        public ActionResult Delete(int id)
        {
            var salesorders = _context.Salesorders.SingleOrDefault(s => s.Id == id);

            if (salesorders == null)
            {
                return HttpNotFound();
            }
            return View(salesorders);
        }

        // POST: Salesorder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Salesorder salesorder = _context.Salesorders.Where(x => x.Id == id).FirstOrDefault();
                _context.Salesorders.Remove(salesorder);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Count()
        {
            var salesorder = new Salesorder();
            var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            return View(salesorder);
        }

        public ActionResult IndexCompleted(string option, string search)
        {
            var salesorders = _context.Salesorders.ToList();
            {
                return View(_context.Salesorders.Where(x => x.Completed == true).ToList());
            }
        }

        public ActionResult IndexReady(string option, string search)
        {
            var salesorders = _context.Salesorders.ToList();
            {
                return View(_context.Salesorders.Where(x => x.InTheModule == true && x.Completed!=true).ToList());
            }
        }

        public ActionResult IndexPending(string option, string search)
        {
            var salesorders = _context.Salesorders.ToList();
            {
                return View(_context.Salesorders.Where(x => x.Completed == false).ToList());
            }
        }

        [Authorize(Roles = "CanManageSalesorders")]
        public ActionResult ImportCSV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImportCSV(HttpPostedFileBase UploadedFile)
        {
            List<Salesorder> salesorders = new List<Salesorder>();
            string filePath = string.Empty;
            if (UploadedFile != null)
            {
                string path = Server.MapPath("~/ProjectBPU/Content/UploadedFiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(UploadedFile.FileName);
                string extension = Path.GetExtension(UploadedFile.FileName);
                UploadedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        salesorders.Add(new Salesorder
                        {
                            Date = Convert.ToDateTime(row.Split(',')[0]),
                            Module = row.Split(',')[1],
                            Style = row.Split(',')[2],
                            Salesorder_No = row.Split(',')[3],
                            Line_Item = (row.Split(',')[4]).TrimStart('0'),
                            Size = row.Split(',')[5],
                            Qty = Convert.ToInt32(row.Split(',')[6]),
                            Color = row.Split(',')[8]
                        });
                    }
                }
                //  using (DBModel excelImportDBEntities = new DBModel())
                {
                    foreach (var item in salesorders)
                    {
                        _context.Salesorders.Add(item);
                        _context.SaveChanges();
                        // excelImportDBEntities.Salesorders.Add(item);
                    }
                    //excelImportDBEntities.SaveChanges();
                    //_context.Salesorders.Add(item);
                    //_context.SaveChanges();

                }
            }
            return RedirectToAction("Index", "Salesorder");
        }
    }
}
