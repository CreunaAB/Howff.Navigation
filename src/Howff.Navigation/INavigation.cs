using System.Collections.Generic;

namespace Howff.Navigation {
	public interface INavigation {
		IList<INavigationItem> GetItems(INavigationItem root, INavigationItem current, INavigationConfig config);
	}
}