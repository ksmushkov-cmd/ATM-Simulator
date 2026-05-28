namespace ATM_Simulator {
  public class User {
    public string Name { get; set; }
    public string CardNumber { get; set; }
    public string PinCode { get; set; }
    public double Balance { get; set; }

    public User(string name, string cardNumber, string pinCode, double balance) {
      Name = name;
      CardNumber = cardNumber;
      PinCode = pinCode;
      Balance = balance;
    }
  }
}
