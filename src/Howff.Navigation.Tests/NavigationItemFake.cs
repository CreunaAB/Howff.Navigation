namespace Howff.Navigation.Tests {
	public class NavigationItemFake : NavigationItem, INavigationItem {
		public INavigationItemId Id { get; }
		public string Name { get; }
		public string Link { get; set; }
		public bool Selected { get; set; }
		public bool Visible { get; set; }

		public NavigationItemFake(string id, string link = null) {
			Id = new NavigationItemIdFake(id);
			Name = id;
			Link = link;
			Visible = true;
		}

	}
}