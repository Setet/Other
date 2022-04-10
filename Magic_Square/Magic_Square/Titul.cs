using System.Windows.Forms;

namespace Magic_Square
{
    public partial class Titul : Form
    {
        public Titul()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }
    }
}
