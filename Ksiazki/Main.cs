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
    public partial class MainForm : Form
    {
        public List<ViewInterface> views = new List<ViewInterface>();
        public List<Book> items = new List<Book>();
        
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.views.Count <= 1 && e.CloseReason != CloseReason.MdiFormClosing) e.Cancel = true;
            else views.Remove((ViewInterface)sender);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BooksForm f = new BooksForm(items, this);
            f.MdiParent = this;
            f.FormClosing += ChildFormClosing;
            views.Add(f);
            f.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void BooksFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksForm f = new BooksForm(items, this);
            f.MdiParent = this;
            f.FormClosing += ChildFormClosing;
            views.Add(f);
            f.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        public List<Book> GetItems()
        {
            return items;
        }

        public void deleteBookFromAllViews(Book book)
        {
            foreach (ViewInterface view in views)
            {
                view.DeleteBook(book);
            }

            items.Remove(book);

        }

        public void updateBookInAllViews(Book book)
        {
            foreach (ViewInterface view in views)
            {
                view.UpdateItem(book);
                
            }
        }

        public void addBookInAllViews(Book book)
        {
            foreach (ViewInterface view in views)
            {
                view.AddBookToListView(book);
            }
        }

        public void updateViews()
        {
            foreach (ViewInterface view in views)
            {
                view.UpdateListView(items);
            }
        }
    }
}
