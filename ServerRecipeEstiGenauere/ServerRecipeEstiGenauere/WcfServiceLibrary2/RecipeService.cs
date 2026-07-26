using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Model;
using ViewModal;
using System.IO;

namespace WcfServiceLibrary2
{
    public class RecipeService : IRecipeService 
    {
        //###########################################################################################################
        //Folder פעולות של try again

        public void AddNewFolder(Folder a)
        { //מוסיף סוג חדש  Folder

            MyDB.folderlist.Add(a);
            MyDB.folderlist.SaveChanges();
        }

        public void DeleteCompletelyFolder(Folder a)
        {// מוחק תיקיה לגמרי
            Folder a1 = MyDB.folderlist.GetFolderByCode(a.folderCode);
            MyDB.folderlist.Delete(a1);
            MyDB.folderlist.SaveChanges();
        }

        public Folder FindFolder(int code)
        {// מוצא תיקיה לפי קוד
            Folder a = MyDB.folderlist.GetFolderByCode(code);
            return a;
        }

        public List<Folder> GetAllFolder()
        {
            //רשימה של כל התיקיות
            List<Folder> lst = MyDB.folderlist.GetList().ToList();
            return lst;
        }

        public List<Folder> GetAllFolderThatHasFavoriteRecipes(WebUser u)
        {//רשימה של כל התיקיות
           
            List<Folder> lst = new List<Folder>();
            List<FavoriteRecipes> lstfr = GetAllFavoriteRecipes().Where(x => x.userCode.userCode == u.userCode&&x.recipeCode.recipeStatus==true).ToList();
            foreach (var x in lstfr)
                lst.Add(x.recipeCode.folderCode);    
           lst =lst.GroupBy(item => item.folderCode)
             .Select(group => group.First()) // Select the first item from each group
         .ToList();
            return lst;
        }

        public List<Folder> GetAllFolderswithmyRecipes(WebUser u)
        {//רשימה של כל התיקיות

            List<Folder> lst = new List<Folder>();
            List<Recipes> lstfr = GetAllRecipes().Where(x => x.userCode.userCode == u.userCode).ToList();
            foreach (var x in lstfr)
                lst.Add(x.folderCode);
           

            lst = lst.GroupBy(item => item.folderCode)
         .Select(group => group.First()) // Select the first item from each group
         .ToList();
            return lst;
        }

        public void UpdateFolder(Folder a)
        {// מעדכן תיקיה
            Folder a1 = MyDB.folderlist.GetFolderByCode(a.folderCode);
            a1.folderCode = a.folderCode;
            a1.folderName = a.folderName;
            MyDB.folderlist.Update(a1);
            MyDB.folderlist.SaveChanges();

        }

        public bool CheckIfFolderHasNewMessage(Folder f,WebUser u)
        {// בודק אם לתיקיה יש הודעה חדשה
            List<Recipes> r = GetRecipesByFolder(f);
            foreach (Recipes x in r)
            {
                if (RecipeHasNewMessage(x,u) == true)
                { return true;
                }
            }
            return false;
        }

        public int GetNextKeyFolder()
        { // מקבל קוד הבא לתיקיה
            return MyDB.folderlist.GetNextKey();
        }

        public bool hasDoublefolder(string s)
        {
            Folder i2 = MyDB.folderlist.GetList().FirstOrDefault(X => X.folderName == s);
            if (i2 != null)
                return true;
            return false;
        }


        //###########################################################################################################
        //FavoriteRecipes פעולות של try again

        public int GetNextKeyFavoriteRecipes()
        {//מקבל קוד הבא למתכון מועדף
            return (MyDB.favRecipeslist.GetNextKey());
        }

        public void AddNewFavoriteRecipes(FavoriteRecipes a)
        { //מוסיף סוג חדש  FavoriteRecipes

            MyDB.favRecipeslist.Add(a);
            MyDB.favRecipeslist.SaveChanges();
        }

