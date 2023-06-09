﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AspNetIdentityClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterWindow : Page
    {
        public RegisterWindow()
        {
            this.InitializeComponent();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            var model = new RegisterViewModel
            {
                Email = txtEmail.Text,
                Password = txtEmail.Text,
                ConfirmPassword = txtEmail.Text,
            };

            var jsonData = JsonConvert.SerializeObject(model);

            var content=new StringContent(jsonData, Encoding.UTF8, "application/json" );

            var response = await client.PostAsync("http://localhost:38915/api/auth/register", content);

            var responseBody= await response.Content.ReadAsStringAsync(); 

            var responseObject=JsonConvert.DeserializeObject<UserManagerResponse>(responseBody);

            if (responseObject.IsSucces)
            {
                var dialog = new MessageDialog("Your account has been created succesfully!");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog(responseObject.Errors.FirstOrDefault());
                await dialog.ShowAsync();
            }


        }
    }


    //Universal windowsda referans elave ede bilmediyim ucun bunu elave olaraq burada yaratdim
    internal class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public bool IsSucces { get; internal set; }
    }



    //Universal windowsda referans elave ede bilmediyim ucun bunu elave olaraq burada yaratdim
    internal class RegisterViewModel
    {
        [Required]
        [StringLength(90, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
