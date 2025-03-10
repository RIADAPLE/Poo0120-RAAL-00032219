﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Labo_09
{
    public partial class Inscription : UserControl
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void Inscription_Load(object sender, EventArgs e)
        {
            var assignatures = Conexion.ExecuteQuery("SELECT nombre FROM materia ");
            var assignaturesCombo = new List<string>();

            foreach (DataRow dr in assignatures.Rows)
            {
                assignaturesCombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource = assignaturesCombo;
        }

        private void btnInscribit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    string query = $"SELECT idMateria FROM materia WHERE nombre = '{comboBox1.SelectedItem.ToString()}'";
                    
                    var dt = Conexion.ExecuteQuery(query);
                    var dr = dt.Rows[0];
                    var idMateria = Convert.ToInt32(dr[0].ToString());
                    
                    string nonQuery = $"INSERT INTO INSCRIPCION(carnet, idmateria) VALUES (" +
                                      $"'{textBox1.Text}',"+
                                      $"{idMateria})";
                    
                    Conexion.ExecuteNonQuery(nonQuery);

                    MessageBox.Show("Se ha inscrito la materia");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}