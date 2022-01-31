namespace SMS.Data
{
    public class DataConstants
    {
       
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        
        public const int UsernameMin = 5;
        
        public const int UsernameMax = 20;

        public const int PasswordMin = 6;

        public const int PasswordMax = 20;        

    }
}
