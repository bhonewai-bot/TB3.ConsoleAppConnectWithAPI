// See https://aka.ms/new-console-template for more information

using TB3.ConsoleAppConnectWithApi;

Start:

Console.WriteLine("-- Welcome to Product API --");
Console.WriteLine("Choose Menu: 1 - Read, 2 - Create, 3- Details, 4 - Update, 0 - Exit");
int choice = Convert.ToInt32(Console.ReadLine());

HttpClientService httpClientService = new HttpClientService();

switch (choice)
{
    case 1:
        await httpClientService.Read();
        goto Start;
    case 2:
        await httpClientService.Create();
        goto Start;
    case 3:
        await httpClientService.Details();
        goto Start;
    case 4:
        await httpClientService.Update();
        goto Start;
    case 5:
    default:
        Console.WriteLine("Exiting...");
        goto Exit;
        
        Exit: Console.ReadLine();
        break;
}