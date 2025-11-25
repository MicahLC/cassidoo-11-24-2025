using FluentAssertions;

namespace cassidoo_11_24_2025
{
    [TestClass]
    public sealed class MealTests
    {
        [TestMethod]
        public void TestFromEmail()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("Make Gravy", 10, 11),
                new MealTask("Mash Potatoes", 11, 12),
                new MealTask("Bake Rolls", 11, 13),
                new MealTask("Prep Salad", 12, 13)
            ]);
            plan.Count.Should().Be(3);
            plan.ChosenTasks.Should().BeEquivalentTo(["Make Gravy", "Mash Potatoes", "Prep Salad"]);
        }

        [TestMethod]
        public void TestBasic()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("Wake Up", 1, 2)
            ]);
            plan.Count.Should().Be(1);
            plan.ChosenTasks.Should().BeEquivalentTo(["Wake Up"]);
        }

        [TestMethod]
        public void TestSimpleMax()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("Buy Eggs", 10, 14),
                new MealTask("Make Cookies", 11, 12),
                new MealTask("Bake Bread", 12, 13),
                new MealTask("Bake Rolls", 13, 14)
            ]);
            plan.Count.Should().Be(3);
            plan.ChosenTasks.Should().BeEquivalentTo(["Make Cookies", "Bake Bread", "Bake Rolls"]);
        }
    }
}