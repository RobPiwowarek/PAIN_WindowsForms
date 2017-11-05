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
    public partial class Form2 : Form
    {
        BookAddForm addForm;
        List<Book> items;
        Form1 mainForm;

        public Form2(List<Book> items, Form1 mainForm)
        {
            InitializeComponent();
            this.items = items;
            this.mainForm = mainForm;
            UpdateListView(items);
        }

        private void Form2_Load(object sender, EventArgs e)
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
                listView1.Items.Add(item);
                mainForm.updateViews();
            }
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
    }
}
