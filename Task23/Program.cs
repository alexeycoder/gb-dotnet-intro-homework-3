// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

do
{
	Console.Clear();
	PrintTitle("Таблица кубов чисел от 1 до заданного", ConsoleColor.Cyan);

	long n = GetUserInput("Введите натуральное число: ", "Некорректный ввод! Пожалуйста повторите");

	PrintCubeTable(n);

} while (AskForRepeat());

// Methods

void PrintCubeTable(long max)
{
	const int padLeft = 3;
	const int padRight = 5;
	const int marginSize = 2;

	string margin = new string(' ', marginSize);

	string tableTitleLeft = margin + "N".PadLeft(padLeft) + margin;
	string tableTitleRight = margin + "N\u00b3".PadRight(padRight) + margin;

	string leftHorizSep = new string('\u2500', tableTitleLeft.Length);
	string rightHorizSep = new string('\u2500', tableTitleRight.Length);

	string upperFrame = leftHorizSep + "\u252c" + rightHorizSep;
	string midFrame = leftHorizSep + "\u253c" + rightHorizSep;
	string lowerFrame = leftHorizSep + "\u2534" + rightHorizSep;

	Console.WriteLine(upperFrame);
	Console.WriteLine(margin + "N".PadLeft(padLeft) + margin + "\u2502" + margin + "N\u00b3".PadRight(padRight) + margin);
	Console.WriteLine(midFrame);
	for (long i = 1; i <= max; ++i)
	{
		Console.WriteLine($"{margin}{i,padLeft}{margin}\u2502{margin}{i * i * i,-padRight}{margin}");
	}
	Console.WriteLine(lowerFrame);
}

bool CheckIfValid(long input)
{
	return input > 0;
}

long GetUserInput(string inputMessage, string errorMessage)
{
	long input;
	bool handleError = false;
	do
	{
		if (handleError)
		{
			PrintError(errorMessage, ConsoleColor.Magenta);
		}
		Console.Write(inputMessage);
		handleError = !(long.TryParse(Console.ReadLine(), out input) && CheckIfValid(input));

	} while (handleError);

	return input;
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
