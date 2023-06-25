using _01electronics_library;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        private SQLServer sqlServer = new SQLServer();

        private CommonQueries commonQueries;
        private CommonFunctions commonFunctions;
        private IntegrityChecks integrityChecks;

        int employeeID;
        String employeeEmail;
        String employeePassword;
        String confirmPassword;
        String employeeHashedPassword;
        public ChangePasswordPage(ref CommonQueries mCommonQueries, ref CommonFunctions mCommonFunctions, ref IntegrityChecks mIntegrityChecks, ref string Email)
        {
            InitializeComponent();
            commonQueries = mCommonQueries;
            commonFunctions = mCommonFunctions;
            integrityChecks = mIntegrityChecks;
            employeeEmail = Email;

        }

        private void OnButtonClickedChange(object sender, RoutedEventArgs e)
        {
            if (!CheckEmployeePasswordEdits())
                return;
            if (!GetEmployeeId())
                return;
            if (!DeleteFromoEmployeesPasswords())
                return;
            if (!InsertIntoEmployeesPasswords())
                return;



            SignInPage signInpage = new SignInPage(ref commonQueries, ref commonFunctions, ref integrityChecks);
            this.NavigationService.Navigate(signInpage);

        }
        bool GetEmployeeId()
        {
            String sqlQueryPart1 = @"SELECT id
      
                                FROM erp_system.dbo.employees_business_emails

                                where email = '";
            String sqlQueryPart2 = employeeEmail;
            String sqlQueryPart3 = "'";


            String sqlQuery;
            sqlQuery = String.Empty;
            sqlQuery += sqlQueryPart1;
            sqlQuery += sqlQueryPart2;
            sqlQuery += sqlQueryPart3;

            BASIC_STRUCTS.SQL_COLUMN_COUNT_STRUCT queryColumns = new BASIC_STRUCTS.SQL_COLUMN_COUNT_STRUCT();

            queryColumns.sql_int = 1;


            if (!sqlServer.GetRows(sqlQuery, queryColumns))
                return false;
            employeeID = sqlServer.rows[0].sql_int[0];


            return true;
        }
        bool CheckEmployeePasswordEdits()
        {
            employeePassword = newPasswordTextBox.Password;
            confirmPassword = cNewPasswordTextBox.Password;

            if (employeePassword != confirmPassword)
                return false;

            SHA256 hashing = SHA256.Create();

            byte[] hashedBytes = hashing.ComputeHash(Encoding.UTF8.GetBytes(employeePassword));

            StringBuilder employeePasswordBuilder = new StringBuilder(hashedBytes.Length * 2);

            foreach (byte currentByte in hashedBytes)
                employeePasswordBuilder.AppendFormat("{0:x2}", currentByte);

            employeeHashedPassword = employeePasswordBuilder.ToString();

            return true;
        }
        private bool DeleteFromoEmployeesPasswords()
        {
            String sqlQueryPart1 = @" DELETE FROM erp_system.dbo.employees_passwords WHERE employees_passwords.id =";
            String sqlQueryPart2 = employeeID.ToString();

            String sqlQuery;
            sqlQuery = String.Empty;
            sqlQuery += sqlQueryPart1;
            sqlQuery += sqlQueryPart2;

            if (!sqlServer.InsertRows(sqlQuery))
                return false;

            return true;

        }
        private bool InsertIntoEmployeesPasswords()
        {
            String sqlQueryPart1 = "insert into erp_system.dbo.employees_passwords values (";
            String sqlQueryPart2 = ",'";
            String sqlQueryPart3 = "', getdate());";



            String sqlQuery;
            sqlQuery = String.Empty;
            sqlQuery += sqlQueryPart1;
            sqlQuery += employeeID.ToString();
            sqlQuery += sqlQueryPart2;
            sqlQuery += employeeHashedPassword;
            sqlQuery += sqlQueryPart3;

            if (!sqlServer.InsertRows(sqlQuery))
                return false;

            return true;
        }
    }
}
