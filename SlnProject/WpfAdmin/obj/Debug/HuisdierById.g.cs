﻿#pragma checksum "..\..\HuisdierById.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78201AF586C4AEEA072EE4C7D354524A41F9284C1FD79A349045AF0FD1B5867E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WpfAdmin;


namespace WpfAdmin {
    
    
    /// <summary>
    /// HuisdierById
    /// </summary>
    public partial class HuisdierById : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblId;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRemark;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSex;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSize;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAge;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUserId;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblType;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\HuisdierById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxResults;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfAdmin;component/huisdierbyid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HuisdierById.xaml"
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
            this.lblId = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblRemark = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblSex = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblSize = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblAge = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblUserId = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblType = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbxResults = ((System.Windows.Controls.ListBox)(target));
            
            #line 45 "..\..\HuisdierById.xaml"
            this.lbxResults.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LbxResults_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

