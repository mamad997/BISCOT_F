﻿#pragma checksum "..\..\ReportP.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4C397CBC7DAB463070F92AE49A12AC361FC5528CEF9B1687AAA4FE4F0C5D8D83"
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
    /// ReportP
    /// </summary>
    public partial class ReportP : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtdatestart;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtdateend;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid id;
        
        #line default
        #line hidden
        
        
        #line 379 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnrefresh;
        
        #line default
        #line hidden
        
        
        #line 389 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 390 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy;
        
        #line default
        #line hidden
        
        
        #line 391 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_Copy1;
        
        #line default
        #line hidden
        
        
        #line 403 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnprint;
        
        #line default
        #line hidden
        
        
        #line 419 "..\..\ReportP.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnexcel;
        
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
            System.Uri resourceLocater = new System.Uri("/BISCOT_F;component/reportp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReportP.xaml"
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
            this.txtdatestart = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\ReportP.xaml"
            this.txtdatestart.GotFocus += new System.Windows.RoutedEventHandler(this.textBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 44 "..\..\ReportP.xaml"
            this.txtdatestart.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Txtdatestart_MouseEnter);
            
            #line default
            #line hidden
            
            #line 44 "..\..\ReportP.xaml"
            this.txtdatestart.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Txtdatestart_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtdateend = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.id = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 348 "..\..\ReportP.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnrefresh_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 355 "..\..\ReportP.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 361 "..\..\ReportP.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnrefresh = ((System.Windows.Controls.Button)(target));
            
            #line 382 "..\..\ReportP.xaml"
            this.btnrefresh.Click += new System.Windows.RoutedEventHandler(this.btnrefresh_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.label_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.label_Copy1 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.btnprint = ((System.Windows.Controls.Button)(target));
            
            #line 406 "..\..\ReportP.xaml"
            this.btnprint.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnexcel = ((System.Windows.Controls.Button)(target));
            
            #line 422 "..\..\ReportP.xaml"
            this.btnexcel.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
