using System;
using System.Collections.Generic;

namespace BlazorTreeControl
{
    public class UITreeNodeAction {
        public bool IsEsabled { get; set; } = true;
        public string Name { get; set; }
        public string OpenIconic { get; set; } = "oi oi-aperture";
    }
    public class UITreeNode
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int Deep {get; set;}
        public string Text { get; set; }
        public string OpenIconic { get; set; } = "oi-bug";
        public bool IsExpanded  { get; set; } = false;
        public bool IsSelected  { get; set; } = false;
        public bool ChildrenLoaded { get; set; } = false;
        public bool? HasChildren { get; set; } = null;
        public bool IsVisible  { get; set; } = true;
        public List<UITreeNodeAction> Actions { get; set; } = new List<UITreeNodeAction>();
        public string IsExpanded_display {
            get {
                if (HasChildren.HasValue && !HasChildren.Value) {
                    return "";
                } else {
                    return (IsExpanded)?"oi oi-caret-bottom":"oi oi-caret-right";
                }
                
            }
        }
        public string IsSelected_display {
            get {
                return (IsSelected)?" active ":"";
            }
        } 
    }
}
