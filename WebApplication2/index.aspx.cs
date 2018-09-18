using System;
using System.Web.UI;
using System.Net;
using System.Net.Mail; //used to send mail 
using System.Net.Sockets;//used to control access to the network
using System.IO; //read file 


namespace WebApplication2
{

    public partial class index : System.Web.UI.Page
    {
        string to = "";
        string password = "";
        string requirements = "https://github.com/dianaduran/pageConfirmmailC-";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Read file with the email and password
            string template = File.ReadAllText(Server.MapPath("~/Enviroment/") + "env.txt");
            //split to get part of the template string
            to = template.Split(':')[0];
            password = template.Split(':')[1];

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //validate if it is connected to the network
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //Get form data and capitalize the first letter
                string name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtName.Text.ToLower());
                string lastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
                string company = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCompany.Text.ToLower());

                //Create body and subject of the email calling the method GetLocalIPAddress() 
                string body = "<h6>" + name + " " + lastName + " from " + company + " company, email " + txtEmail.Text + " and IP address " + GetLocalIPAddress() + " wants to work with you!<br/>" +
                    "This is the link of the application " + requirements + "</h6>";
                string subject = "From: " + name + " " + lastName;

                try
                {
                    //Create obj to send message with to, from, subject and body
                    MailMessage mail = new MailMessage(to, "e&e@eemiamiconstruction.com", subject, body);
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    // body message in html
                    mail.IsBodyHtml = true;

                    //confirmation email and replace the subject and body
                    subject = "From: Iluma Agency";
                    body = "<h6>Your email was sent successfully</h6>";
                    MailMessage mailConfirm = new MailMessage(to, txtEmail.Text, subject, body);
                    mailConfirm.BodyEncoding = System.Text.Encoding.UTF8;
                    // body message in html
                    mailConfirm.IsBodyHtml = true;
                   

                    //Smtp gmail setting
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential(to, password);
                    client.EnableSsl = true;
                    client.Send(mail);
                    client.Send(mailConfirm);

                    //Message
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank you!')", true);                    
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+ex.Message+")", true);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please connect the computer to the network')", true);

            //Clean the textboxes when submit form
            CleanTxt();
        }

        //Method to get current Local IP
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
            throw new Exception("No network adapters with an IP address in the system!");
        }

        //Method to clean textboxes
        public void CleanTxt()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtCompany.Text = "";
            txtEmail.Text = "";            
        }
    }
}