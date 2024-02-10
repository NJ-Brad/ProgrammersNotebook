namespace WinForms.JumpLists
{
    internal class ApplicationStrings
    {
        public static readonly ApplicationString JumpItemsRejectedEventArgs_CountMismatch =
            new ApplicationString("The count of rejected items doesn't match the count of the reasons for rejection.");

        public static readonly ApplicationString JumpList_CantApplyUntilEndInit =
            new ApplicationString("The JumpList cannot be applied after calling BeginInit until there has been a matching call to EndInit.");

        public static readonly ApplicationString JumpList_CantCallUnbalancedEndInit =
            new ApplicationString("Cannot call EndInit without previously calling BeginInit.");

        public static readonly ApplicationString JumpList_CantNestBeginInitCalls =
            new ApplicationString("Cannot nest calls to BeginInit nor call it after modifying the JumpList.");

        public static readonly ApplicationString Verify_ApartmentState =
            new ApplicationString("This operation requires the thread's apartment state to be '{0}'.");

        public static readonly ApplicationString Verify_FileExists =
            new ApplicationString("No file exists at '{0}'.");

        public static readonly ApplicationString Verify_NeitherNullNorEmpty =
            new ApplicationString("The argument can neither be null nor empty.");
    }
}
