using PersonalManagamentSystem.DAL;
using PersonalManagamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PersonalManagamentSystem.ServiceOperations
{
   public class WorkTimeManager
    {
        public static string SqlConnect = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Personal ;Integrated Security=True";
        static DataOperations DataOperations = new DataOperations();

        public static void AddWorkTime()
        {
            WorkTime workTime = new WorkTime();
            Console.WriteLine("Isci nomresini daxil edin: ");
            workTime.PersonalNum = Convert.ToInt32(Console.ReadLine());
            SqlConnection sqlConnection = new SqlConnection(SqlConnect);
            sqlConnection.Open();


            Console.WriteLine("Tarixi daxil edin: ");
            workTime.Date = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Giris saatini daxil et:");
            workTime.EntryHour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Giris deqiqesini daxil et:");
            workTime.EntryMinute = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cixis saatini daxil et:");
            workTime.Exithour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cixis deqiqesini daxil et:");
            workTime.ExitMinute = Convert.ToInt32(Console.ReadLine());


            string insertQuery = "INSERT INTO [dbo].[WorkTime] ([PersonalNumber],[Date],[EntryHour],[EntryMinute],[Exithour],[ExitMinute]) " +
                "VALUES (@PersonalNumber, @Date,@EntryHour, @EntryMinute, @Exithour, @ExitMinute)";

            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.Parameters.AddWithValue("@PersonalNumber", workTime.PersonalNum);
            insertCommand.Parameters.AddWithValue("@Date", workTime.Date);
            insertCommand.Parameters.AddWithValue("@EntryHour", workTime.EntryHour);
            insertCommand.Parameters.AddWithValue("@EntryMinute", workTime.EntryMinute);
            insertCommand.Parameters.AddWithValue("@Exithour", workTime.Exithour);
            insertCommand.Parameters.AddWithValue("@ExitMinute", workTime.ExitMinute);
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            DataOperations.WorkTimes.Add(workTime);
        }
    }
}
