//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portable {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class LocationDetailPage : global::Xamarin.Forms.ContentPage {
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout OuterLayout;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout InfoLayout;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry EntryName;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry EntryLatitude;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry EntryLongitude;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry EntryAltitude;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry EntryGeoLocation;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout MapLayout;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Editor EditorNoates;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button BtnSaveLocation;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button BtnGetCurrentLocation;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button BtnGeoLocateCurrent;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Maps.Map LocationMap;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(LocationDetailPage));
            OuterLayout = this.FindByName<global::Xamarin.Forms.StackLayout>("OuterLayout");
            InfoLayout = this.FindByName<global::Xamarin.Forms.StackLayout>("InfoLayout");
            EntryName = this.FindByName<global::Xamarin.Forms.Entry>("EntryName");
            EntryLatitude = this.FindByName<global::Xamarin.Forms.Entry>("EntryLatitude");
            EntryLongitude = this.FindByName<global::Xamarin.Forms.Entry>("EntryLongitude");
            EntryAltitude = this.FindByName<global::Xamarin.Forms.Entry>("EntryAltitude");
            EntryGeoLocation = this.FindByName<global::Xamarin.Forms.Entry>("EntryGeoLocation");
            MapLayout = this.FindByName<global::Xamarin.Forms.StackLayout>("MapLayout");
            EditorNoates = this.FindByName<global::Xamarin.Forms.Editor>("EditorNoates");
            BtnSaveLocation = this.FindByName<global::Xamarin.Forms.Button>("BtnSaveLocation");
            BtnGetCurrentLocation = this.FindByName<global::Xamarin.Forms.Button>("BtnGetCurrentLocation");
            BtnGeoLocateCurrent = this.FindByName<global::Xamarin.Forms.Button>("BtnGeoLocateCurrent");
            LocationMap = this.FindByName<global::Xamarin.Forms.Maps.Map>("LocationMap");
        }
    }
}