        public FavoriteRecipes favRecipeForUser(Recipes r, WebUser w)
        {//מחזיר מתכון כמועדף  של משתמש זה
            return (MyDB.favRecipeslist.GetList().FirstOrDefault(x => x.userCode.userCode == w.userCode && x.recipeCode.recipeCode == r.recipeCode&&x.recipeCode.recipeStatus==true));
        }


        public void DeleteCompletelyFavoriteRecipes(FavoriteRecipes a)
        {//מוחק לגמרי מתכון מועדף
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            MyDB.favRecipeslist.Delete(a1);
            MyDB.favRecipeslist.SaveChanges();
        }

        public void DeletePartiallyFavoriteRecipes(FavoriteRecipes a)
        {
            //מוחק חלקית מתכון מועדף
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            a1.favRecipeStatus = false;
            MyDB.favRecipeslist.Update(a1);
            MyDB.favRecipeslist.SaveChanges();
        }

        public FavoriteRecipes FindFavoriteRecipes(int code)
        {// מוצא מתכון מועדף עפ"י קוד
            FavoriteRecipes a = MyDB.favRecipeslist.GetFavoriteRecipesByCode(code);
            return a;
        }

        public List<FavoriteRecipes> GetAllFavoriteRecipes()
        {
            //רשימה של המתכונים המועדפים
            List<FavoriteRecipes> lst = MyDB.favRecipeslist.GetList().Where(x => x.favRecipeStatus == true&&x.recipeCode.recipeStatus==true).ToList();
            return lst;
        }

        public void UpdateFavoriteRecipes(FavoriteRecipes a)
        {// מעדכן מתכון מועדף
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            a1.favRecipeCode = a.favRecipeCode;
            a1.userCode = a.userCode;
            a1.recipeCode = a.recipeCode;
            MyDB.favRecipeslist.Update(a1);
            MyDB.favRecipeslist.SaveChanges();

        }


        /// <summary>
        /// /////////////////////////#######################################################
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<Recipes> GetMyFavRecipes(WebUser u)
        { //מחזיר רשימה של מתכונים מועדפים עפי  משתמש
            List<Recipes> lst1 = new List<Recipes>();
            List<FavoriteRecipes> lst = MyDB.favRecipeslist.GetList().Where(x => x.favRecipeStatus == true && x.userCode.userCode == u.userCode&&x.recipeCode.recipeStatus==true).ToList();
            foreach (FavoriteRecipes f in lst)
            { lst1.Add(f.recipeCode); }

            return lst1;

        }

        public bool isFavRecipe(Recipes a, WebUser u)
        {
            if (GetAllFavoriteRecipes().FirstOrDefault(x => x.recipeCode.recipeCode == a.recipeCode && x.userCode.userCode == u.userCode&&x.recipeCode.recipeStatus==true) != null)
                return true;
            return false;
        }


        


        //###########################################################################################################
        //Ingredients פעולות של 

        public int GetNextKeyIngredient()
        { //מקבל קוד הבא למרכיב
            return (MyDB.ingredientslist.GetNextKey());
        }
        public void AddNewIngredients(Ingredients a)
        {
            //מוסיף מרכיב  Ingredients

            MyDB.ingredientslist.Add(a);
            MyDB.ingredientslist.SaveChanges();
        }

        public void DeleteCompletelyIngredients(Ingredients a)
        {
            //מוחק מרכיב לגמרי Ingredients
            Ingredients a1 = MyDB.ingredientslist.GetIngredientsByCode(a.ingredientsCode);
            MyDB.ingredientslist.Delete(a1);
            MyDB.ingredientslist.SaveChanges();
        }

        public void DeletePartiallyIngredients(Ingredients a)
        {
            //מוחק מרכיב חלקי Ingredients
            Ingredients a1 = MyDB.ingredientslist.GetIngredientsByCode(a.ingredientsCode);
            a1.ingredientsStatus = false;
            MyDB.ingredientslist.Update(a1);
            MyDB.ingredientslist.SaveChanges();
        }

        public Ingredients FindIngredients(int code)
        {
            //מוצא מרכיב Ingredients
            Ingredients a = MyDB.ingredientslist.GetIngredientsByCode(code);
            return a;
        }

