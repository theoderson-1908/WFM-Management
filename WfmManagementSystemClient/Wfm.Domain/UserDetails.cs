using System.Text.Json.Serialization;

namespace Wfm.Domain
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
    }
}
