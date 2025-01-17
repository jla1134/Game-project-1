using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Account
{
    public string Username { get; private set; }
    private int ID { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public bool IsActive { get; set; }

    public Account(string username, string passwordHash, string email)
    {
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
        CreatedDate = DateTime.Now;
        IsActive = true;
    }
}

public class AccountManager
{
    private readonly string CSV_PATH = "accounts.csv";
    private List<Account> accounts = new List<Account>();

    public (bool success, string message) CreateAccount(string username, string password, string email)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            return (false, "Username must be at least 3 characters long");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            return (false, "Password must be at least 6 characters long");

        if (!IsValidEmail(email))
            return (false, "Invalid email format");

        if (accounts.Any(a => a.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            return (false, "Username already exists");

        if (accounts.Any(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            return (false, "Email already registered");

        // Hash password
        string passwordHash = HashPassword(password);

        // Create account
        var account = new Account(username, passwordHash, email);
        accounts.Add(account);

        // Save to CSV
        SaveAccounts();

        return (true, "Account created successfully");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    private void SaveAccounts()
    {
        using (StreamWriter writer = new StreamWriter(CSV_PATH))
        {
            writer.WriteLine("Username,PasswordHash,Email,CreatedDate,IsActive");
            foreach (var account in accounts)
            {
                writer.WriteLine($"{account.Username},{account.PasswordHash},{account.Email},{account.CreatedDate},{account.IsActive}");
            }
        }
    }

    public void LoadAccounts()
    {
        if (!File.Exists(CSV_PATH)) return;

        accounts.Clear();
        using (StreamReader reader = new StreamReader(CSV_PATH))
        {
            // Skip header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var account = new Account(
                    values[0],
                    values[1],
                    values[2]
                )
                {
                    IsActive = bool.Parse(values[4])
                };
                accounts.Add(account);
            }
        }
    }

    public bool ValidateLogin(string username, string password)
    {
        var account = accounts.FirstOrDefault(a => 
            a.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (account == null || !account.IsActive)
            return false;

        string hashedPassword = HashPassword(password);
        return account.PasswordHash == hashedPassword;
    }
}
