using _01electronics_library;
using System.Windows.Navigation;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for ModelsWindow.xaml
    /// </summary>
    public partial class ModelsWindow : NavigationWindow
    {
        public ModelBasicInfoPage modelBasicInfoPage;
        public ModelUpsSpecsPage modelUpsSpecsPage;
        public ModelAdditionalInfoPage modelAdditionalInfoPage;
        public ModelUploadFilesPage modelUploadFilesPage;

        private static CommonQueries commonQueries;
        private static SecuredCommonQueries securedCommonQueries;
        private static CommonFunctions commonFunctions;
        private static IntegrityChecks integrityChecks;
        public ModelsWindow(ref CommonQueries mCommonQueries, ref CommonFunctions mCommonFunctions, ref IntegrityChecks mIntegrityChecks, ref Employee mLoggedInUser, ref Model mPrduct, int mViewAddCondition, bool openFilesPage)
        {
            InitializeComponent();

            modelBasicInfoPage = new ModelBasicInfoPage(ref mLoggedInUser, ref mPrduct, mViewAddCondition);
            modelUpsSpecsPage = new ModelUpsSpecsPage(ref commonQueries, ref commonFunctions, ref integrityChecks, ref mLoggedInUser, ref mPrduct, mViewAddCondition);
            modelAdditionalInfoPage = new ModelAdditionalInfoPage(ref commonQueries, ref commonFunctions, ref integrityChecks, ref mLoggedInUser, ref mPrduct, mViewAddCondition);
            modelUploadFilesPage = new ModelUploadFilesPage(ref mLoggedInUser, ref mPrduct, mViewAddCondition);

            commonQueries = mCommonQueries;
            commonFunctions = mCommonFunctions;
            integrityChecks = mIntegrityChecks;
            if (openFilesPage)
            {
                modelUploadFilesPage.modelBasicInfoPage = modelBasicInfoPage;
                modelUploadFilesPage.modelUpsSpecsPage = modelUpsSpecsPage;
                modelUploadFilesPage.modelAdditionalInfoPage = modelAdditionalInfoPage;

                this.NavigationService.Navigate(modelUploadFilesPage);
            }
            else
            {
                modelBasicInfoPage.modelUpsSpecsPage = modelUpsSpecsPage;
                modelBasicInfoPage.modelAdditionalInfoPage = modelAdditionalInfoPage;
                modelBasicInfoPage.modelUploadFilesPage = modelUploadFilesPage;

                this.NavigationService.Navigate(modelBasicInfoPage);
            }
        }
    }
}
