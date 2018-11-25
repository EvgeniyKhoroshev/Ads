namespace Ads.CoreService.Contracts.Dto
{
    public class UserInfoDto
    {
        public string Avatar { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime Created { get; set; }
    }
}
