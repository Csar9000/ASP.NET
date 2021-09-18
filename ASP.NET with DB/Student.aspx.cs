using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Content/Js/jquery-3.2.1.min.js",
            });
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
                if (ex.Message.Contains("This Student already exist in DB"))
                {
                    MessageBox.Show(this, "This Student already exist in DB");
                }
                if (ex.Message.Contains("This Student s group is does not exist"))
                {
                    MessageBox.Show(this, "This Student s group is does not exist");
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
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This Student already exist in DB"))
                {
                    MessageBox.Show(this, "This Student already exist in DB");
                }
                if (ex.Message.Contains("This Student has Task!"))
                {
                    MessageBox.Show(this, "This Student has Task!");
                }
            }
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

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.ToString().Trim().Length != 0)
            {
                try
                {
                    int check = (int.Parse(args.Value));
                    if (check < -2147483647 || check > 2147483647)
                    {
                        args.IsValid = false;
                    }
                }
                catch
                {
                    CustomValidator1.ErrorMessage = "Есть некорректные символы!";
                    args.IsValid = false;
                }
            }
            else { CustomValidator1.ErrorMessage = "Пустая строка зачётки!"; args.IsValid = false; }
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