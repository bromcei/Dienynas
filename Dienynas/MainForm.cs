using Dienynas.Classes;
using Dienynas.Repositories;
using Dienynas.Services;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Dienynas
{
    public partial class MainForm : Form
    {
        public StudentsRepository Students { get; set; }
        public TeachersRepository Teachers { get; set; }
        public SubjectRepository Subjects { get; set; }
        public SubjectMarksRepository SubjectMarks { get; set; }
        public SemesterRepository Semesters { get; set; }

        public StudentsMarkingService StudentsMarking { get; set; }
        public SemesterEveluationService SemesterEveluation { get; set; }   
        public List<string> TestList { get; set; } 
        public MainForm()
        {
            InitializeComponent();
            string env = "prod";
            Students = new StudentsRepository(env);
            Teachers = new TeachersRepository(env);
            Subjects = new SubjectRepository(env);
            SubjectMarks = new SubjectMarksRepository(env);
            Semesters = new SemesterRepository(env);
            StudentsMarking = new StudentsMarkingService(Students, Teachers, Subjects, SubjectMarks);
            SemesterEveluation = new SemesterEveluationService(Students, Teachers, Subjects, SubjectMarks, Semesters);
            List<string> TestList = new List<string>{ "AS", "mnr", "ne"};
            listTest.DataSource = Students.Retrieve().ToList();

            dataGridView1.Columns.Add("newColumnName", "Student Name");
            foreach ( DateTime date in Semesters.SemesterDatesList(1))
            {
                dataGridView1.Columns.Add("newColumnName", date.ToString("yyyy-MM-dd"));
            }
            
            dataGridView1.Rows.Add("1", "XX");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curItem = listTest.SelectedItems;

            MessageBox.Show($"Selected Student {curItem}");
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}