using System.Collections.Generic;
using Newtonsoft.Json;

namespace Belatrix.Connect.Core
{
	public class Employee
	{
		/*
		 * private Integer pk;
    private String username;
    private String email;
    @SerializedName("first_name")
    private String firstName;
    @SerializedName("last_name")
    private String lastName;
    @SerializedName("skype_id")
    private String skypeId;
    @SerializedName("total_score")
    private Integer totalScore;
    @SerializedName("last_month_score")
    private Integer lastMonthScore;
    @SerializedName("current_month_score")
    private Integer currentMonthScore;
    @SerializedName("last_year_score")
    private Integer lastYearScore;
    @SerializedName("current_year_score")
    private Integer currentYearScore;
    private Integer value;
    private Integer level;
    private List<Category> categories;
    @SerializedName("is_active")
    private boolean active;
    @SerializedName("last_login")
    private String lastLogin;
    private String avatar;
    @SerializedName("num_stars")
    private Integer numStars;
    private Location location;
		 */
		[JsonProperty("pk")]
		public int Id { get; set; }
		public string UserName { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("skype_id")]
		public string SkypeId { get; set; }

        public string Email { get; set; }

        [JsonProperty("total_score")]
		public string TotalScore { get; set; }

		[JsonProperty("last_month_score")]
		public string LastMonthScore { get; set; }

		[JsonProperty("current_month_score")]
		public string CurrentMonthScore { get; set; }

		[JsonProperty("current_year_score")]
		public string CurrentYearScore { get; set; }

		public int Value { get; set; }
		public int Level { get; set; }
		public IList<Category> Categories { get; protected set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("last_login")]
		public string LastLogin { get; set; }

		[JsonProperty("avatar")]
		public string AvatarUri { get; set; }

		[JsonProperty("num_star")]
		public int NumStars { get; set; }

		public Location Location { get; set; }

        [JsonProperty("is_base_profile_complete")]
        public bool IsBaseProfileComplete { get; set; }

        [JsonProperty("is_password_reset_required")]
        public bool IsPasswordResetRequired { get; set; }


    }
}