        public bool hasDoubleIngredient(string i)
        {//בודק אם כבר קיים המרכיב
            Ingredients i2 = MyDB.ingredientslist.GetList().FirstOrDefault(X => X.ingredientName == i && X.ingredientsStatus);
            if (i2 != null)
                return true;
                    return false;
        }

        public List<Ingredients> GetAllIngredients()
        {
            //רשימה של כל המרכיבים Ingredients
            List<Ingredients> lst = MyDB.ingredientslist.GetList().Where(x => x.ingredientsStatus == true&&x.ingredientsCode==0).ToList();
            List<Ingredients> lst1 = MyDB.ingredientslist.GetList().Where(x => x.ingredientsStatus == true && x.ingredientsCode != 0).OrderBy(x=>x.ingredientName).ToList();
            lst.AddRange(lst1);
            return lst;
        }

        public void UpdateIngredients(Ingredients a)
        {
            //מעדכן מרכיב
            Ingredients a1 = MyDB.ingredientslist.GetIngredientsByCode(a.ingredientsCode);
            a1.ingredientsCode = a.ingredientsCode;
            a1.ingredientName = a.ingredientName;
            a1.containsEggs = a.containsEggs;
            a1.containsGluten = a.containsGluten;
            a1.containsMilk = a.containsMilk;
            a1.containsNuts = a.containsNuts;
            a1.containsSesame = a.containsSesame;
            a1.containsSoy = a.containsSoy;
            a1.containsSuger = a.containsSuger;
            MyDB.ingredientslist.Update(a1);
            MyDB.ingredientslist.SaveChanges();

        }

        //###########################################################################################################
        //RecipeIngredient פעולות של 

        public void AddNewRecipeIngredient(RecipeIngredient a)
        {
            //  מוסיף מרכיב מתכון  RecipeIngredient 

            MyDB.recipeIngredientlist.Add(a);
            MyDB.recipeIngredientlist.SaveChanges();

        }

        public void DeleteCompletelyRecipeIngredient(RecipeIngredient a)
        {
            //מוחק מרכיב  מתכון לגמרי RecipeIngredient
            RecipeIngredient a1 = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(a.recipeIngredientCode);
            MyDB.recipeIngredientlist.Delete(a1);
            MyDB.recipeIngredientlist.SaveChanges();
        }

        public void DeletePartiallyRecipeIngredient(RecipeIngredient a)
        {
            //מוחק מרכיב מתכון  חלקי RecipeIngredient
            RecipeIngredient a1 = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(a.recipeIngredientCode);
            a1.recipeIngredientStatus = false;
            MyDB.recipeIngredientlist.Update(a1);
            MyDB.recipeIngredientlist.SaveChanges();
        }

        public RecipeIngredient FindRecipeIngredient(int code)
        {
            //מוצא מרכיב RecipeIngredient
            RecipeIngredient a = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(code);
            return a;
        }

        public List<RecipeIngredient> GetAllRecipeIngredient()
        {
            //רשימה של כל המרכיבים RecipeIngredient
            List<RecipeIngredient> lst = MyDB.recipeIngredientlist.GetList().Where(x => x.recipeIngredientStatus == true).ToList();
            return lst;
        }

        public void UpdateRecipeIngredient(RecipeIngredient a)
        {
            //RecipeIngredient מעדכן
            RecipeIngredient a1 = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(a.recipeIngredientCode);
            a1.recipeIngredientCode = a.recipeIngredientCode;
            a1.ingredientCode = a.ingredientCode;
            a1.ingredientamount = a.ingredientamount;
            a1.codeYechidot = a.codeYechidot;
            MyDB.recipeIngredientlist.Update(a1);
            MyDB.recipeIngredientlist.SaveChanges();
        }

        public int RatingForRecipe(Recipes r)
        {
            double x1;
            List<Rating> rr = GetAllRating().Where(X => X.recipeCode.recipeCode == r.recipeCode).ToList();
            if (rr.Count == 0)
                return 0;
            double sum = 0;
            foreach (var y in rr)
            { sum =sum+y.rateValue; }
            x1 = sum / rr.Count;
            return ((int)Math.Round(x1));
        }


