namespace AbyssMothGames.LawnMowerWorld.Helpers
{
    public sealed class Utilite
    {
        public static void RemoveAt<T>(ref T[] array, int index)
        {
            for (int i = index; i < array.Length - 1; i++)
                array[i] = array[i + 1];

            System.Array.Resize(ref array, array.Length - 1);
        }

        public static void RemoveAtArray<T>(ref T[] array, int index)
        {
            array[index] = array[array.Length - 1];

            System.Array.Resize(ref array, array.Length - 1);
        }
    }
}