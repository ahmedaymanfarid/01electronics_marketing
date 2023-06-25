using _01electronics_library;
using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for ForgetPasswordPage.xaml
    /// </summary>
    public partial class ForgetPasswordPage : Page
    {

        IntegrityChecks integrityChecks;

        protected String errorMessage;

        String employeeEmail;
        int SecretCode;
        int SecretCodeConfirmation;
        CommonQueries commonQueries;
        private CommonFunctions commonFunctions;

        public ForgetPasswordPage(ref CommonQueries mCommonQueries, ref CommonFunctions mCommonFunctions, ref IntegrityChecks mIntegrityChecks, ref string Email)
        {
            InitializeComponent();
            employeeEmailTextBox.Text = Email;
            integrityChecks = mIntegrityChecks;
            commonQueries = mCommonQueries;
            commonFunctions = mCommonFunctions;
        }

        private void OnButtonClickedReset(object sender, RoutedEventArgs e)
        {
            employeeEmail = employeeEmailTextBox.Text;

            if (!integrityChecks.CheckEmployeeLoginEmailEditBox(employeeEmail, ref employeeEmail, false, ref errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (employeeEmailTextBox.Text != null)
            {
                SendSecretCode(employeeEmailTextBox.Text);
            }

        }

        private string SendSecretCode(string emailId)
        {
            try
            {
                Random rnd = new Random();
                int Code = rnd.Next(99999, 999999);

                MailMessage mail = new MailMessage();
                mail.To.Add(emailId);
                mail.From = new MailAddress("appsupport@01electronics.net");
                mail.Subject = "Please reset your password " + emailId;
                string userMessage = "";

                userMessage = userMessage + "<br/><b>Login Id:</b> " + emailId;
                userMessage = userMessage + "<br/><b>Secret Code: </b>" + Code;

                string Body = "Dear " + emailId + ", <br/><br/>Need to reset your password?<br/></br> " + " <br/> Use your secret code! <br/> " + userMessage + " <br/><br/>If you did not forget your password, you can ignore this email.<br/></br> " + "<br/><br/><b>Thanks<b>" + "<br/><b>01 Electronics Team<b> ";
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.01electronics.net"; //SMTP Server Address of gmail
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("appsupport@01electronics.net", "!01#elec$app#%");
                // Smtp Email ID and Password For authentication
                //smtp.EnableSsl = true;
                smtp.Send(mail);
                employeeEmailTextBox.Visibility = Visibility.Collapsed;
                employeeEmailLabel.Visibility = Visibility.Collapsed;
                ResetButton.Visibility = Visibility.Collapsed;

                SecretCodeTextBox.Visibility = Visibility.Visible;
                SecretCodeLabel.Visibility = Visibility.Visible;
                ConfirmButton.Visibility = Visibility.Visible;
                SecretCodeConfirmation = Code;
                return "Please check your email for account login detail.";
            }
            catch
            {
                return "Error............";
            }
        }

        private void OnButtonClickedConfirm(object sender, RoutedEventArgs e)
        {
            SecretCode = int.Parse(SecretCodeTextBox.Text);
            if (SecretCode == SecretCodeConfirmation)
            {
                ChangePasswordPage forgetPasswordMail = new ChangePasswordPage(ref commonQueries, ref commonFunctions, ref integrityChecks, ref employeeEmail);
                this.NavigationService.Navigate(forgetPasswordMail);

            }
        }


    }
}
