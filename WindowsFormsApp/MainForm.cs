using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            long userInput;
            long.TryParse(txtValue.Text, out userInput);

            double result = await GetSumOfRandomValuesAsync(userInput);
            richTextBox1.AppendText("Fibonacci(" + userInput + ") = " + result + "\n");
            ReadWriteAsync.WriteLog("Fibonacci(" + userInput + ") = " + result + "\n");

        }
        private async Task<long> GetSumOfRandomValuesAsync(long inputValue)
        {
            long result = 0;
            Task<long> task = Task<long>.Factory.StartNew(() =>
            {
                result = Fibonacci(inputValue);
                return result;
            });
            await task;
            return task.Result; //calling result from a task
        }
      
        private long Fibonacci(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Testing if the UI is locked.");
        }
    }
}
