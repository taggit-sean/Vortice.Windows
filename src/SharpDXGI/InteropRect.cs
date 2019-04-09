// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Runtime.InteropServices;
using Vortice.Mathematics;

namespace SharpDXGI
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [DebuggerDisplay("Left: {Left}, Top: {Top}, Right: {Right}, Bottom: {Bottom}")]
    public readonly struct InteropRect
    {
        /// <summary>
        /// The left position.
        /// </summary>
        public readonly int Left;

        /// <summary>
        /// The top position.
        /// </summary>
        public readonly int Top;

        /// <summary>
        /// The right position
        /// </summary>
        public readonly int Right;

        /// <summary>
        /// The bottom position.
        /// </summary>
        public readonly int Bottom;

        public InteropRect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Rect"/> to <see cref="InteropRect"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator InteropRect(Rect value)
        {
            return new InteropRect(value.Left, value.Top, value.Right, value.Bottom);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="InteropRect"/> to <see cref="Rect"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Rect(InteropRect value)
        {
            return Rect.FromLTRB(value.Left, value.Top, value.Right, value.Bottom);
        }
    }
}
