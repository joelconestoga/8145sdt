using System;
using System.Collections.Generic;

namespace Facebook
{
    public class Timeline : Page
    {
        private MainSession mainSession;
        private List<string> posts = new List<string>();

        public Timeline()
        {
        }

        public Timeline(MainSession mainSession)
        {
            this.mainSession = mainSession;
        }

        public void addContent()
        {
            presentNewContentPage();
            posts.Add(DateTime.Now.ToString(@"MM\/dd\/yyyy HH:mm:ss: ") + Console.ReadLine());
        }

        private void presentNewContentPage()
        {
            Console.Clear();
            mainSession.presentHome();
            Writer.writeALineWith('*', "");
            Console.Write("***\tPost: ");
        }

        public string getHeader()
        {
            return "T I M E L I N E";
        }

        public string getOptions()
        {
            return "4.Add Post";
        }

        public void writeContent()
        {
            if (posts.Count == 0)
                Writer.writeALineWith('*', "No posts yet... :(");
            else
                foreach (string post in posts)
                    Console.WriteLine("***\t" + post);
        }
    }
}