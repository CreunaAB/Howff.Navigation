namespace Howff.Navigation.Tests {
	public class NavigationItemFakes {
		public INavigationItem RootWithNullChildren { get; }
		public INavigationItem Root { get; }

		public INavigationItem FirstChildOfRoot { get; }
		public INavigationItem SecondChildOfRoot { get; }
		public INavigationItem ThirdChildOfRoot { get; }

		public INavigationItem FirstChildOfFirstChildOfRoot { get; }
		public INavigationItem SecondChildOfFirstChildOfRoot { get; }

		public INavigationItem FirstChildOfSecondChildOfRoot { get; }
		public INavigationItem SecondChildOfSecondChildOfRoot { get; }

		public INavigationItem FirstChildOfThirdChildOfRoot { get; }
		public INavigationItem SecondChildOfThirdChildOfRoot { get; }

		public INavigationItem FirstChildOfFirstChildOfFirstChildOfRoot { get; }
		public INavigationItem SecondChildOfFirstChildOfFirstChildOfRoot { get; }

		public INavigationItem FirstChildOfSecondChildOfFirstChildOfRoot { get; }
		public INavigationItem SecondChildOfSecondChildOfFirstChildOfRoot { get; }

		public INavigationItem FirstChildOfFirstChildOfSecondChildOfRoot { get; }
		public INavigationItem SecondChildOfFirstChildOfSecondChildOfRoot { get; }

		public INavigationItem FirstChildOfSecondChildOfSecondChildOfRoot { get; }
		public INavigationItem SecondChildOfSecondChildOfSecondChildOfRoot { get; }

		public NavigationItemFakes() {
			RootWithNullChildren = new NavigationItemFake("0-children-null");
			Root = new NavigationItemFake("0");

			FirstChildOfRoot = new NavigationItemFake("1-1");
			SecondChildOfRoot = new NavigationItemFake("1-2");
			ThirdChildOfRoot = new NavigationItemFake("1-3") { Visible = false };

			FirstChildOfFirstChildOfRoot = new NavigationItemFake("1-1-1");
			SecondChildOfFirstChildOfRoot = new NavigationItemFake("1-1-2");

			FirstChildOfSecondChildOfRoot = new NavigationItemFake("1-2-1");
			SecondChildOfSecondChildOfRoot = new NavigationItemFake("1-2-2");

			FirstChildOfThirdChildOfRoot = new NavigationItemFake("1-3-1");
			SecondChildOfThirdChildOfRoot = new NavigationItemFake("1-3-2") { Visible = false };

			FirstChildOfFirstChildOfFirstChildOfRoot = new NavigationItemFake("1-1-1-1");
			SecondChildOfFirstChildOfFirstChildOfRoot = new NavigationItemFake("1-1-1-2");

			FirstChildOfSecondChildOfFirstChildOfRoot = new NavigationItemFake("1-1-2-1");
			SecondChildOfSecondChildOfFirstChildOfRoot = new NavigationItemFake("1-1-2-2");

			FirstChildOfFirstChildOfSecondChildOfRoot = new NavigationItemFake("1-2-1-1");
			SecondChildOfFirstChildOfSecondChildOfRoot = new NavigationItemFake("1-2-1-2");

			FirstChildOfSecondChildOfSecondChildOfRoot = new NavigationItemFake("1-2-2-1");
			SecondChildOfSecondChildOfSecondChildOfRoot = new NavigationItemFake("1-2-2-2");
		}
	}
}