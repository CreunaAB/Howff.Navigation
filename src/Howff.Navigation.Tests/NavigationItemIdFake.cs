namespace Howff.Navigation.Tests {
	public class NavigationItemIdFake : INavigationItemId {
		public NavigationItemIdFake(string id) {
			Id = id;
		}

		public string Id { get; }
	}
}