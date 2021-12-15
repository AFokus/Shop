using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
static class LibraryRepository
{
private static string connectionString = "Data Source=" + Application.dataPath + "/db/Shop.db";

//----------------------------------------------------------------------------------------------------------------
//                                              Запросы на выборку данных
//----------------------------------------------------------------------------------------------------------------
public static List<Models> GetAllModels()
{
    string sql = $"SELECT * FROM Models";
    return GetData<Models>(sql);
}

    public static Categories GetCategoryByID(int id)
    {
        string sql = $"SELECT * FROM Categories WHERE CategoryId LIKE \"id\"";
        return GetData<Categories>(sql)[0];
    }

    public static Processors GetCPUByID(int id)
    {
        string sql = $"SELECT * FROM Processors WHERE ProcID LIKE \"id\"";
        return GetData<Processors>(sql)[0];
    }

    public static Design GetDesignByID(int id)
    {   
        string sql = $"SELECT * FROM Design WHERE DesignID LIKE \"id\"";
        return GetData<Design>(sql)[0];
    }

    public static ScreenTable GetScreenByID(int id)
    {
        string sql = $"SELECT * FROM Screen WHERE ScreenID LIKE \"id\"";
        return GetData<ScreenTable>(sql)[0];
    }

    public static Storage GetStorageByID(int id)
    {
        string sql = $"SELECT * FROM Storage WHERE StorageID LIKE \"id\"";
        return GetData<Storage>(sql)[0];
    }

    public static GraphicsTable GetGraphicsByID(int id)
    {
        string sql = $"SELECT * FROM Graphics WHERE GraphicsID LIKE \"id\"";
        return GetData<GraphicsTable>(sql)[0];
    }

    //----------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------------------------------------------------------------------
    //                                      Запросы на добавление\обновление данных
    //----------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------------------------------------------------------------------
    //                                         Запрос на удаление
    //----------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------------------------------------------------------------------


    //----------------------------------------------------------------------------------------------------------------
    //                                         Отправители запросов
    //----------------------------------------------------------------------------------------------------------------
    private static List<T> GetData<T>(string sql) where T : class, ITable, new()
{
List<T> variables = new List<T>();
//connectionString = connectionString.Replace("\\", "/");
using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
{
    dbcon.Open();
    using (IDbCommand dbcmd = dbcon.CreateCommand())
    {
        dbcmd.CommandText = sql;

        using (IDataReader reader = dbcmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string[] parameters = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                    parameters[i] = reader.GetValue(i).ToString();
                variables.Add(new T().SetData(parameters) as T);
            }
        }
    }
    // Закрываем соединение
    dbcon.Close();
}
return variables;
}


private static bool SetData(string sql)
{
//connectionString = connectionString.Replace("\\", "/");
using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
{

    dbcon.Open();
    using (IDbCommand dbcmd = dbcon.CreateCommand())
    {

        dbcmd.CommandText = sql;

        try
        {
            dbcmd.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }

    }
}
}

//----------------------------------------------------------------------------------------------------------------
}
