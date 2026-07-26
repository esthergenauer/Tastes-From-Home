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
    /// Interaction logic for UserControlMessages.xaml
    /// </summary>
    public partial class UserControlMessages : UserControl
    {
        RecipesBookService.RecipeMessages currentRecipeMessages;

        public UserControlMessages()
        {
            InitializeComponent();
        }

        public UserControlMessages(RecipesBookService.RecipeMessages rm) : this()
        {
            currentRecipeMessages = rm;

            if (currentRecipeMessages.userCode.userCode == Global.currentUser.userCode)
            { // ג אם ההודעה היא של המשתמש הנוכח ההוגעות שלו יהיו בצד שמאל אחרת בצד ימין
                spStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else
            {
                textTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
                nameTextBlock.HorizontalAlignment = HorizontalAlignment.Right;
            }

            //שם של מי שכתב את ההודעה
            nameTextBlock.Text = currentRecipeMessages.userCode.userName;

            if (currentRecipeMessages.messagesText != "")
            {// גוף ההודעה
                textTextBlock.Text = currentRecipeMessages.messagesText;
            }
        }
    }
}
