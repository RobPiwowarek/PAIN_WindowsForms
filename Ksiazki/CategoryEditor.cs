using System;
using System.ComponentModel;
using System.Windows.Forms.Design;
using static Ksiazki.CategoryControl;

namespace Ksiazki
{
    public class CategoryEditor : System.Drawing.Design.UITypeEditor
    {
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return System.Drawing.Design.UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (edSvc != null)
            {
                CategoryControl categoryControl = new CategoryControl((category) value);
                edSvc.DropDownControl(categoryControl);
                return categoryControl.CurrentCategory;
            }
            return value;
        }
    }

}