﻿using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinformWithEntity
{
    public partial class GUI_Product : Form
    {
        private BUS_CategoryProduct busCategoryProduct = new BUS_CategoryProduct();
        private BUS_Product busProduct = new BUS_Product();
        private int selectedProductID = 0;

        public GUI_Product()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                if (MessageBox.Show("Xác nhận thêm", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SanPham newProduct = new SanPham
                    {
                        Ten = txtName.Text,
                        MaDM = (int)cboCategoryProduct.SelectedValue,
                        DonGia = (int)numPrice.Value
                    };
                    busProduct.Add(newProduct);
                    UpdateDgv(busProduct.GetAll());
                    MessageBox.Show("Thêm thành công!");
                }
            }
            else MessageBox.Show("Vui lòng nhập tên sản phẩm!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xoá", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busProduct.Delete(selectedProductID))
                {
                    UpdateDgv(busProduct.GetAll());
                    MessageBox.Show("Xoá thành công!");
                }
                else MessageBox.Show("Vui lòng chọn đồ ăn!", "Thao tác không hợp lệ");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                if (MessageBox.Show("Xác nhận sửa", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SanPham product = new SanPham
                    {
                        Ma = selectedProductID,
                        Ten = txtName.Text,
                        MaDM = (int)cboCategoryProduct.SelectedValue,
                        DonGia = (int)numPrice.Value
                    };
                    if (busProduct.Update(product))
                    {
                        UpdateDgv(busProduct.GetAll());
                        MessageBox.Show("Sửa thành công!");
                    }
                    else MessageBox.Show("Vui lòng chọn đồ ăn!", "Thao tác không hợp lệ");
                }
            }
            else MessageBox.Show("Vui lòng nhập tên đồ ăn!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtName.Clear();
            cboCategoryProduct.SelectedIndex = 0;
            numPrice.Value = 0;
            UpdateDgv(busProduct.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateDgv(busProduct.SearchProductsByName(txtSearch.Text));
        }

        private void cboCategoryProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDgv(busProduct.SearchProductsByCategory(Convert.ToInt32(cboCategoryProduct.SelectedValue)).ToList());
            }
            catch { };
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedProductID = (int)dgvProduct[0, e.RowIndex].Value;
                SanPham p = busProduct.GetByID(selectedProductID);
                txtName.Text = p.Ten;
                cboCategoryProduct.SelectedValue = p.MaDM;
                numPrice.Value = p.DonGia;
            }
            catch { }
        }

        private void GUI_Product_Load(object sender, EventArgs e)
        {
            cboCategoryProduct.DataSource = busCategoryProduct.GetAll();
            cboCategoryProduct.ValueMember = "Ma";
            cboCategoryProduct.DisplayMember = "Ten";
            UpdateDgv(busProduct.GetAll());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void UpdateDgv(List<SanPham> productList)
        {
            dgvProduct.DataSource = productList.Select(x => new { x.Ma, x.Ten, TenDanhMuc = x.DanhMucSanPham.Ten, x.DonGia }).ToList();
        }
    }
}