using System;

class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private readonly System.Collections.Generic.Dictionary<string, string> _configurations;

    private ConfigurationManager()
    {
        _configurations = new System.Collections.Generic.Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public void SetConfiguration(string key, string value)
    {
        _configurations[key] = value;
    }

    public string GetConfiguration(string key)
    {
        return _configurations.TryGetValue(key, out var value) ? value : null;
    }

    public void DisplayConfigurations()
    {
        Console.WriteLine("Current Configurations:");
        foreach (var entry in _configurations)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        while (true)
        {
            Console.WriteLine("1. Set Configuration");
            Console.WriteLine("2. Get Configuration");
            Console.WriteLine("3. Display Configurations");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter value: ");
                    string value = Console.ReadLine();
                    configManager.SetConfiguration(key, value);
                    Console.WriteLine("Configuration set successfully.");
                    break;

                case 2:
                    Console.Write("Enter key: ");
                    string getKey = Console.ReadLine();
                    string getConfig = configManager.GetConfiguration(getKey);
                    Console.WriteLine($"Configuration for key '{getKey}': {getConfig}");
                    break;

                case 3:
                    configManager.DisplayConfigurations();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
