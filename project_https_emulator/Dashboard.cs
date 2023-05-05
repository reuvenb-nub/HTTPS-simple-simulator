namespace project_https_emulator
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void show_client()
        {
            Form form = new Client();
            form.ShowDialog();
        }

        private void show_server()
        {
            Form form = new Server();
            form.ShowDialog();
        }

        private void btn_cli_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(show_client));
            thread.Start();
        }

        private void btn_ser_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(show_server));
            thread.Start();
        }
    }
}