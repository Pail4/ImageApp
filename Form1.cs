namespace ImageApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (BMP,JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF, *.BMP";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBox.Image = new Bitmap(openFileDialog.FileName); <- по  заданию не требуется
            }
        }
    }
}