using System;

namespace CustomFlowListView.Helpers.FlowListView
{
	public sealed class PreserveAttribute : System.Attribute
	{
		public bool AllMembers;
		public bool Conditional;
	}
}
