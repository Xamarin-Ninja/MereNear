﻿using System;
using System.Collections.ObjectModel;

namespace CustomFlowListView
{
    [Helpers.FlowListView.Preserve(AllMembers = true)]
    internal class FlowGroupColumn : FlowObservableCollection<object>
    {
        public int ColumnCount { get; set; }

        public bool ForceInvalidateColumns { get; set; }

        public FlowGroupColumn(int columnCount)
        {
            ColumnCount = columnCount;
        }
    }
}
