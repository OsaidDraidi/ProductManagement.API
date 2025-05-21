namespace ProductManagement.API.DTOs.AuthDtos
{
    public class AuthenticationResponseDto
    {
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
