namespace CSharpAdvancedConcepts.FeatureApp
{
    public class Playlist
    {
        private string[] podCast;

        public Playlist(int size)
        {
            podCast = new string[size];
        }
        public int Length => podCast.Length;

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= podCast.Length)
                {
                    throw new IndexOutOfRangeException(
                        "Playlist index is out of range."
                    );
                }

                return podCast[index];
            }

            set
            {
                if (index < 0 || index >= podCast.Length)
                {
                    throw new IndexOutOfRangeException(
                        "Playlist index is out of range."
                    );
                }

                podCast[index] = value;
            }
        }
    }
}
