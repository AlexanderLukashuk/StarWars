using StarWarsCharacters.Data;
using StarWarsCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarWarsCharacters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseContext context;

        public MainWindow()
        {
            InitializeComponent();

            context = new DatabaseContext();
        }

        private void SearchCharacter(object sender, RoutedEventArgs e)
        {
            int number;
            bool isNumber = int.TryParse(charecterNumberTextBox.Text, out number);
            if (isNumber)
            {
                string path = "https://swapi.dev/api/people/" + charecterNumberTextBox.Text + "/";
                WebClient client = new WebClient();
                Task task = new Task(() =>
                {
                    var json = client.DownloadString(path);
                    //MessageBox.Show(json);
                    //client.DownloadFile(path, "file");
                    Character character = JsonSerializer.Deserialize<Character>(json);
                    MessageBox.Show(character.name + "\n" + character.height + "\n" + character.mass + "\n" + character.hair_color + "\n" + character.skin_color + "\n" + character.eye_color + "\n" + character.birth_year + "\n" + character.gender);
                    context.Characters.Add(character);
                    context.SaveChanges();
                });



            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        //private static async Task DownloadFileAsync(string path)
        //{
        //    WebClient client = new WebClient();
        //    await client.DownloadString(path));
        //}

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
    }
}
