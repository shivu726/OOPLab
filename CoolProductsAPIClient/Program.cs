
public class Program
{
    public static void Main(string[] args)
    {
        var apiUri = "https://localhost:44322/api/Products";

        HttpClient client = new HttpClient();

        var result = client.GetAsync(apiUri).Result;
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var data = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(data);
        }
        else
        {
            Console.WriteLine(result.StatusCode.ToString());
        }   
    }
}