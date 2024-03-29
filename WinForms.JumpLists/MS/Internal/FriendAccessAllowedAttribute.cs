// This source file is adapted from the Windows Presentation Foundation project. 
// (https://github.com/dotnet/wpf/) 
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Description: Implementation of a FriendAccessAllowedAttribute attribute that is used to mark internal metadata
//              that is allowed to be accessed from friend assemblies.

namespace MS.Internal.WindowsBase;

[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Property |
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Struct |
    AttributeTargets.Enum |
    AttributeTargets.Interface |
    AttributeTargets.Delegate |
    AttributeTargets.Constructor,
    AllowMultiple = false,
    Inherited = true)
]
internal sealed class FriendAccessAllowedAttribute : Attribute
{
}