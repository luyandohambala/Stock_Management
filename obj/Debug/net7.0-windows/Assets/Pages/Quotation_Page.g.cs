﻿#pragma checksum "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F359BB0D8F21F9E4DD880572A77697EBE0CA5B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Stock_Management.Assets.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Stock_Management.Assets.Pages {
    
    
    /// <summary>
    /// Quotation_Page
    /// </summary>
    public partial class Quotation_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid items_grid;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button print_quote;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border input_view;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_edit_button;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serial_entry;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description_entry;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantity_entry;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox unit_price_entry;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Stock_Management;component/assets/pages/quotation_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.items_grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.print_quote = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.input_view = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.add_edit_button = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.serial_entry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.description_entry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.quantity_entry = ((System.Windows.Controls.TextBox)(target));
            
            #line 203 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
            this.quantity_entry.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.quantity_entry_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.unit_price_entry = ((System.Windows.Controls.TextBox)(target));
            
            #line 205 "..\..\..\..\..\Assets\Pages\Quotation_Page.xaml"
            this.unit_price_entry.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.unit_price_entry_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

