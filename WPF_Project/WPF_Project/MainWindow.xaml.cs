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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace WPF_Project
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> valores = new List<string>();
        string path = @"C:\Users\pablo\OneDrive\Desktop\WPF\WPF_Project\WPF_Project\personas.json";
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = nombreTextBox.Text;
            persona.Apellido = apellidoTextBox.Text;
            persona.Direccion = direccionTextBox.Text;
            Guardar(persona);
            
        }
        private void Guardar(Persona persona)
        {  
            string jsonString = JsonSerializer.Serialize(persona);
            System.IO.File.WriteAllText(path, jsonString);
        }
        private void Cargar()
        {
            string archivo = File.ReadAllText(path);
            valores = JsonConverter(archivo);
        }
    }
}
