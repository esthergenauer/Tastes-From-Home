using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Model;


namespace WcfServiceLibrary1
{[ServiceContract]
    public interface IRecipeService
    {

        //FavoriteRecipes
        [OperationContract]
        void AddNewFavoriteRecipes(FavoriteRecipes a);
       // [OperationContract]
       // void UpdateFavoriteRecipes(FavoriteRecipes a);

       // [OperationContract]
       // void DeleteCompletelyFavoriteRecipes(FavoriteRecipes a);
       // [OperationContract]
       // FavoriteRecipes FindFavoriteRecipes(int code);
       // [OperationContract]
       // List<FavoriteRecipes> GetAllFavoriteRecipes();
       // [OperationContract]
       // void DeletePartiallyFavoriteRecipes(FavoriteRecipes a);

       // Ingredients
       //[OperationContract]
       // void AddNewIngredients(Ingredients a);
       // [OperationContract]
       // void UpdateIngredients(Ingredients a);

       // [OperationContract]
       // void DeleteCompletelyIngredients(Ingredients a);
       // [OperationContract]
       // Ingredients FindIngredients(int code);
       // [OperationContract]
       // List<Ingredients> GetAllIngredients();
       // [OperationContract]
       // void DeletePartiallyIngredients(Ingredients a);

       // Rating
       //     [OperationContract]
       //    void AddNewRating(Rating a);
       // [OperationContract]
       // void UpdateRating(Rating a);

       // [OperationContract]
       // void DeleteCompletelyRating(Rating a);
       // [OperationContract]
       // Rating FindRating(int code);
       // [OperationContract]
       // List<Rating> GetAllRating();
       // [OperationContract]
       // void DeletePartiallyRating(Rating a);


       // RecipeIngredient
       //[OperationContract]
       // void AddNewRecipeIngredient(RecipeIngredient a);
       // [OperationContract]
       // void UpdateRecipeIngredient(RecipeIngredient a);

       // [OperationContract]
       // void DeleteCompletelyRecipeIngredient(RecipeIngredient a);
       // [OperationContract]
       // RecipeIngredient FindRecipeIngredient(int code);
       // [OperationContract]
       // List<RecipeIngredient> GetAllRecipeIngredient();
       // [OperationContract]
       // void DeletePartiallyRecipeIngredient(RecipeIngredient a);


       // RecipeMessages
       // [OperationContract]
       // void AddNewRecipeMessages(RecipeMessages a);
       // [OperationContract]
       // void UpdateRecipeMessages(RecipeMessages a);

       // [OperationContract]
       // void DeleteCompletelyRecipeMessages(RecipeMessages a);
       // [OperationContract]
       // RecipeMessages FindRecipeMessages(int code);
       // [OperationContract]
       // List<RecipeMessages> GetAllRecipeMessages();
       // [OperationContract]
       // void DeletePartiallyRecipeMessages(RecipeMessages a);


       // Recipes
       // [OperationContract]
       // void AddNewRecipes(Recipes a);
       // [OperationContract]
       // void UpdateRecipes(Recipes a);

       // [OperationContract]
       // void DeleteCompletelyRecipes(Recipes a);
       // [OperationContract]
       // Recipes FindRecipes(int code);
       // [OperationContract]
       // List<Recipes> GetAllRecipes();
       // [OperationContract]
       // void DeletePartiallyRecipes(Recipes a);


       // WebUser
       // [OperationContract]
       // void AddNewUsers(WebUser a);
       // [OperationContract]
       // void UpdateUsers(WebUser a);

       // [OperationContract]
       // void DeleteCompletelyUsers(WebUser a);
       // [OperationContract]
       // WebUser FindUsers(int code);
       // [OperationContract]
       // List<WebUser> GetAllUsers();
       // [OperationContract]
       // void DeletePartiallyUsers(WebUser a);


       // Yechidot
       // [OperationContract]
       // void AddNewYechidot(Yechidot a);
       // [OperationContract]
       // void UpdateYechidot(Yechidot a);

       // [OperationContract]
       // void DeleteCompletelyYechidot(Yechidot a);
       // [OperationContract]
       // Yechidot FindYechidot(int code);
       // [OperationContract]
       // List<Yechidot> GetAllYechidot();
       // [OperationContract]
       // void DeletePartiallyYechidot(Yechidot a);

    }
}
