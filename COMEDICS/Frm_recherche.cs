
using OutLook = Microsoft.Office.Interop.Outlook;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualEffects;
using VisualEffects.Animations.Effects;
using VisualEffects.Easing;


namespace COMEDICS
{
    public partial class Frm_recherche : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        public Frm_recherche()
        {
            InitializeComponent();
           // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        bool Recherche, Click_nom, Click_prenom, Click_nommarital, Click_cplt_titre, Click_spe, Click_Commune, ClickCP, Click_RPPS, Click_Apicrypt,Click_Dtae,Click_Fleche,Click_ID,Click_Adr,Click_Rens = false;
        DataTable resultatControle = new DataTable();
        private void cbx_cplt_titre_MouseEnter(object sender, EventArgs e)
        {
            ligne_cplt_titre.Visible = true;
            lbl_cplt_titre.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void cbx_cplt_titre_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_cplt_titre)
            {
                ligne_cplt_titre.Visible = false;
                lbl_cplt_titre.ForeColor = Color.Black;
                lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void cbx_cplt_titre_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = true;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_cplt_titre.Visible = true;
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 8);
            lbl_cplt_titre.ForeColor = Color.FromArgb(103, 201, 196);


            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_nommarital.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void cbx_spe_MouseEnter(object sender, EventArgs e)
        {
            ligne_spe.Visible = true;
            lbl_spe.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void cbx_spe_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_spe)
            {
                ligne_spe.Visible = false;
                lbl_spe.ForeColor = Color.Black;
                lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void cbx_spe_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = true;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_spe.Visible = true;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_nommarital.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_spe.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_spe.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void cbx_communes_MouseEnter(object sender, EventArgs e)
        {
            ligne_commune.Visible = true;
            lbl_commune.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void cbx_communes_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_Commune)
            {
                ligne_commune.Visible = false;
                lbl_commune.ForeColor = Color.Black;
                lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void cbx_communes_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = true;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_nommarital.Visible = false;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = true;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_commune.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_commune.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void txt_CP_MouseEnter(object sender, EventArgs e)
        {
            ligne_cp.Visible = true;
            lbl_cp.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void txt_CP_MouseLeave(object sender, EventArgs e)
        {
            if (!ClickCP)
            {
                ligne_cp.Visible = false;
                lbl_cp.ForeColor = Color.Black;
                lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void txt_CP_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = true;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_nommarital.Visible = false;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = true;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_cp.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_cp.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void txt_apicrypt_MouseLeave(object sender, EventArgs e)
        {
            
            if (!Click_Apicrypt)
            {
                ligne_apicrypt.Visible = false;
                lbl_apicrypt.ForeColor = Color.Black;
                lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            }

        }

        private void txt_apicrypt_MouseEnter(object sender, EventArgs e)
        {
            ligne_apicrypt.Visible = true;
            lbl_apicrypt.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void txt_apicrypt_MouseClick(object sender, MouseEventArgs e)
        {

            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = true;
            Click_Dtae = false;

            ligne_nommarital.Visible = false;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = true;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_apicrypt.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void txt_rpps_MouseEnter(object sender, EventArgs e)
        {
            ligne_rpps.Visible = true;
            lbl_rpps.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void txt_rpps_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_RPPS)
            {
                ligne_rpps.Visible = false;
                lbl_rpps.ForeColor = Color.Black;
                lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void txt_rpps_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = true;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_nommarital.Visible = false;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = true;
            lbl_date.Visible = true;

            lbl_rpps.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;


            lbl_rpps.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void dateTimePicker1_MouseEnter(object sender, EventArgs e)
        {
            ligne_date.Visible = true;
            lbl_date.ForeColor = Color.FromArgb(103, 201, 196);
        }

      

        private void dateTimePicker1_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_Dtae)
            {
                ligne_date.Visible = false;
                lbl_date.ForeColor = Color.Black;
                lbl_date.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

      

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = true;

            ligne_nommarital.Visible = false;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = true;

            lbl_date.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;

            lbl_date.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void Frm_recherche_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = GetRoundRect(0.0f, 0.0f, 1300.0f, 580.0f, 20.0f);
            dtgv_search.Region = new Region(gp);
            lbl_Ext.Visible = false;
            
           

            Click_ID = true;
            Click_Adr = false;
            Click_Rens = false;
            panel_id.Size = new Size(365, 324);
            panel_rens.Size = new Size(365, 50);
            panel_adr.Size = new Size(365, 50);

            panel_id.Location = new Point(19, 81);
            panel_rens.Location = new Point(19, 430);//156 + 274
            panel_adr.Location = new Point(19, 505);//231 +310
       
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void lbl_id_Click(object sender, EventArgs e)
        {
            if (Click_ID)
            {
                Click_ID = false;

                // panel_id.Size = new Size(365, 50); //81
                panel_id.Animate
             (
                 new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                 EasingFunctions.CircEaseOut, //.BackEaseIn
                 50, //value to reach
                 400, //animation duration in milliseconds
                 0 //delayed start in milliseconds
             );

                panel_id.Location = new Point(19, 81);//81
                panel_rens.Location = new Point(19, 156);//156
                panel_adr.Location = new Point(19, 231);//231

                panel_id.BackColor = Color.FromArgb(225, 246, 245);
            }
            else
            {
                Click_ID = true;
                Click_Adr = false;
                Click_Rens = false;
                // panel_id.Size = new Size(365, 324); 
                panel_id.Animate
              (
                  new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                  EasingFunctions.CircEaseOut, //.BackEaseIn
                  324, //value to reach
                  400, //animation duration in milliseconds
                  0 //delayed start in milliseconds
              );
                panel_rens.Size = new Size(365, 50);
                panel_adr.Size = new Size(365, 50);

                panel_id.Location = new Point(19, 81);
                panel_rens.Location = new Point(19, 430);//156 + 274
                panel_adr.Location = new Point(19, 505);//231 +310
                                                        // panel1.BackColor = Color.White;

            }
        }

        private void panel_id_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Rechercher(txt_prenom.Text,txt_nom.Text,txt_nommarital.Text,cbx_cplt_titre.SelectedText,cbx_spe.SelectedText,cbx_communes.SelectedText,txt_CP.Text,txt_apicrypt.Text,txt_rpps.Text,date_datecrea.Value.ToString());
            




            //////// GRAPHICS /////////
            dtgv_search.Visible = true;
            pict_Ext.Visible = true;
            pict_Int.Visible = true;
            lbl_int.Visible = true;
            lbl_Ext.Visible = true;
            Click_Fleche = true;
            sPanel1.AutoScroll = false;
            panel_illu.BackgroundImage = null;
            panel_vert.Size = new Size(476, 926);
            panel_illu.Size = new Size(1379, 926);
            dtgv_search.Size = new Size(1300, 580);

            pict_adr_white.Visible = true;
            pict_id_white.Visible = true;
            pict_rens_white.Visible = true;
            panel_vert.Animate
           (
               new XLocationEffect(), //effect to apply implementing IEffect
               EasingFunctions.BounceEaseOut, //easing to apply
               -421, //value to reach
               500, //animation duration in milliseconds
               0 //delayed start in milliseconds
           );
            panel_illu.Animate
          (
              new XLocationEffect(), //effect to apply implementing IEffect
              EasingFunctions.BounceEaseOut, //easing to apply
              43, //value to reach
              500, //animation duration in milliseconds
              0 //delayed start in milliseconds
          );
            dtgv_search.Animate //469; 103
          (
              new XLocationEffect(), //effect to apply implementing IEffect
              EasingFunctions.BounceEaseOut, //easing to apply
              73, //value to reach
              500, //animation duration in milliseconds
              0 //delayed start in milliseconds
          );



        }

        private void dtgv_search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl_rens_Click(object sender, EventArgs e)
        {
            if (Click_Rens) //repli
            {
                Click_Rens = false;

                //panel_rens.Size = new Size(365, 50); //81
                panel_rens.Animate
            (
                new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                EasingFunctions.CircEaseOut, //.BackEaseIn
                50, //value to reach
                400, //animation duration in milliseconds
                0 //
                );
                
                panel_id.Location = new Point(19, 81);//81
                panel_rens.Location = new Point(19, 156);//156
                panel_adr.Location = new Point(19, 231);//231

                panel_id.BackColor = Color.FromArgb(225, 246, 245);
            }
            else //depli
            {
                Click_Rens = true;
                Click_Adr = false;
                Click_ID = false;

                panel_id.Size = new Size(365, 50); 
               // panel_rens.Size = new Size(365, 324);
                panel_adr.Size = new Size(365, 50);
                panel_rens.Animate
            (
                new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                EasingFunctions.CircEaseOut, //.BackEaseIn
                324, //value to reach
                400, //animation duration in milliseconds
                0 //delayed start in milliseconds
            );


                panel_id.Location = new Point(19, 81);
                panel_rens.Location = new Point(19, 156);
                panel_adr.Location = new Point(19, 505);
                                                        // panel1.BackColor = Color.White;
            }
        }

      
        private void lbl_adr_Click(object sender, EventArgs e)
        {
            if (Click_Adr) //repli
            {
                Click_Adr = false;

                // panel_adr.Size = new Size(365, 50); //81
                panel_adr.Animate
             (
                 new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                 EasingFunctions.CircEaseOut, //.BackEaseIn
                 50, //value to reach
                 400, //animation duration in milliseconds
                 0 //delayed start in milliseconds
             );

                panel_id.Location = new Point(19, 81);//81
                panel_rens.Location = new Point(19, 156);//156
                panel_adr.Location = new Point(19, 231);//231

                panel_id.BackColor = Color.FromArgb(225, 246, 245);
            }
            else //depli
            {
                Click_Adr = true;
                Click_Rens = false;
                Click_ID = false;

                panel_id.Size = new Size(365, 50);
                panel_rens.Size = new Size(365, 50);
                panel_adr.Animate
             (
                 new TopAnchoredHeightEffect(), //TopAnchoredHeightEffect(),
                 EasingFunctions.CircEaseOut, //.BackEaseIn
                 295, //value to reach
                 400, //animation duration in milliseconds
                 0 //delayed start in milliseconds
             );
               // panel_adr.Size = new Size(365, 324);


                panel_id.Location = new Point(19, 81);
                panel_rens.Location = new Point(19, 156);
                panel_adr.Location = new Point(19, 231);
                // panel1.BackColor = Color.White;
            }
        }

        private void pict_id_white_Click(object sender, EventArgs e)
        {
            if (Recherche)
            {
                Frm_ajout Newco = new Frm_ajout();
                Newco.Show();
            }
            else MessageBox.Show("Veuillez faire une recherche avant de créer un Correspondant");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Outlook();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Click_Fleche)
            {
                Click_Fleche = false;
                sPanel1.AutoScroll = true;
                pict_adr_white.Visible = false;
                pict_id_white.Visible = false;
                pict_rens_white.Visible = false;
                panel_illu.Size = new Size(958, 926); //958;926
                dtgv_search.Size = new Size(891, 582);
                pictureBox2.Location = new Point(862, 752);


                panel_vert.Animate
               (
                   new XLocationEffect(), //effect to apply implementing IEffect
                   EasingFunctions.BounceEaseOut, //easing to apply
                   0, //value to reach
                   1000, //animation duration in milliseconds
                   0 //delayed start in milliseconds
               );

                panel_illu.Animate
              (
                  new XLocationEffect(), //effect to apply implementing IEffect
                  EasingFunctions.BounceEaseOut, //easing to apply
                  444, //value to reach
                  1000, //animation duration in milliseconds
                  0 //delayed start in milliseconds
              );
                dtgv_search.Animate//469; 103
             (
                 new XLocationEffect(), //effect to apply implementing IEffect
                 EasingFunctions.BounceEaseOut, //easing to apply
                 469, //value to reach
                 1000, //animation duration in milliseconds
                 0 //delayed start in milliseconds
             );
                //pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                //pictureBox1.Refresh();

            }
            else
            {
                Click_Fleche = true;
                sPanel1.AutoScroll = false;
                panel_vert.Size = new Size(476,926);
                panel_illu.Size = new Size(1379, 926);
                dtgv_search.Size = new Size(1300, 580);
                pictureBox2.Location = new Point(1250, 748);

                pict_adr_white.Visible = true;
                pict_id_white.Visible = true;
                pict_rens_white.Visible = true;
                panel_vert.Animate
               (
                   new XLocationEffect(), //effect to apply implementing IEffect
                   EasingFunctions.BounceEaseOut, //easing to apply
                   -421, //value to reach
                   2000, //animation duration in milliseconds
                   0 //delayed start in milliseconds
               );
                panel_illu.Animate
              (
                  new XLocationEffect(), //effect to apply implementing IEffect
                  EasingFunctions.BounceEaseOut, //easing to apply
                  43, //value to reach
                  2000, //animation duration in milliseconds
                  0 //delayed start in milliseconds
              );
                dtgv_search.Animate //469; 103
              (
                  new XLocationEffect(), //effect to apply implementing IEffect
                  EasingFunctions.BounceEaseOut, //easing to apply
                  73, //value to reach
                  2000, //animation duration in milliseconds
                  0 //delayed start in milliseconds
              );


            }

            
          
        }

        private void txt_nommarital_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = false;
            Click_nommarital = true;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;
   
            ligne_nommarital.Visible = true;
            ligne_nom.Visible = false;
            ligne_prenom.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_nommarital.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_prenom.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void txt_nommarital_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_nommarital)
            {
                ligne_nommarital.Visible = false;
                lbl_nommarital.ForeColor = Color.Black;
                lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void txt_nommarital_MouseEnter(object sender, EventArgs e)
        {
            ligne_nommarital.Visible = true;
            lbl_nommarital.ForeColor = Color.FromArgb(103, 201, 196);
        }

        private void txt_prenom_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = true;
            Click_nom = false;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_prenom.Visible = true;
            ligne_nom.Visible = false;
            ligne_nommarital.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_prenom.ForeColor = Color.FromArgb(103, 201, 196);
            lbl_nom.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;

            lbl_prenom.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void txt_prenom_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_prenom)
            {
                ligne_prenom.Visible = false;
                lbl_prenom.ForeColor = Color.Black;
                lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void txt_prenom_MouseEnter(object sender, EventArgs e)
        {
            ligne_prenom.Visible = true;
            lbl_prenom.ForeColor = Color.FromArgb(103, 201, 196);
        }



        private void txt_nom_MouseEnter(object sender, EventArgs e)
        {
            ligne_nom.Visible = true;
            lbl_nom.ForeColor = Color.FromArgb(103,201,196);
        }

        private void txt_nom_MouseLeave(object sender, EventArgs e)
        {
            if (!Click_nom)
            {
                ligne_nom.Visible = false;
                lbl_nom.ForeColor = Color.Black;
                lbl_nom.Font = new Font("Microsoft Sans Serif", 10);
            }
        }

        private void txt_nom_MouseClick(object sender, MouseEventArgs e)
        {
            Click_prenom = false;
            Click_nom = true;
            Click_nommarital = false;
            Click_cplt_titre = false;
            Click_spe = false;
            Click_Commune = false;
            ClickCP = false;
            Click_RPPS = false;
            Click_Apicrypt = false;
            Click_Dtae = false;

            ligne_nom.Visible = true;
            lbl_nom.Font = new Font("Microsoft Sans Serif", 8);
            lbl_nom.ForeColor = Color.FromArgb(103, 201, 196);

            ligne_prenom.Visible = false;
            ligne_nommarital.Visible = false;
            ligne_cplt_titre.Visible = false;
            ligne_spe.Visible = false;
            ligne_commune.Visible = false;
            ligne_cp.Visible = false;
            ligne_apicrypt.Visible = false;
            ligne_rpps.Visible = false;
            ligne_date.Visible = false;

            lbl_prenom.ForeColor = Color.Black;
            lbl_nommarital.ForeColor = Color.Black;
            lbl_apicrypt.ForeColor = Color.Black;
            lbl_commune.ForeColor = Color.Black;
            lbl_cp.ForeColor = Color.Black;
            lbl_cplt_titre.ForeColor = Color.Black;
            lbl_rpps.ForeColor = Color.Black;
            lbl_spe.ForeColor = Color.Black;
            lbl_date.ForeColor = Color.Black;
            
            
            lbl_prenom.Font = new Font("Microsoft Sans Serif", 10);
            lbl_nommarital.Font = new Font("Microsoft Sans Serif", 10);
            lbl_apicrypt.Font = new Font("Microsoft Sans Serif", 10);
            lbl_commune.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cp.Font = new Font("Microsoft Sans Serif", 10);
            lbl_cplt_titre.Font = new Font("Microsoft Sans Serif", 10);
            lbl_rpps.Font = new Font("Microsoft Sans Serif", 10);
            lbl_spe.Font = new Font("Microsoft Sans Serif", 10);
            lbl_date.Font = new Font("Microsoft Sans Serif", 10);


        }
              
            public void Rechercher(string prenom, string nom, string nomMarital, string cpltTitre, string specialite, string commune, string cp, string apicrypt, string rpps, string datecrea)
        {
            int nb_ext = 0;
            
        try
            {
                dtgv_search.DataSource = null;
                dtgv_search.Refresh();
                /*requete recuperation resultats*/
                resultatControle = RequetesSql.Recherche_EXT(prenom,  nom,  nomMarital,  cpltTitre,  specialite,  commune,  cp,  apicrypt,  rpps,  datecrea);
                if (resultatControle.Rows.Count != 0)
                {
                    Recherche = true;
                    pict_Ext.Image = Properties.Resources.tab_white;
                    lbl_Ext.ForeColor = Color.Black;
                    lbl_Ext.BackColor = Color.White;
                    lbl_Ext.Font = new System.Drawing.Font("Avenir LT Std 55 Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    dtgv_search.DataSource = resultatControle;
                    nb_ext = dtgv_search.RowCount;
                    dtgv_search.Columns[0].Width = 100;
                    dtgv_search.Columns[1].Width = 100;
                    dtgv_search.Columns[2].Width = 100;
                    dtgv_search.Columns[3].Width = 130;
                    dtgv_search.Columns[4].Width = 160;
                    dtgv_search.Columns[5].Width = 150;
                    dtgv_search.Columns[6].Width = 70;
                    dtgv_search.Columns[7].Width = 170;
                    dtgv_search.Columns[8].Width = 140;
                    dtgv_search.Columns[9].Width = 110;
                    dtgv_search.Columns[10].Width = 90;

                    dtgv_search.Columns[0].HeaderText = "Nom";
                    dtgv_search.Columns[1].HeaderText = "Prénom";
                    dtgv_search.Columns[2].HeaderText = "Nom Ep";
                    dtgv_search.Columns[3].HeaderText = "C. Titre";
                    dtgv_search.Columns[4].HeaderText = "Spécialité";
                    dtgv_search.Columns[5].HeaderText = "Commune";
                    dtgv_search.Columns[6].HeaderText = "CP";
                    dtgv_search.Columns[7].HeaderText = "Adresse";
                    dtgv_search.Columns[8].HeaderText = "Pays";
                    dtgv_search.Columns[9].HeaderText = "RPPS";
                    dtgv_search.Columns[10].HeaderText = "Titre";

                    if(nb_ext > 1)
                    {
                        lbl_Ext.Text = "Externes "  + nb_ext +"";
                    }else if(nb_ext < 1)
                        lbl_Ext.Text = "Externe "  + nb_ext +"";
                }
                    else
                    {
                    //Popup(getResourcesString("ErreurADM"), "Erreur", "OK", "WARN");
                    MessageBox.Show("Aucun correspondant(s) trouvé(s)");
                    }

               
            }
            catch (System.Exception exception)
            {
                //  Popup(exception.Message.ToString(), "Erreur", "OK", "WARN");
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {

            }
        }

        public void Rechercher_Int(string prenom, string nom, string nomMarital, string cpltTitre, string specialite, string commune, string cp, string apicrypt, string rpps, string datecrea)
        {
            int nb_int = 0;
            try
            {
                dtgv_search.DataSource = null;
                dtgv_search.Refresh();
                /*requete recuperation resultats*/
               // resultatControle = RequetesSql.Recherche_INT(prenom, nom, nomMarital, cpltTitre, specialite, commune, cp, apicrypt, rpps, datecrea);
                if (resultatControle.Rows.Count != 0)
                {

                    dtgv_search.DataSource = resultatControle;
                    nb_int = dtgv_search.RowCount;
                    dtgv_search.Columns[0].Width = 100;
                    dtgv_search.Columns[1].Width = 100;
                    dtgv_search.Columns[2].Width = 100;
                    dtgv_search.Columns[3].Width = 130;
                    dtgv_search.Columns[4].Width = 160;
                    dtgv_search.Columns[5].Width = 150;
                    dtgv_search.Columns[6].Width = 70;
                    dtgv_search.Columns[7].Width = 170;
                    dtgv_search.Columns[8].Width = 140;
                    dtgv_search.Columns[9].Width = 110;
                    dtgv_search.Columns[10].Width = 90;

                    dtgv_search.Columns[0].HeaderText = "Nom";
                    dtgv_search.Columns[1].HeaderText = "Prénom";
                    dtgv_search.Columns[2].HeaderText = "Nom Ep";
                    dtgv_search.Columns[3].HeaderText = "C. Titre";
                    dtgv_search.Columns[4].HeaderText = "Spécialité";
                    dtgv_search.Columns[5].HeaderText = "Commune";
                    dtgv_search.Columns[6].HeaderText = "CP";
                    dtgv_search.Columns[7].HeaderText = "Adresse";
                    dtgv_search.Columns[8].HeaderText = "Pays";
                    dtgv_search.Columns[9].HeaderText = "RPPS";
                    dtgv_search.Columns[10].HeaderText = "Titre";

                    if (nb_int > 1)
                    {
                        lbl_Ext.Text = "Internes ( " + nb_int + " )";
                    }
                    else if (nb_int < 1)
                        lbl_Ext.Text = "Interne (" + nb_int + ")";
                }
                else
                {
                    //Popup(getResourcesString("ErreurADM"), "Erreur", "OK", "WARN");
                    MessageBox.Show("Aucun correspondant(s) trouvé(s)");
                }


            }
            catch (System.Exception exception)
            {
                //  Popup(exception.Message.ToString(), "Erreur", "OK", "WARN");
                MessageBox.Show(exception.Message.ToString());
            }
            finally
            {

            }
        }

        public GraphicsPath GetRoundRect(float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        public static void Outlook ()
        {
            Microsoft.Office.Interop.Outlook.Application Application = null;
            // Si aucun processus n'est détecté, on crée une nouvelle instance d'Outlook avec les logs d'un profil par défaut

            OutLook._Application outlookObj = new OutLook.Application();

            OutLook.NameSpace MSO_Namespace = Application.GetNamespace("MAPI");
            MSO_Namespace.Logon("dylan.huart@chru-lille.fr", "134697oki", Missing.Value, Missing.Value);      // Variable de log outlook UserID et Password
            MSO_Namespace = null;
            OutLook.MAPIFolder BoiteReception =
               Application.ActiveExplorer().Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);


            OutLook.Items Mail_Unread = BoiteReception.Items.Restrict("[Unread]=true");
            MessageBox.Show(("Nombre de mail non lus : {0}" + Mail_Unread.Count));
        }

    }
}
