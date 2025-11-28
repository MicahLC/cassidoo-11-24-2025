using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

		public MealPlan(List<MealTask> tasks) : this(tasks.Count, [.. tasks.Select(m => { return m.Name; })])
		{
		}
	}

	internal class TaskComparer : IComparer<MealTask>
	{
		/// sort by start time ascending, then end time ascending
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
			// sort the meals by start and end time.
			Array.Sort(meals, new TaskComparer());

			// store the index of any task that completely contains the start and end time of at least one other task. we won't use them
			HashSet<int> ignoreTaskIndices = [];
			for (int i = 0; i < meals.Length; ++i)
			{
				for (int j = 0; j < meals.Length; ++j)
				{
					if (j == i) { continue; }
					if (ignoreTaskIndices.Contains(j)) { continue; }
					if (meals[j].StartTime >= meals[i].Endtime)
					{
						// we've looked at enough elements
						break;
					}
					if (meals[j].StartTime >= meals[i].StartTime && meals[j].Endtime <= meals[i].Endtime)
					{
						ignoreTaskIndices.Add(i);
						break;
					}
				}
			}

			// now walk through and greedily grab tasks that we're not ignoring and that don't overlap with a previous task.
			List<MealTask> selectedTasks = [];
			int nextStartTime = -1;
			for (int i = 0; i < meals.Length; ++i)
			{
				if (ignoreTaskIndices.Contains(i))
				{
					continue;
				}
				if (meals[i].StartTime >= nextStartTime)
				{
					selectedTasks.Add(meals[i]);
					nextStartTime = meals[i].Endtime;
				}
			}

			return new MealPlan(selectedTasks);
		}
	}
}
