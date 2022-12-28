using System.Windows.Forms;

namespace Assignment7_IliaBogatyrev
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the initial directory and file filters for the open file dialog
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            // Show the open file dialog and check if the user selected a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog1.FileName;

                // Do 
                char[] correctAnswers = { 'B', 'D', 'A', 'A', 'C', 'A', 'B', 'A', 'C', 'D', 'B', 'C', 'D', 'D', 'D', 'C', 'C', 'B', 'D', 'A' };
                // Read file
                //string[] studentAnswers = File.ReadAllLines(filePath);
                //char[] answers = studentAnswers.Select(s => s[0]).ToArray();
                char[] studentAnswers = new char[20];
                using (StreamReader reader = new StreamReader(filePath))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        string line = reader.ReadLine();
                        if (line.Length > 0)
                        {
                            studentAnswers[i] = line[0];
                        }
                    }
                }

                int numCorrect = 0;
                int numIncorrect = 0;
                List<int> incorrectQuestions = new List<int>();
                for (int i = 0; i < correctAnswers.Length; i++)
                {
                    if (studentAnswers[i] == correctAnswers[i])
                    {
                        numCorrect++;
                    }
                    else
                    {
                        numIncorrect++;
                        incorrectQuestions.Add(i + 1);
                    }
                }
                if (numCorrect >= 15)
                {
                    MessageBox.Show("Student passed the exam!");
                }
                else
                {
                    MessageBox.Show("Student failed the exam");
                }
                

            }
            }
    }
}