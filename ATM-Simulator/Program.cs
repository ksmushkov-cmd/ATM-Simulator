using System;

namespace ATM_Simulator {
  public class Program {
    private static void Main() {

      Console.WriteLine($"Добро пожаловать в {ATM.Instance.Name}!\n" +
                         "СИМУЛЯЦИЯ БАНКОМАТА");

      ATM.Instance.Method1();
      ATM.Instance.Method2();

      Console.WriteLine("\nАВТОРИЗАЦИЯ");

      Console.Write("Введите номер карты: ");
      string cardNum = Console.ReadLine();
      Console.Write("Введите PIN-код: ");
      string pin = Console.ReadLine();

      if (!ATM.Instance.Login(cardNum, pin)) {
        Console.WriteLine("Доступ запрещён. Нажмите Enter для выхода...");
        _ = Console.ReadKey();
        return;
      }

      bool exit = false;
      while (!exit) {
        Console.WriteLine("\n--- МЕНЮ ---\n" +
                          "1. Проверить баланс\n" +
                          "2. Внести деньги\n" +
                          "3. Снять деньги\n" +
                          "4. Перевести деньги\n" +
                          "5. Выйти");
        Console.Write("Выберите действие: ");

        string choice = Console.ReadLine();

        switch (choice) {
          case "1":
            ATM.Instance.ShowBalance();
            break;
          case "2":
            ATM.Instance.Deposit();
            break;
          case "3":
            ATM.Instance.Withdraw();
            break;
          case "4":
            ATM.Instance.Transfer();
            break;
          case "5":
            ATM.Instance.Logout();
            exit = true;
            Console.WriteLine("Спасибо за использование банкомата! =D");
            break;
          default:
            Console.WriteLine("Неверный пункт меню.");
            break;
        }
      }

      _ = Console.ReadKey();
    }
  }
}