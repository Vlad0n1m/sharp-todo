namespace ProductionReadyArrayListAPI.Project.Domain.ValueObjects;

public class Email
{
    public string Value { get; set; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email cannot be empty.", nameof(Email));
        }

        if (!IsValidEmail(value))
        {
            throw new ArgumentException("Invalid email format", nameof(Email));
            
        }
        Value = value;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var mailAdress = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public static implicit operator string(Email email) => email.Value;
    public static explicit operator Email(string email) => new Email(email);

    public override string ToString() => Value;




}