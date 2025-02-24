static int Input(string variable)
{
    int value = 0;
    while (true)
    {
        Console.Write($"Введите параметр {variable}: ");
        try
        {
            value = Convert.ToInt32(Console.ReadLine());
            break;
        }
        catch
        {
            Console.WriteLine("Неверный формат ввода\n");
        }
    }
    return value;
}

Console.WriteLine("==========Программа табуляции функции y(x) = cos(x^2)+sin^2(x)==========\n");
Console.WriteLine("Параметр a - левая граница отрезка\nПараметр b - правая граница отрезка\nПараметр h - шаг\n");

int a, b, h, points = 0, count_sign_changes = 0;
double y = 0, previous_y = 0;

a = Input("a");

b = Input("b");
while (b <= a)
{
    Console.WriteLine("\nПараметр b должен быть больше параметра a\n");
    b = Input("b");
}

h = Input("h");
while (h <= 0)
{
    Console.WriteLine("\nПараметр h должен быть больше 0\n");
    h = Input("h");
}

int min_x = a;
int max_x = b;
double min_y = double.PositiveInfinity;
double max_y = double.NegativeInfinity;

Console.WriteLine("\nx\ty(x)");

for (int x = a; x <= b; x += h)
{
    y = Math.Cos(Math.Pow(x, 2)) + Math.Pow(Math.Sin(x), 2);
    Console.WriteLine($"{x}\t{y}");
    points++;

    if (x != a)
    {
        if ((previous_y > 0 && y < 0) || (previous_y < 0 && y > 0))
        {
            count_sign_changes++;
        }
    }

    previous_y = y;

    if (y < min_y)
    {
        min_y = y;
        min_x = x;
    }
    if (y > max_y)
    {
        max_y = y;
        max_x = x;
    }
}

Console.WriteLine("\nКоличество точек: " + points);
Console.WriteLine($"Минимальное значение функции y(x) = {min_y} при x = {min_x}");
Console.WriteLine($"Максимальное значение функции y(x) = {max_y} при x = {max_x}");
Console.WriteLine($"Количество изменений знака функции: {count_sign_changes}");
