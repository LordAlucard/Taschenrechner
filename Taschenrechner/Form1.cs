using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        Double Zahl = 0;
        String zeichen = "";
        bool zeichen_betätigt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void zahl_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result.Text == "0" && b.Text == ",") { result.Text = "0"; }
            else if (result.Text.Contains(",") && b.Text == ",") { return; } 
            else if((result.Text == "0") || (zeichen_betätigt)) {result.Clear();}
          
            result.Text = result.Text + b.Text;
            
            zeichen_betätigt = false;
        }

        private void rechnung_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // "rechnung_click" ruft hier die Methode "Rechnung" auf
            this.Rechnung(b.Text);
        }

        // Alter Inhalt aus "rechung_click" ausgelagert
        private void Rechnung(String operatorString)
        {
            zeichen = operatorString;
            Zahl = Double.Parse(result.Text);

            label1.Text = Zahl + " " + zeichen;

            zeichen_betätigt = true;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            result.Clear();
            result.Text = "0";
            label1.Text = "";
        }

        private void gleich_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            switch (zeichen)
            {    
                case "+":
                        result.Text = (Zahl + Double.Parse(result.Text)).ToString ();
                        break;

                case "-":
                        result.Text = (Zahl - Double.Parse(result.Text)).ToString ();
                        break;
                case "*":
                        result.Text = (Zahl * Double.Parse(result.Text)).ToString ();
                        break;
                case "/":
                        result.Text = (Zahl / Double.Parse(result.Text)).ToString ();
                        break;
                default:
                    break;
            }

            zeichen_betätigt = true;
        }

  
        private void C_Click(object sender, EventArgs e)
        {
            result.Clear();
            
            result.Text = "0";
        }

        private void vorzeichen_click(object sender, EventArgs e)
        {
            if (Double.Parse(result.Text) < 0) { result.Text = Math.Abs(Double.Parse(result.Text)).ToString(); }
            else if (Double.Parse(result.Text) > 0) { result.Text = (Double.Parse(result.Text)*-1).ToString(); }
            else { result.Text = result.Text; }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prüft, ob Inahlt von "e.KeyChar" + oder * oder / oder - enthält 
            if(e.KeyChar.ToString().IndexOfAny("+*/-".ToCharArray()) != -1)
                // Wenn ja, dann rufe "Rechnung" mit "e.KeyChar" auf
                this.Rechnung(e.KeyChar.ToString());

            // MessageBox.Show(e.KeyChar.ToString(), "KeyPress");
        }
    }
}
