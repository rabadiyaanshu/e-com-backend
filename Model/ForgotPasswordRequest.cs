namespace WebLoginRegisterApi.Model
{
    public class ForgotPasswordRequest
    {
        public string Username { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
