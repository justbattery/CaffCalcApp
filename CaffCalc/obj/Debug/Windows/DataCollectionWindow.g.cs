﻿#pragma checksum "..\..\..\Windows\DataCollectionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67C32925E5BB8D334E958099D1012386CFDB2A78796209555D4924E1FCB3B530"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using CaffCalc.Windows;
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


namespace CaffCalc.Windows {
    
    
    /// <summary>
    /// DataCollectionWindow
    /// </summary>
    public partial class DataCollectionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Windows\DataCollectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_TextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\DataCollectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname_TextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\DataCollectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weight_TextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\DataCollectionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button accept_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/CaffCalc;component/windows/datacollectionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\DataCollectionWindow.xaml"
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
            this.name_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\Windows\DataCollectionWindow.xaml"
            this.name_TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Letters_TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.surname_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Windows\DataCollectionWindow.xaml"
            this.surname_TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Letters_TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.weight_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\Windows\DataCollectionWindow.xaml"
            this.weight_TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Numbers_TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.accept_Button = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Windows\DataCollectionWindow.xaml"
            this.accept_Button.Click += new System.Windows.RoutedEventHandler(this.accept_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

