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
    /// Interaction logic for F_NewMessages_Page.xaml
    /// </summary>
    public partial class F_NewMessages_Page : Page
    {
        public F_NewMessages_Page()
        {
            InitializeComponent();


            List<RecipesBookService.Folder> listnewRecipeFolder = Global.proxy.GetAllFolder();

            foreach (RecipesBookService.Folder f in listnewRecipeFolder)
            {
                if (Global.proxy.CheckIfFolderHasNewMessage(f, Global.currentUser))
                {
                    NewMessageUserControlFolder nmucf = new NewMessageUserControlFolder(f, 5);
                    nmucf.Margin = new Thickness(10);
                    nmucf.Height = 250;
                    nmucf.Width = 350;
                    newMessagesRecipesWrapPanel.Children.Add(nmucf);
                }
            }
        }
    }
}
