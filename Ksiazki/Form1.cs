using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksiazki
{
    public partial class Form1 : Form
    {
        public List<Form2> views = new List<Form2>();
        public List<Book> items = new List<Book>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(items, this);
            f.MdiParent = this;
            views.Add(f);
            f.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        public void updateBookInAllViews(Book book)
        {
            foreach (Form2 view in views)
            {
                view.UpdateItem(book);
            }
        }

        public void updateViews()
        {
            foreach (Form2 view in views)
            {
                view.UpdateListView(items);
            }
        }
    }
}
