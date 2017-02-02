using System;
using Newtonsoft.Json;

namespace Belatrix.Connect.Core.Dtos
{
	public class AuthenticationResponse
	{
		[JsonProperty("user_id")]
		public int Id { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }

		[JsonProperty("reset_password_code")]
		public Guid ResetPasswordCode { get; set; }

		[JsonProperty("is_staff")]
		public bool IsStaff { get; set; }

		[JsonProperty("is_password_reset_required")]
		public bool IsPasswordResetRequired { get; set; }

		[JsonProperty("is_base_profile_complete")]
		public bool IsBaseProfileComplete { get; set; }
	}
}
