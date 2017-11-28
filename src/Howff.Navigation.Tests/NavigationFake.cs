using System.Collections.Generic;

namespace Howff.Navigation.Tests {
	/// <summary>
	/// This class fakes a navigation implementation and is used for tests on the abstract Navigation
	/// base class. The navigation tree this class fakes looks like the tree below. Asterisks represents the selected path.
	/// Hash characters marks not visible items.
	///+---+
	///|0 *|
	///+--++
	///   +-----------------+
	///   v                 v
	///+-----+           +------+           +------+
	///|1-1  |           |1-2  *|           |1-3  #|
	///+--+--+           +--+---+           +--+---+
	///   +--------+        +--------+        +--------+
	///   v        v        v        v        v        v
	///+------+ +------+ +------+ +------+ +------+ +------+
	///|1-1-1 | |1-1-2 | |1-2-1 | |1-2-2*| |1-3-1 | |1-3-2#|
	///+------+ +------+ +------+ +------+ +------+ +------+
	///   |       |        |        |
	///   |       |        |        +--------------------------------+---------+
	///   |       |        +---------------------+---------+         |         |
	///   |       +----------+---------+         |         |         |         |
	///   +-------+          |         |         |         |         |         |
	///   v       v          v         v         v         v         v         v
	///+-------+ +-------+ +-------+ +-------+ +-------+ +-------+ +-------+ +-------+
	///|1-1-1-1| |1-1-1-2| |1-1-2-1| |1-1-2-2| |1-2-1-1| |1-2-1-2| |1-2-2-1| |1-2-2-2|
	///+-------+ +-------+ +-------+ +-------+ +-------+ +-------+ +-------+ +-------+
	/// </summary>
	public class NavigationFake : Navigation {
		private readonly NavigationItemFakes fakes;

		public NavigationFake(NavigationItemFakes fakes) {
			this.fakes = fakes;
		}

		protected override IList<INavigationItem> GetChildren(INavigationItem navigationItem) {
			if(navigationItem == null) {
				return null;
			}

			switch(navigationItem.Name) {
				case "0-children-null":
					return null;
				case "0":
					return ChildrenOfRoot;
				case "1-1":
					return ChildrenOfFirstChildOfRoot;
				case "1-2":
					return ChildrenOfSecondChildOfRoot;
				case "1-3":
					return ChildrenOfThirdChildOfRoot;
				case "1-1-1":
					return ChildrenOfFirstChildOfFirstChildOfRoot;
				case "1-1-2":
					return ChildrenOfSecondChildOfFirstChildOfRoot;
				case "1-2-1":
					return ChildrenOfFirstChildOfSecondChildOfRoot;
				case "1-2-2":
					return ChildrenOfSecondChildOfSecondChildOfRoot;
				default:
					return new INavigationItem[] { };
			}
		}

		public IList<INavigationItem> PublicGetChildren(INavigationItem navigationItem) {
			return GetChildren(navigationItem);
		}

		internal IList<INavigationItem> ChildrenOfRoot => new[] {
			this.fakes.FirstChildOfRoot,
			this.fakes.SecondChildOfRoot,
			this.fakes.ThirdChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfFirstChildOfRoot => new[] {
			this.fakes.FirstChildOfFirstChildOfRoot,
			this.fakes.SecondChildOfFirstChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfSecondChildOfRoot => new[] {
			this.fakes.FirstChildOfSecondChildOfRoot,
			this.fakes.SecondChildOfSecondChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfThirdChildOfRoot => new[] {
			this.fakes.FirstChildOfThirdChildOfRoot,
			this.fakes.SecondChildOfThirdChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfFirstChildOfFirstChildOfRoot => new[] {
			this.fakes.FirstChildOfFirstChildOfFirstChildOfRoot,
			this.fakes.SecondChildOfFirstChildOfFirstChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfSecondChildOfFirstChildOfRoot => new[] {
			this.fakes.FirstChildOfSecondChildOfFirstChildOfRoot,
			this.fakes.SecondChildOfSecondChildOfFirstChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfFirstChildOfSecondChildOfRoot => new[] {
			this.fakes.FirstChildOfFirstChildOfSecondChildOfRoot,
			this.fakes.SecondChildOfFirstChildOfSecondChildOfRoot
		};

		internal IList<INavigationItem> ChildrenOfSecondChildOfSecondChildOfRoot => new[] {
			this.fakes.FirstChildOfSecondChildOfSecondChildOfRoot,
			this.fakes.SecondChildOfSecondChildOfSecondChildOfRoot
		};

		protected override IList<INavigationItemId> GetSelectedPath(INavigationItem rootItem, INavigationItem currentItem) {
			return new[] {
				this.fakes.Root.Id,
				this.fakes.SecondChildOfRoot.Id,
				this.fakes.SecondChildOfSecondChildOfRoot.Id
			};
		}
	}
}