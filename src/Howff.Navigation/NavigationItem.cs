using System.Collections.Generic;

namespace Howff.Navigation {
	public abstract class NavigationItem {
		private readonly List<INavigationItem> children = new List<INavigationItem>();

		public virtual IList<INavigationItem> Children => this.children;

		public virtual void AddChild(INavigationItem child) {
			this.children.Add(child);
		}
	}
}