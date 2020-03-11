using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMEDICS
{
    public partial class Frm_ajout : Form
    {
        int sexe = 0;
        public Frm_ajout()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            if (txt_nom.Text == "" || txt_pays.Text == "" || txt_adresse1.Text == "" || txt_CP.Text == "" || cbx_communes.Text == "")
            {
                MessageBox.Show("Merci de remplir tous les champs obligatoires");
            }
            else
            {

                bool retourConfirmation = RequetesSql.Ajout_Ext(cbx_civilite.Text,sexe, txt_nom.Text, txt_prenom.Text, txt_nommarital.Text, cbx_cplt_titre.Text, cbx_spe.Text, txt_rpps.Text, txt_apicrypt.Text, txt_pays.Text, txt_adresse1.Text, txt_adresse2.Text, txt_adresse3.Text, txt_adresse4.Text, txt_adresseloc.Text, txt_CP.Text, cbx_communes.Text, txt_tel1.Text, txt_tel2.Text);
                if (retourConfirmation != false)
                {
                    MessageBox.Show("Enregistrement effectué");
                }
                else
                {
                    MessageBox.Show("Erreur");
                }
            }
        }

        private void cbx_civilite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_civilite.Text == "M.")
            {
                txt_sexe.Text = "Masculin";
                sexe = 1;
            }
            else if (cbx_civilite.Text == "Mme")
            {
                txt_sexe.Text = "Féminin";
                sexe = 2;
            }
            else if (cbx_civilite.Text == "")
            {
                txt_sexe.Text = "";
                sexe = 0;
            }
        }
    }
}
