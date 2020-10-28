﻿using DeltaQuestionEditor_WPF.ViewModels;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;

namespace DeltaQuestionEditor_WPF.Views
{
    using static Helpers.Helper;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;

        public MainWindow()
        {
            DataContext = viewModel = new MainViewModel();
            InitializeComponent();
            HideBoundingBox(root);
        }

        private void mainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (viewModel.CloseWindowCommand.CanExecute((e,this)))
                viewModel.CloseWindowCommand.Execute((e,this));
        }

        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void mediaPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (viewModel.AddMediaCommand.CanExecute(files))
                    viewModel.AddMediaCommand.Execute(files);
            }
        }

        private void gridWelcomePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 0) return;

                files = files.Where(x => Path.GetExtension(x) == ".qdb").ToArray();

                if (viewModel.OpenFileCommand.CanExecute(files))
                    viewModel.OpenFileCommand.Execute(files);
            }
        }
    }
}
