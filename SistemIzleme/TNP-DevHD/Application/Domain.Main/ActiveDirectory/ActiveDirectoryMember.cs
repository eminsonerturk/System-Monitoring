namespace ActiveDirectory.Models
{
    public class ActiveDirectoryMember
    {
        public string userName;
        public string userMail;
        public bool isAdmin;

        public ActiveDirectoryMember()
        {
            isAdmin = false;
        }
    }
}