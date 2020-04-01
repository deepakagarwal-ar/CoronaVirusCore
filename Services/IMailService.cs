namespace CoronaVirusCore.Services
{
    public interface IMailService
    {
        void SendMessage(string to, string from, string subject, string message);
    }
}