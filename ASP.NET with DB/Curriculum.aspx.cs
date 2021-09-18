using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Insert();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This Curriculum already exist in DB"))
                {
                    MessageBox.Show(this, "This Curriculum already exist in DB");
                }
                if (ex.Message.Contains("There is no same GroupNum in Group"))
                {
                    if (ex.Message.Contains(" and SubjectName in Subject"))
                    {
                        MessageBox.Show(this, "There is no same GroupNum in Group and SubjectName in Subject");
                    }
                    else { MessageBox.Show(this, "This Curriculum already exist in DB"); }
                }


                if (ex.Message.Contains("There is no same SubjectName in Subject"))
                {
                    if (ex.Message.Contains(" and GroupName in Group"))
                    {
                        MessageBox.Show(this, "There is no same SubjectName in Subject and GroupName in Group");
                    }
                    else { MessageBox.Show(this, "There is no same SubjectName in Subject"); }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Delete();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("There is no this Curricukum in Curriculum"))
                {
                    MessageBox.Show(this, "There is no this Curricukum in Curriculum");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Update();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;

            }
            catch (SqlException ex)
            {

                if (ex.Message.Contains("There is no same Curriculum in Curriculum"))
                {
                    MessageBox.Show(this, "There is no same Curriculum in Curriculum");
                }
                if (ex.Message.Contains("This new Subject does not exist in DB"))
                {
                    MessageBox.Show(this, "This new Subject does not exist in DB");
                }
                if (ex.Message.Contains("This Group does not exist in Curriculum"))
                {
                    MessageBox.Show(this, "This Group does not exist in Curriculum");
                }
                if (ex.Message.Contains("This Subject does not exist in DB"))
                {
                    MessageBox.Show(this, "This Subject does not exist in DB");
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tasks.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHasTasks.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Complex.aspx");
        }
    }
}