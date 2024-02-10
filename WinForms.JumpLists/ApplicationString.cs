namespace WinForms.JumpLists
{
    internal class ApplicationString
    {
        private string value = string.Empty;

        public ApplicationString(string value)
        {
            this.value = value;
        }

        public string Value { get => value; set => this.value = value; }

        public string Format(params object[] args)
        {
            return string.Format(value, args);
        }

        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
        public static implicit operator string(ApplicationString input) => input.Value;

        // https://stackoverflow.com/questions/4580085/how-to-allow-implicit-conversion
        //public static implicit operator string(ApplicationString input)
        //{
        //    return new string(input.Value);
        //}
    }
}