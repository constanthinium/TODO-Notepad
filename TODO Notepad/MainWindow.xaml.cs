using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.IO;

namespace TODO_Notepad
{
    public partial class MainWindow : Window
    {
        private const string path = "todo.bin";

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(path))
                using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
                {
                    textBox.Text = reader.ReadString();
                    textBox.CaretIndex = reader.ReadInt32();

                    Left = reader.ReadInt32();
                    Top = reader.ReadInt32();
                    Width = reader.ReadInt32();
                    Height = reader.ReadInt32();
                }
        }

        private void TopmostMenuItem_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Topmost = ((MenuItem)sender).IsChecked;
        }

        private void MonospaceMenuItem_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.FontFamily = new FontFamily(((MenuItem)sender).IsChecked ? "Consolas" : "Segoe UI");
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
            {
                writer.Write(textBox.Text);
                writer.Write(textBox.CaretIndex);

                writer.Write((int)Left);
                writer.Write((int)Top);
                writer.Write((int)Width);
                writer.Write((int)Height);
            }
        }
    }
}
