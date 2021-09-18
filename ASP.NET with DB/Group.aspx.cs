using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Group : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Content/Js/jquery-3.2.1.min.js",
            });


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                if (ex.Message.Contains("This Group already exists in Group"))
                {
                    MessageBox.Show(this, "This Group already exists in Group");
                }
            }

        }

        protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e) { 

                TextBox3.Text = GridView1.SelectedRow.Cells[1].Text;
                TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[3].Text.Substring(0,10);
        }

        protected void Button3_Click(object sender, EventArgs e)
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
                if (ex.Message.Contains("This Group does not exist in Group"))
                {
                    MessageBox.Show(this, "This Group does not exist in Group");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
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
            }catch(SqlException ex)
            {
                if (ex.Message.Contains("This Group does not exist in Group"))
                {
                    MessageBox.Show(this, "This Group does not exist in Group");
                }
                if (ex.Message.Contains("This Group exists in Student"))
                {
                    MessageBox.Show(this, "This Group exists in Student");
                }
                if (ex.Message.Contains("This Group exists in Student"))
                {
                    MessageBox.Show(this, "This Group exists in Student");
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Complex.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHasTasks.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tasks.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Curriculum.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {              
                if (args.Value.ToString().Trim().Length>20)
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
    }  
}