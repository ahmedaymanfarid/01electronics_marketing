using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _01electronics_library;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        CommonQueries commonQueries;
        List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT> salesEmployees;
        List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT> preSalesEmployees;
        List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT> salesAndPreSalesEmployees;
        List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT> managers;
        //Employee loggedInUser;

        bool selected = false;

        Employee loggedInUserFromLoginPage;
        private SecuredCommonQueries securedCommonQueries;
        private CommonFunctions commonFunctions;
        private IntegrityChecks integrityChecks;


        public adminWindow(ref CommonQueries mCommonQueries, ref CommonFunctions mCommonFunctions, ref IntegrityChecks mIntegrityChecks, ref Employee mLoggedInUserr)    
        {     
            InitializeComponent();
            //loggedInUser =mLoggedInUser;
            salesEmployees = new List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT>();
            preSalesEmployees = new List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT>();
            salesAndPreSalesEmployees = new List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT>();
            managers = new List<COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT>();
            loggedInUserFromLoginPage = mLoggedInUserr;

            commonQueries = mCommonQueries;
            commonFunctions = mCommonFunctions;
            integrityChecks = mIntegrityChecks;
            commonQueries.GetTeamEmployees(COMPANY_ORGANISATION_MACROS.SALES_TEAM_ID, ref salesEmployees);
            commonQueries.GetTeamEmployees(COMPANY_ORGANISATION_MACROS.TECHNICAL_OFFICE_TEAM_ID, ref preSalesEmployees);
            commonQueries.GetAllManagerEmployees(ref managers);


            foreach (COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT employee in salesEmployees) {
                    salesAndPreSalesEmployees.Add(employee);               
            }

            foreach (COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT employee in preSalesEmployees)
            {
                salesAndPreSalesEmployees.Add(employee);
            }

            foreach (COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT employee in managers)
            {

                if(employee.team.team_id==COMPANY_ORGANISATION_MACROS.MARKETING_AND_SALES_DEPARTMENT_MANAGEMENT)
                    salesAndPreSalesEmployees.Add(employee);
            }

            foreach (COMPANY_ORGANISATION_MACROS.EMPLOYEE_STRUCT employee in salesAndPreSalesEmployees)
            {

                    salesCombo.Items.Add(employee.employee_name);
            }

            salesCombo.Items.Add(loggedInUserFromLoginPage.GetEmployeeName());

            salesCombo.SelectedIndex = salesCombo.Items.Count - 1;

   
        }

        private void salesComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            if (salesCombo.SelectedIndex == salesCombo.Items.Count - 1)
                loggedInUserFromLoginPage.InitializeEmployeeInfo(loggedInUserFromLoginPage.GetEmployeeId());

            else if (salesCombo.SelectedIndex == salesCombo.Items.Count - 2)
                loggedInUserFromLoginPage.InitializeEmployeeInfo(salesAndPreSalesEmployees[salesCombo.SelectedIndex].employee_id);
            else
                loggedInUserFromLoginPage.InitializeEmployeeInfo(salesAndPreSalesEmployees[salesCombo.SelectedIndex].employee_id);
        }

        private void OnBtnClickSaveChanges(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(ref commonQueries, ref commonFunctions, ref integrityChecks, ref loggedInUserFromLoginPage);
            mainWindow.Show();
            this.Close();
        }
    }
}
