// Updated by XamlIntelliSenseFileGenerator 15/05/2021 04:14:12
#pragma checksum "..\..\AddClientPart.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3F319FBC5826C099D4307267F060C87667BDC82EAB6717031DEBF8AF11250488"
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


namespace VeloMax
{


    /// <summary>
    /// AddClientPart
    /// </summary>
    public partial class AddClientPart : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VeloMax;component/addclientpart.xaml", System.UriKind.Relative);

#line 1 "..\..\AddClientPart.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.BoxNom = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.BoxGrandeur = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.BoxPrix = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.BoxligneProd = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.BoxDateDisc = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:

#line 30 "..\..\AddClientPart.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterClient);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox BoxNomEntre;
        internal System.Windows.Controls.TextBox BoxRemiseEntre;
        internal System.Windows.Controls.TextBox BoxRueClient;
        internal System.Windows.Controls.TextBox BoxCodePostale;
        internal System.Windows.Controls.TextBox BoxProvinceClient;
        internal System.Windows.Controls.TextBox BoxVilleClient;
    }
}

