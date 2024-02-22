namespace apiwc.db;

public class MysqlConfiguration(string sqlString)
{
    public string ConnectionString
    {
        get;
        set;
    } = sqlString;
}