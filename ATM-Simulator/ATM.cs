using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_Simulator {
  public class ATM {
    public static ATM Instance {
      get {
        if (instance == null) {
          instance = new ATM();
        }
        return instance;
      }
    }

    public string Name { get; private set; }

    // Поля класса
    private readonly List<User> users;
    private User currentUser;

    private ATM() {
      users = new List<User>();
      // Добавляем тестовых пользователей
      users.Add(new User("Кирилл", "85148852", "4321", 50000));
      users.Add(new User("Никита", "54325289", "5267", 30000));
      users.Add(new User("Паша", "65424671", "1488", 100000));

      Name = "AuraCash";
    }

    public void Method1() {
      Console.WriteLine("ATM.Method1 - Банкомат готов к работе");
    }

    public void Method2() {
      Console.WriteLine("ATM.Method2 - Версия банкомата 1.0");
    }

    // Метод для входа в систему
    public bool Login(string cardNumber, string pinCode) {
      currentUser = users.FirstOrDefault(u => u.CardNumber == cardNumber && u.PinCode == pinCode);

      if (currentUser != null) {
        Console.WriteLine($"\nДобро пожаложить, {currentUser.Name}!");
        return true;
      }

      Console.WriteLine("\nОшибка: неверный номер карты или PIN-код.");
      return false;
    }

    public void ShowBalance() {
      if (currentUser == null) {
        Console.WriteLine("Вы не вошли в систему");
        return;
      }
      Console.WriteLine($"\n{currentUser.Name}, ваш баланс: {currentUser.Balance} руб.");
    }

    public void Deposit() {
      if (currentUser == null) {
        Console.WriteLine("Вы не вошли в систему");
        return;
      }

      Console.Write("Введите сумму для внесения: ");
      double amount = double.Parse(Console.ReadLine());

      if (amount <= 0) {
        Console.WriteLine("Сумма должна быть больше 0.");
        return;
      }

      currentUser.Balance += amount;
      Console.WriteLine($"Вы внесли {amount} руб. Новый баланс: {currentUser.Balance} руб.");
    }

    // Снять деньги
    public void Withdraw() {
      if (currentUser == null) {
        Console.WriteLine("Вы не вошли в систему");
        return;
      }

      Console.Write("Введите сумму для снятия: ");
      double amount = double.Parse(Console.ReadLine());

      if (amount <= 0) {
        Console.WriteLine("Сумма должна быть больше 0.");
        return;
      }

      if (amount > currentUser.Balance) {
        Console.WriteLine($"Недостаточно средств. Ваш баланс: {currentUser.Balance} руб.");
        return;
      }

      currentUser.Balance -= amount;
      Console.WriteLine($"Вы сняли {amount} руб. Остаток: {currentUser.Balance} руб.");
    }

    public void Transfer() {
      if (currentUser == null) {
        Console.WriteLine("Вы не вошли в систему");
        return;
      }

      Console.Write("Введите номер карты получателя: ");
      string toCard = Console.ReadLine();

      Console.Write("Введите сумму перевода: ");
      double amount = double.Parse(Console.ReadLine());

      if (amount <= 0) {
        Console.WriteLine("Сумма должна быть больше 0.");
        return;
      }

      if (amount > currentUser.Balance) {
        Console.WriteLine($"Недостаточно средств. Ваш баланс: {currentUser.Balance} руб.");
        return;
      }

      User toUser = users.FirstOrDefault(u => u.CardNumber == toCard);

      if (toUser == null) {
        Console.WriteLine("Получатель с таким номером карты не найден.");
        return;
      }

      currentUser.Balance -= amount;
      toUser.Balance += amount;
      Console.WriteLine($"Перевод {amount} руб. пользователю {toUser.Name} выполнен!");
      Console.WriteLine($"Ваш новый баланс: {currentUser.Balance} руб.");
    }

    public void Logout() {
      currentUser = null;
      Console.WriteLine("\nВы вышли из системы.");
    }

    private static ATM instance;
  }
}
