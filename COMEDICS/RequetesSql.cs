using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMEDICS
{
    class RequetesSql
    {
        DataTable dt = new DataTable();
        public static OracleConnection connexionBaseEXT = OpenConnexion_EXT();
        public static OracleConnection connexionBaseINT = OpenConnexion_INT();

        public static OracleConnection OpenConnexion_EXT()
        {
            try
            {
                String connexionIdentifiant = "Data Source =TRA_REFERENCE_01_R;User Id=OTALCHR;Password=OTALCHR";
                OracleConnection connexion = new OracleConnection(connexionIdentifiant);
                return connexion;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
                return null;
            }
        }

        public static OracleConnection OpenConnexion_INT()
        {
            try
            { 
                String connexionIdentifiant = "Data Source =TRA_SOCLE_01_R;User Id=AG_INST_DATA;Password=AG_INST_DATA";
                OracleConnection connexion = new OracleConnection(connexionIdentifiant);
                return connexion;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message.ToString());
                return null;
            }
        }


        public static DataTable Recherche_EXT(string prenom, string nom, string nomMarital, string cpltTitre, string specialite, string commune, string cp, string apicrypt, string rpps, string datecrea)
        {
            string rsql = @"SELECT p.MED_NOM as Nom , p.MED_PREN as Prénom, p.MEDNOM_EP as Nom_marital, p.MEDCPLT_TITRE as Complément_titre, p.MED_SPEC as spécialité, p.MEDADR_CO as commune, p.MEDADR_CP as Code_postal, p.MEDADR_L1 as Adresse, p.MEDADR_PAYS as Pays , p.rpps as RPPS, p.MED_TITRE as Titre
            FROM CORR_MED_EXT p
            WHERE ";

            if (prenom != null && prenom != "")
            {
                rsql += "p.MED_PREN Like '%"+prenom+"%' AND ";
            }


            if ((nom != "") && (nomMarital != "")) //si nom et nom ep sont remplis
            {
                rsql += "(p.MED_NOM Like '%"+nom+"%' AND p.MEDNOM_EP Like '%"+nomMarital+"%') AND ";

            }

            if ((nom != "") && (nomMarital == "")) // si nom saisi et nom ep vide 
            {
                rsql += "p.MED_NOM Like '%"+nom+"%' OR p.MEDNOM_EP Like '%"+nom+"%' AND ";
            }

            if (cpltTitre != null && cpltTitre != "")
            {
                string cpltTitreFormat =   cpltTitre.Replace("'", "''");
                rsql += "p.MEDCPLT_TITRE Like '%"+cpltTitreFormat+"%' AND ";
            }

            if (specialite != null && specialite != "")
            {
                rsql += "p.MED_SPEC Like '%"+specialite+"%' AND ";
            }

            if (commune != null && commune != "")
            {
                rsql += "p.MEDADR_CO Like '%"+commune+"%' AND ";
            }

            if (cp != null && cp != "")
            {
                rsql += "p.MEDADR_CP Like '%"+cp+"%' AND ";
            }

            if (apicrypt != null && apicrypt != "")
            {
                rsql += "p.ADRESSE_APICRYPT Like '%"+apicrypt+"%' AND ";
            }

            if (rpps != null && rpps != "")
            {
                rsql += "p.rpps Like '%"+rpps+"%' AND ";
            }


            string esql = rsql.Substring(0,rsql.Length-4);

            //esql += $@" order by(
            //    case
            //        when med_nom like '{nom}%' and med_pren like '{prenom}%' then '1'
            //        when med_nom like '%{nom}%' and med_pren like '{prenom}%' then '2' 
            //        when med_nom like '%{nom}%' and med_pren like '%{prenom}%' then '3'
            //        else '4' end)";

            //pour inclure prénom : si nom + prénom saisie lancer le code ci-dessus
            //si que prenom comme en dessous mais avec prenom

            esql += $@" order by(
                case
                    when med_nom like '{nom}%' then '1'
                    when med_nom like '%{nom}%'  then '2' 
                    when med_nom like '%{nom}%'  then '3'
                    else '4' end)";



            try
            {
                DataTable recuperationResultat = new DataTable();
                List<string> listeModification = new List<string>();
                connexionBaseEXT.Open();
                OracleCommand requeteAlice = new OracleCommand
                {
                    Connection = connexionBaseEXT,
                    CommandText = esql
                };

                var DataReader = requeteAlice.ExecuteReader();
                if (DataReader != null)
                {
                    if (DataReader.HasRows)
                    {
                        recuperationResultat.Load(DataReader);
                    }
                }

                return recuperationResultat;
            }
            catch (Exception exception)
            {
                connexionBaseEXT.Close();
                //Popup(exception.Message.ToString(), "Erreur", "OK", "WARN");
                System.Windows.Forms.MessageBox.Show(exception.Message.ToString());
                return null;
            }
            finally
            {
                connexionBaseEXT.Close();
            }
        }
       
        public static DataTable Recherche_INT(string prenom, string nom, string nomMarital, string cpltTitre, string specialite, string commune, string cp, string apicrypt, string rpps, string datecrea)
        {
            // REQ a adapter en fonction du modèle de données.
            //Voir le processus de recherche : 1er => récup des infos sur Socle, puis faire un pointeur pour table int ? 

            // ou tout simplement réaliser une vue qui récup déjà toutes les infos dont on a besoin.

            string rsql = @"SELECT p.MED_NOM as Nom , p.MED_PREN as Prénom, p.MEDNOM_EP as Nom_marital, p.MEDCPLT_TITRE as Complément_titre, p.MED_SPEC as spécialité, p.MEDADR_CO as commune, p.MEDADR_CP as Code_postal, p.MEDADR_L1 as Adresse, p.MEDADR_PAYS as Pays , p.rpps as RPPS, p.MED_TITRE as Titre
            FROM CORR_MED_EXT p
            WHERE ";

            if (prenom != null && prenom != "")
            {
                rsql += "p.MED_PREN Like '%" + prenom + "%' AND ";
            }


            if ((nom != "") && (nomMarital != "")) //si nom et nom ep sont remplis
            {
                rsql += "(p.MED_NOM Like '%" + nom + "%' AND p.MEDNOM_EP Like '%" + nomMarital + "%') AND ";

            }

            if ((nom != "") && (nomMarital == "")) // si nom saisi et nom ep vide 
            {
                rsql += "p.MED_NOM Like '%" + nom + "%' OR p.MEDNOM_EP Like '%" + nom + "%' AND ";
            }

            if (cpltTitre != null && cpltTitre != "")
            {
                string cpltTitreFormat = cpltTitre.Replace("'", "''");
                rsql += "p.MEDCPLT_TITRE Like '%" + cpltTitreFormat + "%' AND ";
            }

            if (specialite != null && specialite != "")
            {
                rsql += "p.MED_SPEC Like '%" + specialite + "%' AND ";
            }

            if (commune != null && commune != "")
            {
                rsql += "p.MEDADR_CO Like '%" + commune + "%' AND ";
            }

            if (cp != null && cp != "")
            {
                rsql += "p.MEDADR_CP Like '%" + cp + "%' AND ";
            }

            if (apicrypt != null && apicrypt != "")
            {
                rsql += "p.ADRESSE_APICRYPT Like '%" + apicrypt + "%' AND ";
            }

            if (rpps != null && rpps != "")
            {
                rsql += "p.rpps Like '%" + rpps + "%' AND ";
            }


            string esql = rsql.Substring(0, rsql.Length - 4);


            esql += $@" order by(
                case
                    when med_nom like '{nom}%' then '1'
                    when med_nom like '%{nom}%'  then '2' 
                    when med_nom like '%{nom}%'  then '3'
                    else '4' end)";



            try
            {
                DataTable recuperationResultat = new DataTable();
                List<string> listeModification = new List<string>();
                connexionBaseEXT.Open();
                OracleCommand requeteAlice = new OracleCommand
                {
                    Connection = connexionBaseEXT,
                    CommandText = esql
                };

                var DataReader = requeteAlice.ExecuteReader();
                if (DataReader != null)
                {
                    if (DataReader.HasRows)
                    {
                        recuperationResultat.Load(DataReader);
                    }
                }

                return recuperationResultat;
            }
            catch (Exception exception)
            {
                connexionBaseEXT.Close();
                //Popup(exception.Message.ToString(), "Erreur", "OK", "WARN");
                System.Windows.Forms.MessageBox.Show(exception.Message.ToString());
                return null;
            }
            finally
            {
                connexionBaseEXT.Close();
            }
        }


        public static Boolean Ajout_Ext(string Civilite, int sexe,string Nom, string Prenom, string NomEP, string cplt_titre,string spe,string rpps,string email,string pays,string adresse1,string adresse2,string adresse3,string adresse4,string adresse_loc,string CP,string Commune,string tel1,string tel2)
        {
            try
            {
                connexionBaseEXT.Open();
                OracleCommand InsertEXT = new OracleCommand
                {
                    Connection = connexionBaseEXT,
                    CommandText = $@" INSERT INTO CORR_MED_EXT(CORR_MAT,MED_TITRE,MED_SEXE,MED_NOM,MED_PREN,MEDNOM_EP,MEDCPLT_TITRE,MED_SPEC,
                                    RPPS,ADRESSE_APICRYPT,MEDADR_PAYS,MEDADR_L1,MEDADR_L2,MEDADR_L3,MEDADR_L4,
                                    MEDADR_LOC,MEDADR_CP,MEDADR_CO,TEL_PRINCIPAL,TEL_SECONDAIRE)VALUES(SEQ_CORR_MAT.nextval,'{Civilite}',{sexe},'{Nom.Replace("'", "''")}','{Prenom.Replace("'", "''")}','{NomEP.Replace("'", "''")}','{cplt_titre.Replace("'", "''")}',
                                       '{spe.Replace("'", "''")}','{rpps}','{email}','{pays.Replace("'", "''")}','{adresse1.Replace("'", "''")}','{adresse2.Replace("'", "''")}','{adresse3.Replace("'", "''")}','{adresse4.Replace("'", "''")}','{adresse_loc.Replace("'", "''")}','{CP}','{Commune.Replace("'", "''")}','{tel1.Replace("'", "''")}','{tel2.Replace("'", "''")}')"
                };
                int verificationUpdate = InsertEXT.ExecuteNonQuery();
                if (verificationUpdate > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception exception)
            {
                connexionBaseEXT.Close();
                System.Windows.Forms.MessageBox.Show(exception.Message.ToString());
                return false;
            }
            finally
            {
                connexionBaseEXT.Close();
            }
        }


    }
}
