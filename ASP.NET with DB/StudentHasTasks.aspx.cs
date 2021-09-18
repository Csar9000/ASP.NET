using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class StudentHasTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Convert.ToString(DateTime.Now);
            str = str.Substring(0,10);
            TextBox5.Text = str;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.ToString().Trim().Length != 0)
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
                    CustomValidator2.ErrorMessage = "Есть некорректные символы!";
                    args.IsValid = false;
                }
            }
            else { CustomValidator2.ErrorMessage = "Пустая строка зачётки!"; args.IsValid = false; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CompareValidator1.Enabled = true;
                CompareValidator2.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Insert();
                GridView1.DataBind();

                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CompareValidator1.Enabled = false;
                CompareValidator2.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This S&T already exist in DB"))
                {
                    MessageBox.Show(this, "This S&T already exist in DB");
                }

                if (ex.Message.Contains("There is no same Student_NumberOfCreditBook in Student"))
                {
                    if (ex.Message.Contains(" and idTaskNumber in Tasks"))
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student  and idTaskNumber in Tasks");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student");
                    }
                }

                if (ex.Message.Contains("There is no same idTask in Tasks"))
                {
                    if (ex.Message.Contains(" and NumberOfCreditBook in Student"))
                    {
                        MessageBox.Show(this, "There is no same idTask in Tasks and NumberOfCreditBook in Student");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same idTask in Tasks");
                    }
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CompareValidator1.Enabled = true;
                CompareValidator2.Enabled = true;


                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Update();
                GridView1.DataBind();


                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CompareValidator1.Enabled = false;
                CompareValidator2.Enabled = false;

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("There is no same Student_NumberOfCreditBook in Student"))
                {
                    if (ex.Message.Contains(" and idTaskNumber in Tasks"))
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student and idTaskNumber in Tasks");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student");
                    }
                }

                if (ex.Message.Contains("There is no same idTaskNumber in Tasks"))
                {
                    if (ex.Message.Contains(" and NumberOfCreditBook in Student"))
                    {
                        MessageBox.Show(this, "There is no same idTaskNumber in Tasks and NumberOfCreditBook in Student");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same idTaskNumber in Tasks");
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CompareValidator1.Enabled = true;
                CompareValidator2.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Delete();
                GridView1.DataBind();

                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CompareValidator1.Enabled = false;
                CompareValidator2.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This S&T does not exist in DB"))
                {
                    MessageBox.Show(this, "This S&T does not exist in DB");
                }
                if (ex.Message.Contains("There is no same Student_NumberOfCreditBook in Student"))
                {
                    if (ex.Message.Contains(" and idTaskNumber in Tasks"))
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student and idTaskNumber in Tasks");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same Student_NumberOfCreditBook in Student");
                    }
                }

                if (ex.Message.Contains("There is no same SubjectName in Subject"))
                {
                    if (ex.Message.Contains(" and NumberOfCreditBook in Student"))
                    {
                        MessageBox.Show(this, "There is no same SubjectName in Subject and NumberOfCreditBook in Student");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is no same SubjectName in Subject");
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text.Substring(0, 10);
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text.Substring(0, 10);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text.Substring(0, 10);
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text.Substring(0, 10);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHasTasks.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Curriculum.aspx");
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(TextBox3.Text);
                DateTime dt2 = Convert.ToDateTime(TextBox4.Text);

                if (dt > dt2)
                {
                    args.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(TextBox4.Text);
                DateTime dt2 = Convert.ToDateTime(TextBox5.Text);

                if (dt > dt2)
                {
                    args.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

        protected void CompareValidator3_Load(object sender, EventArgs e)
        {
            string s = Convert.ToString(DateTime.Now);
            s = s.Substring(0,10);
            CompareValidator3.ValueToCompare =s ;
        }
    }
}