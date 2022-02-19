﻿using System;
using System.Windows.Input;


namespace CollectionViewDemos.Views
{
    public partial class CollectionViewPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public CollectionViewPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    await Shell.Current.GoToAsync(pageType.Name);
                    //Page page = (Page)Activator.CreateInstance(pageType);
                    //await Navigation.PushAsync(page);
                });

            BindingContext = this;
        }
    }
}
