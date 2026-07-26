using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModal;

namespace WcfServiceLibrary
{
    public class RecipeService
    {

        //###########################################################################################################
        //FavoriteRecipes פעולות של 

        public void AddNewFavoriteRecipesType(FavoriteRecipes a)
        {
            //מוסיף סוג חדש  FavoriteRecipes

            MyDB.favRecipeslist.Add(a);
            MyDB.favRecipeslist.SaveChanges();

        }


        public void DeleteCompletelyFavoriteRecipesType(FavoriteRecipes a)
        {
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            MyDB.favRecipeslist.Delete(a1);
            MyDB.favRecipeslist.SaveChanges();
        }

        public void DeletePartiallyFavoriteRecipesType(FavoriteRecipes a)
        {
            //מוחק משתמש 
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            a1.favRecipeStatus = false;
            MyDB.favRecipeslist.Update(a1);
            MyDB.favRecipeslist.SaveChanges();
        }

        public FavoriteRecipes FindFavoriteRecipesType(int code)
        {
            FavoriteRecipes a = MyDB.favRecipeslist.GetFavoriteRecipesByCode(code);
            return a;
        }

        public List<FavoriteRecipes> GetAllFavoriteRecipesType()
        {
            //רשימה של כל המשתמשים
            List<FavoriteRecipes> lst = MyDB.favRecipeslist.GetList().Where(x => x.favRecipeStatus == true).ToList();
            return lst;
        }

        public void UpdateFavoriteRecipesType(FavoriteRecipes a)
        {
            FavoriteRecipes a1 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(a.favRecipeCode);
            a1.favRecipeCode = a.favRecipeCode;
            a1.userCode = a.userCode;
            a1.recipeCode = a.recipeCode;
            MyDB.favRecipeslist.Update(a1);
            MyDB.favRecipeslist.SaveChanges();


        }


        //###########################################################################################################
        //Ingredients פעולות של 

        public void AddNewIngredientsType(Ingredients a)
        {
            //מוסיף מרכיב  Ingredients

            MyDB.ingredientslist.Add(a);
            MyDB.ingredientslist.SaveChanges();

        }


        public void DeleteCompletelyIngredientsType(Ingredients a)
        {
            //מוחק מרכיב לגמרי Ingredients
            Ingredients a1 = MyDB.ingredientslist.GetIngredientsByCode(a.ingredientsCode);
            MyDB.ingredientslist.Delete(a1);
            MyDB.ingredientslist.SaveChanges();
        }

        public void DeletePartiallyIngredientsType(Ingredients a)
        {
            //מוחק מרכיב חלקי Ingredients
            Ingredients a1 = MyDB.ingredientslist.GetIngredientsByCode(a.ingredientsCode);
            a1.ingredientsStatus = false;
            MyDB.ingredientslist.Update(a1);
            MyDB.ingredientslist.SaveChanges();
        }

        public Ingredients FindIngredientsType(int code)
        {
            //מוצא מרכיב Ingredients
            Ingredients a = MyDB.ingredientslist.GetIngredientsByCode(code);
            return a;
        }

        public List<Ingredients> GetAllIngredientsType()
        {
            //רשימה של כל המרכיבים Ingredients
            List<Ingredients> lst = MyDB.ingredientslist.GetList().Where(x => x.ingredientsStatus == true).ToList();
            return lst;
        }

