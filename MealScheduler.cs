using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassidoo_11_24_2025
{
	public class MealTask(string name, int start, int end)
	{
		public string Name = name;
		public int StartTime = start;
		public int Endtime = end;
	}
	public class MealPlan(int count, string[] chosen)
	{
		public int Count = count;
		public string[] ChosenTasks = chosen;
	}

	internal class TaskComparer : IComparer<MealTask>
	{
		int IComparer<MealTask>.Compare(MealTask? x, MealTask? y)
		{
			ArgumentNullException.ThrowIfNull(x);
			ArgumentNullException.ThrowIfNull(y);

			int startDiff = x.StartTime - y.StartTime;
			if (startDiff != 0)
			{
				return startDiff;
			}
			int endDiff = x.Endtime - y.Endtime;
			if (endDiff != 0)
			{
				return endDiff;
			}
			return new CaseInsensitiveComparer().Compare(x.Name, y.Name);
		}
	}

	public class MealScheduler
	{
		// private class Heatmap
		public static MealPlan MaxMealPrepTasks(MealTask[] meals)
		{
			// sort?
			Array.Sort(meals, new TaskComparer());
			
			// build a heatmap? for every time interval unit, how many tasks require that interval?

			// walk the list. need to figure out how we prioritize overlaps


			return new MealPlan(0, []);
		}
	}
}
