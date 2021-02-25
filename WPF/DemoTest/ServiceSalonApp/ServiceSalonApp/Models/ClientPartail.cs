namespace ServiceSalonApp.Models
{
    partial class Client
    {
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }
    }
}
