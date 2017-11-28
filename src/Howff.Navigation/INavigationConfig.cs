namespace Howff.Navigation {
	public interface INavigationConfig {
		int StartLevel { get; }
		int EndLevel { get; }
		IncludeItemsMode IncludeRootLevelItems { get; }
		IncludeItemsMode IncludeChildItems { get; }
		IncludeItemsMode IncludeNonVisibleItems { get; }
	}
}