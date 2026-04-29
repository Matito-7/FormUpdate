using MySql.Data.MySqlClient;
using System.Data;
namespace UpDate
{
    public partial class Form1 : Form
    {
        string conexao = "Server=localhost; database=notasescola; uid=root; pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        public void CarregarAlunos()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                string sql = "Select * From alunos";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAlunos.DataSource = dt;
            }
            catch (Exception ex) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarAlunos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dgvAlunos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um aluno");
                return;
            }

            int id = Convert.ToInt32(dgvAlunos.CurrentRow.Cells["id"].Value);
            string nome = dgvAlunos.CurrentRow.Cells["nome"].Value.ToString();
            int idade = Convert.ToInt32(dgvAlunos.CurrentRow.Cells["idade"].Value);
            string curso = dgvAlunos.CurrentRow.Cells["curso"].Value.ToString();
            decimal nota = Convert.ToDecimal(dgvAlunos.CurrentRow.Cells["nota"].Value);

            FormEditarAluno frm = new FormEditarAluno(id, nome, idade, curso, nota);
            frm.ShowDialog();
            CarregarAlunos();
        }
    }
}
