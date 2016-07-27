namespace System
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object item) where T : class
        {
            if( item is T)
                return (T)item;

            return null;
        }
    }
}