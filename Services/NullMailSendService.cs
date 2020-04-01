using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirusCore.Services
{
    public class NullMailSendService : IMailService
    {
        private readonly ILogger<NullMailSendService> logger;

        public NullMailSendService(ILogger<NullMailSendService> logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string to, string from, string subject, string message)
        {
            this.logger.LogInformation(string.Format("To: {0} From : {1} Subject: {2} Message : {3}", to, from, subject, message));
        }
    }
}