        public int GetNextKeyRecipeIngredient()
        {//מקבל קוד הבא למרכיב מתכון
            return (MyDB.recipeIngredientlist.GetNextKey());

        }



        public List<RecipeIngredient> GetAllRecipeIngredientByRecipe(Recipes r)
        {//מחזיר את כל המרכיבי מתכון של המתכון הנוכח
            return GetAllRecipeIngredient().Where(x => x.recipeCode.recipeCode == r.recipeCode && x.recipeIngredientStatus).ToList();

        }





        //###########################################################################################################
        //RecipeMessages פעולות של 

        public void AddNewRecipeMessages(RecipeMessages a)
        {
            //מוסיף הודעה  RecipeMessages

            MyDB.recipeMessageslist.Add(a);
            MyDB.recipeMessageslist.SaveChanges();

        }


        public void DeleteCompletelyRecipeMessages(RecipeMessages a)
        {
            //מוחק מרכיב לגמרי RecipeMessages
            RecipeMessages a1 = MyDB.recipeMessageslist.GetRecipeMessagesByCode(a.messageCode);
            MyDB.recipeMessageslist.Delete(a1);
            MyDB.recipeMessageslist.SaveChanges();
        }



        public RecipeMessages FindRecipeMessages(int code)
        {
            //מוצא הודעה RecipeMessages
            RecipeMessages a = MyDB.recipeMessageslist.GetRecipeMessagesByCode(code);
            return a;
        }

        public List<RecipeMessages> GetAllRecipeMessages()
        {
            //רשימה של כל ההודעות RecipeMessages
            List<RecipeMessages> lst = MyDB.recipeMessageslist.GetList().ToList();
            return lst;
        }

        public void UpdateRecipeMessages(RecipeMessages a)
        {
            //RecipeMessages מעדכן
            RecipeMessages a1 = MyDB.recipeMessageslist.GetRecipeMessagesByCode(a.messageCode);
            a1.messageStatus = a.messageStatus;
            a1.messageCode = a.messageCode;
            a1.recipeCode = a.recipeCode;
           
            a1.messagesText = a.messagesText;
            a1.userCode = a.userCode;
            
            MyDB.recipeMessageslist.Update(a1);
            MyDB.recipeMessageslist.SaveChanges();

        }

        public int GetNextKeyRecipeMessages()
        {//מביא קוד הבא להודעה
            return (MyDB.recipeMessageslist.GetNextKey());

        }



        //public List<Folder> GetAllFlodersWithNewMessage(WebUser u)
        //{ //מחזיר את כל התיקיות שיש בהם מתכונים עם הודעות חדשות

        //    List<Folder> lstf = new List<Folder>();

        //}

     




        //###########################################################################################################
        //Recipes פעולות של 

        public void AddNewRecipes(Recipes a)
        {
            //מוסיף הודעה  Recipes

            MyDB.recipeslist.Add(a);
            MyDB.recipeslist.SaveChanges();

        }

        public void DeleteCompletelyRecipes(Recipes a)
        {
            //מוחק מתכון לגמרי Recipes
            Recipes a1 = MyDB.recipeslist.GetRecipesByCode(a.recipeCode);
            MyDB.recipeslist.Delete(a1);
            MyDB.recipeslist.SaveChanges();
        }

        public void DeletePartiallyRecipes(Recipes a)
        {
            //מוחק מרכיב חלקי Recipes
            Recipes a1 = MyDB.recipeslist.GetRecipesByCode(a.recipeCode);
            a1.recipeStatus = false;
            MyDB.recipeslist.Update(a1);
            MyDB.recipeslist.SaveChanges();
        }

        public Recipes FindRecipes(int code)
        {
            //מוצא מתכון Recipes
            Recipes a = MyDB.recipeslist.GetRecipesByCode(code);
            return a;
        }

