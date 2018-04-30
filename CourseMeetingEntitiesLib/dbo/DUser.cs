namespace CourseMeetingEntitiesLib.dbo
{
    public abstract class DUser{
        public string UID {get;set;}
        public string UserName {get;set;}
        public string RoleID {get;set;}
        public string Email{get;set;}
        public string PhoneNumber { get; set; }
    }
}