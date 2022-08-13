// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

do
{
	Console.Clear();
	PrintTitle("Проверка, является ли пятизначное число палиндромом", ConsoleColor.Cyan);

	int number = GetUserInput("Введите натуральное пятизначное число: ", "Некорректный ввод! Пожалуйста повторите");

	PrintColored($"Вывод: {number} -> {(CheckIfPalindrome(number) ? "Да" : "Нет")}", ConsoleColor.Yellow);

} while (AskForRepeat());

// Methods

bool CheckIfPalindrome(int num)
{
	if (num < 101)
		return false;

	int reversed = 0;
	for (int buffer = num; buffer > 0; buffer /= 10)
	{
		reversed = reversed * 10 + buffer % 10;
	}

	return reversed == num;
}

// bool CheckIfPalindrome_StraightWay(int num)
// {
// 	if (num < 101)
// 		return false;

// 	int magnitude = 100;
// 	while (num >= magnitude * 10) magnitude *= 10; // alt way : Math.Pow(10, Math.Floor(Math.Log10(number)));

// 	while (num >= 10)
// 	{
// 		int left = num / magnitude;
// 		int right = num % 10;

// 		if (left != right)
// 			return false;

// 		num -= left * magnitude;
// 		num /= 10;
// 		magnitude /= 100;
// 	}

// 	return true;
// }

bool CheckIfValid(int input)
{
	return input >= 10000 && input <= 99999;
}

int GetUserInput(string inputMessage, string errorMessage)
{
	int input;
	bool handleError = false;
	do
	{
		if (handleError)
		{
			PrintError(errorMessage, ConsoleColor.Magenta);
		}
		Console.Write(inputMessage);
		handleError = !(int.TryParse(Console.ReadLine(), out input) && CheckIfValid(input));

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
