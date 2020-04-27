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

namespace _8086Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        // Content of registers
        private string AX, BX, CX, DX;

        private string destination, source, command;
        public Simulation()
        {
            InitializeComponent();
            AX = "";
            BX = "";
            CX = "";
            DX = "";
        }


        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var fullCommand = this.ConsoleTextBox.Text;
                var split = fullCommand.Split(' ');

                command = split[0];
                destination = split[1].Remove(2, 1); //remove ","
                source = split[2];

                var bSourceIsRegister = IsSourceARegister();

                if (bSourceIsRegister && command == "MOV")
                {
                    MovRegisterToRegister();
                }
                else if (!bSourceIsRegister && command == "MOV")
                {
                    MovValueToRegister();
                }
            }
            catch
            {
                MessageBox.Show("Invalid params");
            }
        }

        private bool IsSourceARegister()
        {
            if (source != null)
            {
                if (source == "AX" || source == "BX" || source == "CX" || source == "DX")
                {
                    return true;
                }
            }
            return false;
        }

        private void MovRegisterToRegister()
        {
            string contentToCopy = ""; //value of register to be copied
            switch (source)
            {
                case "AX":
                    contentToCopy = this.AX;
                    break;
                case "BX":
                    contentToCopy = this.BX;
                    break;
                case "CX":
                    contentToCopy = this.CX;
                    break;
                case "DX":
                    contentToCopy = this.DX;
                    break;
            }

            switch (destination)
            {
                case "AX":
                    AX = contentToCopy;
                    break;
                case "BX":
                    BX = contentToCopy;
                    break;
                case "CX":
                    CX = contentToCopy;
                    break;
                case "DX":
                    DX = contentToCopy;
                    break;
            }
            UpdateRegisters();
        }

        private void MovValueToRegister()
        {
            switch (destination)
            {
                case "AX":
                    AX = source;
                    break;
                case "BX":
                    BX = source;
                    break;
                case "CX":
                    CX = source;
                    break;
                case "DX":
                    DX = source;
                    break;
            }
            UpdateRegisters();
        }

        // Refresh values of all registers.
        private void UpdateRegisters()
        {
            this.AxTextBlock.Text = AX;
            this.BxTextBlock.Text = BX;
            this.CxTextBlock.Text = CX;
            this.DxTextBlock.Text = DX;
        }
    }
}