        public List<Recipes> GetAllRecipes()
        {
            //רשימה של כל המתכונים Recipes
            List<Recipes> lst = MyDB.recipeslist.GetList().Where(x => x.recipeStatus == true).OrderBy(x=>x.recipeName).ToList();
            return lst;
        }

        public void UpdateRecipes(Recipes a)
        {
            //Recipes מעדכן
            Recipes a1 = MyDB.recipeslist.GetRecipesByCode(a.recipeCode);
            a1.recipeCode = a.recipeCode;
            a1.recipeComments = a.recipeComments;
            a1.recipeDifficulty = a.recipeDifficulty;
            a1.recipeName = a.recipeName;
            a1.recipePicture = a.recipePicture;
            a1.recipePreparation = a.recipePreparation;
            a1.recipePreparationTime = a.recipePreparationTime;
            a1.recipeSarvingAmount = a.recipeSarvingAmount;
            a1.folderCode = a.folderCode;
            a1.recipeStatus = a.recipeStatus;
            a1.recipeDescription = a.recipeDescription;
            a1.recipeNotes = a.recipeNotes;

            MyDB.recipeMessageslist.Update(a1);
            MyDB.recipeMessageslist.SaveChanges();

        }

        public List<Recipes> GetRecipesByFolder(Folder f)
        {
            //רשימה של מתכונים לפי תיקיה  Recipes
            List<Recipes> lst = MyDB.recipeslist.GetList().Where(x => x.recipeStatus == true && x.folderCode.folderCode == f.folderCode).ToList();
            return lst;
        }

        public bool RecipeHasNewMessage(Recipes a,WebUser u)
        {
            // בודק אם יש למתכון הודעה חדשה
            RecipeMessages lrm = GetAllRecipeMessages().FirstOrDefault(x => x.recipeCode.recipeCode == a.recipeCode && x.messageStatus == true&& u.userCode==x.recipeCode.userCode.userCode && x.userCode.userCode!=u.userCode);

            if (lrm != null)
                return true;

            return false;
        }

        public List<Recipes> GetAllRecipeNewMessage(WebUser u)
        {
            //מחזיר רשימה של מתכונים שלי שיש להם הודעה חדשה
            List<Recipes> lst = GetAllRecipes().Where(x => x.userCode.userCode == u.userCode).ToList();
            List<Recipes> lst1 = new List<Recipes>();
            foreach (Recipes r in lst)
            { if (RecipeHasNewMessage(r,u))
                    lst1.Add(r);
            }
            return lst1;

        }

        public List<Recipes> GetAllRecipeNewMessageByFolder(WebUser u, Folder f)
        {
            //מחזיר רשימה של מתכונים שלי עם הודעות לפי תיקיה

            return GetAllRecipeNewMessage(u).Where(x => x.userCode.userCode == u.userCode).ToList();

        }


        public List<Recipes> GetAllMyRecipe(WebUser u)

        {
            //מחזיר רשימה של מתכונים של המשתמש
            return GetAllRecipes().Where(x => x.userCode.userCode == u.userCode).ToList();

        }


        public List<Recipes> GetAllMyRecipesByFolder(WebUser u, Folder f)
        {
            //מחזיר רשימה של מתכונים של המשתמש בתיקיה זו


            return GetAllRecipes().Where(x =>x.userCode.userCode == u.userCode  && x.folderCode.folderCode == f.folderCode).ToList();

        }

       
        public List<Recipes> GetAllMyFavRecipesByFolder(WebUser u, Folder f)
        {
            //מחזיר רשימה של מתכונים מועדפים של המשתמש בתיקיה זו


            return GetMyFavRecipes(u).Where(x => x.folderCode.folderCode == f.folderCode).ToList();

           
        }






        public bool HasDoubleName(string name)
        {
            if (GetAllRecipes().FirstOrDefault(X => X.recipeName == name) == null)
                return false;
            return true;

        }

        public int GetNextKeyRecipes()
        {//מקבל קוד הבא למתכון
            return (MyDB.recipeslist.GetNextKey());
        }


