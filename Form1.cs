using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // Connect Button
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT TutorialID,TutorialName FROM demotb";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            MessageBox.Show(Output, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }



        private void button2_Click(object sender, EventArgs e) // Insert Button
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "INSERT INTO demotb (TutorialID,TutorialName) values(3,'" + "VB.NET" + "')";

            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            MessageBox.Show("Inserted Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            command.Dispose();
            cnn.Close();
        }



        private void button3_Click(object sender, EventArgs e) // Update Button
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "UPDATE demotb set TutorialName='" + "VB.Net Complete" + "' WHERE TutorialID=3";

            command = new SqlCommand(sql, cnn);

            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();

            MessageBox.Show("Updated Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            command.Dispose();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e) // Delete Button
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "DELETE demotb WHERE TutorialID=3";

            command = new SqlCommand(sql, cnn);

            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            MessageBox.Show("Deleted Data!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            command.Dispose();
            cnn.Close();
        }
    }
}
