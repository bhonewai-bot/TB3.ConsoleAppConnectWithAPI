using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using TB3.ConsoleAppConnectWithApi.Dtos;

namespace TB3.ConsoleAppConnectWithApi;

public class HttpClientService
{
    private readonly string _baseUrl = "https://localhost:7043";

    public async Task Read()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"{_baseUrl}/product");
        if (response.IsSuccessStatusCode)
        {
            var lts = await response.Content.ReadFromJsonAsync<List<ProductResponseDto>>();

            Console.WriteLine("Product List:");
            Console.WriteLine("-------------------------");
            foreach (var item in lts)
            {
                Console.WriteLine($"Product Code: {item.ProductCode}");
                Console.WriteLine($"Product Name: {item.ProductName}");
                Console.WriteLine($"Price       : {item.Price:N2}");
                Console.WriteLine($"Quantity    : {item.Quantity:N0}");
                Console.WriteLine("-------------------------");
            }
        }
    }

    public async Task Create()
    {
        Console.Write("Enter product code: ");
        string productCode = Console.ReadLine();
        
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();

        Console.Write("Enter price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter product category code: ");
        string productCategoryCode = Console.ReadLine();

        ProductCreateRequestDto request = new ProductCreateRequestDto()
        {
            ProductCode = productCode,
            ProductName = productName,
            Price = price,
            Quantity = quantity,
            ProductCategoryCode = productCategoryCode
        };

        string jsonRequest = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

        HttpClient client = new HttpClient();
        var response = await client.PostAsync($"{_baseUrl}/product", content);
        var message = await response.Content.ReadAsStringAsync();
        Console.WriteLine(message);
    }

    public async Task Details()
    {
        Console.Write("Enter product id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"{_baseUrl}/product/{id}");
        if (response.IsSuccessStatusCode)
        {
            var item = await response.Content.ReadFromJsonAsync<ProductResponseDto>();

            Console.WriteLine($"Product Code: {item.ProductCode}");
            Console.WriteLine($"Product Name: {item.ProductName}");
            Console.WriteLine($"Price       : {item.Price:N2}");
            Console.WriteLine($"Quantity    : {item.Quantity:N0}");
        }
    }

    public async Task Update()
    {
        Console.Write("Enter product id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter product code: ");
        string productCode = Console.ReadLine();
        
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();

        Console.Write("Enter price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter product category code: ");
        string productCategoryCode = Console.ReadLine();

        ProductUpdateRequestDto request = new ProductUpdateRequestDto()
        {
            ProductCode = productCode,
            ProductName = productName,
            Price = price,
            Quantity = quantity,
            ProductCategoryCode = productCategoryCode
        };

        string jsonRequest = JsonConvert.SerializeObject(request);
        StringContent content = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);
        
        HttpClient client = new HttpClient();
        var response = await client.PutAsync($"{_baseUrl}/product/{id}", content);
        var message = await response.Content.ReadAsStringAsync();
        Console.WriteLine(message);
    }

    public async Task Delete()
    {
        Console.Write("Enter product id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        HttpClient client = new HttpClient();
        var response = await client.DeleteAsync($"{_baseUrl}/product/{id}");
        var message = await response.Content.ReadAsStringAsync();
        Console.WriteLine(message);
    }
}