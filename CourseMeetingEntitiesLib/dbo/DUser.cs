namespace CourseMeetingEntitiesLib.dbo
{
    interface DUser{
        string UID {get;set;}
        string UserName {get;set;}
        string RoleID {get;set;}
        string Email{get;set;}
        string PhoneNumber { get; set; }
    }
}