using Model;
using ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {

        public static void PrintList(List<BaseEntity>lst)
        { 
            foreach(var item in lst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("======================");
              
        }
        static void Main(string[] args)
        {
            //Users:  checked
            // הוספת שורת  נתונים  למסד נתונים Users
            //PrintList(MyDB.userlist.GetList().Cast<BaseEntity>().ToList());
            //WebUser Users1 = new WebUser() { userCode = 6, userName = "Chana", userPasscode = "1234", userEmail = "hjkh", userStatus = true };
            //MyDB.userlist.Add(Users1);
            //MyDB.userlist.SaveChanges();
            //PrintList(MyDB.userlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            //עדכון שורת נתונים למסד נתונים Users
            //PrintList(MyDB.userlist.GetList().Cast<BaseEntity>().ToList());
            //WebUser Users2 = MyDB.userlist.GetList().FirstOrDefault(x => x.userCode == 1);
            //Users2.userPasscode = "11114567";
            //MyDB.userlist.Update(Users2);
            //MyDB.userlist.SaveChanges();
            //PrintList(MyDB.userlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            //מחיקת שורת נתונים מהמסד נתונים Users


            //  RecipeIngredient:
            //  הוספת שורת  נתונים למסד נתונים RecipeIngredient
            //Recipes recipe4 = MyDB.recipeslist.GetRecipesByCode(1);
            //Yechidot yechidot3 = MyDB.yechidotlist.GetYechidotByCode(1);
            //Ingredients ingredients4 = MyDB.ingredientslist.GetIngredientsByCode(1);
            //PrintList(MyDB.recipeIngredientlist.GetList().Cast<BaseEntity>().ToList());
            //RecipeIngredient recipeIngredient1 = new RecipeIngredient() { recipeIngredientCode = 1, recipeCode = recipe4, ingredientamount = 2, codeYechidot = yechidot3, ingredientCode = ingredients4, recipeIngredientStatus = true };
            //MyDB.recipeIngredientlist.Add(recipeIngredient1);
            //MyDB.recipeIngredientlist.SaveChanges();
            //PrintList(MyDB.recipeIngredientlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            ////עדכון שורת נתונים למסד נתונים RecipeIngredient
            //PrintList(MyDB.recipeIngredientlist.GetList().Cast<BaseEntity>().ToList());
            //RecipeIngredient recipeIngredient2 = MyDB.recipeIngredientlist.GetList().FirstOrDefault(x => x.recipeIngredientCode == 1);
            //recipeIngredient2.ingredientamount = 145;
            //MyDB.recipeIngredientlist.Update(recipeIngredient2);
            //MyDB.recipeIngredientlist.SaveChanges();
            //PrintList(MyDB.recipeIngredientlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();



            //  Yechidot: CHECKED
            //  הוספת שורת  נתונים למסד נתונים Yechidot
            //PrintList(MyDB.yechidotlist.GetList().Cast<BaseEntity>().ToList());
            //Yechidot yechidot1 = new Yechidot() { codeYechidot = 1, nameYechidot = "cup" , statusYechidot=true};
            //MyDB.yechidotlist.Add(yechidot1);
            //MyDB.yechidotlist.SaveChanges();
            //PrintList(MyDB.yechidotlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            //  עדכון שורת נתונים למסד נתונים Yechidot
            //PrintList(MyDB.yechidotlist.GetList().Cast<BaseEntity>().ToList());
            //Yechidot yechidot2 = MyDB.yechidotlist.GetList().FirstOrDefault(x => x.codeYechidot == 1);
            //yechidot2.nameYechidot = "TBSP";
            //MyDB.yechidotlist.Update(yechidot2);
            //MyDB.yechidotlist.SaveChanges();
            //PrintList(MyDB.yechidotlist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();



            //  Recipes: CHECKED
            //  הוספת שורת  נתונים למסד נתונים Recipes
            //WebUser users6 = MyDB.userlist.GetUserByCode(1);
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());
            //Recipes recipes1 = new Recipes() { recipeCode = 2, recipeName = "VEGETABLE soup", recipeDifficulty = 1, recipePreparation = "cut veg add to water add chicken for 30 min", userCode = users6, recipeComments = "bubby Goldies friday night soup", recipePicture = "", recipePreparationTime = 120, recipeSarvingAmount = 10, recipeStatus = true };
            //MyDB.recipeslist.Add(recipes1);
            //MyDB.recipeslist.SaveChanges();
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            //  עדכון שורת נתונים למסד נתונים Recipes
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());
            //Recipes recipes2 = MyDB.recipeslist.GetList().FirstOrDefault(x => x.recipeCode == 2);
            //recipes2.recipeName = "yUMMY VEGETABLE soup";
            //MyDB.recipeslist.Update(recipes2);
            //MyDB.recipeslist.SaveChanges();
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            ////  מחיקת שורת נתונים מהמסד נתונים Recipes
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());
            //Recipes recipes4 = MyDB.recipeslist.GetRecipesByCode(1);
            //MyDB.recipeslist.Delete(recipes4);
            //MyDB.recipeslist.SaveChanges();
            //PrintList(MyDB.recipeslist.GetList().Cast<BaseEntity>().ToList());


            //  FavoriteRecipes  CHECKED
            //   הוספת שורת נתונים  למסד נתונים FavoriteRecipes
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());
            //WebUser users3 = MyDB.userlist.GetUserByCode(2);
            //Recipes recipes3 = MyDB.recipeslist.GetRecipesByCode(1);
            //FavoriteRecipes favoriteRecipes1 = new FavoriteRecipes() { favRecipeCode = 1, userCode = users3, recipeCode = recipes3,favRecipeStatus=true };
            //MyDB.favRecipeslist.Add(favoriteRecipes1);
            //MyDB.favRecipeslist.SaveChanges();
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            ////  עדכון שורת נתונים למסד נתונים FavoriteRecipes
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());
            //FavoriteRecipes favoriteRecipes2 = MyDB.favRecipeslist.GetList().FirstOrDefault(x => x.favRecipeCode == 1);
            //WebUser users3 = MyDB.userlist.GetUserByCode(2);
            //favoriteRecipes2.userCode = users3;
            //MyDB.favRecipeslist.Update(favoriteRecipes2);
            //MyDB.favRecipeslist.SaveChanges();
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            ////  מחיקת שורת נתונים מהמסד נתונים FavoriteRecipes
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());
            //FavoriteRecipes favoriteRecipes3 = MyDB.favRecipeslist.GetFavoriteRecipesByCode(1);
            //MyDB.favRecipeslist.Delete(favoriteRecipes3);
            //MyDB.favRecipeslist.SaveChanges();
            //PrintList(MyDB.favRecipeslist.GetList().Cast<BaseEntity>().ToList());


            //  Ingredients:  CHECKED
            //  הוספת שורת  נתונים למסד נתונים Ingredients
            //PrintList(MyDB.ingredientslist.GetList().Cast<BaseEntity>().ToList());
            //Ingredients ingredients1 = new Ingredients() { ingredientsCode = 1, ingredientName = "suger", containsEggs = false, containsGluten = false, containsMilk = false, containsNuts = false, containsSesame = false, containsSoy = false, containsSuger = true };
            //MyDB.ingredientslist.Add(ingredients1);
            //MyDB.ingredientslist.SaveChanges();
            //PrintList(MyDB.ingredientslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            ////  עדכון שורת נתונים למסד נתונים Ingredients
            //PrintList(MyDB.ingredientslist.GetList().Cast<BaseEntity>().ToList());
            //Ingredients ingredients2 = MyDB.ingredientslist.GetList().FirstOrDefault(x => x.ingredientsCode == 1);
            //ingredients2.ingredientName = "splenda";
            //MyDB.ingredientslist.Update(ingredients2);
            //MyDB.ingredientslist.SaveChanges();
            //PrintList(MyDB.ingredientslist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();



            //  Rating: checked
            //  הוספת שורת  נתונים למסד נתונים Rating
            //Recipes recipe3 = MyDB.recipeslist.GetRecipesByCode(1);
            //WebUser users4 = MyDB.userlist.GetUserByCode(1);
            //PrintList(MyDB.ratinglist.GetList().Cast<BaseEntity>().ToList());
            //Rating rating1 = new Rating() { ratingCode = 1, rateValue = 5, recipeCode = recipe3, userCode = users4 };
            //MyDB.ratinglist.Add(rating1);
            //MyDB.ratinglist.SaveChanges();
            //PrintList(MyDB.ratinglist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();
            //עדכון שורת נתונים למסד נתונים Rating
            //PrintList(MyDB.ratinglist.GetList().Cast<BaseEntity>().ToList());
            //Rating rating2 = MyDB.ratinglist.GetList().FirstOrDefault(x => x.ratingCode == 1);
            //rating2.rateValue = 40;
            //MyDB.ratinglist.Update(rating2);
            //MyDB.ratinglist.SaveChanges();
            //PrintList(MyDB.ratinglist.GetList().Cast<BaseEntity>().ToList());
            //Console.ReadLine();


            //RecipeMessages:
            Recipes recipe5 = MyDB.recipeslist.GetRecipesByCode(1);
            WebUser user5 = MyDB.userlist.GetUserByCode(1);
            PrintList(MyDB.recipeMessageslist.GetList().Cast<BaseEntity>().ToList());
            RecipeMessages recipeMessages1 = new RecipeMessages() { messageCode = 2, messagesNumber = 1, messagesText = "Hi", messagesPicture = "", recipeCode = recipe5, userCode = user5, };
            MyDB.recipeMessageslist.Add(recipeMessages1);
            MyDB.recipeMessageslist.SaveChanges();
            PrintList(MyDB.recipeMessageslist.GetList().Cast<BaseEntity>().ToList());
            Console.ReadLine();
            // עדכון שורת נתונים למסד נתונים RecipeMessages
            PrintList(MyDB.recipeMessageslist.GetList().Cast<BaseEntity>().ToList());
            RecipeMessages recipeMessages2 = MyDB.recipeMessageslist.GetList().FirstOrDefault(x => x.messageCode == 1);
            recipeMessages2.messagesPicture = "Hello";
            MyDB.recipeMessageslist.Update(recipeMessages2);
            MyDB.recipeMessageslist.SaveChanges();
            PrintList(MyDB.recipeMessageslist.GetList().Cast<BaseEntity>().ToList());
            Console.ReadLine();
            

        }
    }
}
