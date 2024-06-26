﻿using DAO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_CategoryProduct
    {
        private QLCPEntities db = new QLCPEntities();

        public void Add(DanhMucSanPham categoryProduct)
        {
            db.DanhMucSanPhams.Add(categoryProduct);
            db.SaveChanges();
        }

        public void Delete(DanhMucSanPham categoryProduct)
        {
            db.DanhMucSanPhams.Remove(categoryProduct);
            db.SaveChanges();
        }

        public List<DanhMucSanPham> GetAll()
        {
            return db.DanhMucSanPhams.ToList();
        }

        public DanhMucSanPham GetByID(int id)
        {
            return db.DanhMucSanPhams.Find(id);
        }

        public void Update(DanhMucSanPham categoryProduct)
        {
            DanhMucSanPham cp = db.DanhMucSanPhams.Find(categoryProduct.Ma);
            cp.Ten = categoryProduct.Ten;
            db.SaveChanges();
        }
    }
}