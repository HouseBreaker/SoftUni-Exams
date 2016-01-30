namespace BangaloreUniversityLearningSystem.Models
{
	using System;
	using System.Collections.Generic;

	using BangaloreUniversityLearningSystem.Core;
	using BangaloreUniversityLearningSystem.Utilities;

	public class User
	{
		private string username;
		private string password;

		public User(string username, string password, Role role)
		{
			this.Username = username;
			this.Password = password;
			this.Role = role;

			this.Courses = new List<Course>();
		}

		public string Username
		{
			get
			{
				return this.username;
			}

			set
			{
				const int MinUsernameLength = 5;

				if (string.IsNullOrEmpty(value) || value.Length < MinUsernameLength)
				{
					string message = $"The username must be at least {MinUsernameLength} symbols long.";
					throw new ArgumentException(message);
				}

				this.username = value;
				
			}
		}

		public string Password
		{
			get
			{
				return this.password;
			}

			set
			{
				const int MinPasswordLength = 6;
				
				if (string.IsNullOrEmpty(value) || value.Length < MinPasswordLength)
				{
					string message = $"The password must be at least {MinPasswordLength} symbols long.";
					throw new ArgumentException(message);
				}

				this.password = HashUtilities.HashPassword(value);
			}
		}

		public Role Role { get; private set; }

		public IList<Course> Courses { get; private set; }
	}
}