using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public static class SQL_Engine
{
    private static string _server = "remotemysql.com";
    private static string _database = "8GgaQe5vRh";
    private static string _uid = "8GgaQe5vRh";
    private static string _pwd = "TRDK5DdMe5";
    private static MySqlConnection _connection = null;
    private static bool Connect()
    {
        string connectionString = "SERVER=" + _server + ";" +
                                    "DATABASE=" + _database +";" +
                                    "UID=" + _uid + ";" +
                                    "Pwd=" + _pwd + ";";

        _connection = new MySqlConnection(connectionString);
        try
        {
            _connection.Open();
            return true;
        }
        catch(MySqlException e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    private static void ReadUsersData(MySqlDataReader dataReader, out List<UserData> usersData)
    {
        usersData = new List<UserData>();
        while(dataReader.Read())
        {
            usersData.Add(
                new UserData()
                {
                    Name = dataReader.GetValue(1) as string,
                    Patronymic = dataReader.GetValue(2) as string,
                    Surname = dataReader.GetValue(3) as string,
                    Identificator = dataReader.GetValue(4) as string
                }
            );
        }
    }
    public static List<UserData> GetUsersData()
    {
        List<UserData> usersData = null;

        if (Connect())
        {
            string sqlCommand = "SELECT * FROM USERS";
            MySqlCommand readyCommand = new MySqlCommand(sqlCommand, _connection);
            MySqlDataReader dataReader = readyCommand.ExecuteReader();
            if (dataReader.HasRows)
            {
                ReadUsersData(dataReader, out usersData);
            }
            dataReader.Close();
            _connection.Close();
        }
        return usersData;
    }
}
