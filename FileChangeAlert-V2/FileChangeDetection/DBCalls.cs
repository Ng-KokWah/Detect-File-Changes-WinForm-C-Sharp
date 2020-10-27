using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChangeDetection
{
    class DBCalls
    {
        public static void createFileInfo(int Id, String Filepath, String MD5Hash, String SHA256Hash, String SHA512Hash)
        {
            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String sqlinsert = "INSERT INTO FileTable(Id, Filepath, MD5Hash, SHA256Hash, SHA512Hash) VALUES (" + @Id + ", \'" + @Filepath + "\', \'" + @MD5Hash + "\', \'" + @SHA256Hash + "\', \'" + @SHA512Hash + "\')";
            SqlCommand cmd = new SqlCommand(sqlinsert, conn);

            Console.WriteLine(sqlinsert);
            ///System.Diagnostics.Debug.WriteLine("update history " + sqlinsert);
            using (conn)
            {
                conn.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = Filepath;
                cmd.Parameters.Add("@MD5Hash", SqlDbType.VarChar).Value = MD5Hash;
                cmd.Parameters.Add("@SHA256Hash", SqlDbType.VarChar).Value = SHA256Hash;
                cmd.Parameters.Add("@SHA512Hash", SqlDbType.VarChar).Value = SHA512Hash;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static FileModel retrieveSingleFileInfo(String Filepath)
        {
            FileModel fm = new FileModel();

            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String SqlCommand = "SELECT * FROM FileTable WHERE Filepath = \'" + Filepath + "\'";
            SqlCommand cmd = new SqlCommand(SqlCommand, conn);

            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fm.Filepath = CleaningInput.RemoveWhiteSpaces(rdr["Filepath"].ToString());
                    fm.MD5Hash = CleaningInput.RemoveWhiteSpaces(rdr["MD5Hash"].ToString());
                    fm.SHA256Hash = CleaningInput.RemoveWhiteSpaces(rdr["SHA256Hash"].ToString());
                    fm.SHA512Hash = CleaningInput.RemoveWhiteSpaces(rdr["SHA512Hash"].ToString());
                }
                conn.Close();
            }

            return fm;
        }

        public static int countNoOfFileRecords()
        {
            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM FileTable", conn);
            Int32 count;
            using (conn)
            {
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
                conn.Close();
            }

            return count;
        }

        public static Boolean checkFileExists(String Filepath)
        {
            Boolean existsOrNot;

            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String SqlCommand = "SELECT Count(*) FROM FileTable WHERE Filepath = \'" + Filepath + "\'";
            SqlCommand cmd = new SqlCommand(SqlCommand, conn);
            Int32 count;
            using (conn)
            {
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
                conn.Close();
            }

            // Console.WriteLine(id);
            if (count > 0)
            {
                existsOrNot = true;
            }
            else
            {
                existsOrNot = false;
            }
            //end of retrieve id from the UserTable

            return existsOrNot;
        }

        public static void deleteFileRecord(String Filepath)
        {
            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String sqlinsert = "DELETE FROM FileTable WHERE Filepath = \'" + @Filepath + "\'";
            SqlCommand cmd = new SqlCommand(sqlinsert, conn);

            Console.WriteLine(sqlinsert);

            using (conn)
            {
                conn.Open(); 
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        public static void createConstantAlertInfo(int Id, String Email, String Password, String Filepath, String MD5Hash, String SHA256Hash, String SHA512Hash)
        {
            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String sqlinsert = "INSERT INTO ConstantAlert(Id, Filepath, Email, Password, MD5Hash, SHA256Hash, SHA512Hash) VALUES (" + @Id + ", \'" + @Filepath + "\', \'" + @Email + "\', \'" + @Password + "\', \'" + @MD5Hash + "\', \'" + @SHA256Hash + "\', \'" + @SHA512Hash + "\')";
            SqlCommand cmd = new SqlCommand(sqlinsert, conn);

            Console.WriteLine(sqlinsert);
            ///System.Diagnostics.Debug.WriteLine("update history " + sqlinsert);
            using (conn)
            {
                conn.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = Filepath;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = Email;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
                cmd.Parameters.Add("@MD5Hash", SqlDbType.VarChar).Value = MD5Hash;
                cmd.Parameters.Add("@SHA256Hash", SqlDbType.VarChar).Value = SHA256Hash;
                cmd.Parameters.Add("@SHA512Hash", SqlDbType.VarChar).Value = SHA512Hash;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static ConstantAlertModel retrieveSingleConstantAlertInfo(String Filepath)
        {
            ConstantAlertModel fm = new ConstantAlertModel();

            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String SqlCommand = "SELECT * FROM ConstantAlert WHERE Filepath = \'" + Filepath + "\'";
            SqlCommand cmd = new SqlCommand(SqlCommand, conn);

            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fm.Filepath = CleaningInput.RemoveWhiteSpaces(rdr["Filepath"].ToString());
                    fm.Email = CleaningInput.RemoveWhiteSpaces(rdr["Email"].ToString());
                    fm.Password = CleaningInput.RemoveWhiteSpaces(rdr["Password"].ToString());
                    fm.MD5Hash = CleaningInput.RemoveWhiteSpaces(rdr["MD5Hash"].ToString());
                    fm.SHA256Hash = CleaningInput.RemoveWhiteSpaces(rdr["SHA256Hash"].ToString());
                    fm.SHA512Hash = CleaningInput.RemoveWhiteSpaces(rdr["SHA512Hash"].ToString());
                }
                conn.Close();
            }

            return fm;
        }

        public static int countNoOfConstantAlertRecords()
        {
            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ConstantAlert", conn);
            Int32 count;
            using (conn)
            {
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
                conn.Close();
            }

            return count;
        }

        public static Boolean checkConstantAlertExists(String Filepath)
        {
            Boolean existsOrNot;

            string cs = ConfigurationManager.ConnectionStrings["FileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(cs);

            String SqlCommand = "SELECT Count(*) FROM ConstantAlert WHERE Filepath = \'" + Filepath + "\'";
            SqlCommand cmd = new SqlCommand(SqlCommand, conn);
            Int32 count;
            using (conn)
            {
                conn.Open();
                count = (Int32)cmd.ExecuteScalar();
                conn.Close();
            }

            // Console.WriteLine(id);
            if (count > 0)
            {
                existsOrNot = true;
            }
            else
            {
                existsOrNot = false;
            }
            //end of retrieve id from the UserTable

            return existsOrNot;
        }
    }
}
