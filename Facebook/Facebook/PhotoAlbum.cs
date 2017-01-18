using System;
using System.Collections.Generic;

namespace Facebook
{
    public class PhotoAlbum : Page
    {
        private List<string> photos = new List<string>();
        private MainSession mainSession;

        public PhotoAlbum(MainSession mainSession)
        {
            this.mainSession = mainSession;
        }

        public void addContent()
        {
            presentNewContentPage();
            photos.Add("PHOTO" + (photos.Count + 1) + "-" + Console.ReadLine());
        }

        private void presentNewContentPage()
        {
            Console.Clear();
            mainSession.presentHome();
            Writer.writeALineWith('*', "");
            Console.Write("***\tPhoto title: ");
        }

        public string getHeader()
        {
            return "P H O T O S";
        }

        public string getOptions()
        {
            return "4.Add Photo";
        }

        public void writeContent()
        {
            if (photos.Count == 0)
                Writer.writeALineWith('*', "No photos yet... :(");
            else
                foreach (string post in photos)
                    Console.WriteLine("***\t" + post);

        }
    }
}