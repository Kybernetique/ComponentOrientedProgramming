using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Components.AntonovComponents
{
    public partial class TreeViewControl : UserControl
    {
        private Queue<string> _nodeNames;

        public int SelectedNodeIndex
        {
            get
            {
                if (treeView.SelectedNode != null)
                {
                    return treeView.SelectedNode.Index;
                }
                return -1;
            }
            set
            {
                if (value < treeView.Nodes.Count && value >= 0)
                {
                    treeView.SelectedNode = treeView.Nodes[value];
                    treeView.Focus();
                }
            }
        }

        public TreeViewControl()
        {
            InitializeComponent();
        }

        public void SetTreeСonfiguration(Queue<string> nodeNames)
        {
            if (nodeNames != null)
                _nodeNames = nodeNames;
            else
                throw new ArgumentException();
        }

        public void AddItem<T>(T item) where T : class
        {
            if (_nodeNames == null)
                throw new ArgumentException("TreeСonfiguration is not set!");

            if (item == null)
                throw new ArgumentException("Item is null!");

            var itemType = item.GetType();
            var currentLevelNodes = treeView.Nodes;

            int currentLevel = 1;
            foreach (var nodeName in _nodeNames)
            {
                var propertyInfo = itemType.GetProperty(nodeName);

                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(item).ToString();
                    if (currentLevelNodes.ContainsKey(propertyValue) == false || currentLevel == _nodeNames.Count)
                    {
                        currentLevelNodes.Add(propertyValue, propertyValue);
                    }
                    var nextLevels = currentLevelNodes.Find(propertyValue, false);
                    currentLevelNodes = nextLevels[0].Nodes;
                }
            }
        }

        public T GetSelectedItem<T>() where T : class, new()
        {
            if (treeView.SelectedNode == null)
                return null;

            var currentNode = treeView.SelectedNode;
            while (currentNode.Nodes != null && currentNode.Nodes.Count > 0)
            {
                if (currentNode.Nodes.Count > 1)
                    throw new Exception("Ambiguous definition. There are several child elements in the selected branch");

                currentNode = currentNode.Nodes[0];
            }

            var propertyValues = new Stack<string>();
            while (currentNode != null)
            {
                propertyValues.Push(currentNode.Text);
                currentNode = currentNode.Parent;
            }

            T item = Activator.CreateInstance<T>();
            foreach (var properyName in _nodeNames)
            {
                var propertyInfo = item.GetType().GetProperty(properyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(item, Convert.ChangeType(propertyValues.Pop(), propertyInfo.PropertyType));
                }
            }
            return item;
        }

        public void Clear()
        {
            treeView.Nodes.Clear();
        }
    }
}
