using System.Collections.Generic;

namespace Howff.Navigation {
	public interface INavigationItem {
		INavigationItemId Id { get; }
		string Name { get; }
		string Link { get; }
		bool Selected { get; set; }
		bool Visible { get; }
		IList<INavigationItem> Children { get; }
		void AddChild(INavigationItem child);
	}
}