namespace Howff.Navigation {
	public class NavigationConfig : INavigationConfig {
		public NavigationConfig(
			int startLevel = 0,
			int endLevel = 0,
			IncludeItemsMode includeRootLevelItems = IncludeItemsMode.All,
			IncludeItemsMode includeChildItems = IncludeItemsMode.InSelectedPath,
			IncludeItemsMode includeNonVisibleItems = IncludeItemsMode.None
		) {
			StartLevel = startLevel;
			EndLevel = endLevel;
			IncludeRootLevelItems = includeRootLevelItems;
			IncludeChildItems = includeChildItems;
			IncludeNonVisibleItems = includeNonVisibleItems;
		}

		public int StartLevel { get; }

		public int EndLevel { get; }

		public IncludeItemsMode IncludeRootLevelItems { get; }

		public IncludeItemsMode IncludeChildItems { get; }

		public IncludeItemsMode IncludeNonVisibleItems { get; }
	}
}