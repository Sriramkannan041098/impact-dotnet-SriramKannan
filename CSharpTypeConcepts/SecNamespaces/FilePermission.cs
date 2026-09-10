namespace CSharpTypeConcepts.SecNamespaces
{
    [Flags]
    public enum FilePermission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }    
}

