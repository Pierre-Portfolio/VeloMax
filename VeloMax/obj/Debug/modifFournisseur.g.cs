﻿#pragma checksum "..\..\modifFournisseur.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D9015081E8B7B2C60C04EC7A06DFA9CA34CFE34F694E87B9F87D28D8B8A30111"
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
using VeloMax;


namespace VeloMax {
    
    
    /// <summary>
    /// modifFournisseur
    /// </summary>
    public partial class modifFournisseur : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\modifFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxSiret;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\modifFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxNomEntreprise;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\modifFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxContact;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\modifFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxAddresse;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\modifFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxLibelle;
        
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
            System.Uri resourceLocater = new System.Uri("/VeloMax;component/modiffournisseur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\modifFournisseur.xaml"
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
            this.BoxSiret = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BoxNomEntreprise = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BoxContact = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BoxAddresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BoxLibelle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 30 "..\..\modifFournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ModifFournisseur);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
