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
    /// Interaction logic for D_FavriteRecipes_Page.xaml
    /// </summary>
    public partial class D_FavriteRecipes_Page : Page
    {
        public D_FavriteRecipes_Page()
        {
            InitializeComponent();

            List<RecipesBookService.Folder> listFavRecipeFolder = Global.proxy.GetAllFolderThatHasFavoriteRecipes(Global.currentUser);

            foreach (RecipesBookService.Folder f in listFavRecipeFolder)
            {
                if (Global.proxy.CheckIfFolderHasNewMessage(f,Global.currentUser))
                {
                    NewMessageUserControlFolder nmucf = new NewMessageUserControlFolder(f, 4);
                    nmucf.Margin = new Thickness(10);
                    nmucf.Height = 250;
                    nmucf.Width = 350;
                    favriteRecipesWrapPanel.Children.Add(nmucf);
                }
                else
                {
                    FolderUserControl fuc = new FolderUserControl(f, 4);
                    fuc.Margin = new Thickness(10);
                    fuc.Height = 250;
                    fuc.Width = 350;

                    favriteRecipesWrapPanel.Children.Add(fuc);
                }
            }
        }

       
    }
}
