﻿#pragma checksum "..\..\FexportStat1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "148C7015AB2F851B53DAB04E95F3926E8B08C200AF6030C5E1FFC6D7B487516F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppShedule;
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


namespace AppShedule {
    
    
    /// <summary>
    /// FexportStat
    /// </summary>
    public partial class FexportStat : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbboxToaNha;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtStartDate;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtEndDate;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btStatistical_default;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btStatistical_custom;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btExport;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView List_Statistical_Fillter;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\FexportStat1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkSelectAll;
        
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
            System.Uri resourceLocater = new System.Uri("/AppShedule;component/fexportstat1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FexportStat1.xaml"
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
            this.cbboxToaNha = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\FexportStat1.xaml"
            this.cbboxToaNha.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbboxToaNha_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.txtEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.btStatistical_default = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\FexportStat1.xaml"
            this.btStatistical_default.Click += new System.Windows.RoutedEventHandler(this.btStatistical_default_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btStatistical_custom = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\FexportStat1.xaml"
            this.btStatistical_custom.Click += new System.Windows.RoutedEventHandler(this.btStatistical_custom_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btExport = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\FexportStat1.xaml"
            this.btExport.Click += new System.Windows.RoutedEventHandler(this.btExport_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.List_Statistical_Fillter = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.chkSelectAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 90 "..\..\FexportStat1.xaml"
            this.chkSelectAll.Click += new System.Windows.RoutedEventHandler(this.chkSelectAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 98 "..\..\FexportStat1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.cbSelectRow_Checked);
            
            #line default
            #line hidden
            
            #line 101 "..\..\FexportStat1.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.cbSelectRow_Unchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
