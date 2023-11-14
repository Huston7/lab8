using System;

// Абстрактний клас або інтерфейс для компоненту - екран
abstract class Screen
{
    public abstract void Display();
}

// Конкретна реалізація екрану для смартфона
class SmartphoneScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Smartphone Screen");
    }
}

// Конкретна реалізація екрану для ноутбука
class LaptopScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Laptop Screen");
    }
}

// Конкретна реалізація екрану для планшета
class TabletScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Tablet Screen");
    }
}

// Абстрактний клас або інтерфейс для компоненту - процесор
abstract class Processor
{
    public abstract void Process();
}

// Конкретна реалізація процесору для смартфона
class SmartphoneProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Smartphone Processor");
    }
}

// Конкретна реалізація процесору для ноутбука
class LaptopProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Laptop Processor");
    }
}

// Конкретна реалізація процесору для планшета
class TabletProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Tablet Processor");
    }
}

// Абстрактний клас або інтерфейс для компоненту - камера
abstract class Camera
{
    public abstract void Capture();
}

// Конкретна реалізація камери для смартфона
class SmartphoneCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Smartphone Camera");
    }
}

// Конкретна реалізація камери для ноутбука
class LaptopCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Laptop Camera");
    }
}

// Конкретна реалізація камери для планшета
class TabletCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Tablet Camera");
    }
}

// Абстрактна фабрика для створення компонентів
abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретна реалізація фабрики для смартфона
class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public override Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

// Конкретна реалізація фабрики для ноутбука
class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public override Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public override Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

// Конкретна реалізація фабрики для планшета
class TabletFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new TabletScreen();
    }

    public override Processor CreateProcessor()
    {
        return new TabletProcessor();
    }

    public override Camera CreateCamera()
    {
        return new TabletCamera();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of tech product to create (smartphone/laptop/tablet):");
        string productType = Console.ReadLine();

        // Вибір фабрики відповідно до введеного типу продукту
        TechProductFactory factory;
        switch (productType.ToLower())
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;
            case "laptop":
                factory = new LaptopFactory();
                break;
            case "tablet":
                factory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid product type");
                return;
        }

        // Створення компонентів та відображення їх інформації
        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        screen.Display();
        processor.Process();
        camera.Capture();
    }
}
