using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Insert();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This Subject already exist in DB"))
                {
                    MessageBox.Show(this, "This Subject already exist in DB");
                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Delete();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("There is no subject in Subject"))
                {
                    MessageBox.Show(this, "There is no subject in Subject");
                }
                if (ex.Message.Contains("This subject refers to Tasks"))
                {
                    MessageBox.Show(this, "This subject refers to Tasks");
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;


                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Update();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This Student does not exist in DB"))
                {
                    MessageBox.Show(this, "This Student does not exist in DB");
                }
                if (ex.Message.Contains("This group does not exist"))
                {
                    MessageBox.Show(this, "This group does not exist");
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (args.Value.ToString().Trim().Length > 20)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (args.Value.ToString().Trim().Length > 20)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (args.Value.ToString().Trim().Length > 20)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
        }
    }
}