        public void UpdateIngredientsType(Ingredients a)
        {
            //
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

        public void AddNewRecipeIngredientType(RecipeIngredient a)
        {
            //מוסיף מרכיב  RecipeIngredient

            MyDB.recipeIngredientlist.Add(a);
            MyDB.recipeIngredientlist.SaveChanges();

        }


        public void DeleteCompletelyRecipeIngredientType(RecipeIngredient a)
        {
            //מוחק מרכיב לגמרי RecipeIngredient
            RecipeIngredient a1 = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(a.recipeIngredientCode);
            MyDB.recipeIngredientlist.Delete(a1);
            MyDB.recipeIngredientlist.SaveChanges();
        }

        public void DeletePartiallyRecipeIngredientType(RecipeIngredient a)
        {
            //מוחק מרכיב חלקי RecipeIngredient
            RecipeIngredient a1 = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(a.recipeIngredientCode);
            a1.recipeIngredientStatus = false;
            MyDB.recipeIngredientlist.Update(a1);
            MyDB.recipeIngredientlist.SaveChanges();
        }

        public RecipeIngredient FindRecipeIngredientType(int code)
        {
            //מוצא מרכיב RecipeIngredient
            RecipeIngredient a = MyDB.recipeIngredientlist.GetRecipeIngredientByCode(code);
            return a;
        }

        public List<RecipeIngredient> GetAllRecipeIngredientType()
        {
            //רשימה של כל המרכיבים RecipeIngredient
            List<RecipeIngredient> lst = MyDB.recipeIngredientlist.GetList().Where(x => x.recipeIngredientStatus == true).ToList();
            return lst;
        }

        public void UpdateRecipeIngredientType(RecipeIngredient a)
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




        //###########################################################################################################
        //RecipeMessages פעולות של 

        public void AddNewRecipeMessagesType(RecipeMessages a)
        {
            //מוסיף הודעה  RecipeMessages

            MyDB.recipeMessageslist.Add(a);
            MyDB.recipeMessageslist.SaveChanges();

        }


        public void DeleteCompletelyRecipeMessagesType(RecipeMessages a)
        {
            //מוחק מרכיב לגמרי RecipeMessages
            RecipeMessages a1 = MyDB.recipeMessageslist.GetRecipeMessagesByCode(a.messageCode);
            MyDB.recipeMessageslist.Delete(a1);
            MyDB.recipeMessageslist.SaveChanges();
        }

        public void DeletePartiallyRecipeMessagesType(RecipeMessages a)
        {
            //מוחק מרכיב חלקי RecipeMessages
            RecipeMessages a1 = MyDB.recipeMessageslist.GetRecipeMessagesByCode(a.messageCode);
            a1.messageStatus = false;
            MyDB.recipeMessageslist.Update(a1);
            MyDB.recipeMessageslist.SaveChanges();
        }

        public RecipeMessages FindRecipeMessagesType(int code)
        {
            //מוצא הודעה RecipeMessages
            RecipeMessages a = MyDB.recipeMessageslist.GetRecipeMessagesByCode(code);
            return a;
        }

        public List<RecipeMessages> GetAllRecipeMessagesType()
        {
            //רשימה של כל המרכיבים RecipeMessages
            List<RecipeMessages> lst = MyDB.recipeMessageslist.GetList().Where(x => x.messageStatus == true).ToList();
            return lst;
        }

        public void UpdateRecipeMessagesType(RecipeMessages a)
        {
            //RecipeMessages מעדכן
            RecipeMessages a1 = MyDB.recipeMessageslist.GetRecipeMessagesByCode(a.messageCode);
            a1.messageCode = a.messageCode;
            a1.recipeCode = a.recipeCode;
            a1.messagesNumber = a.messagesNumber;
            a1.messagesText = a.messagesText;
            a1.messagesPicture = a.messagesPicture;
            a1.userCode = a.userCode;
            MyDB.recipeMessageslist.Update(a1);
            MyDB.recipeMessageslist.SaveChanges();

        }


        //###########################################################################################################
        //Recipes פעולות של 

        public void AddNewRecipesType(Recipes a)
        {
            //מוסיף הודעה  Recipes

            MyDB.recipeslist.Add(a);
            MyDB.recipeslist.SaveChanges();

        }

        public void DeleteCompletelyRecipesType(Recipes a)
        {
            //מוחק מתכון לגמרי Recipes
            Recipes a1 = MyDB.recipeslist.GetRecipesByCode(a.recipeCode);
            MyDB.recipeslist.Delete(a1);
            MyDB.recipeslist.SaveChanges();
        }

        public void DeletePartiallyRecipesType(Recipes a)
        {
            //מוחק מרכיב חלקי Recipes
            Recipes a1 = MyDB.recipeslist.GetRecipesByCode(a.recipeCode);
            a1.recipeStatus = false;
            MyDB.recipeslist.Update(a1);
            MyDB.recipeslist.SaveChanges();
        }

        public Recipes FindRecipesType(int code)
        {
            //מוצא הודעה Recipes
            Recipes a = MyDB.recipeslist.GetRecipesByCode(code);
            return a;
        }

        public List<Recipes> GetAllRecipesType()
        {
            //רשימה של כל המרכיבים Recipes
            List<Recipes> lst = MyDB.recipeslist.GetList().Where(x => x.recipeStatus == true).ToList();
            return lst;
        }

        public void UpdateRecipesType(Recipes a)
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
            a1.recipeStatus = a.recipeStatus;
            MyDB.recipeMessageslist.Update(a1);
            MyDB.recipeMessageslist.SaveChanges();

        }



