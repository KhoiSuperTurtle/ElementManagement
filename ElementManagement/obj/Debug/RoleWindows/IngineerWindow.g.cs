﻿#pragma checksum "..\..\..\RoleWindows\IngineerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDFE1C00C88085D7FBB78CF451662AB350DEED2E4B1E912BE5416564DA760021"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ElementManagement.RoleWindows;
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


namespace ElementManagement.RoleWindows {
    
    
    /// <summary>
    /// IngineerWindow
    /// </summary>
    public partial class IngineerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 60 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgDetailsToRequest;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbArticulSearch;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNameSearch;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCountToRequest;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgMyRequested;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAcceptUsage;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancelUsage;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgDeviceLists;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\RoleWindows\IngineerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgDetailsOfDevice;
        
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
            System.Uri resourceLocater = new System.Uri("/ElementManagement;component/rolewindows/ingineerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RoleWindows\IngineerWindow.xaml"
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
            this.dtgDetailsToRequest = ((System.Windows.Controls.DataGrid)(target));
            
            #line 60 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.dtgDetailsToRequest.Loaded += new System.Windows.RoutedEventHandler(this.dtgDetailsToRequest_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbArticulSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.tbArticulSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbArticulSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbNameSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.tbNameSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbNameSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbCountToRequest = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.tbCountToRequest.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 76 "..\..\..\RoleWindows\IngineerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btRequestCount);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 80 "..\..\..\RoleWindows\IngineerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btToRequestUploadClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dtgMyRequested = ((System.Windows.Controls.DataGrid)(target));
            
            #line 101 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.dtgMyRequested.Loaded += new System.Windows.RoutedEventHandler(this.dtgMyRequested_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btAcceptUsage = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.btAcceptUsage.Click += new System.Windows.RoutedEventHandler(this.btAcceptUsage_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btCancelUsage = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.btCancelUsage.Click += new System.Windows.RoutedEventHandler(this.btCancelUsage_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dtgDeviceLists = ((System.Windows.Controls.DataGrid)(target));
            
            #line 125 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.dtgDeviceLists.Loaded += new System.Windows.RoutedEventHandler(this.dtgDeviceLists_Loaded);
            
            #line default
            #line hidden
            
            #line 125 "..\..\..\RoleWindows\IngineerWindow.xaml"
            this.dtgDeviceLists.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtgDeviceLists_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dtgDetailsOfDevice = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            
            #line 138 "..\..\..\RoleWindows\IngineerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btNotifyDeviceProduction_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 139 "..\..\..\RoleWindows\IngineerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btChengeShownDetails_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

