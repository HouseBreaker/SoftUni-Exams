namespace BangaloreUniversityLearningSystem.Controllers
{
	using System;
	using System.Linq;

	using BangaloreUniversityLearningSystem.Core;
	using BangaloreUniversityLearningSystem.Interfaces;
	using BangaloreUniversityLearningSystem.Models;
	using BangaloreUniversityLearningSystem.Utilities;

	public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.User = user;
        }

		public IView All()
		{
			return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
		}

		public IView Details(int courseId)
		{
			this.EnsureAuthorization(Role.Student, Role.Lecturer);

			if (!this.User.Courses.Contains(this.GetCourseById(courseId)))
			{
				throw new ArgumentException("You are not enrolled in this course.");
			}

			return this.View(this.Data.Courses.Get(courseId));
		}

		public IView Enroll(int courseId)
		{
			this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses.Get(courseId);
			if (course == null)
			{
				throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
			}

			if (this.User.Courses.Contains(course))
			{
				throw new ArgumentException("You are already enrolled in this course.");
			}
			course.AddStudent(this.User);
			return this.View(course);
		}

		public IView Create(string name)
		{
			this.EnsureAuthorization(Role.Lecturer);

			var c = new Course(name);
            this.Data.Courses.Add(c);
            return this.View(c);
		}

		public IView AddLecture(int courseId, string lectureName)
		{
			if (!this.HasLoggedInUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

			if (!this.User.IsInRole(Role.Lecturer))
			{
				throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
			}

			Course c = this.GetCourseById(courseId);
            c.AddLecture(new Lecture(lectureName));
            return this.View(c);
        }

		private Course GetCourseById(int courseId)
		{
			var course = this.Data.Courses.Get(courseId);
			if (course == null)
			{
				throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
			}
			return course;
		}
	}
}
