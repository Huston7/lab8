using System;
using System.Collections.Generic;

// Абстрактний клас або інтерфейс для всіх типів графіків
abstract class Chart
{
    public abstract void Draw();
}

// Конкретна реалізація графіка - лінійний графік
class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
        // Реалізація лінійного графіка
    }
}

// Конкретна реалізація графіка - стовпчиковий графік
class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
        // Реалізація стовпчикового графіка
    }
}

// Конкретна реалізація графіка - кругова діаграма
class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Реалізація кругової діаграми
    }
}

// Фабричний метод для створення графіків
abstract class GraphFactory
{
    public abstract Chart CreateChart();
}

// Конкретна реалізація фабрики для лінійного графіка
class LineChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new LineChart();
    }
}

// Конкретна реалізація фабрики для стовпчикового графіка
class BarChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new BarChart();
    }
}

// Конкретна реалізація фабрики для кругової діаграми
class PieChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of chart to create (line/bar/pie):");
        string chartType = Console.ReadLine();

        // Вибір фабрики відповідно до введеного типу графіка
        GraphFactory factory;
        switch (chartType.ToLower())
        {
            case "line":
                factory = new LineChartFactory();
                break;
            case "bar":
                factory = new BarChartFactory();
                break;
            case "pie":
                factory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid chart type");
                return;
        }

        // Створення та візуалізація графіка
        Chart chart = factory.CreateChart();
        chart.Draw();
    }
}
