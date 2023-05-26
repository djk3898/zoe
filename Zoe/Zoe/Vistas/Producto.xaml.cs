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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoe.Negoci;

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Producto : UserControl
    {
        public Producto()
        {
            InitializeComponent();
            Botiga botiga = new Botiga();
            dataGridProductes.ItemsSource = botiga.Productes;
            dataGridPacks.ItemsSource = botiga.Packs;
        }
    }
}