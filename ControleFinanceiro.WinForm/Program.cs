﻿using System;
using System.Windows.Forms;
using ControleFinanceiro.WinForm.Views;

namespace ControleFinanceiro.WinForm
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
