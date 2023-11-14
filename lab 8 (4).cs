using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using CsvHelper;

// Прототип для шаблону даних
interface IDataPrototype
{
    IDataPrototype Clone();
    void DisplayData();
}

// Конкретна реалізація прототипу для шаблону даних
class DataTemplate : IDataPrototype
{
    public string Field1 { get; set; }
    public string Field2 { get; set; }

    public IDataPrototype Clone()
    {
        return MemberwiseClone() as IDataPrototype;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Field1: {Field1}, Field2: {Field2}");
    }
}

// Адаптер для перетворення даних між різними форматами
interface IDataAdapter
{
    string ConvertData(IDataPrototype data);
}

// Адаптер для перетворення з CSV у JSON
class CsvToJsonAdapter : IDataAdapter
{
    public string ConvertData(IDataPrototype data)
    {
        StringWriter sw = new StringWriter();
        var csvWriter = new CsvWriter(sw);
        csvWriter.WriteRecord(new { data.Field1, data.Field2 });
        csvWriter.Flush();
        return JsonConvert.SerializeObject(sw.ToString());
    }
}

// Адаптер для перетворення з XML у JSON
class XmlToJsonAdapter : IDataAdapter
{
    public string ConvertData(IDataPrototype data)
    {
        var xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(rootNode);

        XmlNode dataNode = xmlDoc.CreateElement("Data");
        rootNode.AppendChild(dataNode);

        XmlNode field1Node = xmlDoc.CreateElement("Field1");
        field1Node.InnerText = data.Field1;
        dataNode.AppendChild(field1Node);

        XmlNode field2Node = xmlDoc.CreateElement("Field2");
        field2Node.InnerText = data.Field2;
        dataNode.AppendChild(field2Node);

        return JsonConvert.SerializeXmlNode(xmlDoc);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення прототипу для шаблону даних
        IDataPrototype dataTemplate = new DataTemplate { Field1 = "Value1", Field2 = "Value2" };

        // Вибір формату вихідних даних (CSV, XML)
        Console.WriteLine("Choose the source data format (CSV, XML):");
        string sourceFormat = Console.ReadLine();

        // Вибір формату цільових даних (CSV, XML, JSON)
        Console.WriteLine("Choose the target data format (CSV, XML, JSON):");
        string targetFormat = Console.ReadLine();

        // Адаптер для перетворення даних
        IDataAdapter dataAdapter = null;

        if (sourceFormat.Equals("CSV", StringComparison.OrdinalIgnoreCase) &&
            targetFormat.Equals("JSON", StringComparison.OrdinalIgnoreCase))
        {
            dataAdapter = new CsvToJsonAdapter();
        }
        else if (sourceFormat.Equals("XML", StringComparison.OrdinalIgnoreCase) &&
                 targetFormat.Equals("JSON", StringComparison.OrdinalIgnoreCase))
        {
            dataAdapter = new XmlToJsonAdapter();
        }
        else
        {
            Console.WriteLine("Unsupported conversion.");
            return;
        }

        // Використання адаптера для перетворення даних
        string convertedData = dataAdapter.ConvertData(dataTemplate);

        // Виведення результату
        Console.WriteLine("Converted data:");
        Console.WriteLine(convertedData);
    }
}
