﻿using System;
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

namespace flakosGym.Views
{
    /// <summary>
    /// Lógica de interacción para viewLogin.xaml
    /// </summary>
    public partial class viewLogin : Window
    {
        public viewLogin()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword != null && PasswordBox != null &&
                TextBoxPassword.Visibility == Visibility.Visible)
            {
                TextBoxPassword.Text = PasswordBox.Password;
            }
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window ownerWindow = Window.GetWindow(this);
            ownerWindow.WindowState = WindowState.Minimized;
        }

        private void BtnShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Collapsed;
            TextBoxPassword.Visibility = Visibility.Visible;
            TextBoxPassword.Text = PasswordBox.Password;

            // Cambiar la opacidad de la imagen al mostrar la contraseña
            if (BtnShowPassword.Content is Image image)
            {
                image.Opacity = 1.0;
                // Opcionalmente, cambia la imagen si deseas mostrar un ojo tachado
                // image.Source = new BitmapImage(new Uri("/Images/eye-slash.png", UriKind.Relative));
            }
        }

        private void BtnShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = TextBoxPassword.Text;
            PasswordBox.Visibility = Visibility.Visible;
            TextBoxPassword.Visibility = Visibility.Collapsed;

            // Cambiar la opacidad de la imagen al ocultar la contraseña
            if (BtnShowPassword.Content is Image image)
            {
                image.Opacity = 0.5;
                // Opcionalmente, cambia la imagen para mostrar un ojo
                // image.Source = new BitmapImage(new Uri("/Images/eye.png", UriKind.Relative));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnIniciarSesion_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void hipervinculoCrearCuenta(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
