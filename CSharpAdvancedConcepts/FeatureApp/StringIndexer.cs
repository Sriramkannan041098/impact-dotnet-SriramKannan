namespace CSharpAdvancedConcepts.FeatureApp
{
    public class StringIndexer
    {
        private string text;

        public StringIndexer(string text)
        {
            this.text = text;
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= text.Length)
                {
                    throw new IndexOutOfRangeException(
                        "String index is out of range."
                    );
                }

                return text[index];
            }
        }
    }
}
