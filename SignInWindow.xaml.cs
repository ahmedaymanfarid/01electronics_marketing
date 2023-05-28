using _01electronics_library;
using System.Windows.Navigation;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : NavigationWindow
    {
        private static SQLServer sqlServer;
        private static CommonQueries commonQueries;
        private static SecuredCommonQueries securedCommonQueries;
        private static CommonFunctions commonFunctions;
        private static IntegrityChecks integrityChecks;
        public SignInWindow()
        {
            InitializeComponent();
            sqlServer = new SQLServer();
            commonFunctions = new CommonFunctions();
            commonQueries = new CommonQueries(ref sqlServer, ref commonFunctions);
            securedCommonQueries = new SecuredCommonQueries(ref sqlServer, ref commonFunctions);
            integrityChecks = new IntegrityChecks(ref commonQueries);

            SignInPage signIn = new SignInPage(ref commonQueries, ref commonFunctions, ref integrityChecks);
            this.NavigationService.Navigate(signIn);
        }

    }
}
