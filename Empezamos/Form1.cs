﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Empezamos
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        void cargartabla()
        {
            SqlDataAdapter da = new SqlDataAdapter("SV_LisProveedor", varpublic.conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            da.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargartabla();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdnuevo_Click(object sender, EventArgs e)

        {
            dataGridView1.Enabled = false;
            cmdactualizar.Enabled = false;
            cmdgrabar.Enabled = true;
            
            
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                    
                }

            }
            txtcodigo.Select();
        }

        private void cmdgrabar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            if (txtrazon.Text==""||txtdireccion.Text==""||txtruc.Text==""||txttelefono.Text=="")
            {
                MessageBox.Show("ingrese los datos que falta");
            }
            else
            {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_InsProveedor '" + txtrazon.Text.ToUpper() + "','" + txtdireccion.Text.ToUpper() + "','" + txtruc.Text + "','" + txttelefono.Text + "','" + txtweb.Text + "','" + txtemail.Text + "'", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cargartabla();
                MessageBox.Show("Registro insertado exitosamente");

            }
            catch 
            {
                MessageBox.Show("Error, no se inserto registro");
            }
}
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtcodigo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                txtrazon.Text  = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtdireccion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtruc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txttelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                txtweb.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                txtemail.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            }
            catch 
            { }
        }

        private void cmdactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SV_UpProveedor '" + txtcodigo.Text + "','" + txtrazon.Text.ToUpper() + "','" + txtdireccion.Text.ToUpper() + "','" + txtruc.Text + "','" + txttelefono.Text + "','" + txtweb.Text + "','" + txtemail.Text + "'", varpublic.conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cargartabla();
                MessageBox.Show("Registro actualizado exitosamente");
            }
            catch
            {
                MessageBox.Show("Error, no se actualizó registro");
            }
        }
    }
}
