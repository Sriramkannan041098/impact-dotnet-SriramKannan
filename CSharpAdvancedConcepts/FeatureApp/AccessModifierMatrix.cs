namespace CSharpAdvancedConcepts.FeatureApp
{
    public class AccessModifierMatrix
    {
        public string? PublicValue { get; set; }
        private string? PrivateValue { get; set; }
        protected string? ProtectedValue { get; set; }
        internal string? InternalValue { get; set; }

        public AccessModifierMatrix
            (string pubValue, string privValue, 
            string protValue, string internValue)
        {
            PublicValue = pubValue;
            PrivateValue = privValue;
            ProtectedValue = protValue;
            InternalValue = internValue;
        }

        public void DisplayAccessModifiers()
        {
            Console.WriteLine("\nAccess Modifier Matrix:");
            Console.WriteLine($"[Public]    : {PublicValue}    - Accessible everywhere");
            Console.WriteLine($"[Private]   : {PrivateValue}   - Accessible only within the same class");
            Console.WriteLine($"[Protected] : {ProtectedValue} - Accessible within the same class and derived classes");
            Console.WriteLine($"[Internal]  : {InternalValue}  - Accessible within the same assembly");
        }
    }
}
