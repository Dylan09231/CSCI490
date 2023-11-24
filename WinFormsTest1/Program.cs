using System;
using MySql.Data.MySqlClient;

namespace WinFormsTest1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //if (local.CheckExistance(local.connectToMySQL()) == false)
            //{
            //local.InsertUser(local.connectToMySQL());
            //}
            //local.deleteUser(local.connectToMySQL());
        }
    }
}