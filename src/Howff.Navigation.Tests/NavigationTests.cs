using System.Linq;

using NSubstitute;

using Shouldly;

using Xunit;

namespace Howff.Navigation.Tests {
	public class NavigationTests {
		[Fact]
		public void GetItems_RootItemNull_ReturnsEmptyItemCollection() {
			var navigation = MakeDefaultNavigationFake();

			var navigationItems = navigation.GetItems(null, Substitute.For<INavigationItem>(), Substitute.For<INavigationConfig>());

			navigationItems.ShouldBeEmpty();
		}

		[Fact]
		public void GetItems_StartLevelRootEndLevelOneGetChildrenOnRootItemReturnsNull_ReturnsCollectionWithRoot() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(
				fakes.RootWithNullChildren,
				Substitute.For<INavigationItem>(),
				new NavigationConfig(0, 1, IncludeItemsMode.All, IncludeItemsMode.All)
			).ToArray();

			navigationItemsArray.Length.ShouldBe(1);
			navigationItemsArray[0].Name.ShouldBe("0-children-null");
			navigationItemsArray[0].Children.ShouldBeEmpty();
		}

		[Fact]
		public void GetItems_StartLevelRootEndLevelRootGetChildrenOnRootItemReturnsNullRootItemCurrent_ReturnsCollectionWithSelectedRoot() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.RootWithNullChildren, fakes.RootWithNullChildren, new NavigationConfig()).ToArray();

			navigationItemsArray[0].Selected.ShouldBeTrue();
		}

		[Fact]
		public void GetItems_StartLevelRootEndLevelOneDefaultIncludeConfig_ReturnsCollectionWithRootItemAndVisibleRootChildren() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.Root, Substitute.For<INavigationItem>(), new NavigationConfig(0, 1)).ToArray();

			navigationItemsArray.Length.ShouldBe(1);
			navigationItemsArray[0].Name.ShouldBe("0");
			var rootChildrenArray = navigationItemsArray[0].Children.ToArray();
			rootChildrenArray.Length.ShouldBe(2);
			rootChildrenArray[0].Name.ShouldBe("1-1");
			rootChildrenArray[0].Children.ShouldBeEmpty();
			rootChildrenArray[1].Name.ShouldBe("1-2");
			rootChildrenArray[1].Children.ShouldBeEmpty();
		}

		[Fact]
		public void GetItems_StartLevelRootEndLevelOneSecondChildCurrent_ReturnsCollectionWithSecondRootChildSelected() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, new NavigationConfig(0, 1)).ToArray();

			var rootChildrenArray = navigationItemsArray[0].Children.ToArray();
			rootChildrenArray[1].Selected.ShouldBeTrue();
		}

		[Fact]
		public void GetItems_StartLevelOneEndLevelOneDefaultConfig_ReturnsRootChildren() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.Root, Substitute.For<INavigationItem>(), new NavigationConfig(1, 1)).ToArray();

			navigationItemsArray.Length.ShouldBe(2);
			navigationItemsArray[0].Name.ShouldBe("1-1");
			navigationItemsArray[0].Children.ShouldBeEmpty();
			navigationItemsArray[1].Name.ShouldBe("1-2");
			navigationItemsArray[1].Children.ShouldBeEmpty();
		}

		[Fact]
		public void GetItems_StartLevelOneEndLevelOneFirstChildSelected_ReturnsRootChildrenFirstChildSelected() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.FirstChildOfRoot, new NavigationConfig(1, 1)).ToArray();

			navigationItemsArray[0].Selected.ShouldBeTrue();
		}

		[Fact]
		public void GetItems_StartLevelOneEndLevelTwoSecondItemCurrent_ReturnsRootChildrenAndSecondItemChildren() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, new NavigationConfig(1, 2)).ToArray();

			navigationItemsArray[0].Children.ShouldBeEmpty();
			navigationItemsArray[1].Children.Count.ShouldBe(2);
		}

		[Fact]
		public void GetItems_StartLevelOneEndLevelTwoIncludeChildItemsAll_ReturnsRootChildrenAndAllTheirVisibleChildren() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);
			var navigationConfig = new NavigationConfig(1, 2, IncludeItemsMode.All, IncludeItemsMode.All);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, navigationConfig).ToArray();

			navigationItemsArray[0].Children.Count.ShouldBe(2);

			var firstItemChildrenArray = navigationItemsArray[0].Children.ToArray();
			firstItemChildrenArray[0].Name.ShouldBe("1-1-1");
			firstItemChildrenArray[1].Name.ShouldBe("1-1-2");

			navigationItemsArray[1].Children.Count.ShouldBe(2);
			var secondItemChildrenArray = navigationItemsArray[1].Children.ToArray();
			secondItemChildrenArray[0].Name.ShouldBe("1-2-1");
			secondItemChildrenArray[1].Name.ShouldBe("1-2-2");
		}

		[Fact]
		public void GetItems_StartLevelOneEndLevelTwoIncludeChildItemsAllIncludeNoneVisibleItemsAll_ReturnsRootChildrenAndAllTheirChildren() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);
			var navigationConfig = new NavigationConfig(1, 2, IncludeItemsMode.All, IncludeItemsMode.All, IncludeItemsMode.All);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, navigationConfig).ToArray();

			navigationItemsArray.Length.ShouldBe(3);
			navigationItemsArray[2].Visible.ShouldBeFalse();

			var thirdItemChildrenArray = navigationItemsArray[2].Children.ToArray();
			thirdItemChildrenArray[0].Name.ShouldBe("1-3-1");
			thirdItemChildrenArray[1].Name.ShouldBe("1-3-2");
		}

		[Fact]
		public void GetItems_StartLevelTwoEndLevelTwoIncludeRootLevelItemsInSelectedPath_ReturnsChildrenOfSecondChildOfRoot() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);
			var navigationConfig = new NavigationConfig(2, 2, IncludeItemsMode.InSelectedPath);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, navigationConfig).ToArray();

			navigationItemsArray.Length.ShouldBe(2);
		}

		[Fact]
		public void GetItems_StartLevelTwoEndLevelThreeIncludeRootLevelItemsInSelectedPathIncludeAllChildItems_ContainsAllChildrenOfRootItemsInSelectedPath() {
			var fakes = MakeDefaultNavigationItemFakes();
			var navigation = MakeDefaultNavigationFake(fakes);
			var navigationConfig = new NavigationConfig(2, 3, IncludeItemsMode.InSelectedPath, IncludeItemsMode.All);

			var navigationItemsArray = navigation.GetItems(fakes.Root, fakes.SecondChildOfRoot, navigationConfig).ToArray();

			navigationItemsArray.Length.ShouldBe(2);

			var firstItemChildrenArray = navigationItemsArray[0].Children.ToArray();
			firstItemChildrenArray.Length.ShouldBe(2);
			firstItemChildrenArray[0].Name.ShouldBe("1-2-1-1");
			firstItemChildrenArray[1].Name.ShouldBe("1-2-1-2");

			var secondItemChildrenArray = navigationItemsArray[1].Children.ToArray();
			secondItemChildrenArray.Length.ShouldBe(2);
			secondItemChildrenArray[0].Name.ShouldBe("1-2-2-1");
			secondItemChildrenArray[1].Name.ShouldBe("1-2-2-2");
		}

		private NavigationFake MakeDefaultNavigationFake() {
			return new NavigationFake(new NavigationItemFakes());
		}

		private NavigationFake MakeDefaultNavigationFake(NavigationItemFakes navigationItemFakes) {
			return new NavigationFake(navigationItemFakes);
		}

		private NavigationItemFakes MakeDefaultNavigationItemFakes() {
			return new NavigationItemFakes();
		}
	}
}