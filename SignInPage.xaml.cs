using _01electronics_library;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        IntegrityChecks integrityChecker = new IntegrityChecks();

        String employeeEmail;
        String employeePassword;
        protected SQLServer sqlDatabase;
        Employee loggedInUser;
        protected String errorMessage;

       
      

        public SignInPage()
        {
            InitializeComponent();
            loggedInUser = new Employee();

            if (_01electronics_marketing.Properties.Settings.Default.Email != null)
            {
                employeeEmailTextBox.Text = _01electronics_marketing.Properties.Settings.Default.Email;
            }

            if (_01electronics_marketing.Properties.Settings.Default.PassWordCheck != false)
            {
                RememberMeCheckBox.IsChecked = true;

            }

            if (_01electronics_marketing.Properties.Settings.Default.PassWord != null)
            {
                employeePasswordTextBox.Password = _01electronics_marketing.Properties.Settings.Default.PassWord;
            }
        }

        private void OnButtonClickedSignIn(object sender, RoutedEventArgs e)
        {
            employeeEmail = employeeEmailTextBox.Text;

            if (employeeEmailTextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Email must be specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!integrityChecker.CheckEmployeeLoginEmailEditBox(employeeEmail, ref employeeEmail, false, ref errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loggedInUser.InitializeEmployeeInfo(employeeEmail);

            if (loggedInUser.GetEmployeeDepartmentId() != COMPANY_ORGANISATION_MACROS.MARKETING_AND_SALES_DEPARTMENT_ID 
                && (loggedInUser.GetEmployeePositionId() != COMPANY_ORGANISATION_MACROS.MANAGER_POSTION || loggedInUser.GetEmployeeDepartmentId() != COMPANY_ORGANISATION_MACROS.BUSINESS_DEVELOPMENT_DEPARTMENT_ID)
                && loggedInUser.GetEmployeeTeamId() != COMPANY_ORGANISATION_MACROS.DOCUMENT_CONTROL_TEAM_ID
                && loggedInUser.GetEmployeeTeamId() != COMPANY_ORGANISATION_MACROS.ERP_SYSTEM_DEVELOPMENT_TEAM_ID
                && loggedInUser.GetEmployeeTeamId() != COMPANY_ORGANISATION_MACROS.RECTRUITMENT_TEAM_ID)
            {
                System.Windows.Forms.MessageBox.Show("Unauthorized Access, Please contact your system adminstrator for authorisation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            employeePassword = employeePasswordTextBox.Password;

            if (_01electronics_marketing.Properties.Settings.Default.PassWordCheck)
            {
                _01electronics_marketing.Properties.Settings.Default.Email = employeeEmailTextBox.Text;
                _01electronics_marketing.Properties.Settings.Default.PassWord = employeePasswordTextBox.Password;
                _01electronics_marketing.Properties.Settings.Default.Save();
            }
            else
            {
                _01electronics_marketing.Properties.Settings.Default.Email = employeeEmailTextBox.Text;
                _01electronics_marketing.Properties.Settings.Default.Save();
            }

            if (_01electronics_marketing.Properties.Settings.Default.PassWordCheck)
            {
                _01electronics_marketing.Properties.Settings.Default.Email = employeeEmailTextBox.Text;
                _01electronics_marketing.Properties.Settings.Default.PassWord = employeePasswordTextBox.Password;
                _01electronics_marketing.Properties.Settings.Default.Save();
            }
            else
            {
                _01electronics_marketing.Properties.Settings.Default.Email = employeeEmailTextBox.Text;
                _01electronics_marketing.Properties.Settings.Default.Save();
            }



            if (loggedInUser.GetEmployeeTeamId() == COMPANY_ORGANISATION_MACROS.BUSINESS_DEVELOPMENT_DEPARTMENT_ID || loggedInUser.GetEmployeeTeamId() == COMPANY_ORGANISATION_MACROS.ERP_SYSTEM_DEVELOPMENT_TEAM_ID)
            {
                adminWindow adminWindow = new adminWindow(loggedInUser);
                adminWindow.Show();
                NavigationWindow currentWindoww = (NavigationWindow)this.Parent;
                currentWindoww.Close();
                return;
            }

            if (!integrityChecker.CheckEmployeePasswordEditBox(employeePassword, loggedInUser.GetEmployeeId(), ref errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            MainWindow mainWindowOpen = new MainWindow(ref loggedInUser);

            NavigationWindow currentWindow = (NavigationWindow)this.Parent;
            currentWindow.Close();

            mainWindowOpen.Show();

            Window.GetWindow(this).Close();
        }

        private void OnButtonClickedSignUp(object sender, RoutedEventArgs e)
        {
            SignUpPage signUp = new SignUpPage();
            this.NavigationService.Navigate(signUp);
        }

        private void RememberMeISChecked(object sender, RoutedEventArgs e)
        {

            employeePasswordTextBox.Password = _01electronics_marketing.Properties.Settings.Default.PassWord;

            _01electronics_marketing.Properties.Settings.Default.PassWordCheck = true;
            _01electronics_marketing.Properties.Settings.Default.Save();
        }

        private void RememberMeisUnchecked(object sender, RoutedEventArgs e)
        {
            _01electronics_marketing.Properties.Settings.Default.PassWord = "";
            employeePasswordTextBox.Password = "";
            _01electronics_marketing.Properties.Settings.Default.PassWordCheck = false;
            _01electronics_marketing.Properties.Settings.Default.Save();
        }

        private void OnBtnClicklForgetPassword(object sender, MouseButtonEventArgs e)
        {
            employeeEmail = employeeEmailTextBox.Text;
            ForgetPasswordPage forgetPasswordMail = new ForgetPasswordPage(ref employeeEmail);
            this.NavigationService.Navigate(forgetPasswordMail);
        }

       
    }
}
