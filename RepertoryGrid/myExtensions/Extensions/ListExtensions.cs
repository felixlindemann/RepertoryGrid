using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LimeTree.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="System.Collections.Generic.List{T}"/>
    /// https://github.com/benfoster/Fabrik.Common/blob/master/src/Fabrik.Common/ListExtensions.cs
    /// </summary>
    public static class ListExtensions
    {

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the end of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToEnd<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            if (list.Count > 1)
                list.Move(itemSelector, list.Count - 1);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the beginning of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToBeginning<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            list.Move(itemSelector, 0);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.NotNull(itemSelector, "itemSelector");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");

            var currentIndex = list.FindIndex(itemSelector);
            Ensure.That<ArgumentException>(currentIndex >= 0, "No item was found that matches the specified selector.");

            if (currentIndex == newIndex)
                return;

            // Copy the item
            var item = list[currentIndex];

            // Remove the item from the list
            list.RemoveAt(currentIndex);

            // Finally insert the item at the new index
            list.Insert(newIndex, item);
        }
      
        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void Move<T>(this List<T> list, int CurrentIndex, int newIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.Is(CurrentIndex >= 0, "Current index must be greater than or equal to zero.");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");

            Ensure.Argument.Is(CurrentIndex < list.Count, "Current index must be smaller than the number of items.");
            Ensure.Argument.Is(newIndex < list.Count, "New index must be smaller than the number of items.");

            if (CurrentIndex == newIndex)
                return;

            // Copy the item
            var item = list[CurrentIndex];

            // Remove the item from the list
            list.RemoveAt(CurrentIndex);
            //if (CurrentIndex < newIndex) newIndex--;

            // Finally insert the item at the new index
            list.Insert(newIndex, item);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void MoveDown<T>(this List<T> list, int CurrentIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.Is(CurrentIndex >= 0, "Current index must be greater than or equal to zero.");

            Ensure.Argument.Is(CurrentIndex < list.Count - 1, "Current index must be smaller than the number of items.");

            int newIndex = CurrentIndex + 1;
            list.Move(CurrentIndex, newIndex);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void MoveUp<T>(this List<T> list, int CurrentIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.Is(CurrentIndex >= 1, "Current index must be greater than or equal to zero.");

            Ensure.Argument.Is(CurrentIndex < list.Count , "Current index must be smaller than the number of items.");

            int newIndex = CurrentIndex - 1;
            list.Move(CurrentIndex, newIndex);
        }


        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void Swap<T>(this List<T> list, int CurrentIndex, int newIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.Is(CurrentIndex >= 0, "Current index must be greater than or equal to zero.");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");

            Ensure.Argument.Is(CurrentIndex < list.Count, "Current index must be smaller than the number of items.");
            Ensure.Argument.Is(newIndex < list.Count, "New index must be smaller than the number of items.");

            if (CurrentIndex == newIndex)
                return;

            if (CurrentIndex > newIndex)
            {
                int tmp = newIndex;
                newIndex = CurrentIndex;
                CurrentIndex = tmp;
            }

            // Copy the item
            var item1 = list[CurrentIndex];
            var item2 = list[newIndex];

            // Remove the item from the list
            list.RemoveAt(newIndex);
            list.RemoveAt(CurrentIndex);

            // Finally insert the item at the new index
            list.Insert(CurrentIndex, item2);
            list.Insert(newIndex, item1);
        }

    
    }
}
