using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UpDate
{
    public partial class FormEditarAluno : Form
    {
        int alunoId;
        string conexao = "Server=localhost; database=notasescola; uid=root; pwd=;";
        public FormEditarAluno(int id, string nome, int idade, string curso, decimal nota)
        {
            InitializeComponent();

            alunoId = id;
            txtNome.Text = nome;
            txtIdade.Text = idade.ToString();
            txtCurso.Text = curso;
            txtNota.Text = nota.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();

                string sql = "UPDATE alunos SET nome=@nome, idade=@idade, curso=@curso, nota=@nota Where id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@idade", int.Parse(txtIdade.Text));
                cmd.Parameters.AddWithValue("@curso", txtCurso.Text);
                cmd.Parameters.AddWithValue("@nota", decimal.Parse(txtNota.Text));
                cmd.Parameters.AddWithValue("@id", alunoId);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Aluno atualizado com sucesso");
            this.Close();
        }
    }
}
