﻿namespace ProgrammersNotebook
{
    // This is for use in the tree.  It is not to be used directly in the data domain
    public class TreeFragment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("D").ToUpper();
        public string Name { get; set; }
    }
}
