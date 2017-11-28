using Shouldly;

using Xunit;

namespace Howff.Navigation.Tests {
	public class NavigationItemFakesTests {
		[Fact]
		public void Constructor_CorrectItemsCreated() {
			var fakes = new NavigationItemFakes();

			fakes.RootWithNullChildren.Name.ShouldBe("0-children-null");
			fakes.Root.Name.ShouldBe("0");

			fakes.FirstChildOfRoot.Name.ShouldBe("1-1");
			fakes.SecondChildOfRoot.Name.ShouldBe("1-2");
			fakes.ThirdChildOfRoot.Name.ShouldBe("1-3");
			fakes.ThirdChildOfRoot.Visible.ShouldBeFalse();

			fakes.FirstChildOfFirstChildOfRoot.Name.ShouldBe("1-1-1");
			fakes.SecondChildOfFirstChildOfRoot.Name.ShouldBe("1-1-2");

			fakes.FirstChildOfSecondChildOfRoot.Name.ShouldBe("1-2-1");
			fakes.SecondChildOfSecondChildOfRoot.Name.ShouldBe("1-2-2");

			fakes.FirstChildOfThirdChildOfRoot.Name.ShouldBe("1-3-1");
			fakes.SecondChildOfThirdChildOfRoot.Name.ShouldBe("1-3-2");
			fakes.SecondChildOfThirdChildOfRoot.Visible.ShouldBeFalse();

			fakes.FirstChildOfFirstChildOfFirstChildOfRoot.Name.ShouldBe("1-1-1-1");
			fakes.SecondChildOfFirstChildOfFirstChildOfRoot.Name.ShouldBe("1-1-1-2");

			fakes.FirstChildOfSecondChildOfFirstChildOfRoot.Name.ShouldBe("1-1-2-1");
			fakes.SecondChildOfSecondChildOfFirstChildOfRoot.Name.ShouldBe("1-1-2-2");

			fakes.FirstChildOfFirstChildOfSecondChildOfRoot.Name.ShouldBe("1-2-1-1");
			fakes.SecondChildOfFirstChildOfSecondChildOfRoot.Name.ShouldBe("1-2-1-2");

			fakes.FirstChildOfSecondChildOfSecondChildOfRoot.Name.ShouldBe("1-2-2-1");
			fakes.SecondChildOfSecondChildOfSecondChildOfRoot.Name.ShouldBe("1-2-2-2");
		}
	}
}