namespace CSharpMiniProjects.ExtensionMethods
{
    public static class ListExtensions
    {
        // Extension method for List<T>
        public static bool IsNullOrEmpty<T>(this List<T>? list)
        {
            return list == null || list.Count == 0;
        }
    }
}