        public List<RecipeMessages> GetMessagesByRecipe(Recipes r)
        { //מחזיר רשימה של כל ההודעות הקשורות למתכון הנוכחי

            return (MyDB.recipeMessageslist.GetList().Where(x => x.recipeCode.recipeCode == r.recipeCode).OrderBy(x => x.messageCode).ToList());

        }

        public List<RecipeIngredient> GetIngredientsByRecipe(Recipes r)
        { //מחזיר רשימה של כל המרכיבים הקשורות למתכון הנוכחי

            return (MyDB.recipeIngredientlist.GetList().Where(x => x.recipeCode.recipeCode == r.recipeCode).OrderBy(x => x.recipeIngredientCode).ToList());

        }





        //גלוטן!!!!!!!!!!!!!!!!
        public List<Recipes> GetAllRecipesWithoutGluten(List<Recipes> lstall)
        {//
            List<Recipes> lst=new List<Recipes>() ;
            
            foreach(var x in lstall)
            { bool bad = false;
               List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
               foreach(var y in lstri)
                { if (ingredientsWithGlutan().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;
                            
               }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }

        public List<Ingredients> ingredientsWithGlutan()
        {//מוצא את כל המרכיבים המכילים גלוטן

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            { if (x.containsGluten == true)
                    lst.Add(x);
            }
            return lst;
        }


        //שומשום!!!!!!!!!!!!!!!!


        public List<Recipes> GetAllRecipesWithoutSesame(List<Recipes> lstall)
        {//
            List<Recipes> lst = new List<Recipes>();
            
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithSesame().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }




        public List<Ingredients> ingredientsWithSesame()
        {//מוצא את כל המרכיבים המכילים שומשום

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsSesame == true)
                    lst.Add(x);
            }
            return lst;
        }



        //חלב!!!!!!!!!!!!!!!!


        public List<Recipes> GetAllRecipesWithoutMilk(List<Recipes> lstall)
        {//
            List<Recipes> lst = new List<Recipes>();
           
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithMilk().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }








