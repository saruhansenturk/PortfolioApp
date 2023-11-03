namespace PortfolioApp.Application.Exceptions.DatabaseExceptions;

public class AddRangeException : Exception
{
    public AddRangeException() : base("Veriler eklenirken bir sorun oluştu. Lütfen verileri kontrol ediniz.")
    {
    }

    public AddRangeException(string? message) : base(message)
    {
    }

    public AddRangeException(string? message, Exception? exception) : base(message, exception)
    {
    }
}