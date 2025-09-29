using System.Collections.Generic;

namespace Shared
{
    public static class Shared
    {
        private static List<int> addedCourseIds = new List<int>();

        public static void AddCourseId(int id)
        {
            addedCourseIds.Add(id);
        }

        public static List<int> GetAddedCourseIds()
        {
            return addedCourseIds;
        }

        public static void ClearCourseIds()
        {
            addedCourseIds.Clear();
        }
    }
}
