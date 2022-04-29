using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vista
{
    public partial class Form1 : Form
    {

        private CD_Producto objetoCN = new();
         private string IdProd;
        private bool editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leerprod();
        }
        private void LeerProducto()
        {
             CD_Producto objeto = new();

            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtEsta.Clear();
            txtDesc.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (editar==false)
            {
                try {
                    objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtExis.Text, txtPrec.Text, txtEsta.Text);
                    MessageBox.Show("Registro insertado exitosamente");
                    LeerProducto();
                    LimpiarForm();
                } catch (Exception ex) {
                    MessageBox.Show("registro no puede ser insertado, el motivo es:" + ex);
                
                }
            }
            if (editar==true)
            {
                try {
                    objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtExis.Text, txtPrec.Text, txtEsta.Text);
                } catch (Exception ex) {
                    MessageBox.Show("registro no pudo ser actualizado. el motivo es:" + ex);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtProd.Text = dataGridView1.CurrentRow.Cells["nomprod"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["cantida"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                txtProd.Text = dataGridView1.CurrentRow.Cells["idproducto"].Value.ToString();



            }
            else
            {
                MessageBox.Show("Favor selecionar una fila");

            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                IdProd = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                objetoCN.EliProd(IdProd);
                MessageBox.Show("Eliminado correctamente");
                LeerProducto();
            }
            else
            {
                MessageBox.Show("seleccione una fila por favor");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
