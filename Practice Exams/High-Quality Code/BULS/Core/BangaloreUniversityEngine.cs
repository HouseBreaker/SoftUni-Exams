namespace BangaloreUniversityLearningSystem.Core
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.ExceptionServices;

	using BangaloreUniversityLearningSystem.Interfaces;
	using BangaloreUniversityLearningSystem.Models;

	using Data;

	public class BangaloreUniversityEngine : IEngine
	{
		public void Run()
		{
			var db = new BangaloreUniversityData();
			User user = null;
			while (true)
			{
				string line = Console.ReadLine();
				if (line == null)
				{
					break;
				}

				var route = new Route(line);
				var controllerType =
					Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == route.ControllerName);
				var controller = Activator.CreateInstance(controllerType, db, user) as Controller;
				var action = controllerType.GetMethod(route.ActionName);
				object[] @params = MapParameters(route, action);

				try
				{
					var view = action.Invoke(controller, @params) as IView;
					Console.WriteLine(view.Display());
					user = controller.User;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.InnerException.Message);
				}
			}
		}

		private static object[] MapParameters(Route route, MethodInfo action)
		{
			return action.GetParameters().Select<ParameterInfo, object>(
				p =>
					{
						if (p.ParameterType == typeof(int))
						{
							return int.Parse(route.Parameters[p.Name]);
						}
						else
						{
							return route.Parameters[p.Name];
						}
					}).ToArray();
		}
	}
}