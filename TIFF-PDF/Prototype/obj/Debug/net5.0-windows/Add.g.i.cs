﻿#pragma checksum "..\..\..\Add.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AA8DF213148846B45C5E2D48EFCF0714BA316974"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Prototype2;
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


namespace Prototype2 {
    
    
    /// <summary>
    /// Add
    /// </summary>
    public partial class Add : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_cname;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_ckey;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_ctype;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_desc;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_doctype;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_archive;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_filelocation;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_scandate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_browse;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_update;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_undo;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_done;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Add.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TIFFToPDFViewer;component/add.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Add.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_cname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_ckey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_ctype = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_desc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_doctype = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_archive = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_filelocation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txt_scandate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.btn_browse = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Add.xaml"
            this.btn_browse.Click += new System.Windows.RoutedEventHandler(this.btn_browse_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Add.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.btn_save_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_update = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Add.xaml"
            this.btn_update.Click += new System.Windows.RoutedEventHandler(this.btn_update_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btn_undo = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Add.xaml"
            this.btn_undo.Click += new System.Windows.RoutedEventHandler(this.btn_undo_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.txt_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\Add.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btn_done = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\Add.xaml"
            this.btn_done.Click += new System.Windows.RoutedEventHandler(this.btn_done_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Add.xaml"
            this.btn_delete.Click += new System.Windows.RoutedEventHandler(this.btn_delete_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.dataGrid2 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 65 "..\..\..\Add.xaml"
            this.dataGrid2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid2_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\Add.xaml"
            this.dataGrid2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGrid2_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

