﻿using AbstractUniversityBusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MailKit.Net.Pop3;
using MailKit.Security;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AbstractUniversityBusinessLogic.BuisnessLogic
{
    public class MailLogic
    {
        private static string smtpClientHost;
        private static int smtpClientPort;
        private static string mailLogin;
        private static string mailPassword;
        public static void MailConfig(MailConfig config)
        {
            smtpClientHost = config.SmtpClientHost;
            smtpClientPort = config.SmtpClientPort;
            mailLogin = config.MailLogin;
            mailPassword = config.MailPassword;
        }

        public static async void MailSend(MailSendInfo info)
        {
            if (string.IsNullOrEmpty(smtpClientHost) || smtpClientPort == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(mailLogin) || string.IsNullOrEmpty(mailPassword))
            {
                return;
            }
            if (string.IsNullOrEmpty(info.MailAddress) ||
           string.IsNullOrEmpty(info.Subject) || string.IsNullOrEmpty(info.Text))
            {
                return;
            }
            using (var objMailMessage = new MailMessage())
            {
                using (var objSmtpClient = new SmtpClient(smtpClientHost,
               smtpClientPort))
                {

                    try
                    {
                        objMailMessage.From = new MailAddress(mailLogin);
                        objMailMessage.To.Add(new MailAddress(info.MailAddress));
                        objMailMessage.Subject = info.Subject;
                        objMailMessage.Body = info.Text;
                        objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                        objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                        objMailMessage.Attachments.Add(new Attachment(info.FileName));

                        objSmtpClient.UseDefaultCredentials = false;
                        objSmtpClient.EnableSsl = true;
                        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        objSmtpClient.Credentials = new NetworkCredential(mailLogin, mailPassword);
                        objSmtpClient.Send(objMailMessage);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
        public static async void MailSendBackUp(MailSendInfo info)
        {
            if (string.IsNullOrEmpty(smtpClientHost) || smtpClientPort == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(mailLogin) || string.IsNullOrEmpty(mailPassword))
            {
                return;
            }
            if (string.IsNullOrEmpty(info.MailAddress) ||
           string.IsNullOrEmpty(info.Subject) || string.IsNullOrEmpty(info.Text))
            {
                return;
            }
            using (var objMailMessage = new MailMessage())
            {
                using (var objSmtpClient = new SmtpClient(smtpClientHost,
               smtpClientPort))
                {

                    try
                    {
                        objMailMessage.From = new MailAddress(mailLogin);
                        objMailMessage.To.Add(new MailAddress(info.MailAddress));
                        objMailMessage.Subject = info.Subject;
                        objMailMessage.Body = info.Text;
                        objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                        objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                        objMailMessage.Attachments.Add(new Attachment(info.FileName + "\\Request." + info.Type));
                        objMailMessage.Attachments.Add(new Attachment(info.FileName + "\\RequestPlaces." + info.Type));
                        objMailMessage.Attachments.Add(new Attachment(info.FileName + "\\PlaceDiscipline." + info.Type));
                        objMailMessage.Attachments.Add(new Attachment(info.FileName + "\\Discipline." + info.Type));
                        objMailMessage.Attachments.Add(new Attachment(info.FileName + "\\Place." + info.Type));

                        objSmtpClient.UseDefaultCredentials = false;
                        objSmtpClient.EnableSsl = true;
                        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        objSmtpClient.Credentials = new NetworkCredential(mailLogin, mailPassword);
                        objSmtpClient.Send(objMailMessage);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
