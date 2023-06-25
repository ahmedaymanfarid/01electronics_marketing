﻿#pragma checksum "..\..\ModelUploadFilesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17824EE54E4319155BBB83AF2B2EC9185A1C73BC18672A40EDF4663640B64826"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using _01electronics_marketing;


namespace _01electronics_marketing {
    
    
    /// <summary>
    /// ModelUploadFilesPage
    /// </summary>
    public partial class ModelUploadFilesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DataSheetHeader;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SpecsType;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollViewer;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel uploadFilesStackPanel;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextButton;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finishButton;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\ModelUploadFilesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/01electronics_marketing;component/modeluploadfilespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModelUploadFilesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DataSheetHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 50 "..\..\ModelUploadFilesPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnClickBasicInfo);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 55 "..\..\ModelUploadFilesPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnClickUpsSpecs);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SpecsType = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            
            #line 64 "..\..\ModelUploadFilesPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnClickAdditionalInfo);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 70 "..\..\ModelUploadFilesPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBtnClickUploadFiles);
            
            #line default
            #line hidden
            return;
            case 7:
            this.scrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 8:
            this.uploadFilesStackPanel = ((System.Windows.Controls.StackPanel)(target));
            
            #line 89 "..\..\ModelUploadFilesPage.xaml"
            this.uploadFilesStackPanel.Drop += new System.Windows.DragEventHandler(this.OnDropUploadFilesStackPanel);
            
            #line default
            #line hidden
            return;
            case 9:
            this.backButton = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.nextButton = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\ModelUploadFilesPage.xaml"
            this.nextButton.Click += new System.Windows.RoutedEventHandler(this.OnClickNextButton);
            
            #line default
            #line hidden
            return;
            case 11:
            this.finishButton = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\ModelUploadFilesPage.xaml"
            this.cancelButton.Click += new System.Windows.RoutedEventHandler(this.OnBtnClickCancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

