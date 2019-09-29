using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeThree
{
    public class Item
    {
        public string ItemNumber { get; set; }
        public List<Item> SubItems { get; set; }

        public SubItemSummary[] GetSubItemSummary(string itemNumber)
        {
            List<SubItemSummary> subItems = new List<SubItemSummary>();

            var target = SubItems.FirstOrDefault(i => i.ItemNumber == itemNumber);
            if(target != null)
            {
                subItems.AddRange(target.SubItems.Select(i => i.GetSummary()));
            }
            return subItems.ToArray();
        }

        public SubItemSummary GetSummary()
        {
            var itemSummary = new SubItemSummary
            {
                ItemNumber = ItemNumber
            };

            if(SubItems != null)
            {
                var builder = new StringBuilder();
                foreach(var subItem in SubItems)
                {
                    var subItemCount = subItem.LeafNodeCount();
                    if(subItemCount > 1)
                    {
                        builder.Append($"{subItem.ItemNumber} (${subItem.SubItems.Count}); ");
                    }
                    else
                    {
                        builder.Append($"{subItem.ItemNumber}; ");
                    }
                }

                itemSummary.Summary = builder.ToString().Trim();
            }
            else
            {
                itemSummary.Summary = "";
            }
            return itemSummary;
        }
        private int LeafNodeCount()
        {
            if (SubItems == null && SubItems.Count == 0) return 1;
            var count = 0; 
            foreach(var subItem in SubItems)
            {
                count += subItem.LeafNodeCount();
            }

            return count;
        }
    }
}
