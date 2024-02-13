namespace apiwc.db;

public class MysqlConfiguration
{
    public MysqlConfiguration(string sqlString)
    {
        ConnectionString = sqlString;
    }
    public string ConnectionString
    {
        get;
        set;
    }
}