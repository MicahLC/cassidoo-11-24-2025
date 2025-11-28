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

			// store the index of any task that completely contains the start and end time of 2 other tasks, and we won't use them
			HashSet<int> ignoreTaskIndices = [];
			for (int i = 0; i < meals.Length; ++i)
			{
				int contained = 0;
				for (int j = 0; j < meals.Length; ++j)
				{
					if (j == i) { continue; }
					if (meals[j].StartTime >= meals[i].Endtime)
					{
						// we've looked at enough elements
						break;
					}
					if (meals[j].StartTime >= meals[i].StartTime && meals[j].Endtime <= meals[i].Endtime)
					{
						Debug.WriteLine($"Task {i} ({meals[i].Name}) contains task {j} ({meals[j].Name})");
						++contained;
						if (contained > 1)
						{
							Debug.WriteLine($"Task {i} ({meals[i].Name}) contains at least 2 tasks, adding it to ignore set.");
							ignoreTaskIndices.Add(i);
							break;
						}
					}
				}
			}
			if (ignoreTaskIndices.Count == 0)
			{
				Debug.WriteLine("No indices to be ignored.");
			}


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

			/*int LAST_START_TIME = meals[^1].StartTime;
			int nextStartTime = -1;

			int potentialSolutionCount = 0;
			string[] solutionArray = [];

			Stack<int> decisionPoint = new();
			List<MealTask> selectedTasks = [];
			for(int i = 0; i < meals.Length; ++i)
			{
				if (meals[i].StartTime >= nextStartTime)
				{
					// decisionPoint.Push(meals[i]);
					selectedTasks.Add(meals[i]);
					nextStartTime = meals[i].Endtime;
				}
				else
				{
					decisionPoint.Push(i);
				}
			}
			// selectedTasks now contains a potential solution
			if (selectedTasks.Count > potentialSolutionCount)
			{
				// we have a new, better solution
				potentialSolutionCount = selectedTasks.Count;
				solutionArray = [.. selectedTasks.Select(m => { return m.Name; })];
			}

			return new MealPlan(0, []); */
		}
	}
}
