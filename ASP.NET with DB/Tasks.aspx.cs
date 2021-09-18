using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CustomValidator3.Enabled = true;


                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Update();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CustomValidator3.Enabled = false;

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("There is no task in Tasks"))
                {
                    MessageBox.Show(this, "There is no task in Tasks");
                }
                if (ex.Message.Contains("This id refers to Student has Tasks"))
                {
                    MessageBox.Show(this, "This id refers to Student has Tasks");
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int check = (int.Parse(args.Value));
                if (check < -32768 || check > 32767)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (args.Value.ToString().Length > 20)
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
                if (args.Value.ToString().Length > 255)
                {
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CustomValidator3.Enabled = true;

                Page.Validate();
                if (!Page.IsValid)
                    return;

                SqlDataSource1.Insert();
                GridView1.DataBind();

                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CustomValidator3.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("This Task already exist in DB"))
                {
                    MessageBox.Show(this, "This Task already exist in DB");
                }
                if (ex.Message.Contains("This Task does not have subject"))
                {
                    MessageBox.Show(this, "This Task does not have subject");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                CustomValidator1.Enabled = true;
                CustomValidator2.Enabled = true;
                CustomValidator3.Enabled = true;
                Page.Validate();
                if (!Page.IsValid)
                    return;
                SqlDataSource1.Delete();
                GridView1.DataBind();
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                CustomValidator1.Enabled = false;
                CustomValidator2.Enabled = false;
                CustomValidator3.Enabled = false;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("There is no task in Tasks"))
                {
                    MessageBox.Show(this, "There is no task in Tasks");
                }
                if (ex.Message.Contains("This id refers to Student has Tasks"))
                {
                    MessageBox.Show(this, "This id refers to Student has Tasks");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int check = (int.Parse(args.Value));
                if (check < -32768 || check > 32767)
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