using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Web.UI;

namespace WebApplication2
{

    public partial class index : System.Web.UI.Page
    {
         

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                string name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtName.Text.ToLower());
                string lastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
                string company = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCompany.Text.ToLower());
                string body = "<h6>" + name + " " + lastName + " from " + company + " and email " + txtEmail.Text + " and IP address " + GetLocalIPAddress() + " wants to work with you!</h6>";
                string subject = "From: " + name + " " + lastName;

                try
                {
                    MailMessage mail = new MailMessage("ddurandor@gmail.com", "e&e@eemiamiconstruction.com", subject, body);
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    // body in html
                    mail.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("ddurandor@gmail.com", "diana+2010");
                    client.EnableSsl = true;
                    client.Send(mail);

                    //confirmation email
                    subject = "From: Iluma Agency";
                    body = "<h6>Your email was sent successfully</h6>";
                    MailMessage mailConfirm = new MailMessage("ddurandor@gmail.com", txtEmail.Text, subject, body);
                    mailConfirm.BodyEncoding = System.Text.Encoding.UTF8;
                    // body in html
                    mailConfirm.IsBodyHtml = true;
                    SmtpClient clientConfirm = new SmtpClient("smtp.gmail.com");
                    clientConfirm.Port = 587;
                    clientConfirm.Credentials = new System.Net.NetworkCredential("ddurandor@gmail.com", "diana+2010");
                    clientConfirm.EnableSsl = true;
                    clientConfirm.Send(mailConfirm);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank you!')", true);
                    
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+ex.Message+")", true);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please connect the computer to the network')", true);

            CleanTxt();
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
           
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public void CleanTxt()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtCompany.Text = "";
            txtEmail.Text = "";            
        }
    }
}