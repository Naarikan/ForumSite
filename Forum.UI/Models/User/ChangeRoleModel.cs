namespace Forum.UI.Models.User
{
    public class ChangeRoleModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CurrentRole { get; set; }
        public string SelectedRole { get; set; }
      
    }
}
