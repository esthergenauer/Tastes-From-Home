using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserClientRecipeEstiGenauer
{
    /// <summary>
    /// Interaction logic for E_MyRecipes_Page.xaml
    /// </summary>
    public partial class E_MyRecipes_Page : Page
    {
        public E_MyRecipes_Page()
        {
            InitializeComponent();

            /////לבדוק שהקוד נכון אם זה מתכון או תיקיה -צריך שזה יהיה תיקיה שבתוכה יש מתכונים שלי ואם אין בתיקיה מתכונים שלי אז שזה לא יראה אותו! 


            List<RecipesBookService.Folder> listMYRecipeFolder = Global.proxy.GetAllFolderswithmyRecipes(Global.currentUser);

            foreach (RecipesBookService.Folder f in listMYRecipeFolder)
            {
                if (Global.proxy.CheckIfFolderHasNewMessage(f, Global.currentUser))
                {
                    NewMessageUserControlFolder nmucf = new NewMessageUserControlFolder(f, 5);
                    nmucf.Margin = new Thickness(10);
                    nmucf.Height = 250;
                    nmucf.Width = 350;
                    myRecipesWrapPanel.Children.Add(nmucf);
                }
                else
                {
                    FolderUserControl fuc = new FolderUserControl(f, 5);
                    fuc.Margin = new Thickness(10);
                    fuc.Height = 250;
                    fuc.Width = 350;

                    myRecipesWrapPanel.Children.Add(fuc);
                }
            }
        }
    }
}
