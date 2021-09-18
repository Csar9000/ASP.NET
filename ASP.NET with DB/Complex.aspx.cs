using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace WebApplication4
{
    public partial class Complex : System.Web.UI.Page
    {
		static HttpCookie httpCookie = new HttpCookie("IDCookie", (-1).ToString());
		protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			RequiredFieldValidator1.Enabled = true;
			RequiredFieldValidator2.Enabled = true;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = true;

			Page.Validate();
			if (!Page.IsValid)
				return;

			System.Data.DataTable dataTable = new DataTable();
            System.Data.DataTable dataGridTable = new DataTable();
			String[] headersTable = new string[5]{
			"GroupNum",
			"NumberOfCreditBook",
			"FIO",
			"Subject",
			"Count"};
			for (int i = 0; i < headersTable.Length - 1; i++)
			{
				dataTable.Columns.Add(headersTable[i]);
			}

			for (int i = 0; i < headersTable.Length; i++)
			{
				dataGridTable.Columns.Add(headersTable[i]);
			}

				using (SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students & Tasks;Integrated Security=True"))
				{

					sqlConnection.Open();
					using (SqlCommand command = new SqlCommand("dbo.TaskOneProc", sqlConnection))
					{
						command.CommandType = System.Data.CommandType.StoredProcedure;

						command.Parameters.AddWithValue("@GroupNum", TextBox6.Text);
						SqlDataReader sqlReader = command.ExecuteReader();
						if (sqlReader.HasRows)
						{
							while (sqlReader.Read())
							{
								String fullName = sqlReader.GetValue(0).ToString();
								String Number = sqlReader.GetValue(1).ToString();
								String FIO = sqlReader.GetValue(2).ToString();
								String Subject = sqlReader.GetValue(3).ToString();


								dataTable.Rows.Add(fullName, Number, FIO,Subject);
							}
						}
						sqlReader.Close();
					}

					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						using (SqlCommand command2 = new SqlCommand("dbo.TaskOneProcFindNumber", sqlConnection))
						{
							command2.CommandType = System.Data.CommandType.StoredProcedure;

							SqlParameter valueReturn = new SqlParameter("valueReturn", SqlDbType.Int);
							valueReturn.Direction = ParameterDirection.ReturnValue;

							command2.Parameters.Add(valueReturn);
							command2.Parameters.AddWithValue("@NumberOfCreditBook", int.Parse(dataTable.Rows[i].ItemArray[1].ToString()));
							command2.Parameters.AddWithValue("@Subject", Convert.ToString(dataTable.Rows[i].ItemArray[3].ToString()));
							command2.Parameters.AddWithValue("@DateNow", Convert.ToDateTime(TextBoxDate.Text));
							command2.ExecuteScalar();

							dataGridTable.Rows.Add(
								dataTable.Rows[i].ItemArray[0].ToString(),
								dataTable.Rows[i].ItemArray[1].ToString(),
								dataTable.Rows[i].ItemArray[2].ToString(),
								dataTable.Rows[i].ItemArray[3].ToString(),
								Convert.ToString(valueReturn.Value));
						}
					}
			
				sqlConnection.Close();
			}

			GridView1.DataSource = dataGridTable;
			GridView1.DataBind();

			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;
		}

        protected void Button2_Click(object sender, EventArgs e)
        {
			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = true;
			RequiredFieldValidator3.Enabled = true;
			RequiredFieldValidator4.Enabled = true;
			CompareValidator1.Enabled = true;

			Page.Validate();
			if (!Page.IsValid)
				return;

			DataTable dataTable = new DataTable();
			DataTable dataGridTable = new DataTable();
			String[] headersTable = new string[5]{
			"GroupNum",
			"NumberOfCreditBook",
			"FIO",
			"Subject",
			"Count"};
			for (int i = 0; i < headersTable.Length - 1; i++)
			{
				dataTable.Columns.Add(headersTable[i]);
			}

			for (int i = 0; i < headersTable.Length; i++)
			{
				dataGridTable.Columns.Add(headersTable[i]);
			}

			using (SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students & Tasks;Integrated Security=True"))
			{

				sqlConnection.Open();



				using (SqlCommand command = new SqlCommand("dbo.TaskTwoProc1", sqlConnection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@Subject", TextBoxSubject.Text);
					SqlDataReader sqlReader = command.ExecuteReader();
					int j = 0;
					if (sqlReader.HasRows)
					{
						while (sqlReader.Read())
						{
							String Group = sqlReader.GetValue(0).ToString();
							String Number = sqlReader.GetValue(1).ToString();
							String FIO = sqlReader.GetValue(2).ToString();
							String Subject = sqlReader.GetValue(3).ToString();


							dataTable.Rows.Add(Group, Number, FIO, Subject);
							j++;
						}
					}
					sqlReader.Close();
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					using (SqlCommand command2 = new SqlCommand("dbo.TaskOneProcFindNumber", sqlConnection))
					{
						command2.CommandType = System.Data.CommandType.StoredProcedure;

						SqlParameter valueReturn = new SqlParameter("valueReturn", SqlDbType.Int);
						valueReturn.Direction = ParameterDirection.ReturnValue;

						command2.Parameters.Add(valueReturn);
						command2.Parameters.AddWithValue("@NumberOfCreditBook", int.Parse(dataTable.Rows[i].ItemArray[1].ToString()));
						command2.Parameters.AddWithValue("@Subject", Convert.ToString(dataTable.Rows[i].ItemArray[3].ToString()));
						command2.Parameters.AddWithValue("@DateNow", Convert.ToDateTime(TextBoxDate.Text));
						command2.ExecuteScalar();

						dataGridTable.Rows.Add(
							dataTable.Rows[i].ItemArray[0].ToString(),
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							dataTable.Rows[i].ItemArray[3].ToString(),
							Convert.ToString(valueReturn.Value));

					}
				}

				for (int i = 0; i < dataGridTable.Rows.Count; i++)
				{
					
					if (Convert.ToInt32(dataGridTable.Rows[i].ItemArray[4]) > Convert.ToInt32(TextBoxTaskCount.Text))
					{
						dataGridTable.Rows.RemoveAt(i);
					}

				}

				sqlConnection.Close();
			}
			GridView2.DataSource = dataGridTable;
			GridView2.DataBind();


			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;

		}

		protected void Button3_Click(object sender, EventArgs e)
        {

			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;
			if (File1.PostedFile.FileName.Trim().Length == 0)
			{

			}
			else {


				string filename = File1.PostedFile.FileName;
				Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				excelApp.Workbooks.Add();
				Microsoft.Office.Interop.Excel.Worksheet workSheet = excelApp.ActiveSheet;

				workSheet.Cells[1, "A"] = "GroupNum";
				workSheet.Cells[1, "B"] = "NumberOfCreditBook";
				workSheet.Cells[1, "C"] = "FIO";
				workSheet.Cells[1, "D"] = "Subject";
				workSheet.Cells[1, "E"] = "Count";

				for (int i = 0; i < GridView1.Rows.Count; i++)
				{
					workSheet.Cells[(i + 2), "A"] = GridView1.Rows[i].Cells[0].Text;
					workSheet.Cells[(i + 2), "B"] = GridView1.Rows[i].Cells[1].Text;
					workSheet.Cells[(i + 2), "C"] = GridView1.Rows[i].Cells[2].Text;
					workSheet.Cells[(i + 2), "D"] = GridView1.Rows[i].Cells[3].Text;
					workSheet.Cells[(i + 2), "E"] = GridView1.Rows[i].Cells[4].Text;
				}

				try
				{
					workSheet.SaveAs(filename);
				}
				catch (Exception) { }

				try
				{
					excelApp.Quit();
				}
				catch (Exception) { }

				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);


				RequiredFieldValidator2.Enabled = false;
				RequiredFieldValidator3.Enabled = false;
				RequiredFieldValidator4.Enabled = false;

			}
		}

		protected void Button4_Click(object sender, EventArgs e)
		{
			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;

			if (File2.PostedFile.FileName.Trim().Length == 0)
			{

			}
			else
			{
				string fileName = File2.PostedFile.FileName;

				DataTable dataTable = new DataTable();
				String[] headersTable = new string[5]{
			"GroupNum",
			"NumberOFCreditBook",
			"FIO",
			"Subject",
			"Count" };
				for (int i = 0; i < headersTable.Length; i++)
				{
					dataTable.Columns.Add(headersTable[i]);
				}

				Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(fileName);
				Microsoft.Office.Interop.Excel._Worksheet excelSheet = excelBook.Sheets[1];
				Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

				int rows = excelRange.Rows.Count;
				int cols = excelRange.Columns.Count;
				List<List<string>> maping = new List<List<string>>();
				for (int i = 1; i <= rows; i++)
				{
					maping.Add(new List<string>());
					for (int j = 1; j <= cols; j++)
					{
						if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
							maping[(i - 1)].Add(excelRange.Cells[i, j].Value2.ToString());
					}
				}

				try
				{
					excelBook.Close();
					excelApp.Quit();
				}
				catch (Exception) { }

				for (int i = 1; i < maping.Count; i++)
				{
					dataTable.Rows.Add(
						maping[i][0],
						maping[i][1],
						maping[i][2],
						maping[i][3],
						maping[i][4]);
				}

				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

				GridView1.DataSource = dataTable;
				GridView1.DataBind();
			}
		}

		protected void Button5_Click(object sender, EventArgs e)
		{

			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;


			if (File3.PostedFile.FileName.Trim().Length == 0)
			{

			}
			else
			{
				string filename = File3.PostedFile.FileName;
				Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				excelApp.Workbooks.Add();
				Microsoft.Office.Interop.Excel.Worksheet workSheet = excelApp.ActiveSheet;

				workSheet.Cells[1, "A"] = "GroupNum";
				workSheet.Cells[1, "B"] = "NumberOfCreditBook";
				workSheet.Cells[1, "C"] = "FIO";
				workSheet.Cells[1, "D"] = "Subject";
				workSheet.Cells[1, "E"] = "Count";

				for (int i = 0; i < GridView2.Rows.Count; i++)
				{
					workSheet.Cells[(i + 2), "A"] = GridView2.Rows[i].Cells[0].Text;
					workSheet.Cells[(i + 2), "B"] = GridView2.Rows[i].Cells[1].Text;
					workSheet.Cells[(i + 2), "C"] = GridView2.Rows[i].Cells[2].Text;
					workSheet.Cells[(i + 2), "D"] = GridView2.Rows[i].Cells[3].Text;
					workSheet.Cells[(i + 2), "E"] = GridView2.Rows[i].Cells[4].Text;
				}

				try
				{
					workSheet.SaveAs(filename);
				}
				catch (Exception) { }

				try
				{
					excelApp.Quit();
				}
				catch (Exception) { }

				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

			}
		}

		protected void Button6_Click(object sender, EventArgs e)
		{


			RequiredFieldValidator1.Enabled = false;
			RequiredFieldValidator2.Enabled = false;
			RequiredFieldValidator3.Enabled = false;
			RequiredFieldValidator4.Enabled = false;
			CompareValidator1.Enabled = false;


			if (File4.PostedFile.FileName.Trim().Length == 0)
			{

			}
			else
			{
				string fileName = File4.PostedFile.FileName;

				DataTable dataTable = new DataTable();
				String[] headersTable = new string[5]{
			"GroupNum",
			"NumberOFCreditBook",
			"FIO",
			"Subject",
			"Count" };
				for (int i = 0; i < headersTable.Length; i++)
				{
					dataTable.Columns.Add(headersTable[i]);
				}

				Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
				Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(fileName);
				Microsoft.Office.Interop.Excel._Worksheet excelSheet = excelBook.Sheets[1];
				Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

				int rows = excelRange.Rows.Count;
				int cols = excelRange.Columns.Count;
				List<List<string>> maping = new List<List<string>>();
				for (int i = 1; i <= rows; i++)
				{
					maping.Add(new List<string>());
					for (int j = 1; j <= cols; j++)
					{
						if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
							maping[(i - 1)].Add(excelRange.Cells[i, j].Value2.ToString());
					}
				}

				try
				{
					excelBook.Close();
					excelApp.Quit();
				}
				catch (Exception) { }

				for (int i = 1; i < maping.Count; i++)
				{
					dataTable.Rows.Add(
						maping[i][0],
						maping[i][1],
						maping[i][2],
						maping[i][3],
						maping[i][4]);
				}

				System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

				GridView2.DataSource = dataTable;
				GridView2.DataBind();


			}
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

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
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
    }
}