        public List<Ingredients> ingredientsWithMilk()
        {//מוצא את כל המרכיבים המכילים חלב

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsMilk == true)
                    lst.Add(x);
            }
            return lst;
        }


        //בוטנים ואגוזים!!!!!!!!!!!!!!!!



        public List<Recipes> GetAllRecipesWithoutNuts(List<Recipes> lstall)
        {//
            List<Recipes> lst = new List<Recipes>();
            
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithNuts().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }






        public List<Ingredients> ingredientsWithNuts()
        {//מוצא את כל המרכיבים המכילים בוטנים ואגוזים

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsNuts == true)
                    lst.Add(x);
            }
            return lst;
        }




        //סוכר!!!!!!!!!!!!!!!!


        public List<Recipes> GetAllRecipesWithoutSugar(List<Recipes> lstall)
        {//
            List<Recipes> lst = new List<Recipes>();
          
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithSugar().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }







        public List<Ingredients> ingredientsWithSugar()
        {//מוצא את כל המרכיבים המכילים סוכר

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsSuger == true)
                    lst.Add(x);
            }
            return lst;
        }


        //סויה!!!!!!!!!!!!!!!!



        public List<Recipes> GetAllRecipesWithoutSoy(List<Recipes> lstall)
        {//
            List<Recipes> lst = new List<Recipes>();
            
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithSoy().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }







        public List<Ingredients> ingredientsWithSoy()
        {//מוצא את כל המרכיבים המכילים סויה

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsSoy == true)
                    lst.Add(x);
            }
            return lst;
        }


        //ביצים!!!!!!!!!!!!!!!!

        public List<Recipes> GetAllRecipesWithoutEggs(List<Recipes> lstall) 
        {//
            List<Recipes> lst = new List<Recipes>();
          
            foreach (var x in lstall)
            {
                bool bad = false;
                List<RecipeIngredient> lstri = GetIngredientsByRecipe(x);
                foreach (var y in lstri)
                {
                    if (ingredientsWithEggs().FirstOrDefault(w => w.ingredientsCode == y.ingredientCode.ingredientsCode) != null)
                        bad = true;

                }
                if (bad == false)
                    lst.Add(x);
            }
            return lst;
        }

        public List<Ingredients> ingredientsWithEggs()
        {//מוצא את כל המרכיבים המכילים ביצים

            List<Ingredients> lst = new List<Ingredients>();
            List<Ingredients> lstall = GetAllIngredients();
            foreach (var x in lstall)
            {
                if (x.containsEggs == true)
                    lst.Add(x);
            }
            return lst;
        }




        //###########################################################################################################


        //WebUser פעולות של 


        public WebUser FindUserByEmail(string email)
        {// מוצא משתמש לפי דוא"ל
            WebUser a = MyDB.userlist.GetList().FirstOrDefault(x => x.userEmail == email && x.userStatus == true);
            return a;
        }

        public int GetNextKeyUsers()
        {//מקבל קוד הבא למשתמש
            return (MyDB.userlist.GetNextKey());
        }




        public bool CheckUsers(string userEmail, string userPasscode)
        {
            // בודק אם המייל והסיסמה מתאימים
            WebUser a = MyDB.userlist.GetList().FirstOrDefault(x => x.userEmail == userEmail && x.userStatus == true && x.userPasscode == userPasscode);
            if (a == null)
                return false;
            return true;
        }

        public void AddNewUsers(WebUser a)
        {
            //מוסיף הודעה  WebUser

            MyDB.userlist.Add(a);
            MyDB.userlist.SaveChanges();

        }

        public void DeleteCompletelyUsers(WebUser a)
        {
            //מוחק משתמש לגמרי WebUser
            WebUser a1 = MyDB.userlist.GetUserByCode(a.userCode);
            MyDB.userlist.Delete(a1);
            MyDB.userlist.SaveChanges();
        }

        public void DeletePartiallyUsers(WebUser a)
        {
            //מוחק משתמש חלקי WebUser
            WebUser a1 = MyDB.userlist.GetUserByCode(a.userCode);
            a1.userStatus = false;
            MyDB.userlist.Update(a1);
            MyDB.userlist.SaveChanges();
        }

        public WebUser FindUsers(int code)
        {
            //מוצא משתמש WebUser
            WebUser a = MyDB.userlist.GetUserByCode(code);
            return a;
        }

        public List<WebUser> GetAllUsers()
        {
            //רשימה של כל המשתמשים WebUser
            List<WebUser> lst = MyDB.userlist.GetList().Where(x => x.userStatus == true).ToList();
            return lst;
        }

        public void UpdateUsers(WebUser a)
        {
            //WebUser מעדכן
            WebUser a1 = MyDB.userlist.GetUserByCode(a.userCode);
            a1.userCode = a.userCode;
            a1.userEmail = a.userEmail;
            a1.userName = a.userName;
            a1.userPasscode = a.userPasscode;
            a1.userStatus = a.userStatus;
            MyDB.userlist.Update(a1);
            MyDB.userlist.SaveChanges();

        }



        //###########################################################################################################


        //Yechidot פעולות של 



        public int GetNextKeyYechidot()
        {//מקבל קוד הבא למשתמש
            return (MyDB.yechidotlist.GetNextKey());
        }

        public void AddNewYechidot(Yechidot a)
        {
            //מוסיף יחידות  Yechidot

            MyDB.yechidotlist.Add(a);
            MyDB.yechidotlist.SaveChanges();

        }

        public void DeleteCompletelyYechidot(Yechidot a)
        {
            //מוחק מתכון לגמרי Yechidot
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            MyDB.yechidotlist.Delete(a1);
            MyDB.yechidotlist.SaveChanges();
        }

        public void DeletePartiallyYechidot(Yechidot a)
        {
            //מוחק מרכיב חלקי Yechidot
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            a1.statusYechidot = false;
            MyDB.yechidotlist.Update(a1);
            MyDB.yechidotlist.SaveChanges();
        }

        public Yechidot FindYechidot(int code)
        {
            //מוצא הודעה Yechidot
            Yechidot a = MyDB.yechidotlist.GetYechidotByCode(code);
            return a;
        }

        public List<Yechidot> GetAllYechidot()
        {
            //רשימה של כל המרכיבים Yechidot
            
            List<Yechidot> lst = MyDB.yechidotlist.GetList().Where(x => x.statusYechidot == true && x.codeYechidot == 0).ToList();
            List<Yechidot> lst1 = MyDB.yechidotlist.GetList().Where(x => x.statusYechidot == true && x.codeYechidot != 0).OrderBy(x => x.nameYechidot).ToList();
            lst.AddRange(lst1);
            return lst;
        }

        public void UpdateYechidot(Yechidot a)
        {
            //Yechidot מעדכן
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            a1.codeYechidot = a.codeYechidot;
            a1.nameYechidot = a.nameYechidot;
            a1.statusYechidot = a.statusYechidot;
            MyDB.userlist.Update(a1);
            MyDB.userlist.SaveChanges();

        }


        public bool hasDoubleYechidot(Yechidot i)
        {//בודק אם כבר קיים המרכיב
            Yechidot i2 = MyDB.yechidotlist.GetList().FirstOrDefault(X => X.nameYechidot == i.nameYechidot && X.statusYechidot);
            if (i2 != null)
                return true;
            return false;
        }




        //###########################################################################################################
        //Rating

        public int GetNextKeyRating()
        {//מקבל קוד הבא לדירוג
            return (MyDB.ratinglist.GetNextKey());
        }
        
        public void AddNewRating(Rating a)
        {// מוסיף דירוג חדש
            MyDB.ratinglist.Add(a);
            MyDB.ratinglist.SaveChanges();
        }

        public void UpdateRating(Rating a)
        {// מעדכן דירוג
            Rating a1 = MyDB.ratinglist.GetRatingByCode(a.ratingCode);
            a1.rateValue = a.rateValue;
            a1.ratingCode = a.ratingCode;
            a1.ratingStatus = a.ratingStatus;
            a1.recipeCode = a.recipeCode;
            a1.userCode = a.userCode;

            MyDB.ratinglist.Update(a1);
            MyDB.ratinglist.SaveChanges();
        }

        public void DeleteCompletelyRating(Rating a)
        {// מוחק דירוג לגמרי
            Rating a1 = MyDB.ratinglist.GetRatingByCode(a.ratingCode);
            MyDB.ratinglist.Delete(a1);
            MyDB.ratinglist.SaveChanges();
        }

        public Rating FindRating(int code)
        {// מוצא דירוג לפי קוד
            return (MyDB.ratinglist.GetRatingByCode(code));
        }


        public Rating FindRatingByUserName(string name)
        {// מוצא דירוג לפי קוד
            throw new NotImplementedException();

        }

        public Rating RatingRecipeForUser(Recipes r, WebUser w)
        {
            return (MyDB.ratinglist.GetList().FirstOrDefault(x => x.userCode.userCode == w.userCode && x.recipeCode.recipeCode == r.recipeCode));

        }
        public List<Rating> GetAllRating()
        {// מחזיר רשימה של כל הדירוגים 

            return(  MyDB.ratinglist.GetList().Where(x => x.ratingStatus == true).ToList());
            
        }

        public void DeletePartiallyRating(Rating a)
        {// מוחק חלקית דירוג 
            throw new NotImplementedException();
        }

        //###########################################################################################################
        //others-pic 
        public byte[] GetImage(string fileName)
        {//
            string path = BaseDB.GetCurrentPath() + @"ViewModal\Pictures\" + fileName;
            if (File.Exists(path))
                return (File.ReadAllBytes(path));//קורא את כל קובץ התמונה מהמקום שלהוממיר אותה לקובץ ביטים
            return null;
        }
        public void SaveImage(byte[] imageArray, string fileName)
        {//
            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            string path = BaseDB.GetCurrentPath() + @"ViewModal\Pictures\" + fileName;
            img.Save(path);
        }

        //###########################################################################################################

    }

}