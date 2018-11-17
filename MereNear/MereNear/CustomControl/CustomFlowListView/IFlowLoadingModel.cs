using System;

namespace CustomFlowListView
{
    [Helpers.FlowListView.Preserve(AllMembers = true)]
    public interface IFlowLoadingModel
    {
    }

    [Helpers.FlowListView.Preserve(AllMembers = true)]
    internal class FlowLoadingModel : IFlowLoadingModel
    {
    }
}
