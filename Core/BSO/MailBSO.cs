using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
namespace BSO
{
    public class MailBSO
    {
        public MailBSO() 
        {
            //contrustor
        }

        private string emailfrom;
        public string EmailFrom 
        {
            set { emailfrom = value; }
            get { return emailfrom; }
        }

        #region SendMail
        public bool SendMail(string emailTo, string subject, string body)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(emailfrom);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = mailAddress;
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient();

                string strHost = WebConfigurationManager.ConnectionStrings["SMTPServer"].ConnectionString;

              //  smtpClient.Host = "localhost";
                smtpClient.Host = strHost;

                smtpClient.Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
                //throw new BusinessException(ex.Message.ToString());

            }
            return sendSucessful;
        }

        #endregion

        #region SendMail
        public bool SendMail(string emailTo, string emailCC , string emailBCC, string subject, string body)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(emailfrom);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = mailAddress;
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                if (emailCC != "")
                    mailMessage.CC.Add(emailCC);
                if (emailBCC != "")
                    mailMessage.Bcc.Add(emailBCC);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
                //throw new BusinessException(ex.Message.ToString());

            }
            return sendSucessful;
        }
        #endregion

        #region SendMail
        public bool SendMail(string emailTo, string emailCC,string emailBCC, string subject,string body, string[] attachFileName)
        {
            bool sendSucessful = true;
            try
            {
                MailAddress mailAddress = new MailAddress(emailfrom);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = mailAddress;
                mailMessage.To.Add(emailTo);
                mailMessage.Subject = subject;
                if (emailCC != "")
                    mailMessage.CC.Add(emailCC);
                if (emailBCC != "")
                    mailMessage.Bcc.Add(emailBCC);
                mailMessage.Body = body;
                if (attachFileName != null)
                {
                    foreach (string fileName in attachFileName)
                    {
                        AttachFile(mailMessage, fileName);
                    }
                }
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);
            }
            catch
            {
                sendSucessful = false;
                //throw new BusinessException(ex.Message.ToString());

            }
            return sendSucessful;
        }
        #endregion

        #region AttachFile
        private void AttachFile(MailMessage mailMessage,string attachFileName)
        {
            if (attachFileName != "")
            {
                using (Attachment attachment =
                    new Attachment(attachFileName))
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }

        }
        #endregion

        #region IsEmail
        public bool IsEmail(string inputEmail)
        {
            if (inputEmail == null | inputEmail.Length > 35) return false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return (re.IsMatch(inputEmail));
        }
        #endregion
    }
}
