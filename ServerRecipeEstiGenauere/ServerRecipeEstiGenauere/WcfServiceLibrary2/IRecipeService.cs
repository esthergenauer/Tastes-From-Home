using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModal;

namespace WcfServiceLibrary2
{
    [ServiceContract]
    public interface IRecipeService
    {


        //  Folder
        [OperationContract]
        void AddNewFolder(Folder f);
        [OperationContract]
        void UpdateFolder(Folder f);
        [OperationContract]
        void DeleteCompletelyFolder(Folder f);
        [OperationContract]
        Folder FindFolder(int code);
        [OperationContract]
        List<Folder> GetAllFolder();
        [OperationContract]
        List<Folder> GetAllFolderThatHasFavoriteRecipes(WebUser u);
        [OperationContract]
        bool CheckIfFolderHasNewMessage(Folder f,WebUser u);
        [OperationContract]
        int GetNextKeyFolder();
        [OperationContract]
        bool hasDoublefolder(string s );


        //  FavoriteRecipes

        [OperationContract]
        bool isFavRecipe(Recipes a, WebUser u);

        [OperationContract]
        bool hasDoubleIngredient(string i);

        [OperationContract]
        int GetNextKeyFavoriteRecipes();
        [OperationContract]
        FavoriteRecipes favRecipeForUser(Recipes r, WebUser w);

        [OperationContract]
        void AddNewFavoriteRecipes(FavoriteRecipes a);
        [OperationContract]
        void UpdateFavoriteRecipes(FavoriteRecipes a);
        [OperationContract]
        void DeleteCompletelyFavoriteRecipes(FavoriteRecipes a);
        [OperationContract]
        FavoriteRecipes FindFavoriteRecipes(int code);
        [OperationContract]
        List<FavoriteRecipes> GetAllFavoriteRecipes();
        [OperationContract]
        void DeletePartiallyFavoriteRecipes(FavoriteRecipes a);
        [OperationContract]
        List<Recipes> GetMyFavRecipes(WebUser u);
        [OperationContract]
        List<Folder> GetAllFolderswithmyRecipes(WebUser u);

        // Ingredients
        [OperationContract]
        int GetNextKeyIngredient();

       [OperationContract]
        void AddNewIngredients(Ingredients a);
        [OperationContract]
        void UpdateIngredients(Ingredients a);
        [OperationContract]
        void DeleteCompletelyIngredients(Ingredients a);
        [OperationContract]
        Ingredients FindIngredients(int code);
        [OperationContract]
        List<Ingredients> GetAllIngredients();
        [OperationContract]
        void DeletePartiallyIngredients(Ingredients a);



        //Rating

        [OperationContract]
        int GetNextKeyRating();
        [OperationContract]
        void AddNewRating(Rating a);
        [OperationContract]
        void UpdateRating(Rating a);
        [OperationContract]
        void DeleteCompletelyRating(Rating a);
        [OperationContract]
        Rating FindRating(int code);
        [OperationContract]
        List<Rating> GetAllRating();
        [OperationContract]
        void DeletePartiallyRating(Rating a);

        [OperationContract]
        int RatingForRecipe(Recipes r);
        [OperationContract]
        Rating RatingRecipeForUser(Recipes r, WebUser w);


        // RecipeIngredient

        [OperationContract]
        void AddNewRecipeIngredient(RecipeIngredient a);
        [OperationContract]
        void UpdateRecipeIngredient(RecipeIngredient a);
        [OperationContract]
        void DeleteCompletelyRecipeIngredient(RecipeIngredient a);
        [OperationContract]
        RecipeIngredient FindRecipeIngredient(int code);
        [OperationContract]
        List<RecipeIngredient> GetAllRecipeIngredient();
        [OperationContract]
        void DeletePartiallyRecipeIngredient(RecipeIngredient a);
        [OperationContract]
        int GetNextKeyRecipeIngredient();
        [OperationContract]
        List<RecipeIngredient> GetAllRecipeIngredientByRecipe(Recipes r);





