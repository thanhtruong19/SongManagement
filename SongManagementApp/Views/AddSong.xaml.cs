﻿using SongManagementApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SongManagementApp.Views
{
    /// <summary>
    /// Interaction logic for AddSong.xaml
    /// </summary>
    public partial class AddSong : Window
    {
        public AddSong()
        {
            InitializeComponent();
            AddSongViewModel addsongviewmodel = new AddSongViewModel(); 
            this.DataContext = addsongviewmodel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ thêm bài hát khi nút được nhấn
        }
    }
}
