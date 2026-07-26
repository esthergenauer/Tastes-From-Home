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
    /// Interaction logic for C_AllRecipes_Page.xaml
    /// </summary>
    public partial class C_AllRecipes_Page : Page
    {
        List<RecipesBookService.Recipes> lst = Global.proxy.GetAllRecipes();

        public C_AllRecipes_Page()
        {
            InitializeComponent();

            List<RecipesBookService.Folder> listFolder = Global.proxy.GetAllFolder();

            UserControlAddFolder ucaf = new UserControlAddFolder();
            ucaf.Margin = new Thickness(10);
            ucaf.Height = 250;
            ucaf.Width = 350;

            folderWrapPanel.Children.Add(ucaf);

            foreach (RecipesBookService.Folder f in listFolder)
            {
                if (Global.proxy.CheckIfFolderHasNewMessage(f, Global.currentUser))
                {
                    NewMessageUserControlFolder nmucf = new NewMessageUserControlFolder(f, 3);
                    nmucf.Margin = new Thickness(10);
                    nmucf.Height = 250;
                    nmucf.Width = 350;
                    folderWrapPanel.Children.Add(nmucf);
                }
                else
                {
                    FolderUserControl fuc = new FolderUserControl(f, 3);
                    fuc.Margin = new Thickness(10);
                    fuc.Height = 250;
                    fuc.Width = 350;
                    folderWrapPanel.Children.Add(fuc);
                }
            }
        }
    }
}