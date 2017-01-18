using System;

namespace Facebook
{
    public class FriendsList : Page
    {
        private MainSession mainSession;

        public FriendsList(MainSession mainSession)
        {
            this.mainSession = mainSession;
        }

        public void addContent()
        {
            throw new NotImplementedException();
        }

        public string getHeader()
        {
            return "F R I E N D S";
        }

        public string getOptions()
        {
            return "4.Add Friend";
        }

        public void writeContent()
        {
            Writer.writeALineWith('*', "No friends yet... :(");
        }
    }
}