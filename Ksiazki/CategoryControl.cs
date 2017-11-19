using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Ksiazki
{
    public class CategoryControl : PictureBox
    {
        private static string[] imagePaths = { @"C:\Users\T540p\Desktop\PAIN_WindowsForms-master\Ksiazki\poezja.png",
                                               @"C:\Users\T540p\Desktop\PAIN_WindowsForms-master\Ksiazki\resources\fantastyka.png",
                                               @"C:\Users\T540p\Desktop\PAIN_WindowsForms-master\Ksiazki\resources\kryminal.png" };
        public enum category { poetry = 0, fantasy = 1, criminal = 2};

        [EditorAttribute(typeof(CategoryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Category control")]
        [BrowsableAttribute(true)]
        public category CurrentCategory
        {
            get { return Category; }
            set
            {
                this.Category = value;
                this.Image = Image.FromFile(imagePaths[(int)value]);
            }
        }

        private category Category
        {
            get; set;
        }

        public override string ToString()
        {
            return Category.ToString();
        }

        public void NextCategory()
        {
            ++Category;
            Category = (category)(((int)Category) % 3);
            this.Image = Image.FromFile(imagePaths[(int) Category]);
        }

        public CategoryControl()
        {
            this.Size = new Size(64, 64);
            this.Category = category.poetry;
            Image = Image.FromFile(imagePaths[(int) Category]);
            this.Click += CategoryControl_Click;
        }

        public CategoryControl(category cat)
        {
            this.Size = new Size(64, 64);
            this.Category = cat;
            Image = Image.FromFile(imagePaths[(int)cat]);
            this.Click += CategoryControl_Click;
        }

        public void SetCategory(category cat)
        {
            this.Category = cat;
            this.Image = Image.FromFile(imagePaths[(int) Category]);
        }

        private void CategoryControl_Click(object sender, EventArgs e)
        {
            NextCategory();
            Invalidate();
        }
    }
}