﻿#pragma checksum "..\..\TimeTabItem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6194425DFD59FA75D62AF4E3BDC8B4C3FB6787A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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
using Tischreservierung_Employee;
using Xceed.Wpf.Toolkit;


namespace Tischreservierung_Employee {
    
    
    /// <summary>
    /// TimeTabItem
    /// </summary>
    public partial class TimeTabItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\TimeTabItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker TimePicker;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TimeTabItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox TimeLB;
        
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
            System.Uri resourceLocater = new System.Uri("/Tischreservierung-Employee;component/timetabitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TimeTabItem.xaml"
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
            this.TimePicker = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            
            #line 16 "..\..\TimeTabItem.xaml"
            this.TimePicker.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TimePicker_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TimeLB = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

