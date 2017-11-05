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
    public partial class BookAddForm : Form
    {
        Book book;

        public BookAddForm(Book book)
        {
            InitializeComponent();
            this.book = book;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        public String BookTitle()
        {
            return titleTextBox.Text;
        }

        public String BookAuthor()
        {
            return authorTextBox.Text;
        }

        public DateTime BookDate()
        {
            return dateTimePicker1.Value.Date;
        }

        public String BookCategory()
        {
            return categoryTextBox.Text;
        }

        private void BookAddForm_Load(object sender, EventArgs e)
        {
            if (book != null)
            {
                titleTextBox.Text = book.title;
                authorTextBox.Text = book.author;
                dateTimePicker1.Value = book.date;
                categoryTextBox.Text = book.category;
            }
        }
    }
}
