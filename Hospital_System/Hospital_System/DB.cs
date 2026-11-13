using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_System
{
    public static class DB
    {
        public static MySqlConnection Conn()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["hospital"].ConnectionString);
        }

        public static DataTable Table(string sql, params MySqlParameter[] p)
        {
            using (MySqlConnection con = Conn())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(p);
                DataTable dt = new DataTable();
                new MySqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
        }

        public static object Scalar(string sql, params MySqlParameter[] p)
        {
            using (MySqlConnection con = Conn())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(p);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static long Insert(string sql, params MySqlParameter[] p)
        {
            using (MySqlConnection con = Conn())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(p);
                con.Open();
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
        }

        public static int Run(string sql, params MySqlParameter[] p)
        {
            using (MySqlConnection con = Conn())
            using (MySqlCommand cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(p);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}