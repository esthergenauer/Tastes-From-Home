using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UserClientRecipeEstiGenauer
{
    public class PicturesFunctions
    {

       
            public static BitmapImage GetImage(string fileName)
            {
                if (fileName == "")
                    return null;
                string path = Global.GetCurrentPath() + @"Pictures\" + fileName;
                if (!File.Exists(path))
                {
                    byte[] imageArr = Global.proxy.GetImage(fileName);
                    var stream = new MemoryStream(imageArr);
                    Image image = Image.FromStream(stream);
                    image.Save(path);//שמירה בתיקייה מקומית

                }
                return new BitmapImage(new Uri(path));
            }

            public static string SaveImage(string sourcefileName)
            {
                string fileName = System.IO.Path.GetFileName(sourcefileName);
                string path = Global.GetCurrentPath() + @"Pictures\" + fileName;
                if (!File.Exists(path))
                {
                    byte[] imgArray = File.ReadAllBytes(sourcefileName);
                    var stream = new MemoryStream(imgArray);
                    Image img = Image.FromStream(stream);
                    img.Save(path);
                }
                return (fileName);
            }

            public static string UploadImage_Dlg()
            {
                string filename = null;
                //יצירת אובייקט שפותח חלון
                OpenFileDialog dlg = new OpenFileDialog();
               
           
            // Allow users to select JPEG, PNG, and JPG files without filtering
            dlg.Filter = "Image files|*.jpeg;*.png;*.jpg";

            //פותח חלונית בחירת תמונה
            Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    filename = dlg.FileName;
                    filename = SaveImage(filename);
                }
                return (filename);

            }
            public static void SendImage(string image)
            //פעולה שמקבלת שם של תמונה ושולחת אותה לשרת
            {
                string path = Global.GetCurrentPath() + @"Pictures\" + image;
                byte[] imgArray = File.ReadAllBytes(path);//קריאת התמונה מהתיקיה המקומוית
                Global.proxy.SaveImage(imgArray, image);//שליחה לפעולה בשרת
            }







        }
   
}
