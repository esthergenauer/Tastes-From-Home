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
    /// Interaction logic for UserControlAddFolder.xaml
    /// </summary>
    public partial class UserControlAddFolder : UserControl
    {
        RecipesBookService.Folder currentFolder = new RecipesBookService.Folder();
        bool pictureAdded = false;
        public UserControlAddFolder()
        {
            InitializeComponent();
        }

        //Source="/RecipeBookPictuers/WindowhomePage/C_AllRecipes/AddPicRecipeFulder.png"

        private void StackPanel_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (newFolderName.Text != "" && pictureAdded)
                {
                    if (Global.proxy.hasDoublefolder(newFolderName.Text))
                    {
                        MessageBox.Show("תיקיה זו כבר קימת");

                    }
                    else
                    {
                        currentFolder.folderCode = Global.proxy.GetNextKeyFolder();
                        currentFolder.folderName = newFolderName.Text;
                        Global.proxy.AddNewFolder(currentFolder);
                        NavigationService nav = NavigationService.GetNavigationService(this);
                        nav.Navigate(new C_AllRecipes_Page());
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        private void addImageForNewFulder_Click(object sender, RoutedEventArgs e)
        {//newFolderPicture
            try
            {
                currentFolder.folderPicture = PicturesFunctions.UploadImage_Dlg();
                if (currentFolder.folderPicture != null)
                    newFolderPicture.Source = PicturesFunctions.GetImage(currentFolder.folderPicture);

                if (!(currentFolder.folderPicture == null || currentFolder.folderPicture == ""))
                {
                    PicturesFunctions.SendImage(currentFolder.folderPicture);
                    pictureAdded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("הוספת תמונה לא הצליחה");
                //newFolderPicture.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("/RecipeBookPictuers/WindowhomePage/C_AllRecipes/AddPicRecipeFulder.png"));
            }
        }

        private void picButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newFolderName_LostFocus(object sender, RoutedEventArgs e)
        {//שם תיקיה חדשה
            //if (newFolderName.Text.Contains(""))
            //{
            //    newFolderName.Text = "תיקיה חדשה";
            //}
            //else
            //{
            //    currentFolder.folderName = newFolderName.Text;
            //}
        }

        private void newFolderName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (newFolderName.Text.Contains("תיקיה חדשה"))
            //{
            //    newFolderName.Text = "";
            //}
        }

       
    }
}

