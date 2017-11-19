using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ksiazki.CategoryControl;

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
            return categoryControl1.ToString();
        }

        private void BookAddForm_Load(object sender, EventArgs e)
        {
            if (book != null)
            {
                titleTextBox.Text = book.title;
                authorTextBox.Text = book.author;
                dateTimePicker1.Value = book.date;

                if (book.category.Equals("poetry"))
                    categoryControl1.SetCategory(category.poetry);
                else if (book.category.Equals("fantasy"))
                    categoryControl1.SetCategory(category.fantasy);
                else
                    categoryControl1.SetCategory(category.criminal);
            }
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(authorTextBox, "");
        }

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (authorTextBox.Text.Equals(""))
            {
                errorProvider1.SetError(authorTextBox, "Author cannot be left blank");
                e.Cancel = true;
            }
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (titleTextBox.Text.Equals(""))
            {
                errorProvider1.SetError(authorTextBox, "Title cannot be left blank");
                e.Cancel = true;
            }
        }

        private void titleTextBox_Validated(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(titleTextBox, "");
        }
    }
}
