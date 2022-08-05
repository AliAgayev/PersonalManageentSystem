using PersonalManagamentSystem.DAL;
using PersonalManagamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PersonalManagamentSystem.ServiceOperations
{
    public class PersonalManager
    {
        public static string SqlConnect = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Personal ;Integrated Security=True";
        static DataOperations DataOperations = new DataOperations();

        public static void AddPersonal()
        {
            Personal personal = new Personal();
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();

            Console.WriteLine("Isci nomresini daxil edin: ");
            personal.PersonalNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Isci adini qeyd edin:");
            personal.Name = Console.ReadLine();
            Console.WriteLine("Isci soyadini daxil edin:");
            personal.Surname = Console.ReadLine();
            Console.WriteLine("Ise giris vaxtini daxil edin:");
            personal.EntryTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Isci vezifesini daxil edin:");
            personal.Position = Console.ReadLine();
            Console.WriteLine("Emek haqqi emsalini daxil edin:");
            personal.WageRate = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ayliq umumi deqiqeni daxil edin:");
            personal.TotalWorkingTimeinMonth = Convert.ToInt32(Console.ReadLine());

            string insertQuery= "INSERT INTO [dbo].[Personal] ([PersonalNumber],[Name],[Surname],[EntryTime] " +
                ",[Position] ,[WageRate],[TotalWorkingTimeinMonth]) " +
                " VALUES (@PersonalNumber, @Name, @Surname," +
                " @EntryTime, @Position, @WageRate, @TotalWorkingTimeinMonth)";

            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.Parameters.AddWithValue("@PersonalNumber", personal.PersonalNumber);
            insertCommand.Parameters.AddWithValue("@Name", personal.Name);
            insertCommand.Parameters.AddWithValue("@Surname", personal.Surname);
            insertCommand.Parameters.AddWithValue("@EntryTime", personal.EntryTime);
            insertCommand.Parameters.AddWithValue("@Position", personal.Position);
            insertCommand.Parameters.AddWithValue("@WageRate", personal.WageRate);
            insertCommand.Parameters.AddWithValue("@TotalWorkingTimeinMonth", personal.TotalWorkingTimeinMonth);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            DataOperations.Personals.Add(personal);
        }

        public static void ShowPersonal()
        {
            Console.WriteLine("Isci nomresini daxil edin:");
            int personalnumber = Convert.ToInt32(Console.ReadLine());
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();
            
            string selectQuery = $"SELECT [PersonalNumber],[Name],[Surname],[EntryTime],[Position]," +
                $"[WageRate],[TotalWorkingTimeinMonth]FROM[dbo].[Personal]";

            SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@personalnumber", personalnumber);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Personal personal = new Personal();

                personal.PersonalNumber = (int)sqlDataReader.GetValue(0);
                personal.Name = (string)sqlDataReader.GetValue(1);
                personal.Surname = (string)sqlDataReader.GetValue(2);
                personal.EntryTime = Convert.ToDateTime(sqlDataReader.GetValue(3));
                personal.Position = (string)sqlDataReader.GetValue(4);
                personal.WageRate = (decimal)sqlDataReader.GetValue(5);
                personal.TotalWorkingTimeinMonth = (int)sqlDataReader.GetValue(6);
                DataOperations.Personals.Add(personal);
            }
            sqlConnection.Close();

            foreach (var item in DataOperations.Personals)
            {
                if (item.PersonalNumber== personalnumber)
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"Isci nomresi - {item.PersonalNumber} \nIsci adi - {item.Name} \nIsci soyadi - {item.Surname}" +
                        $" \nIscinin ise giris tarixi - {item.EntryTime} \nIscinin vezifesi - {item.Position} \nIscinin emek haqqi emsali - {item.WageRate}");
                }

               
            }
        }

        public static void ShowPersonalForPosition()
        {
           
                Console.WriteLine("Gormek istediyiniz vesife adini daxil edin:(Mudir/Mudir muavini/Biznes analitik/Software Developer)");
                string position = Console.ReadLine();
                SqlConnection sqlConnection = new SqlConnection(SqlConnect);
                sqlConnection.Open();

                string selectQuery = $"SELECT [PersonalNumber],[Name],[Surname],[EntryTime],[Position]," +
                    $"[WageRate],[TotalWorkingTimeinMonth]FROM[dbo].[Personal]";

                SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@position", position);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Personal personal = new Personal();

                    personal.PersonalNumber = (int)sqlDataReader.GetValue(0);
                    personal.Name = (string)sqlDataReader.GetValue(1);
                    personal.Surname = (string)sqlDataReader.GetValue(2);
                    personal.EntryTime = Convert.ToDateTime(sqlDataReader.GetValue(3));
                    personal.Position = (string)sqlDataReader.GetValue(4);
                    personal.WageRate = (decimal)sqlDataReader.GetValue(5);
                    personal.TotalWorkingTimeinMonth = (int)sqlDataReader.GetValue(6);
                    DataOperations.Personals.Add(personal);
                }
                sqlConnection.Close();

                foreach (var item in DataOperations.Personals)
                {
                    if (item.Position == position)
                    {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"Isci nomresi - {item.PersonalNumber} \nIsci adi - {item.Name} \nIsci soyadi - {item.Surname}" +
                            $" \nIscinin ise giris tarixi - {item.EntryTime} \nIscinin emek haqqi emsali - {item.WageRate}");
                    }
                }
            


        }

        public static void DeletePersonal()
        {
            Console.WriteLine("Isci nomresini daxil edin:");
            int personalnumber = Convert.ToInt32(Console.ReadLine());
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();


            string deleteQuery = $"DELETE FROM [dbo].[Personal] WHERE PersonalNumber = {personalnumber}";
            SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
