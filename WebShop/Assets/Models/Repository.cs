using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
static class Repository
{
private static string connectionString = "Data Source=" + Application.dataPath + "/db/Shop.db";

    //----------------------------------------------------------------------------------------------------------------
    //                                              Запросы на выборку данных
    //----------------------------------------------------------------------------------------------------------------

    public static bool Authorization(ref User_Data loginData)
    {
        var sql = $"SELECT * FROM \"User Data\" WHERE Login LIKE \"{loginData.Login}\" AND Password LIKE \"{loginData.Password}\"";
        var tmp = GetData<User_Data>(sql);
        if (tmp.Count == 0)
            return false;
        else
        {
            loginData = tmp[0];
            return true;
        }
    }

    public static List<Models> GetAllModels()
    {
        string sql = $"SELECT * FROM Models";
        return GetData<Models>(sql);
    }

    public static List<Orders> GetAllOrders()
    {
        string sql = $"SELECT * FROM Orders";
        return GetData<Orders>(sql);
    }

    public static List<Categories> GetAllCategories()
    {
        string sql = $"SELECT * FROM Categories";
        return GetData<Categories>(sql);
    }

    public static List<Processors> GetAllCPU()
    {
        string sql = $"SELECT * FROM CPU";
        return GetData<Processors>(sql);
    }

    public static List<Design> GetAllDesign()
    {
        string sql = $"SELECT * FROM Design";
        return GetData<Design>(sql);
    }

    public static List<ScreenTable> GetAllScreen()
    {
        string sql = $"SELECT * FROM Screen";
        return GetData<ScreenTable>(sql);
    }

    public static List<Storage> GetAllStorages()
    {
        string sql = $"SELECT * FROM Storages";
        return GetData<Storage>(sql);
    }

    public static List<GraphicsTable> GetAllGraphics()
    {
        string sql = $"SELECT * FROM Graphics";
        return GetData<GraphicsTable>(sql);
    }

    public static List<RAM> GetAllRAM()
    {
        string sql = $"SELECT * FROM RAM";
        return GetData<RAM>(sql);
    }