        //RecipeMessages

        [OperationContract]
        void AddNewRecipeMessages(RecipeMessages a);
        [OperationContract]
        void UpdateRecipeMessages(RecipeMessages a);
        [OperationContract]
        void DeleteCompletelyRecipeMessages(RecipeMessages a);
        [OperationContract]
        RecipeMessages FindRecipeMessages(int code);
        [OperationContract]
        List<RecipeMessages> GetAllRecipeMessages();
        [OperationContract]
        List<RecipeMessages> GetMessagesByRecipe(Recipes r);
        [OperationContract]
        int GetNextKeyRecipeMessages();


        //Recipes

        [OperationContract]
        void AddNewRecipes(Recipes a);
        [OperationContract]
        void UpdateRecipes(Recipes a);
        [OperationContract]
        void DeleteCompletelyRecipes(Recipes a);
        [OperationContract]
        Recipes FindRecipes(int code);
        [OperationContract]
        List<Recipes> GetAllRecipes();
        [OperationContract]
        void DeletePartiallyRecipes(Recipes a);
        [OperationContract]
        List<Recipes> GetRecipesByFolder(Folder f);
        [OperationContract]
        bool RecipeHasNewMessage(Recipes a,WebUser u);
        [OperationContract]
        List<Recipes> GetAllRecipeNewMessage(WebUser u);
        [OperationContract]
        List<Recipes> GetAllMyRecipe(WebUser u);
        [OperationContract]
        List<Recipes> GetAllMyRecipesByFolder(WebUser u, Folder f);
        [OperationContract]
        List<Recipes> GetAllMyFavRecipesByFolder(WebUser u, Folder f);
        [OperationContract]
        List<Recipes> GetAllRecipeNewMessageByFolder(WebUser u, Folder f);
        [OperationContract]
        bool HasDoubleName(string name);
        [OperationContract]
        int GetNextKeyRecipes();
        [OperationContract]
        List<RecipeIngredient> GetIngredientsByRecipe(Recipes r);
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutGluten(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithGlutan();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutSesame(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithSesame();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutMilk(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithMilk();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutNuts(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithNuts();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutSugar(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithSugar();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutSoy(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithSoy();
        [OperationContract]
        List<Recipes> GetAllRecipesWithoutEggs(List<Recipes> lstall);
        [OperationContract]
        List<Ingredients> ingredientsWithEggs();



        //WebUser
        [OperationContract]
        WebUser FindUserByEmail(string email);
        [OperationContract]
        bool CheckUsers(string userEmail, string userPasscode);
        [OperationContract]
        void AddNewUsers(WebUser a);
        [OperationContract]
        void UpdateUsers(WebUser a);
        [OperationContract]
        void DeleteCompletelyUsers(WebUser a);
        [OperationContract]
        WebUser FindUsers(int code);
        [OperationContract]
        List<WebUser> GetAllUsers();
        [OperationContract]
        void DeletePartiallyUsers(WebUser a);
        [OperationContract]
       int GetNextKeyUsers();


        //Yechidot
        [OperationContract]
        int GetNextKeyYechidot();

        [OperationContract]
        void AddNewYechidot(Yechidot a);

        [OperationContract]
        void UpdateYechidot(Yechidot a);

        [OperationContract]
        void DeleteCompletelyYechidot(Yechidot a);

        [OperationContract]
        Yechidot FindYechidot(int code);

        [OperationContract]
        List<Yechidot> GetAllYechidot();

        [OperationContract]
        void DeletePartiallyYechidot(Yechidot a);
        [OperationContract]
        bool hasDoubleYechidot(Yechidot i);

        //others - pics

        [OperationContract]
        byte[] GetImage(string fileName);
        [OperationContract]
        void SaveImage(byte[] imageArray, string fileName);


    }

}
