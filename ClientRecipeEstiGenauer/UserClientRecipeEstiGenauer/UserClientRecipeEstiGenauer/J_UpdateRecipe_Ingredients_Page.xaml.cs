using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for J_UpdateRecipe_Ingredients_Page.xaml
    /// </summary>
    public partial class J_UpdateRecipe_Ingredients_Page : Page
    {
        bool usedPopup = false;
        bool usedPopup1 = false;
        RecipesBookService.Recipes currentRecipe;
        List<RecipesBookService.RecipeIngredient> lst;
        List<RecipesBookService.RecipeIngredient> lstri;
        RecipesBookService.Ingredients i = new RecipesBookService.Ingredients();
        RecipesBookService.Yechidot y = new RecipesBookService.Yechidot();
        List<RecipesBookService.Ingredients> lstingredients = Global.proxy.GetAllIngredients();
        List<RecipesBookService.Yechidot> lstYechidot = Global.proxy.GetAllYechidot();

        Popup myPopup1;
        ListBox listBox = new ListBox();
        TextBox addNewIngredientsTextBox = new TextBox();
        Button addNewIngredientsButton = new Button();
        Button CanceladdNewIngredientsButton = new Button();

        Popup myPopup3;
        TextBox addNewYechidaTextBox = new TextBox();
        Button addNewYechidaButton = new Button();
        Button CanceladdNewYechidaButton = new Button();



        public J_UpdateRecipe_Ingredients_Page()
        {
            InitializeComponent();
        }
        public J_UpdateRecipe_Ingredients_Page(RecipesBookService.Recipes r) : this()
        {
            currentRecipe = r;
            lst =Global.proxy.GetAllRecipeIngredientByRecipe(currentRecipe);
            ingredientsNameComboBox.ItemsSource = lstingredients;
            ingredientsUnitComboBox.ItemsSource = lstYechidot;

            lstri = Global.proxy.GetAllRecipeIngredientByRecipe(currentRecipe);
            bool found = false;

            foreach (var x in lstri)
            {
                //אם כן הוסף אז מעדכן אותו לפי מה שהוסיפו עכשיו

                Button y1 = new Button();
                y1.Tag = x.recipeIngredientCode;
                y1.Click += buttonYClick;
                y1.Content = x.ingredientamount + "_" + x.codeYechidot.nameYechidot + "_" + x.ingredientCode.ingredientName;
                StackPanel2.Children.Add(y1);
            }
        }

        public void buttonYClick(object sender, RoutedEventArgs e)
        {
            int x1 = 0;
            Button button = sender as Button;

            if (button != null)
            {
                var tag = button.Tag;
                if (tag != null)
                {
                    string tagContent = tag.ToString(); // Assuming tag content is a string
                                                        // Now you can use tagContent as needed
                    x1 = int.Parse(tagContent);                                   // For example:
                }

                RecipesBookService.RecipeIngredient r11 = Global.proxy.FindRecipeIngredient(x1);
                RecipesBookService.Ingredients r1 = Global.proxy.FindRecipeIngredient(x1).ingredientCode;

                ingredientsNameComboBox.SelectedItem = r1;
                r1 = lstingredients.Find(x => x.ingredientsCode == r1.ingredientsCode);
                ingredientsNameComboBox.SelectedItem = r1;

                RecipesBookService.Yechidot unit1 = Global.proxy.FindRecipeIngredient(x1).codeYechidot;

                ingredientsUnitComboBox.SelectedItem = unit1;
                unit1 = lstYechidot.Find(x => x.codeYechidot == unit1.codeYechidot);
                ingredientsUnitComboBox.SelectedItem = unit1;

                ingredientsAmountDoubleUpDown.Value = r11.ingredientamount;
                // ingredientsUnitComboBox.SelectedItem = r11.codeYechidot;
            }
        }
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel2.Children.Count == 0)
                MessageBox.Show("חסר מרכיבים");
            else
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new J_UpdateRecipe_Directions_Page(currentRecipe, lst));
            }
        }

        private void addIngredientsButton_Click(object sender, RoutedEventArgs e)
        { //כאשר לוחצים על להוסיף מרכיב  

            if (ingredientsNameComboBox.SelectedItem == null || ingredientsAmountDoubleUpDown.Value == null || ingredientsUnitComboBox.SelectedItem == null)
            {//בודק האם חסר פרטים של המרכיב

                if (ingredientsNameComboBox.SelectedItem == null)
                {//בודק שהוסיף שם מרכיב

                    MessageBox.Show("חסר שם מרכיב");

                    ingredientsNameComboBox.BorderBrush = Brushes.Red;
                }

                if (ingredientsAmountDoubleUpDown.Value == null)
                {//בודק שהוסיפו כמות מרכיב

                    MessageBox.Show("חסר כמות מרכיב");

                    ingredientsAmountDoubleUpDown.BorderBrush = Brushes.Red;
                }

                if (ingredientsUnitComboBox.SelectedItem == null)
                {//בודק שהוסיפו מידת מרכיב

                    MessageBox.Show("חסר מידת מרכיב");

                    ingredientsUnitComboBox.BorderBrush = Brushes.Red;
                }
            }

            else
            {//אם לא חסר פרטים אז i זה המרכיב שהוסיפו  
                RecipesBookService.Ingredients i = ((RecipesBookService.Ingredients)ingredientsNameComboBox.SelectedItem);

                //בודק שהמריכב לא כבר הוסף לרשימת המרכיבים
                bool found = false;

                foreach (var x in lst)
                {
                    if (i.ingredientsCode == x.ingredientCode.ingredientsCode)
                    {//אם כן הוסף אז מעדכן אותו לפי מה שהוסיפו עכשיו

                        x.codeYechidot = (RecipesBookService.Yechidot)ingredientsUnitComboBox.SelectedItem;
                        x.ingredientamount = (double)ingredientsAmountDoubleUpDown.Value;
                        Global.proxy.UpdateRecipeIngredient(x);
                        found = true;
                        Button y1 = new Button();


                        foreach (Button y in StackPanel2.Children)
                        {// מוחק את המרכיב מהstackpanel אם כבר שם
                            string s2 = (string)y.Content;
                            if (s2.Contains(i.ingredientName))
                                y1 = y;
                        }

                        StackPanel2.Children.Remove(y1);

                        //מוסיף שום לרשימה שנראית stackpanel
                        Button t = new Button();
                        t.Content = x.ingredientamount + "_" + x.codeYechidot.nameYechidot + "_" + x.ingredientCode.ingredientName;

                        StackPanel2.Children.Add(t);
                        ingredientsNameComboBox.SelectedItem = null;
                        ingredientsAmountDoubleUpDown.Value = null;
                        ingredientsUnitComboBox.SelectedItem = null;
                    }
                }

                if (found == false)
                {//אם המרכיב לא כבר מופיע ברשימה אז הוא מוסיף מרכיב חדש לרשימה וגם מוסיף ל stackpanel

                    RecipesBookService.RecipeIngredient ri = new RecipesBookService.RecipeIngredient();

                    ri.codeYechidot = (RecipesBookService.Yechidot)ingredientsUnitComboBox.SelectedItem;
                    ri.ingredientCode = (RecipesBookService.Ingredients)ingredientsNameComboBox.SelectedItem;
                    ri.recipeCode = currentRecipe;
                    ri.recipeIngredientStatus = true;
                    ri.ingredientamount = (double)ingredientsAmountDoubleUpDown.Value;
                    ri.recipeIngredientCode = Global.proxy.GetNextKeyRecipeIngredient();
                    lst.Add(ri);
                    Button t = new Button();
                    t.Content = ri.ingredientamount + "_" + ri.codeYechidot.nameYechidot + "_" + ri.ingredientCode.ingredientName;
                    StackPanel2.Children.Add(t);

                    Global.proxy.AddNewRecipeIngredient(ri);
                    ingredientsNameComboBox.SelectedItem = null;
                    ingredientsAmountDoubleUpDown.Value = null;
                    ingredientsUnitComboBox.SelectedItem = null;

                }
            }
        }

        private void OpenPopup2()
        { myPopup1.IsOpen = true; }
        private void OpenPopup1()
        {
            usedPopup = true;
            // Create a new instance of the Popup
            myPopup1 = new Popup();

            
            Border border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Background = Brushes.White,
                Width = 300,
                Height = 300
            };
            myPopup1.Child = border;

            StackPanel sp1 = new StackPanel();
            sp1.Name = "sp1";
            Grid.SetRow(sp1, 2);
            Grid.SetRowSpan(sp1, 1);
            Grid.SetColumn(sp1, 3);
            Grid.SetColumnSpan(sp1, 1);
            sp1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDED5BF"));

            // TextBox
            addNewIngredientsTextBox.Name = "addNewIngredientsTextBox";
            addNewIngredientsTextBox.Text = "שם מרכיב אחר";
            addNewIngredientsTextBox.LostFocus += addNewIngredientsTextBox_LostFocus;
            addNewIngredientsTextBox.PreviewMouseDown += addNewIngredientsTextBox_PreviewMouseDown;
            //addNewIngredientsTextBox.Background = System.Windows.Media.Brushes.#FFDED5BF;
            //addNewIngredientsTextBox.Foreground = System.Windows.Media.Brushes.#FF7A4928;
            sp1.Children.Add(addNewIngredientsTextBox);

            //listBox
            listBox.Items.Add("מכיל ביצים");
            listBox.Items.Add("מכיל גלוטן");
            listBox.Items.Add("מכיל חלב");
            listBox.Items.Add("מכיל אגוזים");
            listBox.Items.Add("מכיל שומשום");
            listBox.Items.Add("מכיל סויה");
            listBox.Items.Add("מכיל סוכר");

            listBox.SelectionMode = SelectionMode.Multiple;
            listBox.SelectionChanged += ListBox_SelectionChanged;

            sp1.Children.Add(listBox);

            // Button
            addNewIngredientsButton.Click += addNewIngredientsButton_Click;
            addNewIngredientsButton.Name = "addNewIngredientsButton";
            addNewIngredientsButton.Content = "הוסף מרכיב";
            // Add button properties, event handlers, etc. if needed
            sp1.Children.Add(addNewIngredientsButton);

            // Button בטל
            CanceladdNewIngredientsButton.Click += CanceladdNewIngredientsButton_Click;
            CanceladdNewIngredientsButton.Name = "CanceladdNewIngredientsButton";
            CanceladdNewIngredientsButton.Content = "בטל";
            // Add button properties, event handlers, etc. if needed
            sp1.Children.Add(CanceladdNewIngredientsButton);


            border.Child = sp1;

            double centerX = ActualWidth / 1.75;
            double centerY = ActualHeight / 3.5;

            // Set the position of the popup
            myPopup1.HorizontalOffset = centerX - (border.ActualWidth / 2);
            myPopup1.VerticalOffset = centerY - (border.ActualHeight / 2);

            // Open the Popup
            myPopup1.IsOpen = true;
        }

        private void addNewIngredientsTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addNewIngredientsTextBox.Text == "")
                addNewIngredientsTextBox.Text = "שם מרכיב אחר";
        }

        private void addNewIngredientsTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (addNewIngredientsTextBox.Text == "שם מרכיב אחר")
                addNewIngredientsTextBox.Text = "";
        }

        private void addNewIngredientsButton_Click(object sender, RoutedEventArgs e)
        {//הוספת מרכיב חדש אם לא כבר קיים
            i.ingredientName = addNewIngredientsTextBox.Text;
            i.ingredientsCode = Global.proxy.GetNextKeyIngredient();
            i.ingredientsStatus = true;

            if (Global.proxy.hasDoubleIngredient(i.ingredientName))
            {
                MessageBox.Show("מרכיב זה כבר קיים");
                myPopup1.IsOpen = false;

                //לעשות שהמרכיב שכתבו יהיה הנבחר
            }
            else
            {
                Global.proxy.AddNewIngredients(i);
                listBox.SelectedItems.Clear();
                addNewIngredientsTextBox.Text = "שם מרכיב אחר";
                myPopup1.IsOpen = false;
                List<RecipesBookService.Ingredients> lsting = Global.proxy.GetAllIngredients();
                ingredientsNameComboBox.ItemsSource = lsting;
                var ingredientToSelect = lsting.FirstOrDefault(j => j.ingredientName == i.ingredientName);
                if (ingredientToSelect != null)
                {
                    ingredientsNameComboBox.SelectedItem = ingredientToSelect;
                }

            }
            myPopup1.IsOpen = false;
        }
        private void CanceladdNewIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            listBox.SelectedItems.Clear();
            myPopup1.IsOpen = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  ListBox אלרגנים במרכיב
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                string selectedValue = listBox.SelectedItem.ToString();

                {
                    if (selectedValue == "מכיל ביצים")
                        i.containsEggs = true;
                    if (selectedValue == "מכיל גלוטן")
                        i.containsGluten = true;
                    if (selectedValue == "מכיל חלב")
                        i.containsMilk = true;
                    if (selectedValue == "מכיל אגוזים")
                        i.containsNuts = true;
                    if (selectedValue == "מכיל שומשום")
                        i.containsSesame = true;
                    if (selectedValue == "מכיל סויה")
                        i.containsSoy = true;
                    if (selectedValue == "מכיל סוכר")
                        i.containsSuger = true;
                }
            }
        }

        private void ingredientsNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ingredientsNameComboBox.SelectedItem != null)
            {
                int code = ((RecipesBookService.Ingredients)ingredientsNameComboBox.SelectedItem).ingredientsCode;
                if (code == 0 && usedPopup)
                    OpenPopup2();
                if (code == 0 && usedPopup == false)
                    OpenPopup1();

            }
        }


        //popup יחידות
        private void OpenPopup4()
        { myPopup3.IsOpen = true; }
        private void OpenPopup3()
        {
            usedPopup1 = true;
            // Create a new instance of the Popup
            myPopup3 = new Popup();

            //  Create an instance of the UserControl with the parameter

            Border border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Background = Brushes.White,
                Width = 300,
                Height = 300
            };
            myPopup3.Child = border;

            StackPanel sp2 = new StackPanel();
            sp2.Name = "sp2";
            Grid.SetRow(sp2, 2);
            Grid.SetRowSpan(sp2, 1);
            Grid.SetColumn(sp2, 3);
            Grid.SetColumnSpan(sp2, 1);
            sp2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDED5BF"));

            // TextBox
            addNewYechidaTextBox.Name = "addNewYechidutTextBox";
            addNewYechidaTextBox.Text = "שם יחידה חדשה";
            addNewYechidaTextBox.LostFocus += addNewYechidutTextBox_LostFocus;
            addNewYechidaTextBox.PreviewMouseDown += addNewYechidutTextBox_PreviewMouseDown;
            //addNewIngredientsTextBox.Background = System.Windows.Media.Brushes.#FFDED5BF;
            //addNewIngredientsTextBox.Foreground = System.Windows.Media.Brushes.#FF7A4928;
            sp2.Children.Add(addNewYechidaTextBox);

            // Button
            addNewYechidaButton.Click += addNewYechidaButton_Click;
            addNewYechidaButton.Name = "addNewYechidaButton";
            addNewYechidaButton.Content = "הוסף יחידה";
            // Add button properties, event handlers, etc. if needed
            sp2.Children.Add(addNewYechidaButton);

            //cancel button
            CanceladdNewYechidaButton.Click += CanceladdNewYechidaButton_Click;
            CanceladdNewYechidaButton.Name = "CanceladdNewYechidaButton";
            CanceladdNewYechidaButton.Content = "בטל";
            sp2.Children.Add(CanceladdNewYechidaButton);
            border.Child = sp2;

            double centerX = ActualWidth / 1.75;
            double centerY = ActualHeight / 3.5;

            // Set the position of the popup
            myPopup3.HorizontalOffset = centerX - (border.ActualWidth / 2);
            myPopup3.VerticalOffset = centerY - (border.ActualHeight / 2);



            // Open the Popup
            myPopup3.IsOpen = true;
        }

        private void addNewYechidutTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addNewIngredientsTextBox.Text == "")
                addNewIngredientsTextBox.Text = "שם יחידה חדשה";
        }

        private void addNewYechidutTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (addNewIngredientsTextBox.Text == "שם יחידה חדשה")
                addNewIngredientsTextBox.Text = "";
        }


        private void addNewYechidaButton_Click(object sender, RoutedEventArgs e)
        {
            y.nameYechidot = addNewYechidaTextBox.Text;
            y.codeYechidot = Global.proxy.GetNextKeyYechidot();
            y.statusYechidot = true;
            //
            if (Global.proxy.hasDoubleYechidot(y))
            {
                MessageBox.Show("יחידה זו כבר קימת");
                myPopup3.IsOpen = false;
            }
            Global.proxy.AddNewYechidot(y);
            addNewYechidaTextBox.Text = "שם יחידה חדשה";
            myPopup3.IsOpen = false;
            List<RecipesBookService.Yechidot> lsting = Global.proxy.GetAllYechidot();
            ingredientsUnitComboBox.ItemsSource = lsting;
            var unitToSelect = lsting.FirstOrDefault(j => j.nameYechidot == y.nameYechidot);
            if (unitToSelect != null)
            {
                ingredientsUnitComboBox.SelectedItem = unitToSelect;
            }
        
            myPopup3.IsOpen = false;
        }

        private void CanceladdNewYechidaButton_Click(object sender, RoutedEventArgs e)
        {
          
            myPopup3.IsOpen = false;
        }
        private void ingredientsUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ingredientsUnitComboBox.SelectedItem != null)
            {
                int code = ((RecipesBookService.Yechidot)ingredientsUnitComboBox.SelectedItem).codeYechidot;
                if (code == 0 && usedPopup1)
                    OpenPopup4();
                if (code == 0 && usedPopup1 == false)
                    OpenPopup3();

            }
        }

        private void eraseIngredientsButton_Click(object sender, RoutedEventArgs e)
        {if (ingredientsNameComboBox.SelectedItem == null)
                MessageBox.Show("לא נבחר מרכיב");
            else
            {


                RecipesBookService.Ingredients i = ((RecipesBookService.Ingredients)ingredientsNameComboBox.SelectedItem);
                RecipesBookService.RecipeIngredient ri = Global.proxy.GetAllRecipeIngredient().FirstOrDefault(x => x.ingredientCode.ingredientsCode == i.ingredientsCode && x.recipeCode.recipeCode == currentRecipe.recipeCode);
                if (ri != null)
                {
                    MessageBoxResult result = MessageBox.Show("למחוק?", "מחיקה", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        Global.proxy.DeleteCompletelyRecipeIngredient(ri);
                        ri = lst.Find(x => x.recipeIngredientCode == ri.recipeIngredientCode);
                        lst.Remove(ri);

                        lstri = Global.proxy.GetAllRecipeIngredientByRecipe(currentRecipe);

                        StackPanel2.Children.Clear();
                        foreach (var x in lstri)
                        {
                            //אם כן הוסף אז מעדכן אותו לפי מה שהוסיפו עכשיו


                            Button y1 = new Button();
                            y1.Tag = x.recipeIngredientCode;
                            y1.Click += buttonYClick;
                            y1.Content = x.ingredientamount + "_" + x.codeYechidot.nameYechidot + "_" + x.ingredientCode.ingredientName;
                            StackPanel2.Children.Add(y1);

                        }
                    }
                }
            }
        }

        private void ingredientsAmountDoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ingredientsAmountDoubleUpDown.ToolTip = null;

            ingredientsAmountDoubleUpDown.BorderBrush = new SolidColorBrush(Global.colorDarkBrown);
        }
    }
}
