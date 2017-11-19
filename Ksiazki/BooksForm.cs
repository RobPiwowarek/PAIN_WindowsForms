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
    public partial class BooksForm : Form, ViewInterface
    {
        BookAddForm addForm;
        List<Book> items;
        MainForm mainForm;

        public BooksForm(List<Book> items, MainForm mainForm)
        {
            InitializeComponent();
            this.items = items;
            this.mainForm = mainForm;
            UpdateListView(items);
            this.toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm = new BookAddForm(null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                Book book = new Book(addForm.BookTitle(), addForm.BookAuthor(), addForm.BookDate(), addForm.BookCategory());
                items.Add(book);
                ListViewItem item = new ListViewItem();
                item.Tag = book;
                UpdateItem(item);
                mainForm.addBookInAllViews(book);
            }
        }

        public void AddBookToListView(Book book)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = book;
            UpdateItem(item);
            if (book.date.Year < 2000 && beforeRadioButton.Checked)
                listView1.Items.Add(item);
            else if (book.date.Year >= 2000 && afterRadioButton.Checked)
                listView1.Items.Add(item);
            else if (allRadioButton.Checked || (allRadioButton.Checked && !beforeRadioButton.Checked && !afterRadioButton.Checked))
                listView1.Items.Add(item);

            this.toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        public void UpdateListView(List<Book> items)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                    listView1.Items[i].Remove();
            }

            foreach (Book book in items)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = book;
                UpdateItem(item);
                listView1.Items.Add(item);
            }

            this.toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        private void UpdateItem(ListViewItem item)
        {
            Book book = (Book)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = book.title;
            item.SubItems[1].Text = book.author;
            item.SubItems[2].Text = book.date.ToString("dd/MM/yyyy");
            item.SubItems[3].Text = book.category;

            this.toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        public void UpdateItem(Book book)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag == book)
                {
                    item.SubItems[0].Text = book.title;
                    item.SubItems[1].Text = book.author;
                    item.SubItems[2].Text = book.date.ToString("dd/MM/yyyy");
                    item.SubItems[3].Text = book.category;
                    return;
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Book book = (Book)listView1.SelectedItems[0].Tag;
                addForm = new BookAddForm(book);

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    book.title = addForm.BookTitle();
                    book.author = addForm.BookAuthor();
                    book.date = addForm.BookDate();
                    book.category = addForm.BookCategory();

                    UpdateItem(listView1.SelectedItems[0]);
                    mainForm.updateBookInAllViews(book);
                }
            }
        }

        private void BooksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void DeleteBook(Book book)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag == book)
                {
                    listView1.Items.Remove(item);
                    break;
                }
            }
            this.toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Book book = (Book)listView1.SelectedItems[0].Tag;

                mainForm.deleteBookFromAllViews(book);
            }
        }

        private void beforeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (beforeRadioButton.Checked)
            {
                List<Book> filteredList = new List<Book>();

                foreach (Book book in mainForm.GetItems())
                {
                    if (book.date.Year < 2000)
                        filteredList.Add(book);
                }

                UpdateListView(filteredList);
            }
        }

        private void afterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (afterRadioButton.Checked)
            {
                List<Book> filteredList = new List<Book>();

                foreach (Book book in mainForm.GetItems())
                {
                    if (book.date.Year >= 2000)
                        filteredList.Add(book);
                }

                UpdateListView(filteredList);
            }
        }

        private void allRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (allRadioButton.Checked)
            {
                UpdateListView(items);
            }
        }

        private void BooksForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(this.statusStrip1, ((MainForm)this.MdiParent).statusStrip1);
        }

        private void BooksForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)this.MdiParent).statusStrip1, this.statusStrip1);
        }
    }
}