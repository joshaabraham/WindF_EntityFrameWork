using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameWork
{
    public partial class FormEmployeeProject : Form
    {
        EmployeProjetEntities empProjet = new EmployeProjetEntities();
        public FormEmployeeProject()
        {
            InitializeComponent();
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSauvegarder_Click(object sender, EventArgs e)
        {
            //Valider des donnees 

            Employe emp = new Employe();
            emp.NoEmploye = Convert.ToInt32(textBoxNoEmploye.Text);
            emp.Prenom = textBoxPrenom.Text;
            emp.Nom = textBoxNom.Text;
            emp.Telephone = textBoxTelephone.Text;
            emp.Courriel = textBoxCourriel.Text;
            empProjet.Employes.Add(emp);
            empProjet.SaveChanges();
            MessageBox.Show("Sauvegarde avec succes.");


        }

        private void buttonRechercher_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxNoEmploye.Text);

            //LINQ to entity
            var employe = (from emp in empProjet.Employes
                           where emp.NoEmploye == id
                           select emp).Single();
        }

        private void buttonAfficherEmp_Click(object sender, EventArgs e)
        {
            var listEmp = (from emp in empProjet.Employes
                           select emp).ToList();
            dataGridViewEmploye.DataSource = listEmp;
            dataGridViewEmploye.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
