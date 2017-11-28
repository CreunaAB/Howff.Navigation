namespace Howff.Navigation {
	public class DefaultConfiguration : INavigationConfig {
		public int StartLevel => 1;

		public int EndLevel => int.MaxValue;

		public IncludeItemsMode IncludeRootLevelItems => IncludeItemsMode.All;

		public IncludeItemsMode IncludeChildItems => IncludeItemsMode.InSelectedPath;

		public IncludeItemsMode IncludeNonVisibleItems => IncludeItemsMode.None;

		public bool ShowOnlyItemsInSelectedPath => true;
	}
}