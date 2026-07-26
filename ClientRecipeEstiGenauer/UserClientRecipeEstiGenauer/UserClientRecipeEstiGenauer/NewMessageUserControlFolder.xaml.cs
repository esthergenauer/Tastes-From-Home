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
    /// Interaction logic for NewMessageUserControlFolder.xaml
    /// </summary>
    public partial class NewMessageUserControlFolder : UserControl
    {
        int code;
        RecipesBookService.Folder currentFolder;
        public NewMessageUserControlFolder()
        {
            InitializeComponent();
        }
        public NewMessageUserControlFolder(RecipesBookService.Folder f, int c) : this()
        {

            code = c;
            currentFolder = f;
            this.DataContext = currentFolder;
            try
            {
                if (!(currentFolder.folderPicture == "" || currentFolder.folderPicture == null))
                    imageFolder.Source = PicturesFunctions.GetImage(currentFolder.folderPicture);
            }
            catch (Exception ex)
            { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new RecipeByFolder(currentFolder, code));

        }
    }
}
