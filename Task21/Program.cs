// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

const string title = "Расстояние между точками A и B";
const string errorMsg = "Некорректный ввод! Пожалуйста повторите";
Console.Title = title;

do
{
	Console.Clear();
	PrintTitle(title, ConsoleColor.Cyan);

	Console.WriteLine("Введите координаты точки A:");
	double aX = GetUserInput("X?: ", errorMsg);
	double aY = GetUserInput("Y?: ", errorMsg);
	double aZ = GetUserInput("Z?: ", errorMsg);

	Console.WriteLine("Введите координаты точки B:");
	double bX = GetUserInput("X?: ", errorMsg);
	double bY = GetUserInput("Y?: ", errorMsg);
	double bZ = GetUserInput("Z?: ", errorMsg);

	double distance = CalcDistance(aX, aY, aZ, bX, bY, bZ);

	PrintColored($"A ({aX} , {aY} , {aZ}); B ({bX} , {bY} , {bZ}) -> {distance:F2}", ConsoleColor.Yellow);

} while (AskForRepeat());

// Methods

double CalcDistance(double x1, double y1, double z1, double x2, double y2, double z2)
{
	double dx = x2 - x1;
	double dy = y2 - y1;
	double dz = z2 - z1;
	return Math.Sqrt(dx * dx + dy * dy + dz * dz);
}

double GetUserInput(string inputMessage, string errorMessage)
{
	double input = 0;
	bool handleError = false;
	do
	{
		if (handleError)
		{
			PrintError(errorMessage, ConsoleColor.Magenta);
		}
		Console.Write(inputMessage);

		string? inputStr = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(inputStr))
		{
			handleError = true;
			continue;
		}
		handleError = !(double.TryParse(MakeInvariantToSeparator(inputStr), out input));

	} while (handleError);

	return input;
}

string MakeInvariantToSeparator(string input)
{
	char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
	char wrongSeparator = decimalSeparator.Equals('.') ? ',' : '.';
	return input.Replace(wrongSeparator, decimalSeparator);
}

void PrintTitle(string title, ConsoleColor foreColor)
{
	string titleDelimiter = new string('\u2550', title.Length);
	PrintColored(titleDelimiter + Environment.NewLine + title + Environment.NewLine + titleDelimiter, foreColor);
}

void PrintError(string errorMessage, ConsoleColor foreColor)
{
	PrintColored("\u2757 Ошибка: " + errorMessage, foreColor);
}

void PrintColored(string message, ConsoleColor foreColor)
{
	var bkpColor = Console.ForegroundColor;
	Console.ForegroundColor = foreColor;
	Console.WriteLine(message);
	Console.ForegroundColor = bkpColor;
}

bool AskForRepeat()
{
	Console.WriteLine();
	Console.WriteLine("Нажмите Enter, чтобы повторить или Esc, чтобы завершить...");
	ConsoleKeyInfo key = Console.ReadKey(true);
	return key.Key != ConsoleKey.Escape;
}
