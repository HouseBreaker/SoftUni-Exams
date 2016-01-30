namespace BangaloreUniversityLearningSystem.Models
{
	using System;

	public class Lecture
	{
		private string name;

		public Lecture(string name)
		{
			this.Name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				const int MinimumCourseNameLength = 3;
				if (value == null || value.Length < MinimumCourseNameLength)
				{
					var message = $"The lecture name must be at least {MinimumCourseNameLength} symbols long.";
					throw new ArgumentException(message);
				}

				this.name = value;
			}
		}
	}
}