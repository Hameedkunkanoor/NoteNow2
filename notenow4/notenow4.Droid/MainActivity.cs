using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platform;
using System.IO;
using Xamarin.Forms;
using System;
namespace notenow4.Droid
{
    [Activity(Label = "MainActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity
        : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("Notes.db3");
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            var formsPresenter = (MvxFormsPagePresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            LoadApplication(formsPresenter.FormsApplication);
        }
    }
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          //  string path = System.Environment.GetFolderPath(Android.OS.Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, filename);

            CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }

        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(System.Net.Mime.MediaTypeNames.Application.Context.Assets.Open("Notes.db3")))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
    }
}


