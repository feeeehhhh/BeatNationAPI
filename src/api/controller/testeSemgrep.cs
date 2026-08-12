using Microsoft.Data.SqlClient;

public class SemgrepTest
{
    public void Test(string userId)
    {
        var connection = new SqlConnection("Server=localhost;Database=Test;");
        var command = new SqlCommand(
            "SELECT * FROM Users WHERE Id = " + userId,
            connection
        );
    }
}