        //###########################################################################################################


        //WebUser פעולות של 

        public void AddNewWebUserType(WebUser a)
        {
            //מוסיף הודעה  WebUser

            MyDB.userlist.Add(a);
            MyDB.userlist.SaveChanges();

        }

        public void DeleteCompletelyWebUserType(WebUser a)
        {
            //מוחק מתכון לגמרי WebUser
            WebUser a1 = MyDB.userlist.GetUserByCode(a.userCode);
            MyDB.userlist.Delete(a1);
            MyDB.userlist.SaveChanges();
        }

        public void DeletePartiallyWebUserType(WebUser a)
        {
            //מוחק מרכיב חלקי WebUser
            WebUser a1 = MyDB.userlist.GetUserByCode(a.userCode);
            a1.userStatus = false;
            MyDB.userlist.Update(a1);
            MyDB.userlist.SaveChanges();
        }

        public WebUser FindWebUserType(int code)
        {
            //מוצא הודעה WebUser
            WebUser a = MyDB.userlist.GetUserByCode(code);
            return a;
        }

        public List<WebUser> GetAllWebUserType()
        {
            //רשימה של כל המרכיבים WebUser
            List<WebUser> lst = MyDB.userlist.GetList().Where(x => x.userStatus == true).ToList();
            return lst;
        }

        public void UpdateWebUserType(WebUser a)
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

        public void AddNewYechidotType(Yechidot a)
        {
            //מוסיף הודעה  Yechidot

            MyDB.yechidotlist.Add(a);
            MyDB.yechidotlist.SaveChanges();

        }

        public void DeleteCompletelyYechidotType(Yechidot a)
        {
            //מוחק מתכון לגמרי Yechidot
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            MyDB.yechidotlist.Delete(a1);
            MyDB.yechidotlist.SaveChanges();
        }

        public void DeletePartiallyYechidotType(Yechidot a)
        {
            //מוחק מרכיב חלקי Yechidot
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            a1.statusYechidot = false;
            MyDB.yechidotlist.Update(a1);
            MyDB.yechidotlist.SaveChanges();
        }

        public Yechidot FindYechidotType(int code)
        {
            //מוצא הודעה Yechidot
            Yechidot a = MyDB.yechidotlist.GetYechidotByCode(code);
            return a;
        }

        public List<Yechidot> GetAllYechidotType()
        {
            //רשימה של כל המרכיבים Yechidot
            List<Yechidot> lst = MyDB.yechidotlist.GetList().Where(x => x.statusYechidot == true).ToList();
            return lst;
        }

        public void UpdateYechidotType(Yechidot a)
        {
            //Yechidot מעדכן
            Yechidot a1 = MyDB.yechidotlist.GetYechidotByCode(a.codeYechidot);
            a1.codeYechidot = a.codeYechidot;
            a1.nameYechidot = a.nameYechidot;
            a1.statusYechidot = a.statusYechidot;
            MyDB.userlist.Update(a1);
            MyDB.userlist.SaveChanges();

        }



    }
}
