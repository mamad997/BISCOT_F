﻿#pragma checksum "..\..\user_main.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9B5E13060E7B7A88C70D5FAC7DBA4DEC38FA6DB8F40097032BAA5F0F6A64FBD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using test_matrial;


namespace test_matrial {
    
    
    /// <summary>
    /// user_main
    /// </summary>
    public partial class user_main : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid id;
        
        #line default
        #line hidden
        
        
        #line 348 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btnrefresh;
        
        #line default
        #line hidden
        
        
        #line 362 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnedithe;
        
        #line default
        #line hidden
        
        
        #line 379 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 380 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\user_main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy1;
        
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
            System.Uri resourceLocater = new System.Uri("/BISCOT_F;component/user_main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\user_main.xaml"
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
            this.id = ((System.Windows.Controls.DataGrid)(target));
            
            #line 41 "..\..\user_main.xaml"
            this.id.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.id_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 300 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Btnrefresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 305 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnexcel);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 311 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnNew_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 316 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnedithe_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 322 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 328 "..\..\user_main.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnexcel);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Btnrefresh = ((System.Windows.Controls.Button)(target));
            
            #line 351 "..\..\user_main.xaml"
            this.Btnrefresh.Click += new System.Windows.RoutedEventHandler(this.Btnrefresh_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 358 "..\..\user_main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnNew_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnedithe = ((System.Windows.Controls.Button)(target));
            
            #line 365 "..\..\user_main.xaml"
            this.btnedithe.Click += new System.Windows.RoutedEventHandler(this.btnedithe_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 372 "..\..\user_main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.label_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            
            #line 396 "..\..\user_main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnexcel);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 414 "..\..\user_main.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnexcel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

