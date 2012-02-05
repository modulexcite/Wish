﻿using System;
using System.Windows;
using System.Windows.Controls;
using Wish.ViewModels;

namespace Wish.Menu.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView(WishViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void CmdSelected(object sender, RoutedEventArgs e)
        {
            //pshell.IsChecked = false;
            //vsPrompt.IsChecked = false;
            //cmd.IsChecked = true;
            //_wishModel.SetRunner(new Cmd(), Title);
            //Execute();
        }

        private void PowershellSelected(object sender, RoutedEventArgs e)
        {
            //cmd.IsChecked = false;
            //vsPrompt.IsChecked = false;
            //pshell.IsChecked = true;
            //_wishModel.SetRunner(new Powershell(), Title);
            //Execute();
        }

        private void VsSelected(object sender, RoutedEventArgs e)
        {
            //cmd.IsChecked = false;
            //pshell.IsChecked = false;
            //vsPrompt.IsChecked = true;
            //_wishModel.SetRunner(new Powershell(), Title);
            throw new NotImplementedException();
        }

        private void NewTab(object sender, RoutedEventArgs e)
        {
            //ExecuteNewTab(sender, null);
        }
    }
}