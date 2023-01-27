/*
 * Created by SharpDevelop.
 * User: valerio
 * Date: 26/01/2023
 * Time: 11:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Thread _hilo1;
		Thread _hilo2;
		//static bool estadoThread = false;
		public MainForm()
		{
			InitializeComponent();
		}

		Point currentPosition = new Point(90, 39); // Global variable

		public void Mover_en_X()
		{
		    for (int i = 0; i < 339; i++)
		    {
		        currentPosition.X = currentPosition.X + 1;
		        button1.BeginInvoke((Action)delegate ()
		        {
		            button1.Location = currentPosition;
		        });
		        Thread.Sleep(5);
		    }
		}
        public void Moder_en_Y()
		{
		    for (int i = 0; i < 214; i++)
		    {
		        currentPosition.Y = currentPosition.Y + 1;
		        button1.BeginInvoke((Action)delegate ()
		        {
		            button1.Location = currentPosition;
		        });
		        Thread.Sleep(5);
		        //estadoThread = true;
		    }
		}
        private void Button2Click(object sender, EventArgs e)
        {
        	try {
        		button2.Enabled = false;
        		_hilo1 = new Thread(Mover_en_X);
        		_hilo1.Start();
        		
        	} catch (ThreadInterruptedException error) {        		
        		Console.WriteLine("Ah Ocurrido un Error\n"+error.Message);
        	}
        }
        private void Button3Click(object sender, EventArgs e)
        {
        	try {
        		button3.Enabled = false;
        		_hilo2 = new Thread(Moder_en_Y);
        		_hilo2.Start();
        		//_hilo2.Join();
        	} catch (ThreadInterruptedException error) {
        		Console.WriteLine("Ah Ocurrido un Error\n"+error.Message);
        	}
        }
        private void Button4Click(object sender, EventArgs e)
        {
        	_hilo1.Abort();
        	button2.Enabled = true;
        }
        private void Button5Click(object sender, EventArgs e)
        {
            _hilo2.Abort();
            button3.Enabled = true;
        }
	}
}
