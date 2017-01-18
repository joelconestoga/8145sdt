using System;
using System.Collections.Generic;

namespace Facebook
{
    public class MainSession
    {
        User user;

        Timeline timeline;
        PhotoAlbum photos;
        FriendsList friends;

        List<Page> pages = new List<Page>();
        Page currentPage;

        public MainSession()
        {
            timeline = new Timeline(this);
            photos = new PhotoAlbum(this);
            friends = new FriendsList(this);

            pages.Add(timeline);
            pages.Add(photos);
            pages.Add(friends);
            currentPage = timeline;
        }

        public void execute()
        {
            readUser();

            while (currentPage != null)
            {
                presentHome();
                presentCurrentSession();
                presentOptions();
                readOption();
            }

            Writer.writeHeaderWithTitle(String.Format("Logging off, bye {0}, hit any key to finish...", user.Login));
            Console.ReadKey();
        }

        private void readUser()
        {
            Writer.writeHeaderWithTitle("FACEBOOK");
            Console.Write("***\tLogin: ");
            string login = Console.ReadLine();
            Console.Write("***\tPassword: ");
            string pass = Console.ReadLine();

            user = new User(login, pass);
        }

        public void presentHome()
        {
            Console.Clear();
            Writer.writeHeaderWithTitle("FACEBOOK");
            Writer.writeALineWith('*', "Welcome " + user.Login);
        }

        private void presentCurrentSession()
        {
            Writer.writeHeaderWithTitle(currentPage.getHeader());
            currentPage.writeContent();
        }

        private void presentOptions()
        {
            Writer.writeHeaderWithTitle("OPTIONS");
            Writer.writeALineWith('*', "1.Timeline   2.Photos   3.Friends   " + currentPage.getOptions() + "   5.Exit");
            Writer.writeALineWith('*', "");
        }

        private void readOption()
        {
            int option = 0;
            option = readOptionUpTo(5);

            switch (option)
            {
                case 1:
                    currentPage = timeline;
                    break;
                case 2:
                    currentPage = photos;
                    break;
                case 3:
                    currentPage = friends;
                    break;
                case 4:
                    currentPage.addContent();
                    break;
                case 5:
                    currentPage = null;
                    break;
                default:
                    currentPage = timeline;
                    option = 0;
                    break;
            }
        }

        private int readOptionUpTo(int options)
        {
            int choice = 0;

            Console.Write("***\tOption: ");

            try
            {
                choice = Convert.ToInt16(Console.ReadLine());
                return (0 < choice && choice <= options) ? choice : 0;
            }
            catch (Exception e)
            {
                choice = 0;
            }

            return choice;
        }

    }
}