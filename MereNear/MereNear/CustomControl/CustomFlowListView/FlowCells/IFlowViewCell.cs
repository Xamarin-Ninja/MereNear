using System;
using Xamarin.Forms;

namespace CustomFlowListView
{
	/// <summary>
	/// IFlowViewCell.
	/// </summary>
	[Helpers.FlowListView.Preserve(AllMembers = true)]
    public interface IFlowViewCell
	{
		/// <summary>
		/// Raised when cell is tapped.
		/// </summary>
		void OnTapped();
	}
}

