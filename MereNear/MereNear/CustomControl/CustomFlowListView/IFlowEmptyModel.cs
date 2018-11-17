using System;
namespace CustomFlowListView
{
    [Helpers.FlowListView.Preserve(AllMembers = true)]
    public interface IFlowEmptyModel
    {
    }

    [Helpers.FlowListView.Preserve(AllMembers = true)]
    internal class FlowEmptyModel : IFlowEmptyModel
    {
    }
}