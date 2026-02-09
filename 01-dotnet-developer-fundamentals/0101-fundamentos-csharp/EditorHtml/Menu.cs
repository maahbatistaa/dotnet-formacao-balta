using System;

namespace EditorHtml
{
  public static class Menu
  {
    public static void Show()
    {
      Console.Clear();
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.Black;

      DrawScreen();
      WriteOptions();

      var option = short.Parse(Console.ReadLine());
      HandleMenuOption(option);
    }

    public static void DrawScreen()
    {
      Lines(30);
      Columns(10, 30);
      Lines(30);
    }

    public static void Lines(int lines)
    {
      Console.Write("+");
      for (int i = 0; i <= lines; i++)
        Console.Write("-");

      Console.Write("+");
      Console.Write("\n");
    }

    public static void Columns(int columns, int lines)
    {
      for (int line = 0; line <= columns; line++)
      {
        Console.Write("|");
        for (int i = 0; i <= lines; i++)
          Console.Write(" ");
        Console.Write("|");
        Console.Write("\n");
      }
    }

    public static void WriteOptions()
    {
      Console.SetCursorPosition(3, 2);
      Console.WriteLine("Editor HTML");
      Console.SetCursorPosition(3, 3);
      Console.WriteLine("============");
      Console.SetCursorPosition(3, 4);
      Console.WriteLine("Selecione uma opção abaixo:");
      Console.SetCursorPosition(3, 6);
      Console.WriteLine("1 - Novo arquivo");
      Console.SetCursorPosition(3, 7);
      Console.WriteLine("2 - Abrir");
      Console.SetCursorPosition(3, 9);
      Console.WriteLine("0 - Sair");
      Console.SetCursorPosition(3, 10);
      Console.Write("Opção: ");
    }

    public static void HandleMenuOption(short option)
    {
      switch (option)
      {
        case 1: Editor.Show(); break;
        case 2: Console.Write("View"); break;
        case 0:
          {
            Console.Clear();
            Environment.Exit(0);
            break;
          }
        default: Show(); break;
      }
    }
  }
}