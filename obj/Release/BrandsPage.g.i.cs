﻿#pragma checksum "..\..\BrandsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62B4A76B4578E4005F3C89286775F6243E6DB4D5D976D372D5A995624C33F970"
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
    /// BrandsPage
    /// </summary>
    public partial class BrandsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\BrandsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProductsLabel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\BrandsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\BrandsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BrandsGrid;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\BrandsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas addBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/01electronics_marketing;component/brandspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BrandsPage.xaml"
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
            this.ProductsLabel = ((System.Windows.Controls.TextBlock)(target));
            
            #line 24 "..\..\BrandsPage.xaml"
            this.ProductsLabel.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnButtonClickedProducts);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.BrandsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.addBtn = ((System.Windows.Controls.Canvas)(target));
            
            #line 38 "..\..\BrandsPage.xaml"
            this.addBtn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.addBtnMouseEnter);
            
            #line default
            #line hidden
            
            #line 38 "..\..\BrandsPage.xaml"
            this.addBtn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.addBtnMouseLeave);
            
            #line default
            #line hidden
            
            #line 38 "..\..\BrandsPage.xaml"
            this.addBtn.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.onBtnAddClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

