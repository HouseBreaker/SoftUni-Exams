using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4
{
	class Rectangles
	{
		static List<Rectangle> rectangles = new List<Rectangle>();

		static void Main()
		{
			string input = Console.ReadLine();

			while (true)
			{
				if (input == "End")
				{
					break;
				}

				ReadInput(input);

				input = Console.ReadLine();
			}

			var rectanglesInsideEachOther = new Dictionary<Rectangle, List<Rectangle>>();

			foreach (Rectangle rect in rectangles)
			{
				foreach (Rectangle target in rectangles.Where(target => rect.Name != target.Name))
				{
					if (!rectanglesInsideEachOther.ContainsKey(rect))
					{
						rectanglesInsideEachOther.Add(rect, new List<Rectangle>());
					}

					if (rect.IsInside(target))
					{
						rectanglesInsideEachOther[rect].Add(target);
					}
				}
			}

			var nonEmptySequences = rectanglesInsideEachOther
				.Where(a => a.Value.Count > 0)
				.ToDictionary(a => a.Key, b => b.Value);

			var cleanSequences = new Dictionary<Rectangle, List<Rectangle>>(nonEmptySequences);

			foreach (var currentSequence in nonEmptySequences)
			{
				var currentKey = currentSequence.Key;
				var currentValue = currentSequence.Value;

				for (int j = 1; j < currentValue.Count - 1; j ++)
				{
					var previous = currentValue[j - 1];
					var current = currentValue[j];
					var next = currentValue[j + 1];

					if (!(previous.IsInside(current) ||
					      current.IsInside(next)))
					{
						cleanSequences[currentKey].Remove(next);
					}
				}
			}

			var largestCount = cleanSequences.Max(a => a.Value.Count);

			Dictionary<Rectangle, List<Rectangle>> largestSequence =
				cleanSequences.Where(a => a.Value.Count == largestCount)
				.ToDictionary(a => a.Key, b => b.Value);


			var firstLargest = largestSequence.First();
			Console.WriteLine(string.Join(" < ", firstLargest.Value) + " < " + firstLargest.Key);
			//PrintRectangles(largestSequence);
		}

		private static void PrintRectangles(Dictionary<Rectangle, List<Rectangle>> sequence)
		{
			foreach (var rectangle in sequence.Keys)
			{
				Console.WriteLine(string.Join(" < ", sequence[rectangle]) + " < " + rectangle);
			}
		}

		private static void ReadInput(string input)
		{
			string[] tokens = input.Split(' ');

			string name = tokens[0].Substring(0, tokens[0].Length - 1);

			int left = int.Parse(tokens[1]);
			int top = int.Parse(tokens[2]);
			int right = int.Parse(tokens[3]);
			int bottom = int.Parse(tokens[4]);

			rectangles.Add(new Rectangle(
				name,
				new Point(left, top),
				new Point(right, top),
				new Point(left, bottom),
				new Point(right, bottom)));
		}
	}

	internal struct Rectangle
	{
		public string Name { get; }

		public Point TopLeft { get; }
		public Point TopRight { get; }
		public Point BottomLeft { get; }
		public Point BottomRight { get; }

		public Rectangle(string name, Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
		{
			Name = name;
			TopLeft = topLeft;
			TopRight = topRight;
			BottomLeft = bottomLeft;
			BottomRight = bottomRight;
		}

		public bool IsInside(Rectangle rect)
		{
			return TopLeft.X >= rect.TopLeft.X &&
			       BottomLeft.X >= rect.BottomLeft.X &&
			       TopRight.X <= rect.TopRight.X &&
			       BottomRight.X <= rect.BottomRight.X;
		}

		public int CalculateArea()
		{
			int width = TopLeft.X + TopRight.X;
			int height = TopLeft.Y + BottomLeft.Y;

			return width*height;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	internal struct Point
	{
		public int X { get; }
		public int Y { get; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}