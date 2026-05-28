using System;

namespace ATM_Simulator {
  public class Program {
    private static void Main() {
      Console.WriteLine("Нажмите Enter для запуска программы...");
      _ = Console.ReadLine();

      Console.WriteLine("СИМУЛЯЦИЯ БАНКОМАТА\n");

      ATM.Instance.Method1();
      ATM.Instance.Method2();

      Console.WriteLine("\nАВТОРИЗАЦИЯ");

      // Вход в систему
      Console.Write("Введите номер карты: ");
      string cardNum = Console.ReadLine();
      Console.Write("Введите PIN-код: ");
      string pin = Console.ReadLine();

      if (!ATM.Instance.Login(cardNum, pin)) {
        Console.WriteLine("Доступ запрещён. Нажмите Enter для выхода...");
        _ = Console.ReadLine();
        return;
      }

      // Основное меню
      bool exit = false;
      while (!exit) {
        Console.WriteLine("\n--- МЕНЮ ---\n" +
                          "1. Проверить баланс\n" +
                          "2. Внести деньги\n" +
                          "3. Снять деньги\n" +
                          "4. Перевести деньги\n" +
                          "5. Выйти");
        Console.Write("Выберите действие: ");
      }
    }
  }
}