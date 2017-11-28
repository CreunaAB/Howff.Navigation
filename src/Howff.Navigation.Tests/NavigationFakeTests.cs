using System.Linq;

using Shouldly;

using Xunit;

namespace Howff.Navigation.Tests {
	public class NavigationFakeTests {
		[Fact]
		public void Constructor_NavigationFakesAsConstructorArgument_CorrectChildProperties() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			navigationFake.ChildrenOfRoot.Count.ShouldBe(3);
			navigationFake.ChildrenOfRoot.ElementAt(0).ShouldBeSameAs(fakes.FirstChildOfRoot);
			navigationFake.ChildrenOfRoot.ElementAt(1).ShouldBeSameAs(fakes.SecondChildOfRoot);
			navigationFake.ChildrenOfRoot.ElementAt(2).ShouldBeSameAs(fakes.ThirdChildOfRoot);

			navigationFake.ChildrenOfFirstChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfFirstChildOfRoot.ElementAt(0).ShouldBeSameAs(fakes.FirstChildOfFirstChildOfRoot);
			navigationFake.ChildrenOfFirstChildOfRoot.ElementAt(1).ShouldBeSameAs(fakes.SecondChildOfFirstChildOfRoot);

			navigationFake.ChildrenOfSecondChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfSecondChildOfRoot.ElementAt(0).ShouldBeSameAs(fakes.FirstChildOfSecondChildOfRoot);
			navigationFake.ChildrenOfSecondChildOfRoot.ElementAt(1).ShouldBeSameAs(fakes.SecondChildOfSecondChildOfRoot);

			navigationFake.ChildrenOfThirdChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfThirdChildOfRoot.ElementAt(0).ShouldBeSameAs(fakes.FirstChildOfThirdChildOfRoot);
			navigationFake.ChildrenOfThirdChildOfRoot.ElementAt(1).ShouldBeSameAs(fakes.SecondChildOfThirdChildOfRoot);

			navigationFake.ChildrenOfFirstChildOfFirstChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfFirstChildOfFirstChildOfRoot.ElementAt(0)
				.ShouldBeSameAs(fakes.FirstChildOfFirstChildOfFirstChildOfRoot);
			navigationFake.ChildrenOfFirstChildOfFirstChildOfRoot.ElementAt(1)
				.ShouldBeSameAs(fakes.SecondChildOfFirstChildOfFirstChildOfRoot);

			navigationFake.ChildrenOfSecondChildOfFirstChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfSecondChildOfFirstChildOfRoot.ElementAt(0)
				.ShouldBeSameAs(fakes.FirstChildOfSecondChildOfFirstChildOfRoot);
			navigationFake.ChildrenOfSecondChildOfFirstChildOfRoot.ElementAt(1)
				.ShouldBeSameAs(fakes.SecondChildOfSecondChildOfFirstChildOfRoot);

			navigationFake.ChildrenOfFirstChildOfSecondChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfFirstChildOfSecondChildOfRoot.ElementAt(0)
				.ShouldBeSameAs(fakes.FirstChildOfFirstChildOfSecondChildOfRoot);
			navigationFake.ChildrenOfFirstChildOfSecondChildOfRoot.ElementAt(1)
				.ShouldBeSameAs(fakes.SecondChildOfFirstChildOfSecondChildOfRoot);

			navigationFake.ChildrenOfSecondChildOfSecondChildOfRoot.Count.ShouldBe(2);
			navigationFake.ChildrenOfSecondChildOfSecondChildOfRoot.ElementAt(0)
				.ShouldBeSameAs(fakes.FirstChildOfSecondChildOfSecondChildOfRoot);
			navigationFake.ChildrenOfSecondChildOfSecondChildOfRoot.ElementAt(1)
				.ShouldBeSameAs(fakes.SecondChildOfSecondChildOfSecondChildOfRoot);
		}

		[Fact]
		public void GetChildren_RootItemWithNullChildren_ReturnsNull() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.RootWithNullChildren);

			children.ShouldBeNull();
		}

		[Fact]
		public void GetChildren_RootItem_ReturnsChildrenOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.Root);

			children.ShouldBe(navigationFake.ChildrenOfRoot);
		}

		[Fact]
		public void GetChildren_FirstChildOfRoot_ReturnsChildrenOfFirstChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.FirstChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfFirstChildOfRoot);
		}

		[Fact]
		public void GetChildren_SecondChildOfRoot_ReturnsChildrenOfSecondChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.SecondChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfSecondChildOfRoot);
		}

		[Fact]
		public void GetChildren_ThirdChildOfRoot_ReturnsChildrenOfThirdChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.ThirdChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfThirdChildOfRoot);
		}

		[Fact]
		public void GetChildren_FirstChildOfFirstChildOfRoot_ReturnsChildrenOfFirstChildOfFirstChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.FirstChildOfFirstChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfFirstChildOfFirstChildOfRoot);
		}

		[Fact]
		public void GetChildren_SecondChildOfFirstChildOfRoot_ReturnsChildrenOfSecondChildOfFirstChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.SecondChildOfFirstChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfSecondChildOfFirstChildOfRoot);
		}

		[Fact]
		public void GetChildren_FirstChildOfSecondChildOfRoot_ReturnsChildrenOfFirstChildOfSecondChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.FirstChildOfSecondChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfFirstChildOfSecondChildOfRoot);
		}

		[Fact]
		public void GetChildren_SecondChildOfSecondChildOfRoot_ReturnsChildrenOfSecondChildOfSecondChildOfRoot() {
			var fakes = new NavigationItemFakes();
			var navigationFake = new NavigationFake(fakes);

			var children = navigationFake.PublicGetChildren(fakes.SecondChildOfSecondChildOfRoot);

			children.ShouldBe(navigationFake.ChildrenOfSecondChildOfSecondChildOfRoot);
		}
	}
}