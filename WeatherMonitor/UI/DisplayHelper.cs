using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.UI;

public static class DisplayHelper
{
    public static void Print(string body, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(body);
        Console.ResetColor();
    }

    public static void PrintLine(string body, ConsoleColor color = ConsoleColor.White)
        => Print($"{body}\n", color);

    public static void ShowWelcomeMessage()
    {
        PrintLine("""
                        
                             __    __     _                          
                            / / /\ \ \___| | ___ ___  _ __ ___   ___ 
                            \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \
                             \  /\  /  __/ | (_| (_) | | | | | |  __/
                              \/  \/ \___|_|\___\___/|_| |_| |_|\___|

            
            """, ConsoleColor.Blue);
    }

    public static T? PromptMenu<T>(string message, string? exitItem = null) where T : struct, Enum
    {
        var items = GetMenuListFromEnum<T>();
        if (exitItem != null) items.Add(exitItem);

        int previousLineIndex = -1, selectedLineIndex = 0;
        ConsoleKey pressedKey;

        do
        {
            if (previousLineIndex != selectedLineIndex)
            {
                DrawMenu(items, selectedLineIndex, message);
                previousLineIndex = selectedLineIndex;
            }
            pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.DownArrow && selectedLineIndex + 1 < items.Count)
                selectedLineIndex++;

            else if (pressedKey == ConsoleKey.UpArrow && selectedLineIndex - 1 >= 0)
                selectedLineIndex--;

        } while (pressedKey != ConsoleKey.Enter);

        if (exitItem != null && selectedLineIndex == items.Count - 1) return null;

        return (T)Enum.Parse(typeof(T), Enum.GetNames(typeof(T))[selectedLineIndex]);
    }

    public static void DrawMenu(List<string> items, int selectedIndex, string message = "")
    {
        Console.Clear();
        PrintLine(message, ConsoleColor.Magenta);
        Console.WriteLine();
        for (int i = 0; i < items.Count; i++)
        {
            bool isSelected = i == selectedIndex;
            if (isSelected)
                DrawSelectedMenuItem(items[i]);
            else
                PrintLine($"  {items[i]}", ConsoleColor.Yellow);
        }
    }

    public static void DrawSelectedMenuItem(string item)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"> {item}");
        Console.ResetColor();
    }

    public static List<string> GetMenuListFromEnum<T>() where T : Enum
        => Enum.GetNames(typeof(T)).Select(item => item.Replace('_', ' ')).ToList();

    public static void Pause(string message)
    {
        Print(message, ConsoleColor.Blue);
        Console.ReadLine();
    }
}
