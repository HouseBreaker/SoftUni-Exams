﻿namespace BangaloreUniversityLearningSystem.Utilities
{
	using BangaloreUniversityLearningSystem.Core;
	using BangaloreUniversityLearningSystem.Models;

	public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }
    }
}
