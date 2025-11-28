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

        [TestMethod]
        public void TestDoubleOverlaps()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("a", 1, 4),
                new MealTask("b", 4, 7),
                new MealTask("c", 7, 10),
                new MealTask("d", 2, 3),
                new MealTask("e", 3, 8)
            ]);
            plan.Count.Should().Be(3);
            plan.ChosenTasks.Should().BeEquivalentTo(["d", "b", "c"]);
        }

        [TestMethod]
        public void TestTwoLongThreeShort()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("a", 1, 5),
                new MealTask("b", 5, 9),
                new MealTask("c", 2, 6),
                new MealTask("d", 6, 7),
                new MealTask("e", 8, 10)
            ]);
            plan.Count.Should().Be(3);
            plan.ChosenTasks.Should().BeEquivalentTo(["a", "d", "e"]);
        }
    }
}