using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class InventorySlot
    {
        private int itemId;
        private int itemCount;

        public int ItemId { get => itemId; }
        public int ItemCount { get => ItemCount; }

        public InventorySlot()
        {
            EmptyInvenSlot();
        }

        public void AddItem(int id, int cnt)
        {
            if (IsEmpty())
            {
                itemId = id; itemCount = cnt;
            }
            else
            {
                itemCount += cnt;
            }

        }

        public void EraseItem(int id, int cnt)
        {
            itemCount -= cnt;
            if (cnt == 0) EmptyInvenSlot();
        }

        private void EmptyInvenSlot()
        {
            itemId = -1;
            itemCount = -1;
        }

        public bool IsEmpty()
        {
            return itemId == -1 || itemCount == -1;
        }

    }

    public class InvenManager : MonoBehaviour
    {
        List<InventorySlot> invenSlot = new List<InventorySlot>();

        public Action InvenUIUpdateAction { get => InvenUIUpdateAction; set => InvenUIUpdateAction = value; }

        public void Init()
        {
            for (int i = 0; i < Constants.MAX_INVENTORY_SLOTS; i++)
            {
                invenSlot.Add(new InventorySlot());
            }
        }



        public bool AddItemToInven(int itemId, int cnt)
        {
            int itemInvenId = -1;
            int emptyInvenId = -1;
            for (int i = 0; i < invenSlot.Count; i++)
            {
                if (itemId == invenSlot[i].ItemId)
                {
                    itemInvenId = i;
                }
                if (invenSlot[i].IsEmpty() && emptyInvenId == -1)
                {
                    emptyInvenId = i;
                }
            }

            if (itemInvenId == -1 && emptyInvenId == -1) return false;  // No corresponding Item, No Empty Slot
            else invenSlot[itemInvenId != -1 ? itemInvenId : emptyInvenId].AddItem(itemId, cnt);

            InvenUIUpdateAction.Invoke();
            return true;
        }

        public bool RemoveItemFromInven(int itemId, int cnt)
        {
            int itemInvenId = -1;

            for (int i = 0; i < invenSlot.Count; i++)
            {
                if (itemId == invenSlot[i].ItemId)
                {
                    itemInvenId = i; break;
                }
            }

            if (itemInvenId == -1) return false;

            invenSlot[itemInvenId].EraseItem(itemId, cnt);
            InvenUIUpdateAction.Invoke();
            return true;
        }

    }

}