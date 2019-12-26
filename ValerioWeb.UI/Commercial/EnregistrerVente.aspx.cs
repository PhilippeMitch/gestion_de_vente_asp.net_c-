using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Commercial
{
    public partial class EnregistrerVente : System.Web.UI.Page
    {
        vente vt = null;
        decimal montant_final;
        string nom_user;
        public void Verifier_Roles()
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(nom_user, "EnregistrerVente.aspx");
                if (util != null)
                {
                    Master.ContentTextBoxOfMasterPage = nom_user;
                    if (!Page.IsPostBack)
                    {
                        SetInitialRow();
                    }
                }
                else
                {
                    Response.Redirect("../Erreur.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Verifier_Session()
        {

            #region Verifier connexion
            ConnexionUser conse = null;
            try
            {
                conse = ConnexionUserControleur.Verifier_Session(nom_user);
                if (conse == null)
                {
                    Server.Transfer("../Login.aspx");
                }
                else
                {
                    Verifier_Roles();
                }
            }
            catch (Exception)
            {

            }
            #endregion
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            ///lblmessage.Text = cli.Id_client.ToString();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["Column7"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtNumVente");
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtCodeArt");
                        TextBox box3 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtQuantite");
                        TextBox box4 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtPx");
                        TextBox box5 = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtEstimation");
                        TextBox box6 = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtRabais");
                        TextBox box7 = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("txtMontant");
                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box5.Text = dt.Rows[i]["Column5"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        box7.Text = dt.Rows[i]["Column7"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number 
                        TextBox box7 = (TextBox)GridView2.Rows[rowID].Cells[7].FindControl("txtMontant");
                        txtmontant.Text = (Convert.ToDecimal(txtmontant.Text)-Convert.ToDecimal(box7.Text)).ToString();
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }
                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data  
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            //Set Previous Data on Postbacks  
            SetPreviousData();
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        protected void ButtonRemove_Click(object sender, GridViewDeleteEventArgs e)
        {
            AddNewRowToGrid();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    txtnomclient.Text = "remo";
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    for (int i = 0; i < GridView2.Rows.Count - 1; i++)
                    {
                        GridView2.Rows[i].Cells[0].Text = Convert.ToString(i + 1);               
                    }
                    SetPreviousData();
                }
            }
        }
        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("btnannuler");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;  
            decimal estimation;
            Boolean bind = true;
            decimal montant;
            decimal rabais;
            Random ale = new Random();                    
            image_article art = null;
            if (string.IsNullOrEmpty(txtidvente.Text))
            {
                txtidvente.Text = string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
            }
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   
                    ViewState["CurrentTable"] = dtCurrentTable;
                    for (int i = 1; i <= dtCurrentTable.Rows.Count-1; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtNumVente");
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtCodeArt");
                       try
                       {
                            art = articleControleur.Verifier_Prix_Quantite_Article(box2.Text);
                            if(art!=null)
                            {
                                TextBox box3 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtQuantite");
                                if(Convert.ToInt32(box3.Text)>=art.Qte_enstock)
                                {                                   
                                    lblmessage.Text = "Quantite en Stock non sufisant!";
                                    lblmessage.ForeColor = System.Drawing.Color.Orange;
                                    bind = false;
                                    i = i - 1;                                                                       
                                }
                                else
                                {
                                    bind = true;
                                    lblmessage.Text = "";
                                    TextBox box4 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtPx");
                                    TextBox box5 = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtEstimation");
                                    TextBox box6 = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtRabais");
                                    TextBox box7 = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("txtMontant");
                                    estimation = art.Px_vente * Convert.ToDecimal(box3.Text);                                   
                                    if(Convert.ToInt32(box3.Text)<=20 && Convert.ToInt32(box3.Text)>=10)
                                    {
                                        rabais = estimation * Convert.ToDecimal(0.02);
                                        dtCurrentTable.Rows[i - 1]["Column6"] = rabais;
                                        montant = estimation - rabais;
                                        montant_final = montant + montant_final;
                                        txtmontant.Text = montant_final.ToString();
                                        dtCurrentTable.Rows[i - 1]["Column7"] = montant;
                                        drCurrentRow = dtCurrentTable.NewRow();
                                        drCurrentRow["RowNumber"] = i + 1;
                                        dtCurrentTable.Rows[i - 1]["Column1"] = txtidvente.Text;
                                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                                        dtCurrentTable.Rows[i - 1]["Column4"] = art.Px_vente;
                                        dtCurrentTable.Rows[i - 1]["Column5"] = estimation;
                                    }
                                    else if(Convert.ToInt32(box3.Text) <= 40 && Convert.ToInt32(box3.Text) >= 21)
                                    {
                                        rabais = estimation * Convert.ToDecimal(0.03);
                                        dtCurrentTable.Rows[i - 1]["Column6"] = rabais;
                                        montant = estimation - rabais;
                                        montant_final = montant + montant_final;
                                        txtmontant.Text = montant_final.ToString();
                                        dtCurrentTable.Rows[i - 1]["Column7"] = montant;
                                        drCurrentRow = dtCurrentTable.NewRow();
                                        drCurrentRow["RowNumber"] = i + 1;
                                        dtCurrentTable.Rows[i - 1]["Column1"] =txtidvente.Text;
                                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                                        dtCurrentTable.Rows[i - 1]["Column4"] = art.Px_vente;
                                        dtCurrentTable.Rows[i - 1]["Column5"] = estimation;
                                    }
                                    else if (Convert.ToInt32(box3.Text)<20)
                                    {
                                        rabais = estimation * Convert.ToDecimal(0.04);
                                        dtCurrentTable.Rows[i - 1]["Column6"] = rabais;
                                        montant = estimation - rabais;
                                        montant_final = montant + montant_final;
                                        txtmontant.Text = montant_final.ToString();
                                        dtCurrentTable.Rows[i - 1]["Column7"] = montant;
                                        drCurrentRow = dtCurrentTable.NewRow();
                                        drCurrentRow["RowNumber"] = i + 1;
                                        dtCurrentTable.Rows[i - 1]["Column1"] = txtidvente.Text;
                                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                                        dtCurrentTable.Rows[i - 1]["Column4"] = art.Px_vente;
                                        dtCurrentTable.Rows[i - 1]["Column5"] = estimation;
                                    } 
                                    else
                                    {
                                        rabais = estimation * Convert.ToDecimal(0.04);
                                        dtCurrentTable.Rows[i - 1]["Column6"] = rabais;
                                        montant = estimation - rabais;
                                        montant_final = montant + montant_final;
                                        txtmontant.Text = montant_final.ToString();
                                        dtCurrentTable.Rows[i - 1]["Column7"] = montant;
                                        drCurrentRow = dtCurrentTable.NewRow();
                                        drCurrentRow["RowNumber"] = i + 1;
                                        dtCurrentTable.Rows[i - 1]["Column1"] = txtidvente.Text;
                                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                                        dtCurrentTable.Rows[i - 1]["Column4"] = art.Px_vente;
                                        dtCurrentTable.Rows[i - 1]["Column5"] = estimation;
                                    }                                 
                                   
                                }
                                
                            }
                            else
                            {
                                lblmessage.Text = "Aucun article ne correspond a ce code !";
                                lblmessage.ForeColor = System.Drawing.Color.Orange;
                                bind = false;
                                i = i - 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblmessage.Text = ex.Message;
                            lblmessage.ForeColor = System.Drawing.Color.Red;
                        }
                        if (bind == true) { rowIndex++; }
                    }
                    if (bind == true)
                    {
                        GridView2.DataSource = dtCurrentTable;
                        GridView2.DataBind();
                        lblmessage.Text = "";
                    }
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks
            if(bind==true)
            {
                SetPreviousData();
            }
            
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values  
                        TextBox box1 =(TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtNumVente");
                        //int num = int.Parse(box1.Text);
                        TextBox box2 = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtCodeArt");
                        TextBox box3 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtQuantite");
                        TextBox box4 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtPx");
                        TextBox box5 = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtEstimation");
                        TextBox box6 = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtRabais");
                        TextBox box7 = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("txtMontant");
                        //get the values from TextBox and DropDownList  
                        //then add it to the collections with a comma "," as the delimited values                      
                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6}", box1.Text, box2.Text,box3.Text,box4.Text, box5.Text, box6.Text ,box7.Text));
                        rowIndex++;
                    }
                    //Call the method for executing inserts  
                    InsertRecords(sc);
                }
            }
        }
        public void Enregistrer(StringCollection sc)
        {
            int result = 0;
            try
            {
                Client cli = new Client(txtnomclient.Text.Trim(), txtprenomclient.Text.Trim(), "", "", "", "");
                vt = new vente(Convert.ToInt32(txtidvente.Text.Trim()), Convert.ToDecimal(txtmontant.Text), DateTime.Now.ToString(), cli.Id_client, 1);
                TraceSystem tr = new TraceSystem("Mitch", "Enregistrement vente", DateTime.Now.ToString());
                result = venteControleur.Enregistrer_vente(vt, sc,cli, tr);
                if(result>0)
                {
                    lblmessage.Text = "Success !";
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    StringBuilder sb = new StringBuilder(string.Empty);
                    string[] splitItems = null;
                    const string req = "INSERT INTO Contenu_Vente (Id_vente,Code_article,Qte_article,Px_unitaire,Estimation,Rabais,Montant_) VALUES";                    
                    foreach (string item in sc)
                    {
                        if (item.Contains(","))
                        {
                            splitItems = item.Split(",".ToCharArray());
                            sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}'); ", req, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6]);
                        }
                    }
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(sb.ToString(), connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label2.Text= ex.Message;
                Label2.ForeColor = System.Drawing.Color.Red;
                SetInitialRow();
                txtmontant.Text = "";
                txtnomclient.Text = "";
                txtprenomclient.Text = "";
                txtidvente.Text = "";
            }
        }
        private void InsertRecords(StringCollection sc)
        {
            Enregistrer(sc);
        }
        private string GetConnectionString()
        {
            return string.Format("{0}", "Data Source=JESUS-FR-MITCH;Initial Catalog=ValerioCanezDB;Integrated Security=True");
            //return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            nom_user = (string)Session["Login"];
            if (nom_user != null)
            {
                Verifier_Session();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
}