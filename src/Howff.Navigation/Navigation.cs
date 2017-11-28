using System.Collections.Generic;
using System.Linq;

namespace Howff.Navigation {
	public abstract class Navigation {
		private INavigationItem rootItem;
		private INavigationItem currentItem;
		private INavigationConfig configuration;

		protected abstract IList<INavigationItem> GetChildren(INavigationItem navigationItem);
		protected abstract IList<INavigationItemId> GetSelectedPath(INavigationItem rootItem, INavigationItem currentItem);

		public virtual IList<INavigationItem> GetItems(INavigationItem root, INavigationItem current, INavigationConfig config) {
			this.rootItem = root;
			this.currentItem = current;
			this.configuration = config ?? new DefaultConfiguration();

			var items = new List<INavigationItem>();

			if(root != null) {
				items.Add(root);
				items = GetItems(items, 0);
			}

			return items;
		}

		private List<INavigationItem> GetItems(List<INavigationItem> items, int currentLevel) {
			if(currentLevel == this.configuration.StartLevel) {
				BuildNavigationTree(items, currentLevel);
				return items;
			}

			var children = GetChildrenAsList(items);
			return GetItems(children, currentLevel + 1);
		}

		private void BuildNavigationTree(List<INavigationItem> items, int currentLevel) {
			if(currentLevel <= this.configuration.EndLevel) {
				items.RemoveAll(ExcludeItem);
				foreach(var item in items) {
					item.Selected = item.Id.Equals(this.currentItem.Id);
					if(IncludeChildren(currentLevel, item.Id)) {
						var children = GetChildrenAsList(item);
						children.RemoveAll(ExcludeItem);
						foreach(var child in children) {
							item.AddChild(child);
						}
						BuildNavigationTree(children, currentLevel + 1);
					}
				}
			}
		}

		private bool ExcludeItem(INavigationItem item) {
			return item == null ||
			       (!item.Visible && this.configuration.IncludeNonVisibleItems == IncludeItemsMode.None);
		}

		private bool IncludeChildren(int currentLevel, INavigationItemId id) {
			return currentLevel < this.configuration.EndLevel &&
			       (this.configuration.IncludeChildItems == IncludeItemsMode.All || InSelectedPath(id));
		}

		private bool InSelectedPath(INavigationItemId id) {
			var selectedPath = GetSelectedPath(this.rootItem, this.currentItem);
			return selectedPath.Contains(id);
		}

		private List<INavigationItem> GetChildrenAsList(IEnumerable<INavigationItem> items) {
			var children = new List<INavigationItem>();
			foreach(var item in items) {
				if(AddChildrenOfItem(item)) {
					children.AddRange(GetChildrenAsList(item));
				}
			}
			return children;
		}

		private bool AddChildrenOfItem(INavigationItem item) {
			return this.configuration.IncludeRootLevelItems == IncludeItemsMode.All ||
			       (this.configuration.IncludeRootLevelItems == IncludeItemsMode.InSelectedPath && InSelectedPath(item.Id));
		}

		private List<INavigationItem> GetChildrenAsList(INavigationItem item) {
			var children = GetChildren(item);
			return children?.ToList() ?? new List<INavigationItem>();
		}
	}
}