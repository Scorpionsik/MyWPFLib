﻿using CoreWPF.MVVM;
using CoreWPF.Utilites.Navigation.Interfaces;
using System;

namespace CoreWPF.Utilites.Navigation
{
    [Serializable]
    public abstract class NavigationViewModel : ViewModel
    {
        public NavigationManager Navigator { get; private set; }
        private string subtitle;
        public string Subtitle
        {
            get { return this.subtitle; }
            set
            {
                this.subtitle = value;
                this.OnPropertyChanged("Title");
            }
        }

        public override string Title
        {
            get
            {
                string tmp_send = base.Title;
                if(this.Subtitle != null && this.Subtitle != "") tmp_send += " [" + this.Subtitle + "]";
                return tmp_send;
            }
            set
            {
                base.Title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public NavigationViewModel(NavigationManager navigator) : base()
        {
            navigator.Navigation_invoke = new Action<INavigateModule>(this.SetContent);
            this.Navigator = navigator;
        }

        public abstract void SetContent(INavigateModule module);
    }
}