    public static List<StorageTypes> GetAllStorageTypes()
    {
        string sql = $"SELECT * FROM StorageTypes";
        return GetData<StorageTypes>(sql);
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

    public static RAM GetRAMByID(int id)
    {
        string sql = $"SELECT * FROM RAM WHERE RAMID LIKE \"id\"";
        return GetData<RAM>(sql)[0];
    }

    public static RAM GetStorageTypeByID(int id)
    {
        string sql = $"SELECT * FROM StorageTypes WHERE STID LIKE \"id\"";
        return GetData<RAM>(sql)[0];
    }

    //----------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------------------------------------------------------------------
    //                                      Запросы на добавление\обновление данных
    //----------------------------------------------------------------------------------------------------------------

    public static bool SetNewModel(Models newO)
    {
        string sql = $"INSERT INTO Models (Name, Options, Price, CategoryId, \"Release Date\", CPUID, DesignID, Weight, ScreenID, RAMID, StorageID, GraphicsID)" +
            $" VALUES ('{newO.Name}', '{newO.Options}','{newO.Price}','{newO.CategoryId}','{newO.Release_Date}','{newO.CPUID}'," +
            $"'{newO.DesignID}','{newO.Weight}','{newO.ScreenID}','{newO.RAMID}','{newO.StorageID}','{newO.GraphicsID}')";
        return SetData(sql);
    }

    public static bool UpdateModel(Models newO)
    {
        string sql = $"UPDATE Models SET Name = '{newO.Name}', Options='{newO.Options}', Price='{newO.Price}', CategoryId='{newO.CategoryId}', \"Release Date\"='{newO.Release_Date}'" +
            $", CPUID='{newO.CPUID}', DesignID='{newO.DesignID}', Weight='{newO.Weight}', ScreenID='{newO.ScreenID}', RAMID='{newO.RAMID}', StorageID='{newO.StorageID}', GraphicsID='{newO.GraphicsID}'" +
            $"WHERE ModelId='{newO.ModelId}'";
        return SetData(sql);
    }

    public static bool SetNewOrders(Orders newO)
    {
        string sql = $"INSERT INTO Orders (Name, Adress, City, State, Zip, Country, GiftWrap)" +
            $" VALUES ('{newO.Name}', '{newO.Adress}','{newO.City}','{newO.State}','{newO.Zip}','{newO.Country}'," +
            $"'{newO.GiftWrap}')";
        return SetData(sql);
    }

    public static bool UpdateOrders(Orders newO)
    {
        string sql = $"UPDATE Orders SET Name = '{newO.Name}', Adress='{newO.Adress}', City='{newO.City}', State='{newO.State}', Zip='{newO.Zip}'" +
            $", Country='{newO.Country}', GiftWrap='{newO.GiftWrap}' WHERE OrderID='{newO.OrderID}'";
        return SetData(sql);
    }

    public static bool SetNewCategories(Categories newO)
    {
        string sql = $"INSERT INTO Categories (Type, Description)" +
            $" VALUES ('{newO.Type}', '{newO.Description}')";
        return SetData(sql);
    }

    public static bool UpdateCategories(Categories newO)
    {
        string sql = $"UPDATE Categories SET Type = '{newO.Type}', Description='{newO.Description}' WHERE CategoryId='{newO.CategoryId}'";
        return SetData(sql);
    }

    public static bool SetNewCPU(Processors newO)
    {
        string sql = $"INSERT INTO Processors (Platform, Model, Cores, Threads, Frequency, \"Trubo Frequency\", TDP, GraphicsID)" +
            $" VALUES ('{newO.Platform}', '{newO.Model}','{newO.Cores}','{newO.Threads}','{newO.Trubo_Frequency}','{newO.TDP}'," +
            $"'{newO.GraphicsID}')";
        return SetData(sql);
    }

    public static bool UpdateCPU(Processors newO)
    {
        string sql = $"UPDATE Processors SET Platform = '{newO.Platform}', Model='{newO.Model}', Cores='{newO.Cores}', Threads='{newO.Threads}', Frequency='{newO.Frequency}'" +
            $", \"Trubo Frequency\"='{newO.Trubo_Frequency}', TDP='{newO.TDP}', GraphicsID='{newO.GraphicsID}'" +
            $"WHERE ProcID='{newO.ProcID}'";
        return SetData(sql);
    }

    public static bool SetNewDesign(Design newO)
    {
        string sql = $"INSERT INTO Design (Material, Color, \"Backlight Housing\", \"Keyboard Light\")" +
            $" VALUES ('{newO.Material}', '{newO.Color}','{newO.Backlight_Housing}','{newO.Keyboard_light}')";
        return SetData(sql);
    }

    public static bool UpdateDesign(Design newO)
    {
        string sql = $"UPDATE Design SET Material = '{newO.Material}', Color='{newO.Color}', \"Backlight Housing\"='{newO.Backlight_Housing}', \"Keyboard Light\"='{newO.Keyboard_light}'" +
            $"WHERE DesignID='{newO.DesignID}'";
        return SetData(sql);
    }

    public static bool SetNewScreen(ScreenTable newO)
    {
        string sql = $"INSERT INTO Screen (Diagonal, Resolution, Frequency, Surface, Technology)" +
            $" VALUES ('{newO.Diagonal}', '{newO.Resolution}','{newO.Frequency}','{newO.Surface}','{newO.Technology}')";
        return SetData(sql);
    }

    public static bool UpdateScreen(ScreenTable newO)
    {
        string sql = $"UPDATE Screen SET Diagonal = '{newO.Diagonal}', Resolution='{newO.Resolution}', Frequency='{newO.Frequency}'," +
            $" Surface='{newO.Surface}', Technology='{newO.Technology}'" +
            $"WHERE ScreenID='{newO.ScreenID}'";
        return SetData(sql);
    }

    public static bool SetNewStorages(Storage newO)
    {
        string sql = $"INSERT INTO Storage (Type, Volume, \"M.2 Slots\", \"SSD Interface\")" +
            $" VALUES ('{newO.Type}', '{newO.Volume}','{newO.M_2_Slots}','{newO.SSD_Interface}')";
        return SetData(sql);
    }

    public static bool UpdateStorages(Storage newO)
    {
        string sql = $"UPDATE Storage SET Type = '{newO.Type}', Volume='{newO.Volume}', \"M.2 Slots\"='{newO.M_2_Slots}'," +
            $" \"SSD Interface\"='{newO.SSD_Interface}'" +
            $"WHERE StorageID='{newO.StorageID}'";
        return SetData(sql);
    }

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
        try
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
        catch
        {
            return new List<T>();
        }
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
